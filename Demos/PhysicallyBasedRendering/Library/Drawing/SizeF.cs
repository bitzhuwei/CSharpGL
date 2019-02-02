using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeImageAPI
{
    public struct SizeF
    {
        private float width;
        private float height;

        public SizeF(float width, float height)
        {
            this.width = width;
            this.height = height;
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
    }
}
