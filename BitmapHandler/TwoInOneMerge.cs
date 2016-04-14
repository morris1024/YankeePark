using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

/***************************************************
 * Creator: Morris @ PC-HAMILTON
 * Create Date: 2016/4/14-星期四 09:27:27
 * ID: da0384c9-21d3-43e7-8fe0-3bab0cc9cb72
 ***************************************************/
namespace Morris.YankeePark.BitmapHandler
{
    /// <summary>
    /// 双图片合并
    /// </summary>
    public class TwoInOneMerge
    {

        /* batchMerge CodeSample
            string inputPicture1Directory = @"E:\1\";
            string inputPicture2Directory = @"E:\2\";
            string outputPictureDirectory = @"E:\o\";
            string outputPictureNamePrefix = @"WP-Coss-160413-";

            int outputHeight = 1750;
            int outputWidth = 3360;

            int input1Height = 900;
            int input1Width = 1440;
            int input1Left = 0;
            int input1Top = 0;

            int input2Height = 1080;
            int input2Width = 1920;
            int input2Left = 1440;
            int input2Top = 670;
            TwoInOneMerge.merge(
                inputPicture1Directory, inputPicture2Directory,
                outputPictureDirectory, outputPictureNamePrefix, System.Drawing.Imaging.ImageFormat.Png,
                outputWidth, outputHeight,
                input1Width, input1Height, input1Left, input1Top,
                input2Width, input2Height, input2Left, input2Top
                );
         */


        public static Random rand = new Random();

        /// <summary>
        /// 批量合并
        /// </summary>
        /// <param name="inputPicture1Directory">一号位图片目录</param>
        /// <param name="inputPicture2Directory">二号位图片目录</param>
        /// <param name="outputPictureDirectory">输出目录</param>
        /// <param name="outputPictureNamePrefix">输出名前缀</param>
        /// <param name="outputFormat">输出格式</param>
        /// <param name="outputWidth">输出图片宽</param>
        /// <param name="outputHeight">输出图片高</param>
        /// <param name="input1Width">一号位图片宽</param>
        /// <param name="input1Height">一号位图片高</param>
        /// <param name="input1Left">一号位图片左偏移</param>
        /// <param name="input1Top">一号位图片上偏移</param>
        /// <param name="input2Width">二号位图片宽</param>
        /// <param name="input2Height">二号位图片高</param>
        /// <param name="input2Left">二号位图片左偏移</param>
        /// <param name="input2Top">二号位图片上偏移</param>
        public static void batchMerge(
            string inputPicture1Directory, string inputPicture2Directory,
            string outputPictureDirectory,string outputPictureNamePrefix,ImageFormat outputFormat,
            int outputWidth,int outputHeight,
            int input1Width,int input1Height,int input1Left,int input1Top,
            int input2Width,int input2Height,int input2Left,int input2Top
            )
        {
            if (Directory.Exists(inputPicture1Directory) && Directory.Exists(inputPicture2Directory) && Directory.Exists(outputPictureDirectory))
            {
                MergeCanvas mc = new MergeCanvas(outputWidth, outputHeight);
                var input1Enumer = Directory.EnumerateFiles(inputPicture1Directory);
                var input2Enumer = Directory.EnumerateFiles(inputPicture2Directory);
                int i = 0;
                string outputPiturePath = outputPictureDirectory + outputPictureNamePrefix +
                    rand.Next(1, 100000).ToString().PadLeft(5, '0') + "." + outputFormat.ToString();
                foreach (string input1PicturePath in input1Enumer)
                {
                    Bitmap bmpInput1;
                    try
                    {
                        bmpInput1 = new Bitmap(input1PicturePath);
                        i++;
                    }
                    catch
                    {
                        continue;
                    }
                    int j = 0;
                    MergeElement me1 = new MergeElement(bmpInput1, input1Left, input1Top, input1Width, input1Height);
                    foreach (string input2PicturePath in input2Enumer)
                    {
                        Bitmap bmpInput2;
                        try
                        {
                            bmpInput2 = new Bitmap(input2PicturePath);
                            j++;
                        }
                        catch
                        {
                            continue;
                        }
                        while(File.Exists(outputPiturePath))
                        {
                            outputPiturePath =
                                outputPictureDirectory + outputPictureNamePrefix +
                                rand.Next(1, 100000).ToString().PadLeft(5, '0') + "-" + i + j + "." + outputFormat.ToString();
                        }
                        MergeElement me2 = new MergeElement(bmpInput2, input2Left, input2Top, input2Width, input2Height);
                        mc.merge(new MergeElement[] {me1,me2});
                        mc.saveMergedPicture(
                           outputPiturePath,
                            outputFormat);
                        me2.bitmap.Dispose();
                    }
                    me1.bitmap.Dispose();
                }
            }
        }
    }
}
