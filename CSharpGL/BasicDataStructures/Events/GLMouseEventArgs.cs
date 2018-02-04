using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class GLMouseEventArgs : GLEventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="button">MouseButtons 值之一，它指示曾按下的是哪个鼠标按钮。</param>
        /// <param name="clicks">鼠标按钮曾被按下的次数。</param>
        /// <param name="x">鼠标单击的 x 坐标（以像素为单位，以left为0）。相对<see cref="CtrlRoot"/>而言。</param>
        /// <param name="y">鼠标单击的 y 坐标（以像素为单位，以bottom为0）。相对<see cref="CtrlRoot"/>而言。</param>
        /// <param name="delta">鼠标轮已转动的制动器数的有符号计数。</param>
        public GLMouseEventArgs(GLMouseButtons button, int clicks, int x, int y, int delta)
        {
            this.Button = button; this.Clicks = clicks; this.X = x; this.Y = y; this.Delta = delta;
        }

        /// <summary>
        /// MouseButtons 值之一。
        /// </summary>
        public GLMouseButtons Button { get; private set; }

        /// <summary>
        /// 一个 System.Int32，包含按下并释放鼠标按钮的次数。
        /// </summary>
        public int Clicks { get; private set; }

        /// <summary>
        /// 获取鼠标轮已转动的制动器数的有符号计数。制动器是鼠标轮的一个凹口。
        /// </summary>
        public int Delta { get; private set; }

        /// <summary>
        /// 一个 ivec2，包含鼠标的 x 和 y 坐标（以像素为单位，以(left, bottom)为0）。
        /// </summary>
        public ivec2 Location { get { return new ivec2(X, Y); } }

        /// <summary>
        /// 鼠标单击的 x 坐标（以像素为单位，以left为0）。
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// 鼠标单击的 y 坐标（以像素为单位，以bottom为0）。
        /// </summary>
        public int Y { get; private set; }
    }

    /// <summary>
    /// 指定定义哪个鼠标按钮曾按下的常数。
    /// </summary>
    [Flags]
    public enum GLMouseButtons
    {
        /// <summary>
        /// 未曾按下鼠标按钮。
        /// </summary>
        None = 0,

        /// <summary>
        /// 鼠标左按钮曾按下。
        /// </summary>
        Left = 1048576,

        /// <summary>
        /// 鼠标右按钮曾按下。
        /// </summary>
        Right = 2097152,

        /// <summary>
        /// 鼠标中按钮曾按下。
        /// </summary>
        Middle = 4194304,

        /// <summary>
        /// 第 1 个 XButton 曾按下。
        /// </summary>
        XButton1 = 8388608,

        /// <summary>
        /// 第 2 个 XButton 曾按下。
        /// </summary>
        XButton2 = 16777216,
    }
}
