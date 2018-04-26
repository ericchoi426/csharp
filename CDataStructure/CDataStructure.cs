using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDataStructure
{
    class CDSHelper
    {
        #region [ string : IndexOf, LastIndexOf, StartsWith 및 EndsWith 메서드를 사용하여 문자열을 검색]
        public static void HandleStringExample1()
        {
            string str = "Extension methods have all the capabilities of regular static methods.";

            // Write the string and include the quotation marks.
            Console.WriteLine("\"{0}\"", str);

            // Simple comparisons are always case sensitive! 
            bool test1 = str.StartsWith("extension");
            Console.WriteLine("Starts with \"extension\"? {0}", test1);

            // For user input and strings that will be displayed to the end user,  
            // use the StringComparison parameter on methods that have it to specify how to match strings. 
            bool test2 = str.StartsWith("extension", StringComparison.CurrentCultureIgnoreCase);
            Console.WriteLine("Starts with \"extension\"? {0} (ignoring case)", test2);

            bool test3 = str.EndsWith(".", StringComparison.CurrentCultureIgnoreCase);
            Console.WriteLine("Ends with '.'? {0}", test3);

            // This search returns the substring between two strings, so  
            // the first index is moved to the character just after the first string. 
            int first = str.IndexOf("methods") + "methods".Length;
            int last = str.LastIndexOf("methods");
            string str2 = str.Substring(first, last - first);
            Console.WriteLine("Substring between \"methods\" and \"methods\": '{0}'", str2);

            
        }
        #endregion
        #region[ string : Split 사용 ]
        public static void HandleStringSplit()
        {
            //1.문자열을 공백을 기준으로 단어로 분리
            {
                string phrase = "The quick brown fox jumped over the lazy dog.";
                string[] words = phrase.Split(' ');

                foreach (var word in words)
                {
                    System.Console.WriteLine($"<{word}>");
                }
            }
            //2. 연속된 구분 문자는 반환된 배열의 값으로 빈 문자열을 생성
            {
                string phrase = "The quick brown    fox     jumped over the lazy dog.";
                string[] words = phrase.Split(' ');

                foreach (var word in words)
                {
                    System.Console.WriteLine($"<{word}>");
                }
            }
            //3.다중 구분 문자를 사용
            {
                char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

                string text = "one\ttwo three:four,five six seven";
                System.Console.WriteLine($"Original text: '{text}'");

                string[] words = text.Split(delimiterChars);
                System.Console.WriteLine($"{words.Length} words in text:");

                foreach (var word in words)
                {
                    System.Console.WriteLine($"<{word}>");
                }
            }
            //4.연속되는 모든 구분 기호의 인스턴스는 출력 배열에 빈 문자열을 생성
            {
                char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

                string text = "one\ttwo :,five six seven";
                System.Console.WriteLine($"Original text: '{text}'");

                string[] words = text.Split(delimiterChars);
                System.Console.WriteLine($"{words.Length} words in text:");

                foreach (var word in words)
                {
                    System.Console.WriteLine($"<{word}>");
                }
            }
            //5.문자열 배열(단일 문자 대신 대상 문자열을 구문 분석하는 구분 기호 역할을 
            //하는 문자 시퀀스)을 사용
            {
                string[] separatingChars = { "<<", "..." };

                string text = "one<<two......three<four";
                System.Console.WriteLine("Original text: '{0}'", text);

                string[] words = text.Split(separatingChars, System.StringSplitOptions.RemoveEmptyEntries);
                System.Console.WriteLine("{0} substrings in text:", words.Length);

                foreach (var word in words)
                {
                    System.Console.WriteLine(word);
                }
            }
        }
        #endregion
    }

    class CDataStructure
    {
        static void Main(string[] args)
        {
            CDSHelper.HandleStringExample1();
            CDSHelper.HandleStringSplit();
            
            // Keep the console window open in debug mode
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
