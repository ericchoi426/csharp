using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDirectoryFilesAPI
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
    }

    class CDirectoryFilesAPI
    {
        static void Main(string[] args)
        {
            #region [ 사용법 ] : GetMatchedFiles
            string[] result;
            int num = CDirectoryFileHeper.GetMatchedFiles(@"D:\imdb", "clrpick.tcl", out result);
            foreach(string s in result)
            {
                Console.WriteLine(s);
            }
            #endregion

            Console.ReadKey();
        }
    }
}
