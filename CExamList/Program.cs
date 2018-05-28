using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExamList
{
    class CStudent
    {
        private string name;
        private int korean;
        private int english;
        private int math;

        public int Math { get => math; set => math = value; }
        public int English { get => english; set => english = value; }
        public int Korean { get => korean; set => korean = value; }
        public string Name { get => name; set => name = value; }
    }

    class Program
    {
        public static bool ReadFile(string file_name, ref List<CStudent> result)
        {
            if (File.Exists(file_name))
            {
                // using문을 사용하면 Diposal를 자동 처리 즉 file close를 알아서 처리해줌
                using (StreamReader reader = new StreamReader(file_name))
                {
                    while (true)
                    {
                        string line = reader.ReadLine();
                        
                        if (line == null)
                            return true;

                        string[] data = line.Split(' ');
                        CStudent sdata = new CStudent();
                        sdata.Name = data[0];
                        sdata.Korean = Convert.ToInt32(data[1]);
                        sdata.English = Convert.ToInt32(data[2]);
                        sdata.Math = Convert.ToInt32(data[3]);
                        result.Add(sdata);
                    }
                }
            }
            return false;
        }

        static void printList(ref List<CStudent> list)
        {
            foreach(CStudent s in list)
            {
                Console.WriteLine("{0} {1} {2} {3}",s.Name, s.Korean, s.English, s.Math);
            }
        }

        static void Main(string[] args)
        {
            string cmd;
            List<CStudent> result = new List<CStudent>();
            ReadFile("..\\..\\DATA\\DS_Sample1.txt", ref result);

            while(!(cmd = Console.ReadLine()).Equals("QUIT"))
            {
                if (cmd.Equals("PRINT"))
                {
                    result.Sort((x, y) => x.Name.CompareTo(y.Name));
                    printList(ref result);

                }else if (cmd.Equals("KOREAN"))
                {
                    result.Sort((x, y) => y.Korean.CompareTo(x.Korean));
                    printList(ref result);
                }
                else if (cmd.Equals("ENGLISH"))
                {
                    result.Sort((x, y) => y.English.CompareTo(x.English));
                    printList(ref result);
                }
                else if (cmd.Equals("MATH"))
                {
                    result.Sort((x, y) => y.Math.CompareTo(x.Math));
                    printList(ref result);
                }
                else if (cmd.Equals("QUIT"))
                {
                    break;
                }
            }


        }
    }
}
