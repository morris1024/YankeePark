using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Morris.YankeePark.BitmapHandler;
using Morris.YankeePark.OfficeTools;
using Morris.YankeePark.TinyTools;

namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            TwoInOneMerge.batchMerge(@"e:\1", @"e:\2", @"e:\o1\", "WP-Cros-160715-", 3360, 1080, 1920, 1080, 0, 0, 1440, 900, 1920, 180);
            TwoInOneMerge.batchMerge(@"e:\1", @"e:\2", @"e:\o2\", "WP-Cros-160715-", 3360, 1080, 1920, 1080, 1440, 0, 1440, 900, 0, 180);
        }
    }
}
