using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    public struct Voxel {
        public byte r;
        public byte g;
        public byte b;

        public Voxel(byte r, byte g, byte b) {
            this.r = r; this.g = g; this.b = b;
        }

        public static Voxel operator +(Voxel x, Voxel y) {
            byte r = (byte)(x.r + y.r);
            byte g = (byte)(x.g + y.g);
            byte b = (byte)(x.b + y.b);

            return new Voxel(r, g, b);
        }

    }

    public unsafe class VolumeData {
        public static Voxel[] GetData(int width, int height, int depth) {
            var list = new List<ShapingBase>();
            list.Add(new ShapingSpheroid(width / 11 + 6, 5 * height / 11, depth / 11 + 6, width, height, depth, 0, 0, 0));
            list.Add(new ShapingSpheroid(width / 22 + 6, 2 * height / 11, depth / 22 + 6, width, height, depth, 10, -width / 3, 10));
            list.Add(new ShapingSpheroid(width / 22 + 6, 2 * height / 11, depth / 22 + 6, width, height, depth, 10, -width / 3, -10));
            list.Add(new ShapingSpheroid(width / 22 + 6, 2 * height / 11, depth / 22 + 6, width, height, depth, -10, -width / 3, -10));
            list.Add(new ShapingSpheroid(width / 22 + 6, 2 * height / 11, depth / 22 + 6, width, height, depth, -10, -width / 3, 10));
            list.Add(new ShapingPlane(0, 1, 0, -2.0 * width / 5.0, width, height, depth));

            var result = new Voxel[width * height * depth];
            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    for (int k = 0; k < depth; k++) {
                        var index = i * height * depth + j * depth + k;
                        foreach (var item in list) {
                            Voxel value = item.Shaping(i, j, k);
                            result[index] = result[index] + value;
                        }
                    }
                }
            }

            return result;
        }


        abstract class ShapingBase {
            protected int width;
            protected int height;
            protected int depth;
            public abstract Voxel Shaping(int i, int j, int k);

            public ShapingBase(int width, int height, int depth) {
                this.width = width; this.height = height; this.depth = depth;
            }
        }


        // ax + by + cz + d = 0
        class ShapingPlane : ShapingBase {
            double a;
            double b;
            double c;
            double d;
            public ShapingPlane(double a, double b, double c, double d, int width, int height, int depth)
                : base(width, height, depth) {
                this.a = a; this.b = b; this.c = c; this.d = d;
            }
            public override Voxel Shaping(int i, int j, int k) {
                double x = (i - width / 2.0);
                double y = (i - width / 2.0);
                double z = (j - height / 2.0);
                double delta = a * x + b * y + c * z - d;
                if (0 <= delta && delta < 1) {
                    return new Voxel(0, byte.MaxValue, 0);
                }
                else {
                    return new Voxel();
                }
            }
        }

        // x*x/(a*a) + y*y/(b*b) + z*z/(c*c) = 1
        class ShapingSpheroid : ShapingBase {
            double aa;
            double bb;
            double cc;
            double posX;
            double posY;
            double posZ;
            double maxDiff;
            byte value;

            public ShapingSpheroid(double a, double b, double c, int width, int height, int depth, double posX, double posY, double posZ, double maxDiff = 0.1, byte value = (byte)40)
                : base(width, height, depth) {
                this.aa = a * a; this.bb = b * b; this.cc = c * c;
                this.posX = posX; this.posY = posY; this.posZ = posZ;
                this.maxDiff = maxDiff;
                this.value = value;
            }
            public override Voxel Shaping(int i, int j, int k) {
                double x = i - width / 2.0 - posX;
                double y = j - height / 2.0 - posY;
                double z = k - depth / 2.0 - posZ;
                double delta = x * x / aa + y * y / bb + z * z / cc - 1;
                if (0 <= delta && delta < maxDiff) {
                    return new Voxel(byte.MaxValue, 0, 0);
                }
                else {
                    return new Voxel();
                }
            }
        }
    }

}
