using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class VolumeData
    {
        private static byte[] data;

        public static byte[] GetData()
        {
            if (data == null) { data = InnerGetData(); }

            return data;
        }

        private static byte[] InnerGetData()
        {
            int width = 256, height = 256, depth = 225;
            var radius = Math.Sqrt(width / 2.0 * width / 2.0 + height / 2.0 * height / 2.0 + depth / 2.0 * depth / 2.0);
            var result = new byte[width * height * depth];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    for (int k = 0; k < depth; k++)
                    {
                        var index = i * height * depth + j * depth + k;
                        var distance = Math.Sqrt((width / 2.0 - i) * (width / 2.0 - i) + (height / 2.0 - j) * (height / 2.0 - j) + (depth / 2.0 - k) * (depth / 2.0 - k));
                        //if (Math.Abs(distance - (radius / 3)) < 80)
                        //if (i == width / 2 && j == height / 2)// && k == depth / 2)
                        //if ((100 < i && i < 130))
                        {
                            result[index] += 36;// byte.MaxValue / 1;
                        }

                        //if ((100 < j && j < 130))
                        //{
                        //    result[index] += 36;// byte.MaxValue / 1;
                        //}

                        //if ((100 < k && k < 130))
                        //{
                        //    result[index] += 36;// byte.MaxValue / 1;
                        //}
                    }
                }
            }

            return result;
        }
    }
}
