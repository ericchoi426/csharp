using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CDataStructure
{
    // String 처리 관련 참고 사항 Class
    class CDSString
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
        #region[ string : formatting ]
        public static void PrintFormattedString()
        {
            Int32 positiveNum = 123456;
            Int32 negativeNum = -123456;
            Single realNumber32 = 123456.789F;
            Double realNumber64 = 123456.789012345;
            String text = "String.Format example";

            Console.WriteLine("서식이 지정되지 않은 그대로의 값: ");
            Console.WriteLine("  positiveNum : {0}", positiveNum);
            Console.WriteLine("  negativeNum : {0}", negativeNum);
            Console.WriteLine("  realNumber32: {0}", realNumber32);
            Console.WriteLine("  realNumber64: {0}", realNumber64);
            Console.WriteLine("  text        : {0}", text);

            Console.WriteLine("통화 서식이 지정된 값: ");
            Console.WriteLine("  positiveNum : {0:c}", positiveNum);
            Console.WriteLine("  negativeNum : {0:C}", negativeNum);
            Console.WriteLine("  realNumber32: {0:c}", realNumber32);
            Console.WriteLine("  realNumber64: {0:C}", realNumber64);
            Console.WriteLine("  text        : {0:C}", text);

            Console.WriteLine("10진수 서식이 지정된 값: ");
            Console.WriteLine("  positiveNum : {0:d}", positiveNum);
            Console.WriteLine("  negativeNum : {0:D}", negativeNum);
            Console.WriteLine("  realNumber32: -");
            Console.WriteLine("  realNumber64: -");
            Console.WriteLine("  text        : {0:D}", text);

            Console.WriteLine("고정 소숫점 서식이 지정된 값: ");
            Console.WriteLine("  positiveNum : {0:f}", positiveNum);
            Console.WriteLine("  negativeNum : {0:F}", negativeNum);
            Console.WriteLine("  realNumber32: {0:f}", realNumber32);
            Console.WriteLine("  realNumber64: {0:F}", realNumber64);
            Console.WriteLine("  text        : {0:F}", text);

            Console.WriteLine("일반 서식이 지정된 값: ");
            Console.WriteLine("  positiveNum : {0:g}", positiveNum);
            Console.WriteLine("  negativeNum : {0:G}", negativeNum);
            Console.WriteLine("  realNumber32: {0:g}", realNumber32);
            Console.WriteLine("  realNumber64: {0:G}", realNumber64);
            Console.WriteLine("  text        : {0:G}", text);

            Console.WriteLine("숫자 서식이 지정된 값: ");
            Console.WriteLine("  positiveNum : {0:n}", positiveNum);
            Console.WriteLine("  negativeNum : {0:N}", negativeNum);
            Console.WriteLine("  realNumber32: {0:n}", realNumber32);
            Console.WriteLine("  realNumber64: {0:N}", realNumber64);
            Console.WriteLine("  text        : {0:N}", text);

            Console.WriteLine("백분율 서식이 지정된 값: ");
            Console.WriteLine("  positiveNum : {0:p}", positiveNum);
            Console.WriteLine("  negativeNum : {0:P}", negativeNum);
            Console.WriteLine("  realNumber32: {0:p}", realNumber32);
            Console.WriteLine("  realNumber64: {0:P}", realNumber64);
            Console.WriteLine("  text        : {0:P}", text);

            Console.WriteLine("라운드트립 서식이 지정된 값: ");
            Console.WriteLine("  positiveNum : -");
            Console.WriteLine("  negativeNum : -");
            Console.WriteLine("  realNumber32: {0:r}", realNumber32);
            Console.WriteLine("  realNumber64: {0:R}", realNumber64);
            Console.WriteLine("  text        : {0:R}", text);

            Console.WriteLine("16진수 서식이 지정된 값: ");
            Console.WriteLine("  positiveNum : {0:x}", positiveNum);
            Console.WriteLine("  negativeNum : {0:X}", negativeNum);
            Console.WriteLine("  realNumber32: -");
            Console.WriteLine("  realNumber64: -");
            Console.WriteLine("  text        : {0:X}", text);
        }
        #endregion

        #region[ string : between ]
        public static String betweenStrings(String text, String start, String end)
        {
            int p1 = text.IndexOf(start) + start.Length;
            int p2 = text.IndexOf(end, p1);
            if (end == "") return (text.Substring(p1));
            else
            {
                return text.Substring(p1, p2 - p1);
            }
        }
        #endregion

        #region [ string : 정규식 숫자 추출 ]
        public static string GetDecimalFromString(string input, string rep)
        {
            // \d : 숫자 \D: 문자를 의미
            // 따라서 하기 내용은 문자열중에서 숫자를 제외한 문자만 골라서 rep 문자로 대체한다.
            string strNum = Regex.Replace(input, @"\D", rep);
            return strNum;
        }
        #endregion

        #region [ TEST ]
        public static void DoTest(bool doTest)
        {
            if (doTest)
            {
                HandleStringExample1();
                HandleStringSplit();
                PrintFormattedString();

                #region [ example of between ]
                {
                    String text = "One=1,Two=2,ThreeFour=34";

                    Console.WriteLine(betweenStrings(text, "One=", ",")); // 1
                    Console.WriteLine(betweenStrings(text, "Two=", ",")); // 2
                    Console.WriteLine(betweenStrings(text, "ThreeFour=", "")); // 34
                }
                #endregion

                #region [ example of GetDecimal ]
                {
                    string strDel = GetDecimalFromString("123adkdi67dkdkdkdk7d88888a", " ");
                    //string[] words = strDel.Split(' ');
                    var words = strDel.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    Console.WriteLine("input words :{0} and # of splited words:{1}", strDel, words.Length);

                    foreach (string word in words)
                    {
                        Console.Write("{0} ", word);
                    }
                    Console.WriteLine();

                }
                #endregion
            }
        }
        #endregion

    }
}
