using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CExamEncoding
{
    class Program
    {
        public static void ToBase64(string input)
        {
            byte[] strByte = Encoding.UTF8.GetBytes(input);
            string encodedStr = Convert.ToBase64String(strByte);
            Console.WriteLine(encodedStr);
            byte[] decodedByte = Convert.FromBase64String(encodedStr);
            string decodedStr = Encoding.Default.GetString(decodedByte);
            if (input.Equals(decodedStr))
            {
                Console.WriteLine("It's same string!!:{0}",decodedStr);
            }
            else
            {
                Console.WriteLine("It's not same string!!:{0}",decodedStr);
            }

        }
        public static void SHA256(string input)
        {
            byte[] hashValue;
            byte[] byteInput = Encoding.UTF8.GetBytes(input);
            SHA256 mySHA256 = SHA256Managed.Create();
            hashValue = mySHA256.ComputeHash(byteInput);
            Console.WriteLine(hashValue);
            for (int i = 0; i < hashValue.Length; i++)
            {
                Console.Write("{0:X2}", hashValue[i]);
            }
        }
        static void Main(string[] args)
        {
            ToBase64("This is Base64 test.");
            SHA256("1234");
            Console.ReadKey();
        }
    }
}
