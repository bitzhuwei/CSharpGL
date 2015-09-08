// Title:	Vector.cs
// Author: 	Scott Ellington <scott.ellington@gmail.com>
//
// Copyright (C) 2006 Scott Ellington and authors
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;

namespace CSharpGL._3DSFiles
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
