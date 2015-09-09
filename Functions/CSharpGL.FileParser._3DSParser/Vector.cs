using System;

namespace CSharpGL.FileParser._3DSParser
{
    public struct Vector
    {
        public double X;
        public double Y;
        public double Z;

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector CrossProduct(Vector v)
        {
            return new Vector(Y * v.Z - Z * v.Y,
                    Z * v.X - X * v.Z,
                    X * v.Y - Y * v.X);
        }

        public double DotProduct(Vector v)
        {
            return X * v.X + Y * v.Y + Z * v.Z;
        }

        public Vector Normalize()
        {
            double d = Math.Sqrt(X * X + Y * Y + Z * Z);

            if (d == 0) d = 1;

            return this / d;
        }

        public override string ToString()
        {
            return String.Format("X: {0} Y: {1} Z: {2}", X, Y, Z);
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            Vector vr;

            vr.X = v1.X + v2.X;
            vr.Y = v1.Y + v2.Y;
            vr.Z = v1.Z + v2.Z;

            return vr;
        }

        public static Vector operator /(Vector v1, double s)
        {
            Vector vr;

            vr.X = v1.X / s;
            vr.Y = v1.Y / s;
            vr.Z = v1.Z / s;

            return vr;
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            Vector vr;

            vr.X = v1.X - v2.X;
            vr.Y = v1.Y - v2.Y;
            vr.Z = v1.Z - v2.Z;

            return vr;
        }
    }
}
