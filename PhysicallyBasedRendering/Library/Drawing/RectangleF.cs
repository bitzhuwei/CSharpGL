using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeImageAPI
{
    public struct RectangleF
    {
        private float top;
        private float left;
        private float width;
        private float height;

        public RectangleF(float left, float top, float width, float height)
        {
            this.left = left;
            this.top = top;
            this.width = width;
            this.height = height;
        }

        public float Top
        {
            get
            {
                return top;
            }
            set
            {
                top = value;
            }
        }

        public float Left
        {
            get
            {
                return left;
            }
            set
            {
                left = value;
            }
        }

        public float X
        {
            get
            {
                return left;
            }
            set
            {
                left = value;
            }
        }

        public float Y
        {
            get
            {
                return top;
            }
            set
            {
                top = value;
            }
        }

        public float Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        public float Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }

        public float Right
        {
            get
            {
                return left + width;
            }
            set
            {
                width = value - left;
            }
        }

        public float Bottom
        {
            get
            {
                return top + height;
            }
            set
            {
                height = value - top;
            }
        }
    }
}
