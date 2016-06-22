using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace GridViewer
{
    class WindowSizeHelper
    {

        public static Rectangle WindowSize(float widthRatio, float heightRatio)
        {

            Rectangle rect = Screen.PrimaryScreen.WorkingArea;
            int width = (int)Math.Round(rect.Width * widthRatio);
            int height = (int)Math.Round(rect.Height * heightRatio);
            int left = (int)((rect.Width - width) / 2.0f);
            int top = (int)((rect.Height - height) / 2.0f);
            Rectangle result = new Rectangle(left, top, width, height);
            return result;

        }
    }
}
