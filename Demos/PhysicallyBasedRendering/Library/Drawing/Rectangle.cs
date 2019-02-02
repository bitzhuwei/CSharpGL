using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeImageAPI
{
    public struct Rectangle
    {
        private int top;
        private int left;
        private int width;
        private int height;

        public Rectangle(int left, int top, int width, int height)
        {
            this.left = left;
            this.top = top;
            this.width = width;
            this.height = height;
        }

        public int Top
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

        public int Left
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

        public int X
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

        public int Y
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

        public int Width
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

        public int Height
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

        public int Right
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

        public int Bottom
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
