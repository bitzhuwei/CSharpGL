﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CSharpGL {
    /// <summary>
    /// 一个要处理的单元（一个字符串）。
    /// </summary>
    abstract class ChunkBase {
        ///// <summary>
        ///// 
        ///// </summary>
        //public object Tag { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public readonly string text;

        /// <summary>
        /// 
        /// </summary>
        public readonly System.Drawing.Font theFont;

        /// <summary>
        /// 
        /// </summary>
        public SizeF size;

        /// <summary>
        /// 
        /// </summary>
        public PointF leftTop;

        /// <summary>
        /// 如果页索引超出范围，就表示页不够用了。
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 一个要处理的单元（一个字符串）。
        /// </summary>
        /// <param name="text"></param>
        /// <param name="font"></param>
        public ChunkBase(string text, Font font) {
            this.text = text;
            this.theFont = font;
        }

        /// <summary>
        /// 把这个单元安排到合适的地方去。
        /// </summary>
        /// <param name="context"></param>
        public abstract void Put(PagesContext context);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format("{0}", this.text);
        }
    }
}
