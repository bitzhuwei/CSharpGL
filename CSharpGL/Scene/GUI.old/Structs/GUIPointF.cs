using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    //[ComVisible(true)]
    /// <summary>
    /// 表示在二维平面中定义点的浮点 x 和 y 坐标的有序对。
    /// </summary>
    [Serializable]
    public struct GUIPointF
    {
        /// <summary>
        /// 表示 CSharpGL.GUIPointF 类的、成员数据未被初始化的新实例。
        /// </summary>
        public static readonly GUIPointF Empty = default(GUIPointF);

        private float x;

        private float y;

        /// <summary>
        /// 获取一个值，该值指示此 CSharpGL.GUIPointF 是否为空。
        /// 如果 CSharpGL.GUIPointF.X 和 CSharpGL.GUIPointF.Y 均为 0，该值为 true；否则为 false。
        /// </summary>
        [Browsable(false)]
        public bool IsEmpty
        {
            get
            {
                return this.x == 0f && this.y == 0f;
            }
        }

        /// <summary>
        /// 获取或设置此 CSharpGL.GUIPointF 的 x 坐标。
        /// </summary>
        public float X
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
        /// 获取或设置此 CSharpGL.GUIPointF 的 y 坐标。
        /// </summary>
        public float Y
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
        /// 用指定坐标初始化 CSharpGL.GUIPointF 类的新实例。
        /// </summary>
        /// <param name="x">该点的水平位置。</param>
        /// <param name="y">该点的垂直位置。</param>
        public GUIPointF(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// 将 CSharpGL.GUIPointF 平移给定 CSharpGL.GUISize。
        /// </summary>
        /// <param name="pt">要平移的 CSharpGL.GUIPointF。</param>
        /// <param name="sz">CSharpGL.GUISize，它指定要添加到 pt 的坐标的数字对。</param>
        /// <returns>返回经过平移的 CSharpGL.GUIPointF。</returns>
        public static GUIPointF operator +(GUIPointF pt, GUISize sz)
        {
            return GUIPointF.Add(pt, sz);
        }

        /// <summary>
        /// 将 CSharpGL.GUIPointF 平移给定 CSharpGL.GUISize 的负数。
        /// </summary>
        /// <param name="pt">要比较的 CSharpGL.GUIPointF。</param>
        /// <param name="sz">要比较的 CSharpGL.GUIPointF。</param>
        /// <returns>平移后的 CSharpGL.GUIPointF。</returns>
        public static GUIPointF operator -(GUIPointF pt, GUISize sz)
        {
            return GUIPointF.Subtract(pt, sz);
        }

        /// <summary>
        /// 按指定的 CSharpGL.GUISizeF 平移 CSharpGL.GUIPointF。
        /// </summary>
        /// <param name="pt">要平移的 CSharpGL.GUIPointF。</param>
        /// <param name="sz">CSharpGL.GUISizeF，它指定要增加到 CSharpGL.GUIPointF 的 x 坐标和 y 坐标的数。</param>
        /// <returns>平移后的 CSharpGL.GUIPointF。</returns>
        public static GUIPointF operator +(GUIPointF pt, GUISizeF sz)
        {
            return GUIPointF.Add(pt, sz);
        }

        /// <summary>
        /// 按指定 CSharpGL.GUISizeF 的负值平移 CSharpGL.GUIPointF。
        /// </summary>
        /// <param name="pt">要平移的 CSharpGL.GUIPointF。</param>
        /// <param name="sz">CSharpGL.GUISizeF，它指定要从 pt 的坐标中减去的数。</param>
        /// <returns>平移后的 CSharpGL.GUIPointF。</returns>
        public static GUIPointF operator -(GUIPointF pt, GUISizeF sz)
        {
            return GUIPointF.Subtract(pt, sz);
        }

        /// <summary>
        /// 比较两个 CSharpGL.GUIPointF 结构。此结果指定两个 CSharpGL.GUIPointF 结构的 CSharpGL.GUIPointF.X 和 CSharpGL.GUIPointF.Y 属性的值是否相等。
        /// </summary>
        /// <param name="left">要比较的 CSharpGL.GUIPointF。</param>
        /// <param name="right">要比较的 CSharpGL.GUIPointF。</param>
        /// <returns>如果左边和右边的 CSharpGL.GUIPointF 结构的 CSharpGL.GUIPointF.X 和 CSharpGL.GUIPointF.Y 值相等，为 true；否则为 false。</returns>
        public static bool operator ==(GUIPointF left, GUIPointF right)
        {
            return left.X == right.X && left.Y == right.Y;
        }

        /// <summary>
        /// 确定指定点的坐标是否不等。
        /// </summary>
        /// <param name="left">要比较的 CSharpGL.GUIPointF。</param>
        /// <param name="right">要比较的 CSharpGL.GUIPointF。</param>
        /// <returns>要指示 left 和 right 的 CSharpGL.GUIPointF.X 和 CSharpGL.GUIPointF.Y 值不等，为 true；否则为 false。</returns>
        public static bool operator !=(GUIPointF left, GUIPointF right)
        {
            return !(left == right);
        }

        /// <summary>
        /// 按指定的 CSharpGL.GUISize 平移给定的 CSharpGL.GUIPointF。
        /// </summary>
        /// <param name="pt">要平移的 CSharpGL.GUIPointF。</param>
        /// <param name="sz">CSharpGL.GUISize，它指定要增加到 pt 的坐标的数。</param>
        /// <returns>平移后的 CSharpGL.GUIPointF。</returns>
        public static GUIPointF Add(GUIPointF pt, GUISize sz)
        {
            return new GUIPointF(pt.X + (float)sz.Width, pt.Y + (float)sz.Height);
        }

        /// <summary>
        /// 按指定大小的负值平移 CSharpGL.GUIPointF。
        /// </summary>
        /// <param name="pt">要平移的 CSharpGL.GUIPointF。</param>
        /// <param name="sz">CSharpGL.GUISize，它指定要从 pt 的坐标中减去的数。</param>
        /// <returns>平移后的 CSharpGL.GUIPointF。</returns>
        public static GUIPointF Subtract(GUIPointF pt, GUISize sz)
        {
            return new GUIPointF(pt.X - (float)sz.Width, pt.Y - (float)sz.Height);
        }

        /// <summary>
        /// 按指定的 CSharpGL.GUISizeF 平移给定的 CSharpGL.GUIPointF。
        /// </summary>
        /// <param name="pt">要平移的 CSharpGL.GUIPointF。</param>
        /// <param name="sz">CSharpGL.GUISizeF，它指定要增加到 pt 的坐标的数。</param>
        /// <returns>平移后的 CSharpGL.GUIPointF。</returns>
        public static GUIPointF Add(GUIPointF pt, GUISizeF sz)
        {
            return new GUIPointF(pt.X + sz.Width, pt.Y + sz.Height);
        }

        /// <summary>
        /// 按指定大小的负值平移 CSharpGL.GUIPointF。
        /// </summary>
        /// <param name="pt">要平移的 CSharpGL.GUIPointF。</param>
        /// <param name="sz">CSharpGL.GUISizeF，它指定要从 pt 的坐标中减去的数。</param>
        /// <returns>平移后的 CSharpGL.GUIPointF。</returns>
        public static GUIPointF Subtract(GUIPointF pt, GUISizeF sz)
        {
            return new GUIPointF(pt.X - sz.Width, pt.Y - sz.Height);
        }

        /// <summary>
        /// 指定此 CSharpGL.GUIPointF 是否包含与指定 System.Object 有相同的坐标。
        /// </summary>
        /// <param name="obj">要测试的 System.Object。</param>
        /// <returns>如果 obj 是一个 CSharpGL.GUIPointF，并且具有与此 CSharpGL.GUIPoint 相同的坐标，则此方法将返回 true。</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is GUIPointF))
            {
                return false;
            }
            GUIPointF pointF = (GUIPointF)obj;
            return pointF.X == this.X && pointF.Y == this.Y && pointF.GetType().Equals(base.GetType());
        }

        /// <summary>
        /// 返回此 CSharpGL.GUIPointF 结构的哈希代码。
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// 将此 CSharpGL.GUIPointF 转换为可读字符串。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{{X={0}, Y={1}}}", new object[]
			{
				this.x,
				this.y
			});
        }
    }
}
