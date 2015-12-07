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
            for (int i = 0; i < 5; i++)
            {
                System.Console.WriteLine(
                    SecurityVerifyModule.RandomStringBuilder.GenerateRandomString(20)
                    );
            }
            System.Console.Read();
        }
    }
}
