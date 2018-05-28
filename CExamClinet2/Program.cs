using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CExamClinet2
{
    class FileClient
    {
        private static void SendToServer(String strFilename)
        {
            try
            {
                // Establish the remote endpoint for the socket.
                //IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                //IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 27015);
                const int BUF_SIZE = 4096;
                int nFReadLen;
                // Create a TCP/IP  socket.
                Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // Connect the socket to the remote endpoint. Catch any errors.
                try
                {
                    sender.Connect(remoteEP);

                    // Send Data
                    // Process the list of files found in the directory.
                    string strPath = "..\\..\\ClientFiles\\" + strFilename;
                    byte[] buffer = new byte[BUF_SIZE];
                    FileStream fileStream = new FileStream(strPath, FileMode.Open, FileAccess.Read);
                    while ((nFReadLen = fileStream.Read(buffer, 0, BUF_SIZE)) > 0)
                        sender.Send(buffer, nFReadLen, SocketFlags.None);
                    fileStream.Close();

                    // Release the socket.
                    //..sender.Shutdown(SocketShutdown.Both);
                    sender.Close();

                    Console.WriteLine(strFilename + " is sent.");
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        static void Main(string[] args)
        {
            SendToServer("test.exe");
        }
    }
}
