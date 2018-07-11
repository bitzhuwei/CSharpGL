using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class VolumeData
    {
        public static byte[] GetData(int width, int height, int depth)
        {
            var list = new List<ShapingBase>();
            list.Add(new ShapingSphere(width, height, depth));

            var result = new byte[width * height * depth];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    for (int k = 0; k < depth; k++)
                    {
                        var index = i * height * depth + j * depth + k;
                        foreach (var item in list)
                        {
                            byte value = item.Shaping(i, j, k);
                            if (byte.MaxValue - result[index] > value)
                            {
                                result[index] = value;
                            }
                            else
                            {
                                result[index] = byte.MaxValue;
                                break;
                            }
                        }
                    }
                }
            }

            return result;
        }


        abstract class ShapingBase
        {
            protected int width;
            protected int height;
            protected int depth;
            public abstract byte Shaping(int i, int j, int k);

            public ShapingBase(int width, int height, int depth)
            {
                this.width = width; this.height = height; this.depth = depth;
            }
        }

        class ShapingSphere : ShapingBase
        {
            double radius;

            public ShapingSphere(int width, int height, int depth)
                : base(width, height, depth)
            {
                this.radius = Math.Sqrt(width / 2.0 * width / 2.0 + height / 2.0 * height / 2.0 + depth / 2.0 * depth / 2.0);
            }

            public override byte Shaping(int i, int j, int k)
            {
                var distance = Math.Sqrt((width / 2.0 - i) * (width / 2.0 - i) + (height / 2.0 - j) * (height / 2.0 - j) + (depth / 2.0 - k) * (depth / 2.0 - k));
                return (Math.Abs(distance - (radius / 3)) < 2) ? (byte)36 : (byte)0;
            }
        }
    }

}
