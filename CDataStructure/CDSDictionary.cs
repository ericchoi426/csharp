using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDataStructure
{
    class CDSDictionary
    {
        #region [ Dictionary : 기본 사용법 ]
        public static void addDictionary(bool doTest)
        {
            if (!doTest) return;

            Dictionary<string, int> dictionary = new Dictionary<string, int>
            {
                { "one", 1 },
                { "two", 2 },
                { "three", 3 }
            };
            Console.WriteLine("first one value:{0}", dictionary["one"]);
        }
        #endregion
        #region [ ContainsKey : 주어진 문자열이 Dictionary에 존재하면 true 없으면 false 리턴 ]
        public static void Test_ContainKey(bool doTest)
        {
            if (!doTest) return;

            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"apple",1 },
                {"window",2 }
            };

            if (dict.ContainsKey("apple"))
            {
                int val = dict["apple"];
                Console.WriteLine(val);
            }
            if (!dict.ContainsKey("arcorn"))
            {
                Console.WriteLine(false);
            }
        }
        #endregion

        #region[ TryGetValue : 효율적인 검색 방법 ]
        public static void Test_TryGetValue(bool doTest)
        {
            if (!doTest) return;
            Dictionary<string, string> dc = new Dictionary<string, string>()
            {
                {"cat","feline" },{"dog","canline"}
            };
            string result;
            if(dc.TryGetValue("cat",out result))
            {
                Console.WriteLine(result);
            }
            if (dc.TryGetValue("dog", out string result2))
            {
                Console.WriteLine(result2);
            }
        }
        #endregion
        #region [ Dictionary loop ]
        public static void Test_Loop(bool doTest)
        {
            if (!doTest) return;
            Dictionary<string, int> dc = new Dictionary<string, int>()
            {
                {"one",1 },
                {"two",2 },
                {"three",3 },
                {"four",4 },
                {"five",5 }
            };

            foreach(KeyValuePair<string,int> pair in dc)
            {
                Console.WriteLine("{0},{1}", pair.Key, pair.Value);
            }

            foreach(var pair in dc)
            {
                Console.WriteLine("{0},{1}", pair.Key, pair.Value);
            }

            List<string> list = new List<string>(dc.Keys);
            foreach(string k in list)
            {
                Console.WriteLine("{0},{1}", k, dc[k]);
            }

        }
        #endregion
        #region[ convert array to Dictionary ]
        public static void Test_Array2Dict(bool doTest)
        {
            if (!doTest) return;
            string[] arr = new string[]
            {
                "One",
                "Two",
                "Three"
            };

            var dict = arr.ToDictionary(item => item, item => true);
            foreach(var pair in dict)
            {
                Console.WriteLine("{0},{1}", pair.Key, pair.Value);
            }

        }
        #endregion
        #region [ TEST ]
        public static void DoTest(bool doTest)
        {
            if (doTest)
            {
                addDictionary(false);
                Test_ContainKey(false);
                Test_TryGetValue(false);
                Test_Loop(false);
                Test_Array2Dict(true);
            }
        }
        #endregion
    }
}
