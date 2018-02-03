using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    //[TypeConverter(typeof(GUISizeConverter)), ComVisible(true)]
    /// <summary>
    /// 存储一个有序整数对，通常为矩形的宽度和高度。
    /// </summary>
    [Serializable]
    public struct GUISize
    {
        /// <summary>
        /// 初始化 CSharpGL.GUISize 类的新实例。
        /// </summary>
        public static readonly GUISize Empty = default(GUISize);

        private int width;

        private int height;

        /// <summary>
        /// 测试此 CSharpGL.GUISize 的宽度和高度是否为 0。
        /// 如果此 CSharpGL.GUISize 的宽度和高度均为 0，此属性将返回 true；否则将返回 false。
        /// </summary>
        [Browsable(false)]
        public bool IsEmpty
        {
            get
            {
                return this.width == 0 && this.height == 0;
            }
        }

        /// <summary>
        /// 获取或设置此 CSharpGL.GUISize 的水平分量。
        /// 此 CSharpGL.GUISize 的水平组件，通常以像素为单位进行度量。
        /// </summary>
        public int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }

        /// <summary>
        /// 获取或设置此 CSharpGL.GUISize 的垂直分量。
        /// 此 CSharpGL.GUISize 的垂直组件，通常以像素为单位进行度量。
        /// </summary>
        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }

        /// <summary>
        /// 从指定的 CSharpGL.GUIPoint 初始化 CSharpGL.GUISize 类的新实例。
        /// </summary>
        /// <param name="pt">从中初始化此 CSharpGL.GUISize 的 CSharpGL.GUIPoint。</param>
        public GUISize(GUIPoint pt)
        {
            this.width = pt.X;
            this.height = pt.Y;
        }

        /// <summary>
        /// 用指定尺寸初始化 CSharpGL.GUISize 类的新实例。
        /// </summary>
        /// <param name="width">新 CSharpGL.GUISize 的宽度分量。</param>
        /// <param name="height">新 CSharpGL.GUISize 的高度分量。</param>
        public GUISize(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// 将指定的 CSharpGL.GUISize 转换为 CSharpGL.GUISizeF。
        /// </summary>
        /// <param name="p">要转换的 CSharpGL.GUISize。</param>
        /// <returns>此运算符将转换到的 CSharpGL.GUISizeF 结构。</returns>
        public static implicit operator GUISizeF(GUISize p)
        {
            return new GUISizeF((float)p.Width, (float)p.Height);
        }

        /// <summary>
        /// 将一个 CSharpGL.GUISize 结构的宽度和高度与另一个 CSharpGL.GUISize 结构的宽度和高度相加。
        /// </summary>
        /// <param name="sz1">要相加的第一个 CSharpGL.GUISize。</param>
        /// <param name="sz2">要相加的第二个 CSharpGL.GUISize。</param>
        /// <returns>一个 CSharpGL.GUISize 结构，它是该加法运算的结果。</returns>
        public static GUISize operator +(GUISize sz1, GUISize sz2)
        {
            return GUISize.Add(sz1, sz2);
        }

        /// <summary>
        /// 将一个 CSharpGL.GUISize 结构的宽度和高度从另一个 CSharpGL.GUISize 结构的宽度和高度中减去。
        /// </summary>
        /// <param name="sz1">减法运算符左侧的 CSharpGL.GUISize 结构。</param>
        /// <param name="sz2">减法运算符右侧的 CSharpGL.GUISize 结构。</param>
        /// <returns>一个 CSharpGL.GUISize 结构，它是该减法运算的结果。</returns>
        public static GUISize operator -(GUISize sz1, GUISize sz2)
        {
            return GUISize.Subtract(sz1, sz2);
        }

        /// <summary>
        /// 测试两个 CSharpGL.GUISize 结构是否相等。
        /// </summary>
        /// <param name="sz1">相等运算符左侧的 CSharpGL.GUISize 结构。</param>
        /// <param name="sz2">相等运算符右侧的 CSharpGL.GUISize 结构。</param>
        /// <returns>如果 sz1 和 sz2 的宽度和高度均相等，为 true；否则为 false。</returns>
        public static bool operator ==(GUISize sz1, GUISize sz2)
        {
            return sz1.Width == sz2.Width && sz1.Height == sz2.Height;
        }

        /// <summary>
        /// 测试两个 CSharpGL.GUISize 结构是否不同。
        /// </summary>
        /// <param name="sz1">不等运算符左侧的 CSharpGL.GUISize 结构。</param>
        /// <param name="sz2">不等运算符右侧的 CSharpGL.GUISize 结构。</param>
        /// <returns>如果 sz1 和 sz2 的宽度或高度不同，为 true；如果 sz1 和 sz2 相等，则为 false。</returns>
        public static bool operator !=(GUISize sz1, GUISize sz2)
        {
            return !(sz1 == sz2);
        }

        /// <summary>
        /// 将指定的 CSharpGL.GUISize 转换为 CSharpGL.GUIPoint。
        /// </summary>
        /// <param name="size">要转换的 CSharpGL.GUISize。</param>
        /// <returns>此运算符将转换到的 CSharpGL.GUIPoint 结构。</returns>
        public static explicit operator GUIPoint(GUISize size)
        {
            return new GUIPoint(size.Width, size.Height);
        }

        /// <summary>
        /// 将一个 CSharpGL.GUISize 结构的宽度和高度与另一个 CSharpGL.GUISize 结构的宽度和高度相加。
        /// </summary>
        /// <param name="sz1">要相加的第一个 CSharpGL.GUISize。</param>
        /// <param name="sz2">要相加的第二个 CSharpGL.GUISize。</param>
        /// <returns>一个 CSharpGL.GUISize 结构，它是该加法运算的结果。</returns>
        public static GUISize Add(GUISize sz1, GUISize sz2)
        {
            return new GUISize(sz1.Width + sz2.Width, sz1.Height + sz2.Height);
        }

        /// <summary>
        /// 通过将 CSharpGL.GUISize 结构的值舍入到与其相邻的较大整数值，将指定的 CSharpGL.GUISizeF 结构转换为 CSharpGL.GUISize 结构。
        /// </summary>
        /// <param name="value">要转换的 CSharpGL.GUISizeF 结构。</param>
        /// <returns>此方法转换得到的 CSharpGL.GUISize 结构。</returns>
        public static GUISize Ceiling(GUISizeF value)
        {
            return new GUISize((int)Math.Ceiling((double)value.Width), (int)Math.Ceiling((double)value.Height));
        }

        /// <summary>
        /// 将一个 CSharpGL.GUISize 结构的宽度和高度从另一个 CSharpGL.GUISize 结构的宽度和高度中减去。
        /// </summary>
        /// <param name="sz1">减法运算符左侧的 CSharpGL.GUISize 结构。</param>
        /// <param name="sz2">减法运算符右侧的 CSharpGL.GUISize 结构。</param>
        /// <returns>CSharpGL.GUISize，它是减法运算的结果。</returns>
        public static GUISize Subtract(GUISize sz1, GUISize sz2)
        {
            return new GUISize(sz1.Width - sz2.Width, sz1.Height - sz2.Height);
        }

        /// <summary>
        /// 通过将 CSharpGL.GUISize 结构的值截断到比其小的相邻整数值，将指定的 CSharpGL.GUISizeF 结构转换为 CSharpGL.GUISize 结构。
        /// </summary>
        /// <param name="value">要转换的 CSharpGL.GUISizeF 结构。</param>
        /// <returns>此方法转换得到的 CSharpGL.GUISize 结构。</returns>
        public static GUISize Truncate(GUISizeF value)
        {
            return new GUISize((int)value.Width, (int)value.Height);
        }

        /// <summary>
        /// 通过将 CSharpGL.GUISize 结构的值舍入到最近的整数值，将指定的 CSharpGL.GUISizeF 结构转换为 CSharpGL.GUISize 结构。
        /// </summary>
        /// <param name="value">要转换的 CSharpGL.GUISizeF 结构。</param>
        /// <returns>此方法转换得到的 CSharpGL.GUISize 结构。</returns>
        public static GUISize Round(GUISizeF value)
        {
            return new GUISize((int)Math.Round((double)value.Width), (int)Math.Round((double)value.Height));
        }

        /// <summary>
        /// 测试指定的对象是否是一个与此 CSharpGL.GUISize 具有相同尺寸的 CSharpGL.GUISize。
        /// </summary>
        /// <param name="obj">要测试的 System.Object。</param>
        /// <returns>如果 obj 是一个 CSharpGL.GUISize 并与此 CSharpGL.GUISize 具有相同的宽度和高度，为 true；否则为 false。</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is GUISize))
            {
                return false;
            }
            GUISize size = (GUISize)obj;
            return size.width == this.width && size.height == this.height;
        }

        /// <summary>
        /// 返回此 CSharpGL.GUISize 结构的哈希代码。
        /// </summary>
        /// <returns>一个整数值，它指定此 CSharpGL.GUISize 结构的哈希值。</returns>
        public override int GetHashCode()
        {
            return this.width ^ this.height;
        }

        /// <summary>
        /// 创建一个表示此 CSharpGL.GUISize 的可读字符串。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Concat(new string[]
			{
				"{Width=",
				this.width.ToString(CultureInfo.CurrentCulture),
				", Height=",
				this.height.ToString(CultureInfo.CurrentCulture),
				"}"
			});
        }
    }
}