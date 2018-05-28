using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CExamThread
{
    class CWorker
    {
        private static Mutex mul = new Mutex();

        private int m_num;
        public CWorker(int num)
        {
            m_num = num;
        }
        public void DoWork()
        {
            mul.WaitOne();
            for(int i = 0; i  < 30; i++)
            {
                //Console.WriteLine("[Thread{0}] {1}", m_num, i+1);
                //Thread.Sleep(1);
                Console.Write("{0} ", i + 1);
            }
            Console.WriteLine();
            mul.ReleaseMutex();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            

            CWorker work1 = new CWorker(1);
            Thread workThread1 = new Thread(work1.DoWork);
            workThread1.Start();

            CWorker work2 = new CWorker(2);
            Thread workThread2 = new Thread(work2.DoWork);
            workThread2.Start();

            Mutex mul2 = new Mutex();
            mul2.WaitOne();
            for (int i = 0; i < 30; i++)
            {
                Console.Write("{0} ", i+1);
                //Thread.Sleep(1);
            }
            Console.WriteLine();
            mul2.ReleaseMutex();
            workThread1.Join();
            workThread2.Join();

            Console.ReadKey();

        }
    }
}
