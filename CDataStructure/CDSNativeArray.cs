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
        // Rank 속성을 사용하여 배열의 차원 수를 표시
        public static void GetDimensionOfArray()
        {
            int[,] theArray = new int[5, 10];
            Console.WriteLine("the array has {0} dimensions.", theArray.Rank);
        }

        //multiple array 사용법
        public static void MultipleArrayUsage()
        {
            // Two-dimensional array.
            int[,] array2D = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
            // The same array with dimensions specified.
            int[,] array2Da = new int[4, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
            // A similar array with string elements.
            string[,] array2Db = new string[3, 2] { { "one", "two" }, { "three", "four" },
                                        { "five", "six" } };

            // Three-dimensional array.
            int[,,] array3D = new int[,,] { { { 1, 2, 3 }, { 4, 5, 6 } },
                                 { { 7, 8, 9 }, { 10, 11, 12 } } };
            // The same array with dimensions specified.
            int[,,] array3Da = new int[2, 2, 3] { { { 1, 2, 3 }, { 4, 5, 6 } },
                                       { { 7, 8, 9 }, { 10, 11, 12 } } };

            // Accessing array elements.
            Console.WriteLine(array2D[0, 0]);
            Console.WriteLine(array2D[0, 1]);
            Console.WriteLine(array2D[1, 0]);
            Console.WriteLine(array2D[1, 1]);
            Console.WriteLine(array2D[3, 0]);
            Console.WriteLine(array2Db[1, 0]);
            Console.WriteLine(array3Da[1, 0, 1]);
            Console.WriteLine(array3D[1, 1, 2]);

            // Getting the total count of elements or the length of a given dimension.
            var allLength = array3D.Length;
            var total = 1;
            for (int i = 0; i < array3D.Rank; i++)
            {
                total *= array3D.GetLength(i);
            }
            Console.WriteLine("{0} equals {1}", allLength, total);

            //차수를 지정하지 않고 배열을 초기화
            int[,] array4 = { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };

            //초기화하지 않고 배열 변수를 선언하도록 선택할 경우 new 연산자를 사용하여 변수에 배열을 할당해야 함
            int[,] array5;
            array5 = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };   // OK
                                                                              //array5 = {{1,2}, {3,4}, {5,6}, {7,8}};   // Error

            // 특정 배열 요소에 값을 할당
            array5[2, 1] = 25;

            // 특정 배열 요소의 값을 가져와 elementValue 변수에 할당
            int elementValue = array5[2, 1];

            //  가변 배열을 제외하고 배열 요소를 기본 값으로 초기화
            int[,] array6 = new int[10, 10];

        }
        // foreach 사용
        public static void foreachUsageWithArray()
        {
            int[] numbers = { 4, 5, 6, 1, 2, 3, -2, -1, 0 };
            foreach (int i in numbers)
            {
                Console.Write("{0} ", i);
            }
            // Output: 4 5 6 1 2 3 -2 -1 0

            int[,] numbers2D = new int[3, 2] { { 9, 99 }, { 3, 33 }, { 5, 55 } };
            // Or use the short form:
            // int[,] numbers2D = { { 9, 99 }, { 3, 33 }, { 5, 55 } };

            foreach (int i in numbers2D)
            {
                Console.Write("{0} ", i);
            }
            // Output: 9 99 3 33 5 55
            Console.WriteLine();

        }
        // 배열을 인수로 전달
        #region [ 배열을 인수로 전달 ]
        static void PrintArray(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + "{0}", i < arr.Length - 1 ? " " : "");
            }
            Console.WriteLine();
        }

        static void ChangeArray(string[] arr)
        {
            // The following attempt to reverse the array does not persist when
            // the method returns, because arr is a value parameter.
            arr = (arr.Reverse()).ToArray();
            // The following statement displays Sat as the first element in the array.
            Console.WriteLine("arr[0] is {0} in ChangeArray.", arr[0]);
        }

        static void ChangeArrayElements(string[] arr)
        {
            // The following assignments change the value of individual array 
            // elements. 
            arr[0] = "Sat";
            arr[1] = "Fri";
            arr[2] = "Thu";
            // The following statement again displays Sat as the first element
            // in the array arr, inside the called method.
            Console.WriteLine("arr[0] is {0} in ChangeArrayElements.", arr[0]);
        }
        static void Test_PassArrayAsArguments()
        {
            // Declare and initialize an array.
            string[] weekDays = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

            // Pass the array as an argument to PrintArray.
            PrintArray(weekDays);

            // ChangeArray tries to change the array by assigning something new
            // to the array in the method. 
            ChangeArray(weekDays);

            // Print the array again, to verify that it has not been changed.
            Console.WriteLine("Array weekDays after the call to ChangeArray:");
            PrintArray(weekDays);
            Console.WriteLine();

            // ChangeArrayElements assigns new values to individual array
            // elements.
            ChangeArrayElements(weekDays);

            // The changes to individual elements persist after the method returns.
            // Print the array, to verify that it has been changed.
            Console.WriteLine("Array weekDays after the call to ChangeArrayElements:");
            PrintArray(weekDays);
        }
        #endregion

        #region [ ref , out and array ]
        //out array
        static void FillArrayWithOut(out int[] arr)
        {
            arr = new int[5] { 1, 2, 3, 4, 5 };
        }
        static void Test_FillArrayWithOut()
        {
            int[] theArray; // Initialization is not required

            // Pass the array to the callee using out:
            FillArrayWithOut(out theArray);

            // Display the array elements:
            System.Console.WriteLine("Array elements are:");
            for (int i = 0; i < theArray.Length; i++)
            {
                Console.Write(theArray[i] + " ");
            }
            Console.WriteLine();
        }
        //ref array
        static void FillArrayWithRef(ref int[] arr)
        {
            if(arr == null)
            {
                arr = new int[10];
            }
            arr[0] = 1111;
            arr[4] = 5555;
        }
        static void Test_FillArrayWithRef()
        {
            // Initialize the array:
            int[] theArray = { 1, 2, 3, 4, 5 };

            // Pass the array using ref:
            FillArrayWithRef(ref theArray);

            // Display the updated array:
            System.Console.WriteLine("Array elements are:");
            for (int i = 0; i < theArray.Length; i++)
            {
                Console.Write(theArray[i] + " ");
            }
            Console.WriteLine();
        }
        #endregion

        #region [ TEST ]
        public static void DoTest(bool doTest)
        {
            if (doTest)
            {
                simpleArray();
                GetDimensionOfArray();
                MultipleArrayUsage();
                foreachUsageWithArray();
                Test_PassArrayAsArguments();
                Test_FillArrayWithOut();
                Test_FillArrayWithRef();
                
            }
        }
        #endregion
    }
}
