using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CDataStructure
{
    class CDataStructure
    {
        
        static void Main(string[] args)
        {
            CDSString.DoTest(false);
            CDSNativeArray.DoTest(false);
            CDSList.DoTest(false);
            CDSDictionary.DoTest(false);
            CDSListExtend.DoTest(true);
            // Keep the console window open in debug mode
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
