using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

/***************************************************
 * Creator: Morris @ PC-HAMILTON
 * Create Date: 2016/4/14-星期四 08:19:44
 * ID: 3e9971c3-22e3-4539-bb54-b78c2042954d
 ***************************************************/
namespace ConsoleTester
{
    class SimpleFunction
    {
        /// <summary>
        /// 追加合并读出的类。Joe-160413-Req
        /// </summary>
        /// <param name="inputDirPath">输入文件夹路径</param>
        /// <param name="outputDirPath">输出文件夹路径</param>
        /// <param name="searchPattern">输入文件匹配后缀</param>
        public static void cutInto(string inputDirPath,string outputDirPath,string searchPattern="*.csv")
        {
           if(Directory.Exists(inputDirPath))
           {
               foreach(string inputFilePath in Directory.GetFiles(inputDirPath,searchPattern))
               {
                   string outputFilePath = outputDirPath + Path.GetFileNameWithoutExtension(inputFilePath)+"-OUT"+".txt";
                   using(StreamWriter sw=File.CreateText(outputFilePath))
                   {
                       using(StreamReader sr=File.OpenText(inputFilePath))
                       {
                           sr.ReadLine();
                           while(!sr.EndOfStream)
                           {
                               string line=sr.ReadLine();
                               string[] words=line.Split(',');
                               string firstWord = words[0];
                               for (int i = 1; i < words.Length; i++)
                               {
                                   sw.WriteLine(firstWord + "\t" + words[i]);
                               }
                               sw.Flush();
                           }
                       }
                   }
               }
           }
        }

        /// <summary>
        /// 合并数据文件，适用于文件名编号顺序增加文件。Joe-160324-Req
        /// </summary>
        /// <param name="baseFilePath">起始文件名</param>
        /// <param name="outputFilePath">输出文件名</param>
        /// <param name="fileCount">输入文件数量</param>
        public static void append(string baseFilePath, string outputFilePath, int fileCount)
        {
            using (StreamWriter sw = File.CreateText(outputFilePath))
            {
                System.Console.WriteLine("create outputfile:" + outputFilePath);
                for (int counter = 0; counter < fileCount; counter++)
                {
                    string tmpFilePath = baseFilePath + counter.ToString().PadLeft(2, '0') + ".txt";
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

        /// <summary>
        /// 复制并重命名文件。M-160415-Req
        /// </summary>
        public static void removeFiles()
        {
            string dir = @"E:\1";
            string outDir = @"E:\2\";
            if (Directory.Exists(dir))
            {
                if (!Directory.Exists(outDir))
                {
                    try
                    {
                        Directory.CreateDirectory(outDir);
                    }
                    catch
                    {
                        return;
                    }
                }
                Random rand = new Random();
                var enumer = Directory.EnumerateFiles(dir, "*", SearchOption.AllDirectories);
                string outputFilePath = "";
                foreach (string filePath in enumer)
                {
                    while (String.IsNullOrEmpty(outputFilePath) || File.Exists(outputFilePath))
                    {
                        outputFilePath =
                            outDir + rand.Next(1, enumer.Count() * 10000).ToString().PadLeft(5, '0') +
                            "." + Path.GetExtension(filePath);
                    }
                    File.Copy(filePath, outputFilePath);
                }
            }
        }

    }
}
