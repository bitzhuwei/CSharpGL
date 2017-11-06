using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public static class TranslateExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static GLMouseEventArgs Translate(this System.Windows.Forms.MouseEventArgs e)
        {
            var args = new GLMouseEventArgs((GLMouseButtons)e.Button, e.Clicks, e.X, e.Y, e.Delta);

            return args;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static GLKeyEventArgs Translate(this System.Windows.Forms.KeyEventArgs e)
        {
            var args = new GLKeyEventArgs((GLKeys)e.KeyData);

            return args;
        }
    }
}
