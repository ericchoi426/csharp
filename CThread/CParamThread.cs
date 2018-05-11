using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CThread
{
    class CParamThread
    {
        private static int m_Sum = 0;
        public static void doSomething(object n)
        {
            int sum = 0;
            int[] number = (int[])n;
            for(int i = number[0]; i < number[1];i++)
            {
                sum += i;
            }
            m_Sum += sum;
        }
        public static void Test_Thread(bool doTest)
        {
            if (!doTest) return;
            int[][] bound = new int[][]
            {
                new int[]{1,10},
                new int[]{11,20},
                new int[]{21,30},
                new int[]{31,40},
                new int[]{41,50}
            };

            int count = bound.Length;
            Thread[] threadArr = new Thread[count];
            for(int i = 0; i < bound.Length; i++)
            {
                threadArr[i] = new Thread(start: new ParameterizedThreadStart(doSomething));
                threadArr[i].Start(bound[i]);
            }

            for(int j = 0; j < bound.Length; j++)
            {
                threadArr[j].Join();
            }
            Console.Write("1부터50까지의 합은:{0}", m_Sum);
        }
    }
}
