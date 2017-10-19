using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    //[TypeConverter(typeof(GUIPointConverter)), ComVisible(true)]
    /// <summary>
    /// 表示在二维平面中定义点的、整数 X 和 Y 坐标的有序对。
    /// </summary>
    [Serializable]
    public struct GUIPoint
    {
        /// <summary>
        /// 表示一个 CSharpGL.GUIPoint，其 CSharpGL.GUIPoint.X 和 CSharpGL.GUIPoint.Y 值设为零。
        /// </summary>
        public static readonly GUIPoint Empty = default(GUIPoint);

        private int x;

        private int y;

        /// <summary>
        /// 获取一个值，该值指示此 CSharpGL.GUIPoint 是否为空。
        /// 如果 CSharpGL.GUIPoint.X 和 CSharpGL.GUIPoint.Y 均为 0，则为 true；否则为 false。
        /// </summary>
        [Browsable(false)]
        public bool IsEmpty
        {
            get
            {
                return this.x == 0 && this.y == 0;
            }
        }

        /// <summary>
        /// 获取或设置此 CSharpGL.GUIPoint 的 X 坐标。
        /// </summary>
        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }

        /// <summary>
        /// 获取或设置此 CSharpGL.GUIPoint 的 Y 坐标。
        /// </summary>
        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }

        /// <summary>
        /// 用指定坐标初始化 CSharpGL.GUIPoint 类的新实例。
        /// </summary>
        /// <param name="x">该点的水平位置。</param>
        /// <param name="y">该点的垂直位置。</param>
        public GUIPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// 从 CSharpGL.GUISize 初始化 CSharpGL.GUIPoint 类的新实例。
        /// </summary>
        /// <param name="sz">CSharpGL.GUISize，它指定新 CSharpGL.GUIPoint 的坐标。</param>
        public GUIPoint(GUISize sz)
        {
            this.x = sz.Width;
            this.y = sz.Height;
        }

        /// <summary>
        /// 使用由整数值指定的坐标初始化 CSharpGL.GUIPoint 类的新实例。
        /// </summary>
        /// <param name="dw">一个 32 位整数，它指定新 CSharpGL.GUIPoint 的坐标。</param>
        public GUIPoint(int dw)
        {
            this.x = (int)((short)GUIPoint.LOWORD(dw));
            this.y = (int)((short)GUIPoint.HIWORD(dw));
        }

        /// <summary>
        /// 将指定的 CSharpGL.GUIPoint 结构转换为 CSharpGL.GUIPointF 结构。
        /// </summary>
        /// <param name="p">要转换的 CSharpGL.GUIPoint。</param>
        /// <returns>此转换得到的 CSharpGL.GUIPointF。</returns>
        public static implicit operator GUIPointF(GUIPoint p)
        {
            return new GUIPointF((float)p.X, (float)p.Y);
        }

        /// <summary>
        /// 将指定的 CSharpGL.GUIPoint 结构转换为 CSharpGL.GUISize 结构。
        /// </summary>
        /// <param name="p">要转换的 CSharpGL.GUIPoint。</param>
        /// <returns>此转换得到的 CSharpGL.GUISize。</returns>
        public static explicit operator GUISize(GUIPoint p)
        {
            return new GUISize(p.X, p.Y);
        }

        /// <summary>
        /// 将 CSharpGL.GUIPoint 平移给定 CSharpGL.GUISize。
        /// </summary>
        /// <param name="pt">要平移的 CSharpGL.GUIPoint。</param>
        /// <param name="sz">CSharpGL.GUISize，它指定要添加到 pt 的坐标的数字对。</param>
        /// <returns>平移后的 CSharpGL.GUIPoint。</returns>
        public static GUIPoint operator +(GUIPoint pt, GUISize sz)
        {
            return GUIPoint.Add(pt, sz);
        }

        /// <summary>
        /// 将 CSharpGL.GUIPoint 平移给定 CSharpGL.GUISize 的负数。
        /// </summary>
        /// <param name="pt">要平移的 CSharpGL.GUIPoint。</param>
        /// <param name="sz">CSharpGL.GUISize，它指定要从 pt 的坐标减去的数字对。</param>
        /// <returns>CSharpGL.GUIPoint 结构，此结构按给定 CSharpGL.GUISize 结构的负数平移。</returns>
        public static GUIPoint operator -(GUIPoint pt, GUISize sz)
        {
            return GUIPoint.Subtract(pt, sz);
        }

        /// <summary>
        /// 比较两个 CSharpGL.GUIPoint 对象。此结果指定两个 CSharpGL.GUIPoint 对象的 CSharpGL.GUIPoint.X 和 CSharpGL.GUIPoint.Y 属性的值是否相等。
        /// </summary>
        /// <param name="left">要比较的 CSharpGL.GUIPoint。</param>
        /// <param name="right">要比较的 CSharpGL.GUIPoint。</param>
        /// <returns>如果 left 和 right 的 CSharpGL.GUIPoint.X 和 CSharpGL.GUIPoint.Y 值均相等，则为 true；否则为 false。</returns>
        public static bool operator ==(GUIPoint left, GUIPoint right)
        {
            return left.X == right.X && left.Y == right.Y;
        }

        /// <summary>
        /// 比较两个 CSharpGL.GUIPoint 对象。此结果指定两个 CSharpGL.GUIPoint 对象的 CSharpGL.GUIPoint.X 或 CSharpGL.GUIPoint.Y 属性的值是否不等。
        /// </summary>
        /// <param name="left">要比较的 CSharpGL.GUIPoint。</param>
        /// <param name="right">要比较的 CSharpGL.GUIPoint。</param>
        /// <returns>如果 left 和 right 的 CSharpGL.GUIPoint.X 属性值或 CSharpGL.GUIPoint.Y 属性值不等，则为 true；否则为 false。</returns>
        public static bool operator !=(GUIPoint left, GUIPoint right)
        {
            return !(left == right);
        }

        /// <summary>
        /// 将指定的 CSharpGL.GUISize 添加到指定的 CSharpGL.GUIPoint。
        /// </summary>
        /// <param name="pt">要添加的 CSharpGL.GUIPoint。</param>
        /// <param name="sz">要添加的 CSharpGL.GUISize。</param>
        /// <returns>CSharpGL.GUIPoint，它是加法运算的结果。</returns>
        public static GUIPoint Add(GUIPoint pt, GUISize sz)
        {
            return new GUIPoint(pt.X + sz.Width, pt.Y + sz.Height);
        }

        /// <summary>
        /// 返回从指定的 CSharpGL.GUIPoint 减去指定的 CSharpGL.GUISize 之后的结果。
        /// </summary>
        /// <param name="pt">作为被减数的 CSharpGL.GUIPoint。</param>
        /// <param name="sz">要从 CSharpGL.GUIPoint 中减去的 CSharpGL.GUISize。</param>
        /// <returns>CSharpGL.GUIPoint，它是减法运算的结果。</returns>
        public static GUIPoint Subtract(GUIPoint pt, GUISize sz)
        {
            return new GUIPoint(pt.X - sz.Width, pt.Y - sz.Height);
        }

        /// <summary>
        /// 通过将 CSharpGL.GUIPointF 的值舍入到与其接近的较大整数值，将指定的 CSharpGL.GUIPointF 转换为 CSharpGL.GUIPoint。
        /// </summary>
        /// <param name="value">要转换的 CSharpGL.GUIPointF。</param>
        /// <returns>此方法转换得到的 CSharpGL.GUIPoint。</returns>
        public static GUIPoint Ceiling(GUIPointF value)
        {
            return new GUIPoint((int)Math.Ceiling((double)value.X), (int)Math.Ceiling((double)value.Y));
        }

        /// <summary>
        /// 通过截断 CSharpGL.GUIPoint 值，将指定的 CSharpGL.GUIPointF 转换为 CSharpGL.GUIPoint。
        /// </summary>
        /// <param name="value">要转换的 CSharpGL.GUIPointF。</param>
        /// <returns>此方法转换得到的 CSharpGL.GUIPoint。</returns>
        public static GUIPoint Truncate(GUIPointF value)
        {
            return new GUIPoint((int)value.X, (int)value.Y);
        }

        /// <summary>
        /// 通过将 CSharpGL.GUIPoint 值舍入到最接近的整数值，将指定的 CSharpGL.GUIPointF 转换为 CSharpGL.GUIPoint 对象。
        /// </summary>
        /// <param name="value">要转换的 CSharpGL.GUIPointF。</param>
        /// <returns>此方法转换得到的 CSharpGL.GUIPoint。</returns>
        public static GUIPoint Round(GUIPointF value)
        {
            return new GUIPoint((int)Math.Round((double)value.X), (int)Math.Round((double)value.Y));
        }

        /// <summary>
        /// 指定此 CSharpGL.GUIPoint 是否包含与指定 System.Object 有相同的坐标。
        /// </summary>
        /// <param name="obj">要测试的 System.Object。</param>
        /// <returns>如果 obj 为 CSharpGL.GUIPoint 并与此 CSharpGL.GUIPoint 的坐标相等，则为 true。</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is GUIPoint))
            {
                return false;
            }
            GUIPoint point = (GUIPoint)obj;
            return point.X == this.X && point.Y == this.Y;
        }

        /// <summary>
        /// 返回此 CSharpGL.GUIPoint 的哈希代码。
        /// </summary>
        /// <returns>一个整数值，它指定此 CSharpGL.GUIPoint 的哈希值。</returns>
        public override int GetHashCode()
        {
            return this.x ^ this.y;
        }

        /// <summary>
        /// 将此 CSharpGL.GUIPoint 平移指定的量。
        /// </summary>
        /// <param name="dx">偏移 X 坐标的量。</param>
        /// <param name="dy">偏移 Y 坐标的量。</param>
        public void Offset(int dx, int dy)
        {
            this.X += dx;
            this.Y += dy;
        }

        /// <summary>
        /// 将此 CSharpGL.GUIPoint 平移指定的 CSharpGL.GUIPoint。
        /// </summary>
        /// <param name="p">用于使此 CSharpGL.GUIPoint 发生偏移的 CSharpGL.GUIPoint。</param>
        public void Offset(GUIPoint p)
        {
            this.Offset(p.X, p.Y);
        }

        /// <summary>
        /// 将此 CSharpGL.GUIPoint 转换为可读字符串。
        /// </summary>
        /// <returns>表示此 CSharpGL.GUIPoint 的字符串。</returns>
        public override string ToString()
        {
            return string.Concat(new string[]
			{
				"{X=",
				this.X.ToString(CultureInfo.CurrentCulture),
				",Y=",
				this.Y.ToString(CultureInfo.CurrentCulture),
				"}"
			});
        }

        private static int HIWORD(int n)
        {
            return n >> 16 & 65535;
        }

        private static int LOWORD(int n)
        {
            return n & 65535;
        }
    }
}
