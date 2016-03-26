using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


/***************************************************
 * Creator: Morris @ PC-HAMILTON
 * Create Date: 2016/3/24-星期四 18:38:33
 * ID: d274b3d3-ef22-4cfd-850d-9a8d1ea32a5e
 ***************************************************/
namespace ConsoleTester
{
    public class TextMerger
    {
        static public void append(string baseFilePath,string outputFilePath,int fileCount)
        {
            using (StreamWriter sw = File.CreateText(outputFilePath)) 
            {
                System.Console.WriteLine("create outputfile:" + outputFilePath);
                for (int counter = 0; counter < fileCount; counter++)
                {
                    string tmpFilePath=baseFilePath+counter.ToString().PadLeft(2,'0')+".txt";
                    if (File.Exists(tmpFilePath))
                    {
                        using (StreamReader sr = File.OpenText(tmpFilePath))
                        {
                            System.Console.WriteLine("open file:" + tmpFilePath);
                            sr.ReadLine();
                            while (!sr.EndOfStream)
                            {
                                sw.WriteLine(sr.ReadLine());
                            }
                            sw.Flush();
                            System.Console.WriteLine("done.");
                        }
                    }
                }
            }
            System.Console.WriteLine("All Done.");
            System.Console.ReadKey();
        }
    }
}
