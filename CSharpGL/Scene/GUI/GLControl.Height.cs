using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public partial class GLControl
    {
        /// <summary>
        /// Height of this control.
        /// </summary>
        [Category(strGLControl)]
        [Description("Height of this control.")]
        public int Height
        {
            get { return this.height; }
            set
            {
                if (this.height != value)
                {
                    this.height = value;

                    GLControl.LayoutAfterHeightChanged(this, this.Children);
                }
            }
        }

        private static void LayoutAfterHeightChanged(GLControl parent, GLControlChildren glControlChildren)
        {
            foreach (var control in glControlChildren)
            {
                GUIAnchorStyles anchor = control.Anchor;
                if ((anchor & bottomTopAnchor) == bottomTopAnchor)
                {
                    control.Height = parent.height - control.bottom - control.top;
                }
                else if ((anchor & bottomAnchor) == bottomAnchor)
                {
                    control.top = parent.height - control.bottom - control.height;
                }
                else if ((anchor & topAnchor) == topAnchor)
                {
                    control.bottom = parent.height - control.top - control.height;
                    control.absBottom = parent.absBottom + control.bottom;
                    foreach (var item in control.Children)
                    {
                        UpdateAbsBottom(control, item);
                    }
                }
                else // if ((anchor & noneAnchor) == noneAnchor)
                {
                    int diff = parent.height - control.top - control.height - control.bottom;
                    int halfDiff = diff / 2;
                    int OtherHalfDiff = diff - halfDiff;
                    control.bottom += halfDiff;
                    control.absBottom = parent.absBottom + control.bottom;
                    control.top += OtherHalfDiff;
                    foreach (var item in control.Children)
                    {
                        UpdateAbsBottom(control, item);
                    }
                }
            }
        }

    }
}
