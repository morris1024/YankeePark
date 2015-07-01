using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

/***************************************************
 * Creator: Morris @ PC-HAMILTON
 * Create Date: 2015/6/29 星期一 23:26:35
 * ID: 30a1ad6d-778d-45eb-aa8d-0d128a8dc96c
 ***************************************************/
namespace Morris.YankeePark.BitmapHandler
{
    public class MergeCanvas
    {
        private Bitmap _bmpCanvas;
        private Bitmap _bmpOrginCanvas;
        
        public Bitmap bmpCanvas
        {
            get
            {
                return this._bmpCanvas;
            }
        }
        public Graphics grpCanvas
        {
            get
            {
                return Graphics.FromImage(this.bmpCanvas);
            }
        }

        private List<MergeElement> _lstMergeElements;

        public List<MergeElement> lstMergeElements
        {
            get
            {
                return this._lstMergeElements;
            }
            set
            {
                this._lstMergeElements = value;
                resetCanvas();
                if (this._lstMergeElements != null)
                {
                    List<MergeElement>.Enumerator eTmp = this._lstMergeElements.GetEnumerator();
                    while (eTmp.Current != null)
                    {
                        MergeElement meTmp = eTmp.Current;
                        grpCanvas.DrawImage(meTmp.bitmap, 
                            new Rectangle(meTmp.x, meTmp.y, meTmp.width, meTmp.height));
                        eTmp.MoveNext();
                    }
                }
            }
        }

        public MergeCanvas(Bitmap bmpCanvas)
        {
            if (bmpCanvas != null)
            {
                this._bmpCanvas = bmpCanvas;
                this._bmpOrginCanvas = bmpCanvas.Clone() as Bitmap;
            }
            else
            {
                throw new NullReferenceException("canvas cannot be null");
            }
        }

        public MergeCanvas(int width, int height)
        {
            this._bmpCanvas = new Bitmap(width, height);
            this.bmpCanvas.MakeTransparent();
            this._bmpOrginCanvas = bmpCanvas.Clone() as Bitmap;
        }

        public MergeCanvas(int width, int height, Color color)
        {
            this._bmpCanvas = new Bitmap(width, height);
            Graphics grpTmp = Graphics.FromImage(bmpCanvas);
            SolidBrush brTmp = new SolidBrush(color);
            grpTmp.FillRectangle(brTmp, 0, 0, this.bmpCanvas.Width, this.bmpCanvas.Height);
            this._bmpOrginCanvas = bmpCanvas.Clone() as Bitmap;
        }

        private void resetCanvas()
        {
            grpCanvas.DrawImage(this._bmpOrginCanvas, 0, 0);
        }
    }
}
