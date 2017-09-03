using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public partial class GL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        /// <param name="faceName"></param>
        /// <param name="fontSize"></param>
        /// <param name="text"></param>
        public abstract void DrawText(int x, int y, Color color, string faceName, float fontSize, string text);
    }
}
