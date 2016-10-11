using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class ViewPort : ILayout
    {
        public ViewPort(Rectangle rect, ICamera camera)
        {
            this.Rect = rect;
            this.Camera = camera;
        }

        /// <summary>
        /// 
        /// </summary>
        public Rectangle Rect { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICamera Camera { get; private set; }

        public System.Windows.Forms.AnchorStyles Anchor
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

        public System.Windows.Forms.Padding Margin
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

        public Point Location
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

        public Size Size
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

        public Size ParentLastSize
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

        public int zNear
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

        public int zFar
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

        public UIRenderer Self
        {
            get { throw new NotImplementedException(); }
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
