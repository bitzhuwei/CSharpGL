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
    /// 一个要处理的单元（一个字符或一个字符串）。
    /// </summary>
    class StringChunk : ChunkBase
    {

        /// <summary>
        /// 一个要处理的单元（一个字符或一个字符串）。
        /// </summary>
        /// <param name="text"></param>
        /// <param name="font"></param>
        public StringChunk(string text, Font font)
            : base(text, font)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void Put(PagesContext context)
        {
            if (context == null) { throw new ArgumentNullException("context"); }
            Graphics graphics = context.UnitGraphics;
            if (graphics == null) { throw new Exception("Context already disposed!"); }
            if (context.CurrentIndex >= context.PageList.Count) { return; } // 超过了允许的最多的页数。

            Page page = context.PageList[context.CurrentIndex];
            PointF leftTop = context.CurrentLeftTop;
            SizeF bigSize = graphics.MeasureString("丨" + this.Text + "丨", this.TheFont);
            SizeF emptySize = graphics.MeasureString("丨丨", this.TheFont);
            var width = (bigSize.Width - emptySize.Width);
            var height = bigSize.Height;
            if (page.Width < leftTop.X + width) // 该换行了。
            {
                if (page.Height < leftTop.Y + context.MaxLineHeight + height) // 要换页了。
                {
                    context.CurrentIndex++;
                    if (context.PageList.Count <= context.CurrentIndex // 页用完了。
                        && context.PageList.Count < context.MaxPageCount) // 还可以申请新页。
                    {
                        var newPage = new Page(context.PageWidth, context.PageHeight);
                        context.PageList.Add(newPage);
                    }

                    // 用下一页。（无论能否申请新页，都按能申请处理。）
                    {
                        this.LeftTop = new PointF(0, 0);
                        this.Size = new SizeF(width, height);
                        this.PageIndex = context.CurrentIndex;

                        context.CurrentLeftTop = new PointF(width, 0);
                        context.MaxLineHeight = height;
                    }
                }
                else // 仅仅换行，不换页。
                {
                    leftTop = new PointF(0, leftTop.Y + context.MaxLineHeight);
                    this.LeftTop = leftTop;
                    this.Size = new SizeF(width, height);
                    this.PageIndex = context.CurrentIndex;

                    context.CurrentLeftTop = new PointF(leftTop.X + width, leftTop.Y);
                    context.MaxLineHeight = height;
                }
            }
            else // 当前行还可以放下此chunk。
            {
                this.LeftTop = leftTop;
                this.Size = new SizeF(width, height);
                this.PageIndex = context.CurrentIndex;

                context.CurrentLeftTop = new PointF(leftTop.X + width, leftTop.Y);
                if (leftTop.X == 0 // 第一个字符（串）
                    || context.MaxLineHeight < height)
                {
                    context.MaxLineHeight = height;
                }
            }
        }
    }
}
