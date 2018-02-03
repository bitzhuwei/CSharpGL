using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    //[TypeConverter(typeof(PaddingConverter))]
    /// <summary>
    /// 表示与用户界面 (UI) 元素关联的空白或边距信息。
    /// </summary>
    [Serializable]
    public struct GUIPadding
    {
        private bool _all;

        private int _top;

        private int _left;

        private int _right;

        private int _bottom;

        /// <summary>
        /// 提供没有空白的 System.Windows.Forms.Padding 对象。
        /// </summary>
        public static readonly GUIPadding Empty = new GUIPadding(0);

        /// <summary>
        /// 获取或设置所有边缘的空白值。
        /// 如果所有边缘的空白相同，则为其空白值（以像素为单位）；否则为 -1。
        /// </summary>
        [RefreshProperties(RefreshProperties.All)]
        public int All
        {
            get
            {
                if (!this._all)
                {
                    return -1;
                }
                return this._top;
            }
            set
            {
                if (!this._all || this._top != value)
                {
                    this._all = true;
                    this._bottom = value;
                    this._right = value;
                    this._left = value;
                    this._top = value;
                }
            }
        }

        /// <summary>
        /// 获取或设置下边缘的空白值。
        /// 下边缘的空白值（以像素为单位）。
        /// </summary>
        [RefreshProperties(RefreshProperties.All)]
        public int Bottom
        {
            get
            {
                if (this._all)
                {
                    return this._top;
                }
                return this._bottom;
            }
            set
            {
                if (this._all || this._bottom != value)
                {
                    this._all = false;
                    this._bottom = value;
                }
            }
        }

        /// <summary>
        /// 获取或设置左边缘的空白值。
        /// 左边缘的空白值（以像素为单位）。
        /// </summary>
        [RefreshProperties(RefreshProperties.All)]
        public int Left
        {
            get
            {
                if (this._all)
                {
                    return this._top;
                }
                return this._left;
            }
            set
            {
                if (this._all || this._left != value)
                {
                    this._all = false;
                    this._left = value;
                }
            }
        }

        /// <summary>
        /// 获取或设置右边缘的空白值。
        /// 右边缘的空白值（以像素为单位）。
        /// </summary>
        [RefreshProperties(RefreshProperties.All)]
        public int Right
        {
            get
            {
                if (this._all)
                {
                    return this._top;
                }
                return this._right;
            }
            set
            {
                if (this._all || this._right != value)
                {
                    this._all = false;
                    this._right = value;
                }
            }
        }

        /// <summary>
        /// 获取或设置上边缘的空白值。
        /// 上边缘的空白值（以像素为单位）。
        /// </summary>
        [RefreshProperties(RefreshProperties.All)]
        public int Top
        {
            get
            {
                return this._top;
            }
            set
            {
                if (this._all || this._top != value)
                {
                    this._all = false;
                    this._top = value;
                }
            }
        }

        /// <summary>
        /// 获取左边缘和右边缘的组合空白。
        /// 获取 System.Windows.Forms.Padding.Left 和 System.Windows.Forms.Padding.Right空白值的总和（以像素为单位）。
        /// </summary>
        [Browsable(false)]
        public int Horizontal
        {
            get
            {
                return this.Left + this.Right;
            }
        }

        /// <summary>
        /// 获取上边缘和下边缘的组合空白。
        /// 获取 System.Windows.Forms.Padding.Top 和 System.Windows.Forms.Padding.Bottom空白值的总和（以像素为单位）。
        /// </summary>
        [Browsable(false)]
        public int Vertical
        {
            get
            {
                return this.Top + this.Bottom;
            }
        }

        /// <summary>
        /// 获取 System.Drawing.Size 形式的空白信息。
        /// 包含空白信息的 System.Drawing.Size。
        /// </summary>
        [Browsable(false)]
        public GUISize Size
        {
            get
            {
                return new GUISize(this.Horizontal, this.Vertical);
            }
        }

        /// <summary>
        /// 初始化 System.Windows.Forms.Padding 类的新实例，对所有边缘使用提供的空白大小。
        /// </summary>
        /// <param name="all">要用于所有边缘的空白的像素数目。</param>
        public GUIPadding(int all)
        {
            this._all = true;
            this._bottom = all;
            this._right = all;
            this._left = all;
            this._top = all;
        }

        /// <summary>
        /// 初始化 System.Windows.Forms.Padding 类的新实例，对每个边缘使用各自的空白大小。
        /// </summary>
        /// <param name="left">左边缘的空白大小（以像素为单位）。</param>
        /// <param name="top">上边缘的空白大小（以像素为单位）。</param>
        /// <param name="right">右边缘的空白大小（以像素为单位）。</param>
        /// <param name="bottom">下边缘的空白大小（以像素为单位）。</param>
        public GUIPadding(int left, int top, int right, int bottom)
        {
            this._top = top;
            this._left = left;
            this._right = right;
            this._bottom = bottom;
            this._all = (this._top == this._left && this._top == this._right && this._top == this._bottom);
        }

        /// <summary>
        /// 计算两个指定的 System.Windows.Forms.Padding 值的总和。
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static GUIPadding Add(GUIPadding p1, GUIPadding p2)
        {
            return p1 + p2;
        }

        /// <summary>
        /// 从一个 System.Windows.Forms.Padding 值中减去指定的另一个 System.Windows.Forms.Padding值。
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static GUIPadding Subtract(GUIPadding p1, GUIPadding p2)
        {
            return p1 - p2;
        }

        /// <summary>
        /// 确定指定对象的值是否等效于当前的 System.Windows.Forms.Padding。
        /// </summary>
        /// <param name="other">与当前的 System.Windows.Forms.Padding 比较的对象。</param>
        /// <returns></returns>
        public override bool Equals(object other)
        {
            return other is GUIPadding && (GUIPadding)other == this;
        }

        /// <summary>
        /// 对两个指定的 System.Windows.Forms.Padding 对象执行向量加法，得到新的 System.Windows.Forms.Padding。
        /// </summary>
        /// <param name="p1">要相加的第一个 System.Windows.Forms.Padding。</param>
        /// <param name="p2">要相加的第二个 System.Windows.Forms.Padding。</param>
        /// <returns>将 p1 和 p2 相加得到的新 System.Windows.Forms.Padding。</returns>
        public static GUIPadding operator +(GUIPadding p1, GUIPadding p2)
        {
            return new GUIPadding(p1.Left + p2.Left, p1.Top + p2.Top, p1.Right + p2.Right, p1.Bottom + p2.Bottom);
        }

        /// <summary>
        /// 对两个指定的 System.Windows.Forms.Padding 对象执行向量减法，得到新的 System.Windows.Forms.Padding。
        /// </summary>
        /// <param name="p1">要从中减去的 System.Windows.Forms.Padding（被减数）。</param>
        /// <param name="p2">要减去的 System.Windows.Forms.Padding（减数）。</param>
        /// <returns>p1 减 p2 所得的 System.Windows.Forms.Padding 结果。</returns>
        public static GUIPadding operator -(GUIPadding p1, GUIPadding p2)
        {
            return new GUIPadding(p1.Left - p2.Left, p1.Top - p2.Top, p1.Right - p2.Right, p1.Bottom - p2.Bottom);
        }

        /// <summary>
        /// 测试两个指定的 System.Windows.Forms.Padding 对象是否等效。
        /// </summary>
        /// <param name="p1">要测试的 System.Windows.Forms.Padding。</param>
        /// <param name="p2">要测试的 System.Windows.Forms.Padding。</param>
        /// <returns>如果两个 System.Windows.Forms.Padding 对象相等，则为 true；否则为 false。</returns>
        public static bool operator ==(GUIPadding p1, GUIPadding p2)
        {
            return p1.Left == p2.Left && p1.Top == p2.Top && p1.Right == p2.Right && p1.Bottom == p2.Bottom;
        }

        /// <summary>
        /// 测试两个指定的 System.Windows.Forms.Padding 对象是否不等效。
        /// </summary>
        /// <param name="p1">要测试的 System.Windows.Forms.Padding。</param>
        /// <param name="p2">要测试的 System.Windows.Forms.Padding。</param>
        /// <returns>如果两个 System.Windows.Forms.Padding 对象不同，则为 true；否则为 false。</returns>
        public static bool operator !=(GUIPadding p1, GUIPadding p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// 生成当前 System.Windows.Forms.Padding 的哈希代码。
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.Left ^ RotateLeft(this.Top, 8) ^ RotateLeft(this.Right, 16) ^ RotateLeft(this.Bottom, 24);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="nBits"></param>
        /// <returns></returns>
        private static int RotateLeft(int value, int nBits)
        {
            nBits %= 32;
            return value << nBits | value >> 32 - nBits;
        }

        /// <summary>
        /// 返回表示当前 System.Windows.Forms.Padding 的字符串。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Concat(new string[]
			{
				"{Left=",
				this.Left.ToString(CultureInfo.CurrentCulture),
				",Top=",
				this.Top.ToString(CultureInfo.CurrentCulture),
				",Right=",
				this.Right.ToString(CultureInfo.CurrentCulture),
				",Bottom=",
				this.Bottom.ToString(CultureInfo.CurrentCulture),
				"}"
			});
        }

        private void ResetAll()
        {
            this.All = 0;
        }

        private void ResetBottom()
        {
            this.Bottom = 0;
        }

        private void ResetLeft()
        {
            this.Left = 0;
        }

        private void ResetRight()
        {
            this.Right = 0;
        }

        private void ResetTop()
        {
            this.Top = 0;
        }

        internal void Scale(float dx, float dy)
        {
            this._top = (int)((float)this._top * dy);
            this._left = (int)((float)this._left * dx);
            this._right = (int)((float)this._right * dx);
            this._bottom = (int)((float)this._bottom * dy);
        }

        //internal bool ShouldSerializeAll()
        //{
        //    return this._all;
        //}

        //[Conditional("DEBUG")]
        //private void Debug_SanityCheck()
        //{
        //    if (this._all)
        //    {
        //    }
        //}
    }
}
