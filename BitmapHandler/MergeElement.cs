using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

/***************************************************
 * Creator: Morris @ PC-HAMILTON
 * Create Date: 2015/6/29 星期一 23:37:33
 * ID: cc1fbcd5-ede4-4142-ae0b-dba10d5e8c75
 ***************************************************/
namespace Morris.YankeePark.BitmapHandler
{
    /// <summary>
    /// 聚合元素类。包含图片，左上点，宽高等信息。
    /// </summary>
    public class MergeElement
    {
        /// <summary>
        /// 聚合元素图像实例，禁止直接引用
        /// </summary>
        private Bitmap _bitmap;
        /// <summary>
        /// 聚会元素图像
        /// </summary>
        public Bitmap bitmap
        {
            get
            {
                return this._bitmap;
            }
            protected set
            {
                this._bitmap = value;
            }
        }

        /// <summary>
        /// 聚合元素左偏移值
        /// </summary>
        public int x;
        /// <summary>
        /// 聚合元素下偏移值
        /// </summary>
        public int y;

        /// <summary>
        /// 聚合元素目标宽度
        /// </summary>
        public int width;

        /// <summary>
        /// 聚合元素目标高度
        /// </summary>
        public int height;
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="bitmap">元素图像</param>
        public MergeElement(Bitmap bitmap)
        {
            if (bitmap != null)
            {
                this.bitmap = bitmap;
                this.x = 0;
                this.y = 0;
                this.width = this.bitmap.Width;
                this.height = this.bitmap.Height;
            }
            else
            {
                throw new NullReferenceException("bitmap cannot be null");
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="bitmap">元素图像</param>
        /// <param name="x">左偏移</param>
        /// <param name="y">右偏移</param>
        public MergeElement(Bitmap bitmap,int x,int y)
        {
            if (bitmap != null)
            {
                this.bitmap = bitmap;
                this.x = x;
                this.y = y;
                this.width = this.bitmap.Width;
                this.height = this.bitmap.Height;
            }
            else
            {
                throw new NullReferenceException("bitmap cannot be null");
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="bitmap">元素图像</param>
        /// <param name="x">左偏移</param>
        /// <param name="y">右偏移</param>
        /// <param name="width">目标宽度</param>
        /// <param name="height">目标高度</param>
        public MergeElement(Bitmap bitmap, int x, int y,int width,int height)
        {
            if (bitmap != null)
            {
                this.bitmap = bitmap;
                this.x = x;
                this.y = y;
                this.width = width;
                this.height = height;
            }
            else
            {
                throw new NullReferenceException("bitmap cannot be null");
            }
        }

        /// <summary>
        /// 拷贝构造函数
        /// </summary>
        /// <param name="instance">拷贝实例</param>
        public MergeElement(MergeElement instance)
        {
            this.bitmap = instance.bitmap.Clone() as Bitmap;
            if (bitmap != null)
            {
                this.bitmap = bitmap;
            }
            else
            {
                throw new NullReferenceException("bitmap cannot be null");
            }
            this.x = instance.x;
            this.y = instance.y;
            this.width = this.bitmap.Width;
            this.height = this.bitmap.Height;
        }
    }
}
