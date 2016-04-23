using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Morris.YankeePark.BitmapHandler;
using Morris.YankeePark.OfficeTools;

namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            //SimpleFunction.cutIntoExt(@"e:\a\",@"e:\b\");
            ExcelTool et = new ExcelTool();
            et.foo(@"e:\a.xlsx",@"e:\d\b-");
        }
    }
}
