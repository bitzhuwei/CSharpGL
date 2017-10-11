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
        public static GUIMouseEventArgs Translate(this System.Windows.Forms.MouseEventArgs e)
        {
            var button = (GUIMouseButtons)e.Button;
            var args = new GUIMouseEventArgs(button, e.Clicks, e.X, e.Y, e.Delta);

            return args;
        }
    }
}
