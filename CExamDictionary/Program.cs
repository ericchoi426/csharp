using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExamDictionary
{
    class CMMInfo
    {
        public string Name { get => name; set => name = value; }
        public double A_project { get => a_project; set => a_project = value; }
        public double B_project { get => b_project; set => b_project = value; }
        public double C_project { get => c_project; set => c_project = value; }

        private double a_project;
        private double b_project;
        private double c_project;
        private string name;
    }
    class Program
    {
        public static bool getMM(ref Dictionary<string,CMMInfo> dict)
        {
            string file_name = "..\\..\\DATA\\DS_Sample2.csv";
            

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

                        string[] data = line.Split(',');
                        string key = data[1];
                        if (dict.ContainsKey(key))
                        {
                            dict[key].A_project += Convert.ToDouble(data[3]);
                            dict[key].B_project += Convert.ToDouble(data[4]);
                            dict[key].C_project += Convert.ToDouble(data[5]);
                        }
                        else
                        {
                            CMMInfo mmData = new CMMInfo
                            {
                                Name = data[2],
                                A_project = double.Parse(data[3]),
                                B_project = double.Parse(data[4]),
                                C_project = double.Parse(data[5])
                            };
                            dict.Add(key, mmData);
                        }
                    }                   
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            Dictionary<string, CMMInfo> dict = new Dictionary<string, CMMInfo>();
            getMM(ref dict);
            foreach (var pair in dict)
            {
                double sum = pair.Value.A_project + pair.Value.B_project + pair.Value.C_project;
                Console.WriteLine("{0} {1} {2} {3} {4}   ==>  {5}", pair.Key, pair.Value.Name,pair.Value.A_project, pair.Value.B_project, pair.Value.C_project, sum);
            }
            Console.ReadKey();
        }
    }
}
