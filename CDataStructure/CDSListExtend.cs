using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDataStructure
{
    public class Department
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class DepartmentComparer : IEqualityComparer<Department>
    {
        // equal if their Codes are equal
        public bool Equals(Department x, Department y)
        {
            // reference the same objects?
            if (Object.ReferenceEquals(x, y)) return true;

            // is either null?
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            return x.Code == y.Code;
        }

        public int GetHashCode(Department dept)
        {
            // If Equals() returns true for a pair of objects 
            // then GetHashCode() must return the same value for these objects.

            // if null default to 0
            if (Object.ReferenceEquals(dept, null)) return 0;

            return dept.Code.GetHashCode();
        }
    }
    class CDSListExtend
    {
        static private Department[] departments = { new Department { Code = "MK", Name = "Marketing" },
                               new Department { Code = "SA", Name = "Sales" },
                               new Department { Code = "AC", Name = "Accounts" },
                               new Department { Code = "AC", Name = "Accounting" },
                               new Department { Code = "HR", Name = "Human Resources" },
                               new Department { Code = "HR", Name = "Human Res." }};

        static private Department[] departments2 = { new Department { Code = "MK", Name = "Marketing" },
                               new Department { Code = "SA", Name = "Sales" },
                               new Department { Code = "IT", Name = "Information Technology" },
                               new Department { Code = "HR", Name = "Human Rsc" }};

        static private Department[] departments3 = { new Department { Code = "MK", Name = "Marketing" },
                               new Department { Code = "IT", Name = "Information Tech." },
                               new Department { Code = "SA", Name = "Sales" },
                               new Department { Code = "HR", Name = "Human Resources" }};

        #region[ List : Contains ]
        public static void Test_Contains(bool doTest)
        {
            if (!doTest) return;

            bool deptContains = departments.Contains(new Department { Code = "AC", Name = "Accts." }, new DepartmentComparer());
            Console.WriteLine("It {0} contained.", deptContains ? "is" : "isn't");
            // It is contained.
        }
        #endregion

        #region[ List : Distinct 중복제거]
        public static void Test_Distinct(bool doTest)
        {
            if (!doTest) return;

            IEnumerable<Department> deptDistinct = departments.Distinct(new DepartmentComparer());

            foreach (Department dept in deptDistinct)
            {
                Console.WriteLine("{0} {1}", dept.Code, dept.Name);
                //Console.WriteLine(dept.Code.GetHashCode());   // for testing
            }
        }
        #endregion

        #region[ List : Except 두 리스트의 차집합]
        public static void Test_Except(bool doTest)
        {
            if (!doTest) return;

            IEnumerable<Department> deptExcept = departments.Except(departments2, new DepartmentComparer());

            //Departments with Code "AC" are considered to be the same so, when displaying the Name, which name appears? The first one: "Accounts".
            foreach (Department dept in deptExcept)
            {
                Console.WriteLine("{0} {1}", dept.Code, dept.Name);
            }
            // departments not in departments2: AC, Accounts.
        }
        #endregion

        #region[ List : Intersect 두 리스트의 교집합]
        public static void Test_Intersect(bool doTest)
        {
            if (!doTest) return;

            Console.WriteLine("Intersecting departments:");

            IEnumerable<Department> deptIntersect = departments.Intersect(departments2,
                new DepartmentComparer());

            foreach (Department dept in deptIntersect)
            {
                Console.WriteLine("{0} {1}", dept.Code, dept.Name);
            }
            // MK Marketing, SA Sales, HR Human Resources
        }
        #endregion

        #region[ List : SequenceEqual 두 리스트가 순차적으로 동일하게 일치하는가? ]
        public static void Test_SequenceEqual(bool doTest)
        {
            if (!doTest) return;
            bool deptEquals = departments2.SequenceEqual(departments3, new DepartmentComparer());
            Console.WriteLine("They are{0}the same.", deptEquals ? " " : " not ");
            // They are not the same. Change them to have the same order and they
            // will be the same.
        }
        #endregion

        #region[ List : Union 두 리스트의 합집합 ]
        public static void Test_Union(bool doTest)
        {
            if (!doTest) return;
            Console.WriteLine("Union of departments and departments 2:");

            IEnumerable<Department> deptUnion = departments.Union(departments2,
                new DepartmentComparer());

            foreach (Department dept in deptUnion)
            {
                Console.WriteLine("{0} {1}", dept.Code, dept.Name);
            }
            // MK SA AC HR IT
            // (each only appears once, with AC displaying as "Accounts"
            // and HR as "Human Resources")
        }
        #endregion

        #region [ TEST ]
        public static void DoTest(bool doTest)
        {
            if (doTest)
            {
                Test_Contains(false);
                Test_Distinct(false);
                Test_Except(false);
                Test_Intersect(false);
                Test_SequenceEqual(false);
                Test_Union(true);
            }
        }
        #endregion
    }
}
