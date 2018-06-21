using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public partial class SoftGL
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
        public override void DrawText(int x, int y, System.Drawing.Color color, string faceName, float fontSize, string text)
        {
            //FontBitmaps.DrawText(x, y, color, faceName, fontSize, text);
        }
    }
}
