using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            for (i = 0; i < 26; i++)
            {
                System.Console.Write("'" + (char)('a' + i) + "',");
            }
            for (i = 0; i < 26; i++)
            {
                System.Console.Write("'" + (char)('A' + i) + "',");
            }
            for (i = 0; i < 10; i++)
            {
                System.Console.Write("'" + (char)('0' + i) + "',");
            }
            System.Console.Read();
        }
    }
}
