using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CSharpGL
{

    //[TypeConverter(typeof(GUISizeFConverter)), ComVisible(true)]
    /// <summary>
    /// 存储有序浮点数对，通常为矩形的宽度和高度。
    /// </summary>
    [Serializable]
    public struct GUISizeF
    {
        /// <summary>
        /// 初始化 CSharpGL.GUISizeF 类的新实例。
        /// </summary>
        public static readonly GUISizeF Empty = default(GUISizeF);

        private float width;

        private float height;

        /// <summary>
        /// 获取一个值，该值指示此 CSharpGL.GUISizeF 的宽度和高度是否为零。
        /// 如果此 CSharpGL.GUISizeF 的宽度和高度都为零，则此属性返回 true；否则返回 false。
        /// </summary>
        [Browsable(false)]
        public bool IsEmpty
        {
            get
            {
                return this.width == 0f && this.height == 0f;
            }
        }

        /// <summary>
        /// 获取或设置此 CSharpGL.GUISizeF 的水平分量。
        /// 此 CSharpGL.GUISizeF 的水平分量，通常以像素为单位进行度量。
        /// </summary>
        public float Width
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
        /// 获取或设置此 CSharpGL.GUISizeF 的垂直分量。
        /// 此 CSharpGL.GUISizeF 的垂直分量，通常以像素为单位进行度量。
        /// </summary>
        public float Height
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
        /// 从指定的现有 CSharpGL.GUISizeF 初始化 CSharpGL.GUISizeF 类的新实例。
        /// </summary>
        /// <param name="size">从中创建新 CSharpGL.GUISizeF 的 CSharpGL.GUISizeF。</param>
        public GUISizeF(GUISizeF size)
        {
            this.width = size.width;
            this.height = size.height;
        }

        /// <summary>
        /// 从指定的 CSharpGL.GUIPointF 初始化 CSharpGL.GUISizeF 类的新实例。
        /// </summary>
        /// <param name="pt">从中初始化此 CSharpGL.GUISizeF 的 CSharpGL.GUIPointF。</param>
        public GUISizeF(GUIPointF pt)
        {
            this.width = pt.X;
            this.height = pt.Y;
        }

        /// <summary>
        /// 用指定尺寸初始化 CSharpGL.GUISizeF 类的新实例。
        /// </summary>
        /// <param name="width">新 CSharpGL.GUISizeF 的宽度分量。</param>
        /// <param name="height">新 CSharpGL.GUISizeF 的高度分量。</param>
        public GUISizeF(float width, float height)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// 将一个 CSharpGL.GUISizeF 结构的宽度和高度与另一个 CSharpGL.GUISizeF 结构的宽度和高度相加。
        /// </summary>
        /// <param name="sz1">要相加的第一个 CSharpGL.GUISizeF。</param>
        /// <param name="sz2">要相加的第二个 CSharpGL.GUISizeF。</param>
        /// <returns>一个 CSharpGL.GUISize 结构，它是该加法运算的结果。</returns>
        public static GUISizeF operator +(GUISizeF sz1, GUISizeF sz2)
        {
            return GUISizeF.Add(sz1, sz2);
        }

        /// <summary>
        /// 将一个 CSharpGL.GUISizeF 结构的宽度和高度从另一个 CSharpGL.GUISizeF 结构的宽度和高度中减去。
        /// </summary>
        /// <param name="sz1">减法运算符左侧的 CSharpGL.GUISizeF。</param>
        /// <param name="sz2">减法运算符右侧的 CSharpGL.GUISizeF。</param>
        /// <returns>CSharpGL.GUISizeF，它是减法运算的结果。</returns>
        public static GUISizeF operator -(GUISizeF sz1, GUISizeF sz2)
        {
            return GUISizeF.Subtract(sz1, sz2);
        }

        /// <summary>
        /// 测试两个 CSharpGL.GUISizeF 结构是否相等。
        /// </summary>
        /// <param name="sz1">相等运算符左侧的 CSharpGL.GUISizeF 结构。</param>
        /// <param name="sz2">相等运算符右侧的 CSharpGL.GUISizeF 结构。</param>
        /// <returns>如果 sz1 和 sz2 的宽度和高度均相等，则此运算符返回 true；否则返回 false。</returns>
        public static bool operator ==(GUISizeF sz1, GUISizeF sz2)
        {
            return sz1.Width == sz2.Width && sz1.Height == sz2.Height;
        }

        /// <summary>
        /// 测试两个 CSharpGL.GUISizeF 结构是否不同。
        /// </summary>
        /// <param name="sz1">不等运算符左侧的 CSharpGL.GUISizeF 结构。</param>
        /// <param name="sz2">不等运算符右侧的 CSharpGL.GUISizeF 结构。</param>
        /// <returns>如果 sz1 和 sz2 的宽度或高度不同，则此运算符返回 true；如果 sz1 和 sz2 相等，则返回 false。</returns>
        public static bool operator !=(GUISizeF sz1, GUISizeF sz2)
        {
            return !(sz1 == sz2);
        }

        /// <summary>
        /// 将指定的 CSharpGL.GUISizeF 转换为 CSharpGL.GUIPointF。
        /// </summary>
        /// <param name="size">要转换的 CSharpGL.GUISizeF 结构。</param>
        /// <returns>此运算符转换得到的 CSharpGL.GUIPointF 结构。</returns>
        public static explicit operator GUIPointF(GUISizeF size)
        {
            return new GUIPointF(size.Width, size.Height);
        }

        /// <summary>
        /// 将一个 CSharpGL.GUISizeF 结构的宽度和高度与另一个 CSharpGL.GUISizeF 结构的宽度和高度相加。
        /// </summary>
        /// <param name="sz1">要相加的第一个 CSharpGL.GUISizeF。</param>
        /// <param name="sz2">要相加的第二个 CSharpGL.GUISizeF。</param>
        /// <returns>一个 CSharpGL.GUISizeF 结构，它是该加法运算的结果。</returns>
        public static GUISizeF Add(GUISizeF sz1, GUISizeF sz2)
        {
            return new GUISizeF(sz1.Width + sz2.Width, sz1.Height + sz2.Height);
        }

        /// <summary>
        /// 将一个 CSharpGL.GUISizeF 结构的宽度和高度从另一个 CSharpGL.GUISizeF 结构的宽度和高度中减去。
        /// </summary>
        /// <param name="sz1">减法运算符左侧的 CSharpGL.GUISizeF 结构。</param>
        /// <param name="sz2">减法运算符右侧的 CSharpGL.GUISizeF 结构。</param>
        /// <returns>CSharpGL.GUISizeF，它是减法运算的结果。</returns>
        public static GUISizeF Subtract(GUISizeF sz1, GUISizeF sz2)
        {
            return new GUISizeF(sz1.Width - sz2.Width, sz1.Height - sz2.Height);
        }

        /// <summary>
        /// 测试指定的对象是否是一个与此 CSharpGL.GUISizeF 具有相同尺寸的 CSharpGL.GUISizeF。
        /// </summary>
        /// <param name="obj">要测试的 System.Object。</param>
        /// <returns>如果 obj 是一个 CSharpGL.GUISizeF 并且与此 CSharpGL.GUISizeF 具有相同的宽度和高度，则此方法返回 true；否则返回 false。</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is GUISizeF))
            {
                return false;
            }
            GUISizeF sizeF = (GUISizeF)obj;
            return sizeF.Width == this.Width && sizeF.Height == this.Height && sizeF.GetType().Equals(base.GetType());
        }

        /// <summary>
        /// 返回此 CSharpGL.GUISize 结构的哈希代码。
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// 将 CSharpGL.GUISizeF 转换为 CSharpGL.GUIPointF。
        /// </summary>
        /// <returns>返回一个 CSharpGL.GUIPointF 结构。</returns>
        public GUIPointF ToPointF()
        {
            return (GUIPointF)this;
        }

        /// <summary>
        /// 将 CSharpGL.GUISizeF 转换为 CSharpGL.GUISize。
        /// </summary>
        /// <returns>返回一个 CSharpGL.GUISize 结构。</returns>
        public GUISize ToSize()
        {
            return GUISize.Truncate(this);
        }

        /// <summary>
        /// 创建一个表示此 CSharpGL.GUISizeF 的可读字符串。
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
