using System;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace CSharpGL
{
    public static class Vector2Helper
    {
        public static vec2 UnitX
        {
            get
            {
                return new vec2(1f, 0f);
            }
        }

        public static vec2 UnitY
        {
            get
            {
                return new vec2(0f, 1f);
            }
        }

        //[JitIntrinsic]
        [MethodImpl(256)]
        public static vec2 Min(vec2 value1, vec2 value2)
        {
            return new vec2((value1.x < value2.x) ? value1.x : value2.x, (value1.y < value2.y) ? value1.y : value2.y);
        }

        //[JitIntrinsic]
        [MethodImpl(256)]
        public static vec2 Max(vec2 value1, vec2 value2)
        {
            return new vec2((value1.x > value2.x) ? value1.x : value2.x, (value1.y > value2.y) ? value1.y : value2.y);
        }

        [MethodImpl(256)]
        public static vec2 Abs(vec2 value)
        {
            return new vec2(Math.Abs(value.x), Math.Abs(value.y));
        }

        //[MethodImpl(256)]
        //public static vec2 Transform(vec2 position, Matrix3x2 matrix)
        //{
        //    return new vec2(position.x * matrix.M11 + position.y * matrix.M21 + matrix.M31, position.x * matrix.M12 + position.y * matrix.M22 + matrix.M32);
        //}

        //[MethodImpl(256)]
        //public static Vector2 Transform(Vector2 position, Matrix4x4 matrix)
        //{
        //    return new Vector2(position.X * matrix.M11 + position.Y * matrix.M21 + matrix.M41, position.X * matrix.M12 + position.Y * matrix.M22 + matrix.M42);
        //}

        [MethodImpl(256)]
        public static vec2 TransformNormal(vec2 normal, Matrix3x2 matrix)
        {
            return new vec2(normal.x * matrix.M11 + normal.y * matrix.M21, normal.x * matrix.M12 + normal.y * matrix.M22);
        }

    }
}
