using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDirectoryFileHelper
{
    class CDirectoryFileHeper
    {
        // Constructor
        CDirectoryFileHeper()
        {

        }
        #region [ GetMatchedFiles] : 주어진 Directory에 하위 모든 폴더에서 주어진 이름을 가진 파일을 찾아 경로를 리턴해줌
        public static int GetMatchedFiles(string path, string file_name, out string[] result)
        {
            // find all files which is matched given file_name
            result = Directory.GetFiles(path, file_name, SearchOption.AllDirectories);
            return result.Length;
        }
        #endregion

        #region [ copy file ] 특정 파일을 원하는 위치에 카피함
        public static void CopyFile(string file_name)
        {
            System.IO.Directory.CreateDirectory(".\\OUTPUT");
            const int BUF_SIZE = 512;

            byte[] buffer = new byte[BUF_SIZE];
            int nFReadLen;

            FileStream fs_in = new FileStream("./INPUT/" + file_name, FileMode.Open, FileAccess.Read);
            FileStream fs_out = new FileStream("./OUTPUT/" + file_name, FileMode.Create, FileAccess.Write);

            while ((nFReadLen = fs_in.Read(buffer, 0, BUF_SIZE)) > 0)
            {
                fs_out.Write(buffer, 0, nFReadLen);
            }
            fs_in.Close();
            fs_out.Close();
        }
        #endregion
    }

    class CDirectoryFilesAPI
    {
        static void Main(string[] args)
        {
            #region [ GetMatchedFiles 예제]
            string[] result;
            int num = CDirectoryFileHeper.GetMatchedFiles(@"D:\imdb", "clrpick.tcl", out result);
            foreach (string s in result)
            {
                Console.WriteLine(s);
            }
            #endregion
            #region[ CopyFile 예제 ]
            CDirectoryFileHeper.CopyFile("test.exe");
            #endregion

            Console.ReadKey();
        }
    }
}
