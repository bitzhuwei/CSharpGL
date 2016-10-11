using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class ViewPort
    {
        public System.Windows.Forms.AnchorStyles Anchor { get; set; }

        public System.Windows.Forms.Padding Margin { get; set; }

        public Point Location { get; set; }

        public Size Size { get; set; }

        public Size ParentLastSize { get; set; }

        public int zNear { get; set; }

        public int zFar { get; set; }

        public UIRenderer Self
        {
            get { return this; }
        }

        public UIRenderer Parent
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public ChildList<UIRenderer> Children
        {
            get { throw new NotImplementedException(); }
        }
    }
}
