using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExam1
{
    class CDirectory
    {
        public static void FindFiles(string path, out string[] files)
        {
            files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
        }

        public static void CopyFile(string file_name)
        {
            System.IO.Directory.CreateDirectory("../../OUTPUT");
            const int BUF_SIZE = 512;

            byte[] buffer = new byte[BUF_SIZE];
            int nFReadLen;
            using (FileStream fs_in = new FileStream("../../INPUT/" + file_name, FileMode.Open, FileAccess.Read),
                 fs_out = new FileStream("../../OUTPUT/" + file_name, FileMode.Create, FileAccess.Write))
            {
                while ((nFReadLen = fs_in.Read(buffer, 0, BUF_SIZE)) > 0)
                {
                    fs_out.Write(buffer, 0, nFReadLen);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            const double max_size = 2;
            long bytes = 0;
            double kilobytes = 0;

            string[] result;
            CDirectory.FindFiles("../../INPUT", out result);
            foreach(string file in result)
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(file);
                if (fileInfo.Exists)
                {
                    bytes = fileInfo.Length;
                    kilobytes = (double)bytes / 1024;
                    if(kilobytes > max_size)
                    {
                        Console.WriteLine(file);
                        CDirectory.CopyFile(fileInfo.Name);
                    }
                }
               
            }
            Console.ReadKey();
        }
    }
}
