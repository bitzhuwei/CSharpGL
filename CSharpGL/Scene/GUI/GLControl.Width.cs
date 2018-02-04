using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public partial class GLControl
    {
        private int width;
        /// <summary>
        /// Width of this control.
        /// </summary>
        [Category(strGLControl)]
        [Description("Width of this control.")]
        public int Width
        {
            get { return width; }
            set
            {
                if (width != value)
                {
                    width = value;

                    GLControl.LayoutAfterWidthChanged(this, this.Children);
                }
            }
        }

        private static void LayoutAfterWidthChanged(GLControl parent, GLControlChildren glControlChildren)
        {
            foreach (var control in glControlChildren)
            {
                if (control.parent != parent) { throw new Exception("Parent info not matching!"); }

                GUIAnchorStyles anchor = control.Anchor;
                if ((anchor & leftRightAnchor) == leftRightAnchor)
                {
                    control.Width = parent.width - control.left - control.right;
                }
                else if ((anchor & leftAnchor) == leftAnchor)
                {
                    control.right = parent.width - control.left - control.width;
                }
                else if ((anchor & rightAnchor) == rightAnchor)
                {
                    control.left = parent.width - control.right - control.width;
                }
                else // if ((anchor & noneAnchor) == noneAnchor)
                {
                    int diff = parent.width - control.left - control.width - control.right;
                    int halfDiff = diff / 2;
                    int OtherHalfDiff = diff - halfDiff;
                    control.left += halfDiff;
                    control.right += OtherHalfDiff;
                }
            }
        }

    }
}
