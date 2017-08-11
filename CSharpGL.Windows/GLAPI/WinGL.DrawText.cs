using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public partial class WinGL
    {
        public override void DrawText(int x, int y, System.Drawing.Color color, string faceName, float fontSize, string text)
        {
            FontBitmaps.DrawText(x, y, color, faceName, fontSize, text);
        }
    }
}
