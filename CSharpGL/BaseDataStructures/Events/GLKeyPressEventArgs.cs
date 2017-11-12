using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class GLKeyPressEventArgs : GLEventArgs
    {
        private char keyChar;

        private bool handled;

        /// <summary>
        /// 获取或设置与按下的键对应的字符。例如，如果用户按下 Shift + K，则该属性返回一个大写的 K。
        /// </summary>
        public char KeyChar
        {
            get
            {
                return this.keyChar;
            }
            set
            {
                this.keyChar = value;
            }
        }

        /// <summary>
        /// 获取或设置一个值，该值指示是否处理过 KeyPress 事件。
        /// </summary>
        public bool Handled
        {
            get
            {
                return this.handled;
            }
            set
            {
                this.handled = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyChar">与用户按下的键相对应的 ASCII 字符。</param>
        public GLKeyPressEventArgs(char keyChar)
        {
            this.keyChar = keyChar;
        }
    }
}
