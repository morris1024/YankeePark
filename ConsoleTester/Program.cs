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
            SecurityVerifyModule.UserVerify uv = new SecurityVerifyModule.UserVerify();
            //uv.AddUser("123", "1234");
            uv.UpdatePassword("123", "567");
            System.Console.Write(uv.CheckUser("123", "567"));
            uv.UpdatePasswordAndSalt("123", "789");
            System.Console.Write(uv.CheckUser("123", "789"));
            System.Console.Read();
        }
    }
}
