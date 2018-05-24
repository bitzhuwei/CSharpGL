using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public partial class GLControl
    {
        internal GLControl parent;
        /// <summary>
        /// Parent control.
        /// </summary>
        [Category(strGLControl)]
        [Description("Parent control. This node inherits parent's layout properties.")]
        public GLControl Parent
        {
            get { return this.parent; }
            set
            {
                GLControl old = this.parent;
                if (old != value)
                {
                    this.parent = value; // this records the parent.

                    if (old != null)
                    {
                        old.Children.Remove(this); // bye, old parent.
                    }
                    
                    if (value != null)
                    {
                        value.Children.children.Add(this); // parent records this.

                        GLControl.LayoutAfterAddChild(this, value);
                        GLControl.UpdateAbsLocation(this, value);
                    }
                }
            }
        }

        internal static void LayoutAfterAddChild(GLControl control, GLControl parent)
        {
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
                control.left = parent.width - control.width - control.right;
            }
            else // if ((anchor & noneAnchor) == nonAnchor)
            {
                int diff = parent.width - control.left - control.width - control.right;
                int halfDiff = diff / 2;
                int otherHalfDiff = diff - halfDiff;
                control.left += halfDiff;
                control.right += otherHalfDiff;
            }
            
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
                control.bottom = parent.height - control.height - control.top;
            }
            else // if ((anchor & noneAnchor) == nonAnchor)
            {
                int diff = parent.height - control.bottom - control.height - control.top;
                int halfDiff = diff / 2;
                int otherHalfDiff = diff - halfDiff;
                control.bottom += halfDiff;
                control.top += otherHalfDiff;
            }
        }

    }
}
