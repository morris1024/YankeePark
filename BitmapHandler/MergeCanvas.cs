using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

/***************************************************
 * Creator: Morris @ PC-HAMILTON
 * Create Date: 2015/6/29 星期一 23:26:35
 * ID: 30a1ad6d-778d-45eb-aa8d-0d128a8dc96c
 ***************************************************/
namespace Morris.YankeePark.BitmapHandler
{
    /// <summary>
    /// 聚合框架类
    /// </summary>
    public class MergeCanvas
    {
        /// <summary>
        /// 聚合框架底图实例
        /// </summary>
        private Bitmap _baseBitmap;

        /// <summary>
        /// 聚合框架底图备份实例
        /// </summary>
        private Bitmap _orginBaseBitmap;
        
        /// <summary>
        /// 聚合框架底图
        /// </summary>
        public Bitmap baseBitmap
        {
            get
            {
                return this._baseBitmap;
            }
        }
        /// <summary>
        /// 聚合框架底图Graphics
        /// </summary>
        public Graphics baseBitmapGraphics
        {
            get
            {
                return Graphics.FromImage(this.baseBitmap);
            }
        }

        /// <summary>
        /// 聚合元素列表
        /// </summary>
        public List<MergeElement> mergeElementList;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="baseBitmap"></param>
        public MergeCanvas(Bitmap baseBitmap)
        {
            if (baseBitmap != null)
            {
                this._baseBitmap = baseBitmap;
                this._orginBaseBitmap = baseBitmap.Clone() as Bitmap;
            }
            else
            {
                throw new NullReferenceException("canvas cannot be null");
            }
        }

        /// <summary>
        /// 构造函数，底图为透明
        /// </summary>
        /// <param name="width">框架宽</param>
        /// <param name="height">框架高</param>
        public MergeCanvas(int width, int height)
        {
            this._baseBitmap = new Bitmap(width, height);
            this.baseBitmap.MakeTransparent();
            this._orginBaseBitmap = baseBitmap.Clone() as Bitmap;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="width">框架宽</param>
        /// <param name="height">框架高</param>
        /// <param name="color">底图颜色</param>
        public MergeCanvas(int width, int height, Color color)
        {
            this._baseBitmap = new Bitmap(width, height);
            Graphics grpTmp = Graphics.FromImage(baseBitmap);
            SolidBrush brTmp = new SolidBrush(color);
            grpTmp.FillRectangle(brTmp, 0, 0, this.baseBitmap.Width, this.baseBitmap.Height);
            this._orginBaseBitmap = baseBitmap.Clone() as Bitmap;
        }

        /// <summary>
        /// 重置框架底图
        /// </summary>
        private void resetCanvas()
        {
            baseBitmapGraphics.DrawImage(this._orginBaseBitmap, 0, 0);
        }

        /// <summary>
        /// 生成聚合图像
        /// </summary>
        public void merge()
        {
            resetCanvas();
            if (this.mergeElementList != null)
            {
                List<MergeElement>.Enumerator eTmp = this.mergeElementList.GetEnumerator();
                while (eTmp.Current != null)
                {
                    MergeElement meTmp = eTmp.Current;
                    baseBitmapGraphics.DrawImage(meTmp.bitmap,
                        new Rectangle(meTmp.x, meTmp.y, meTmp.width, meTmp.height));
                    eTmp.MoveNext();
                }
            }
        }

        /// <summary>
        /// 生成聚合图像
        /// </summary>
        /// <param name="mergeElementList">聚合元素列表</param>
        public void merge(List<MergeElement> mergeElementList)
        {
            this.mergeElementList = mergeElementList;
            merge();
        }

        /// <summary>
        /// 保存聚合图像，默认格式为png
        /// </summary>
        /// <param name="fileName">文件名</param>
        public void saveMergedPicture(string fileName)
        {
            this.baseBitmap.Save(fileName, ImageFormat.Png);
        }
        /// <summary>
        /// 保存聚合图像
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="format">格式</param>
        public void saveMergedPicture(string fileName, ImageFormat format)
        {
            this.baseBitmap.Save(fileName, format);
        }
    }
}
