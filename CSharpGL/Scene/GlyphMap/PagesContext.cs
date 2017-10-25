using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CSharpGL
{
    /// <summary>
    /// 布局状态。
    /// </summary>
    class PagesContext : IDisposable
    {
        private List<Page> pageList = new List<Page>();
        private Image unitImage = new Bitmap(1, 1);

        /// <summary>
        /// 画布列表。
        /// </summary>
        public List<Page> PageList
        {
            get { return pageList; }
        }

        /// <summary>
        /// 当前正在使用的<see cref="pageList"/>的索引。
        /// </summary>
        public int CurrentIndex { get; set; }

        /// <summary>
        /// 下一个字符要写到的位置（左上角）。
        /// </summary>
        public PointF CurrentLeftTop { get; set; }

        /// <summary>
        /// 当前行的最大高度。
        /// </summary>
        public float MaxLineHeight { get; set; }

        /// <summary>
        /// 布局状态。
        /// </summary>
        public PagesContext(float pageWidth, float pageHeight, int maxPageCount)
        {
            this.PageWidth = pageWidth;
            this.PageHeight = pageHeight;

            this.PageList.Add(new Page(PageWidth, PageHeight));

            this.MaxPageCount = maxPageCount;
            this.UnitGraphics = Graphics.FromImage(this.unitImage);
        }

        private bool disposedValue = false;

        /// <summary>
        ///
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///
        /// </summary>
        ~PagesContext()
        {
            this.Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (this.disposedValue == false)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                }

                // Dispose unmanaged resources.
                this.UnitGraphics.Dispose();
                this.UnitGraphics = null;
                this.unitImage.Dispose();
                this.unitImage = null;
            }

            this.disposedValue = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public Graphics UnitGraphics { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public float PageWidth { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public float PageHeight { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int MaxPageCount { get; private set; }
    }

    /// <summary>
    /// 一页。将在上面写字（排列布局）。
    /// </summary>
    public class Page
    {
        /// <summary>
        /// 
        /// </summary>
        public float Left { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public float Top { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public float Width { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public float Height { get; private set; }

        /// <summary>
        /// 一页。将在上面写字（排列布局）。
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Page(float width, float height)
        {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("left:{0}, top:{1}, width:{2}, height:{3}", this.Left, this.Top, this.Width, this.Height);
        }
    }
}
