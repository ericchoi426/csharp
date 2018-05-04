using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDataStructure
{
    class CDSList
    {
        #region[ List : Find ]
        public class Part : IEquatable<Part>, IComparable<Part>
        {
            public string PartName { get; set; }
            public int PartId { get; set; }

            public override string ToString()
            {
                return "ID:" + PartId + "Name:" + PartName;
            }

            public override bool Equals(object obj)
            {
                if (obj == null) return false;
                Part objAsPart = obj as Part;
                if (objAsPart == null) return false;
                else return Equals(objAsPart);
            }
            public override int GetHashCode()
            {
                return PartId;
            }
            public bool Equals(Part other)
            {
                if (other == null) return false;
                else return PartId.Equals(other.PartId);
            }

            public int CompareTo(Part other)
            {
                if (other == null)
                    return 1;
                else
                    return this.PartId.CompareTo(other.PartId);
            }
            public int SortByNameAscending(string name1, string name2)
            {
                return name1.CompareTo(name2);
            }
        }
        static void Test_Find(bool doTest)
        {
            if (!doTest) return;

            // Create a list of parts.
            List<Part> parts = new List<Part>();

            // Add parts to the list.
            parts.Add(new Part() { PartName = "crank arm", PartId = 1234 });
            parts.Add(new Part() { PartName = "chain ring", PartId = 1334 });
            parts.Add(new Part() { PartName = "regular seat", PartId = 1434 });
            parts.Add(new Part() { PartName = "banana seat", PartId = 1444 });
            parts.Add(new Part() { PartName = "cassette", PartId = 1534 });
            parts.Add(new Part() { PartName = "shift lever", PartId = 1634 }); ;

            // Write out the parts in the list. This will call the overridden ToString method
            // in the Part class.
            Console.WriteLine();
            foreach (Part aPart in parts)
            {
                Console.WriteLine(aPart);
            }


            // Check the list for part #1734. This calls the IEquatable.Equals method
            // of the Part class, which checks the PartId for equality.
            Console.WriteLine("\nContains: Part with Id=1734: {0}",
                parts.Contains(new Part { PartId = 1734, PartName = "" }));

            // Find items where name contains "seat".
            Console.WriteLine("\nFind: Part where name contains \"seat\": {0}",
                parts.Find(x => x.PartName.Contains("seat")));

            // Check if an item with Id 1444 exists.
            Console.WriteLine("\nExists: Part with Id=1444: {0}",
                parts.Exists(x => x.PartId == 1444));
            /*This code example produces the following output:
            ID: 1234   Name: crank arm
            ID: 1334   Name: chain ring
            ID: 1434   Name: regular seat
            ID: 1444   Name: banana seat
            ID: 1534   Name: cassette
            ID: 1634   Name: shift lever

            Contains: Part with Id=1734: False

            Find: Part where name contains "seat": ID: 1434   Name: regular seat

            Exists: Part with Id=1444: True 
             */
        }
        #endregion
        #region[List: TrueForAll,FindAll,FindLast]
        static void Test_ListAPI(bool doTest)
        {
            if (!doTest) return;

            List<string> dinosaurs = new List<string>();

            dinosaurs.Add("Compsognathus");
            dinosaurs.Add("Amargasaurus");
            dinosaurs.Add("Oviraptor");
            dinosaurs.Add("Velociraptor");
            dinosaurs.Add("Deinonychus");
            dinosaurs.Add("Dilophosaurus");
            dinosaurs.Add("Gallimimus");
            dinosaurs.Add("Triceratops");

            Console.WriteLine();
            foreach (string dinosaur in dinosaurs)
            {
                Console.WriteLine(dinosaur);
            }

            Console.WriteLine("\nTrueForAll(EndsWithSaurus): {0}",
                dinosaurs.TrueForAll(EndsWithSaurus));

            Console.WriteLine("\nFind(EndsWithSaurus): {0}",
                dinosaurs.Find(EndsWithSaurus));

            Console.WriteLine("\nFindLast(EndsWithSaurus): {0}",
                dinosaurs.FindLast(EndsWithSaurus));

            Console.WriteLine("\nFindAll(EndsWithSaurus):");
            List<string> sublist = dinosaurs.FindAll(EndsWithSaurus);

            foreach (string dinosaur in sublist)
            {
                Console.WriteLine(dinosaur);
            }

            Console.WriteLine(
                "\n{0} elements removed by RemoveAll(EndsWithSaurus).",
                dinosaurs.RemoveAll(EndsWithSaurus));

            Console.WriteLine("\nList now contains:");
            foreach (string dinosaur in dinosaurs)
            {
                Console.WriteLine(dinosaur);
            }

            Console.WriteLine("\nExists(EndsWithSaurus): {0}",
                dinosaurs.Exists(EndsWithSaurus));
        }

        // Search predicate returns true if a string ends in "saurus".
        private static bool EndsWithSaurus(String s)
        {
            return s.ToLower().EndsWith("saurus");
        }
        #endregion

        #region[ List : Sort Basic ]
        static void Test_BasicSort(bool doTest)
        {
            if (!doTest) return;

            String[] names = { "Samuel", "Dakota", "Koani", "Saya", "Vanya",
                         "Yiska", "Yuma", "Jody", "Nikita" };
            var nameList = new List<String>();
            nameList.AddRange(names);
            Console.WriteLine("List in unsorted order: ");
            foreach (var name in nameList)
                Console.Write("   {0}", name);

            Console.WriteLine(Environment.NewLine);

            nameList.Sort();
            Console.WriteLine("List in sorted order: ");
            foreach (var name in nameList)
                Console.Write("   {0}", name);

            Console.WriteLine();
        }
        #endregion

        #region[ List : Sort with delegate or Comparator ]
        // Part class의 Interface 상속이 중요한 역할을 하니 참고바람
        static void Test_ExtendedSort(bool doTest)
        {
            if (!doTest) return;
            // Create a list of parts.
            List<Part> parts = new List<Part>();

            // Add parts to the list.
            parts.Add(new Part() { PartName = "regular seat", PartId = 1434 });
            parts.Add(new Part() { PartName = "crank arm", PartId = 1234 });
            parts.Add(new Part() { PartName = "shift lever", PartId = 1634 }); ;
            // Name intentionally left null.
            parts.Add(new Part() { PartId = 1334 });
            parts.Add(new Part() { PartName = "banana seat", PartId = 1444 });
            parts.Add(new Part() { PartName = "cassette", PartId = 1534 });


            // Write out the parts in the list. This will call the overridden 
            // ToString method in the Part class.
            Console.WriteLine("\nBefore sort:");
            foreach (Part aPart in parts)
            {
                Console.WriteLine(aPart);
            }


            // Call Sort on the list. This will use the 
            // default comparer, which is the Compare method 
            // implemented on Part.
            parts.Sort();


            Console.WriteLine("\nAfter sort by part number:");
            foreach (Part aPart in parts)
            {
                Console.WriteLine(aPart);
            }

            // This shows calling the Sort(Comparison(T) overload using 
            // an anonymous method for the Comparison delegate. 
            // This method treats null as the lesser of two values.
            parts.Sort(delegate (Part x, Part y)
            {
                if (x.PartName == null && y.PartName == null) return 0;
                else if (x.PartName == null) return -1;
                else if (y.PartName == null) return 1;
                else return x.PartName.CompareTo(y.PartName);
            });

            Console.WriteLine("\nAfter sort by name:");
            foreach (Part aPart in parts)
            {
                Console.WriteLine(aPart);
            }

        }
        #endregion

        #region[ List : ToArray,AddRange, RemoveRange, InsertRange ]
        static void Test_ToArray(bool doTest)
        {
            if (!doTest) return;
            string[] input = { "Brachiosaurus",
                           "Amargasaurus",
                           "Mamenchisaurus" };

            List<string> dinosaurs = new List<string>(input);

            Console.WriteLine("\nCapacity: {0}", dinosaurs.Capacity);

            Console.WriteLine();
            foreach (string dinosaur in dinosaurs)
            {
                Console.WriteLine(dinosaur);
            }

            Console.WriteLine("\nAddRange(dinosaurs)");
            dinosaurs.AddRange(dinosaurs);

            Console.WriteLine();
            foreach (string dinosaur in dinosaurs)
            {
                Console.WriteLine(dinosaur);
            }

            Console.WriteLine("\nRemoveRange(2, 2)");
            dinosaurs.RemoveRange(2, 2);

            Console.WriteLine();
            foreach (string dinosaur in dinosaurs)
            {
                Console.WriteLine(dinosaur);
            }

            input = new string[] { "Tyrannosaurus",
                               "Deinonychus",
                               "Velociraptor"};

            Console.WriteLine("\nInsertRange(3, input)");
            dinosaurs.InsertRange(3, input);

            Console.WriteLine();
            foreach (string dinosaur in dinosaurs)
            {
                Console.WriteLine(dinosaur);
            }

            Console.WriteLine("\noutput = dinosaurs.GetRange(2, 3).ToArray()");
            string[] output = dinosaurs.GetRange(2, 3).ToArray();

            Console.WriteLine();
            foreach (string dinosaur in output)
            {
                Console.WriteLine(dinosaur);
            }
        }

        #endregion

        #region[ List : 중복제거 ]
        static void Test_RemoveDuplicateElement(bool doTest)
        {
            if (!doTest) return;

            int[] a = { 1, 2, 3, 4, 5 };
            int[] b = { 4, 5, 6, 7, 8, 9, 10 };
            List<int> aa = new List<int>(a);
            List<int> bb = new List<int>(b);

            List<int> result = new List<int>();
            result.AddRange(aa);
            result.AddRange(bb);

            Console.WriteLine("Original list");
            foreach (int item in result)
            {
                Console.Write(item);
            }
            Console.WriteLine();

            result = result.Distinct().ToList();

            Console.WriteLine("Removed Duplicated element list");
            foreach (int item in result)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }
        #endregion

        #region [ TEST ]
        public static void DoTest(bool doTest)
        {
            if (doTest)
            {
                Test_Find(false);
                Test_ListAPI(false);
                Test_BasicSort(false);
                Test_ExtendedSort(false);
                Test_ToArray(false);
                Test_RemoveDuplicateElement(true);
            }
        }
        #endregion
    }
}
