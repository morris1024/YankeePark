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
            TextMerger.append(
                @"E:\Temp\Joe Data\0326 DataFiles\S2016032610382909454",
                @"E:\Temp\Joe Data\0326 DataFiles\0326.txt",
                15);
        }
    }
}
