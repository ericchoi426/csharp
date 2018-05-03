using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDataStructure
{
    class CDSNativeArray
    {
        public static void simpleArray()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            int lengthOfNumbers = numbers.Length;
            Console.WriteLine(lengthOfNumbers);
        }

        #region [ TEST ]
        public static void DoTest(bool doTest)
        {
            if (doTest)
            {
                simpleArray();
            }
        }
        #endregion
    }
}
