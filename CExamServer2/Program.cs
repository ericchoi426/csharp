using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CExamServer2
{
    class FileServer
    {
        static Socket listener;
        public class Worker
        {
            // This method will be called when the thread is started. 
            public void DoWork()
            {
                const int DEFAULT_BUFLEN = 4096;
                const int DEFAULT_PORT = 27015;
                const int FILENAME_LEN = 27;
                const int HEADER_LEN = (1 + FILENAME_LEN + 4);

                // Data buffer for incoming data.
                byte[] recvbuf = new byte[DEFAULT_BUFLEN + HEADER_LEN];
                int recvLen;
                string filename = "test.exe";

                // Establish the local endpoint for the socket.
                //IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                //IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                IPEndPoint localEndPoint = new IPEndPoint(ipAddress, DEFAULT_PORT);

                // Create a TCP/IP socket.
                listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Bind the socket to the local endpoint and 
                // listen for incoming connections.
                try
                {
                    listener.Bind(localEndPoint);
                    listener.Listen(10);

                    // Start listening for connections.
                    while (true)
                    {
                        // Program is suspended while waiting for an incoming connection.
                        Socket handler = listener.Accept();

                        while ((recvLen = handler.Receive(recvbuf)) > 0)
                        {
                            string szFullPath = "..\\..\\ServerFiles\\" + filename;
                            SaveReceiveFile(szFullPath, recvbuf, recvLen);
                        }

                        handler.Shutdown(SocketShutdown.Both);
                        handler.Close();

                        Console.WriteLine(filename + " is received.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

                listener.Close();
            }
        }

        static void Main(string[] args)
        {
            Worker workerObject = new Worker();
            Thread workerThread = new Thread(workerObject.DoWork);
            workerThread.Start();

            string strLine;
            while (true)
            {
                strLine = Console.ReadLine();

                if (strLine.Equals("QUIT"))
                {
                    listener.Close();
                    break;
                }
            }

            workerThread.Join();
        }

        private static void SaveReceiveFile(string fullPath, byte[] buf, int length)
        {
            FileStream fs = new FileStream(fullPath, FileMode.Append);
            fs.Write(buf, 0, length);
            fs.Close();
        }
    }
}
