using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace System.Numerics
{
    public struct Vector2 : IEquatable<Vector2>
    //, IFormattable
    {
        public float X;

        public float Y;

        public static Vector2 Zero
        {
            get
            {
                return default(Vector2);
            }
        }

        public static Vector2 One
        {
            get
            {
                return new Vector2(1f, 1f);
            }
        }

        public static Vector2 UnitX
        {
            get
            {
                return new Vector2(1f, 0f);
            }
        }

        public static Vector2 UnitY
        {
            get
            {
                return new Vector2(0f, 1f);
            }
        }

        public override int GetHashCode()
        {
            return HashCodeHelper.CombineHashCodes(this.X.GetHashCode(), this.Y.GetHashCode());
        }

        [MethodImpl(256)]
        public override bool Equals(object obj)
        {
            return obj is Vector2 && this.Equals((Vector2)obj);
        }

        //public override string ToString()
        //{
        //    return this.ToString("G", CultureInfo.get_CurrentCulture());
        //}

        //public string ToString(string format)
        //{
        //    return this.ToString(format, CultureInfo.get_CurrentCulture());
        //}

        //public string ToString(string format, IFormatProvider formatProvider)
        //{
        //    StringBuilder arg_11_0 = new StringBuilder();
        //    string numberGroupSeparator = NumberFormatInfo.GetInstance(formatProvider).get_NumberGroupSeparator();
        //    arg_11_0.Append('<');
        //    arg_11_0.Append(this.X.ToString(format, formatProvider));
        //    arg_11_0.Append(numberGroupSeparator);
        //    arg_11_0.Append(' ');
        //    arg_11_0.Append(this.Y.ToString(format, formatProvider));
        //    arg_11_0.Append('>');
        //    return arg_11_0.ToString();
        //}

        [MethodImpl(256)]
        public float Length()
        {
            //if (Vector.IsHardwareAccelerated)
            //{
            //    return (float)Math.Sqrt((double)Vector2.Dot(this, this));
            //}
            return (float)Math.Sqrt((double)(this.X * this.X + this.Y * this.Y));
        }

        [MethodImpl(256)]
        public float LengthSquared()
        {
            //if (Vector.IsHardwareAccelerated)
            //{
            //    return Vector2.Dot(this, this);
            //}
            return this.X * this.X + this.Y * this.Y;
        }

        [MethodImpl(256)]
        public static float Distance(Vector2 value1, Vector2 value2)
        {
            //if (Vector.IsHardwareAccelerated)
            //{
            //    Vector2 expr_0E = value1 - value2;
            //    return (float)Math.Sqrt((double)Vector2.Dot(expr_0E, expr_0E));
            //}
            float arg_37_0 = value1.X - value2.X;
            float num = value1.Y - value2.Y;
            double arg_3C_0 = (double)(arg_37_0 * arg_37_0);
            float expr_3A = num;
            return (float)Math.Sqrt(arg_3C_0 + (double)(expr_3A * expr_3A));
        }

        [MethodImpl(256)]
        public static float DistanceSquared(Vector2 value1, Vector2 value2)
        {
            if (Vector.IsHardwareAccelerated)
            {
                Vector2 expr_0E = value1 - value2;
                return Vector2.Dot(expr_0E, expr_0E);
            }
            float arg_30_0 = value1.X - value2.X;
            float num = value1.Y - value2.Y;
            float arg_35_0 = arg_30_0 * arg_30_0;
            float expr_33 = num;
            return arg_35_0 + expr_33 * expr_33;
        }

        [MethodImpl(256)]
        public static Vector2 Normalize(Vector2 value)
        {
            if (Vector.IsHardwareAccelerated)
            {
                float value2 = value.Length();
                return value / value2;
            }
            float num = value.X * value.X + value.Y * value.Y;
            float num2 = 1f / (float)Math.Sqrt((double)num);
            return new Vector2(value.X * num2, value.Y * num2);
        }

        [MethodImpl(256)]
        public static Vector2 Reflect(Vector2 vector, Vector2 normal)
        {
            if (Vector.IsHardwareAccelerated)
            {
                float num = Vector2.Dot(vector, normal);
                return vector - 2f * num * normal;
            }
            float num2 = vector.X * normal.X + vector.Y * normal.Y;
            return new Vector2(vector.X - 2f * num2 * normal.X, vector.Y - 2f * num2 * normal.Y);
        }

        [MethodImpl(256)]
        public static Vector2 Clamp(Vector2 value1, Vector2 min, Vector2 max)
        {
            float num = value1.X;
            num = ((num > max.X) ? max.X : num);
            num = ((num < min.X) ? min.X : num);
            float num2 = value1.Y;
            num2 = ((num2 > max.Y) ? max.Y : num2);
            num2 = ((num2 < min.Y) ? min.Y : num2);
            return new Vector2(num, num2);
        }

        [MethodImpl(256)]
        public static Vector2 Lerp(Vector2 value1, Vector2 value2, float amount)
        {
            return new Vector2(value1.X + (value2.X - value1.X) * amount, value1.Y + (value2.Y - value1.Y) * amount);
        }

        [MethodImpl(256)]
        public static Vector2 Transform(Vector2 position, Matrix3x2 matrix)
        {
            return new Vector2(position.X * matrix.M11 + position.Y * matrix.M21 + matrix.M31, position.X * matrix.M12 + position.Y * matrix.M22 + matrix.M32);
        }

        //[MethodImpl(256)]
        //public static Vector2 Transform(Vector2 position, Matrix4x4 matrix)
        //{
        //    return new Vector2(position.X * matrix.M11 + position.Y * matrix.M21 + matrix.M41, position.X * matrix.M12 + position.Y * matrix.M22 + matrix.M42);
        //}

        [MethodImpl(256)]
        public static Vector2 TransformNormal(Vector2 normal, Matrix3x2 matrix)
        {
            return new Vector2(normal.X * matrix.M11 + normal.Y * matrix.M21, normal.X * matrix.M12 + normal.Y * matrix.M22);
        }

        //[MethodImpl(256)]
        //public static Vector2 TransformNormal(Vector2 normal, Matrix4x4 matrix)
        //{
        //    return new Vector2(normal.X * matrix.M11 + normal.Y * matrix.M21, normal.X * matrix.M12 + normal.Y * matrix.M22);
        //}

        //[MethodImpl(256)]
        //public static Vector2 Transform(Vector2 value, Quaternion rotation)
        //{
        //    float num = rotation.X + rotation.X;
        //    float num2 = rotation.Y + rotation.Y;
        //    float num3 = rotation.Z + rotation.Z;
        //    float num4 = rotation.W * num3;
        //    float num5 = rotation.X * num;
        //    float num6 = rotation.X * num2;
        //    float num7 = rotation.Y * num2;
        //    float num8 = rotation.Z * num3;
        //    return new Vector2(value.X * (1f - num7 - num8) + value.Y * (num6 - num4), value.X * (num6 + num4) + value.Y * (1f - num5 - num8));
        //}

        [MethodImpl(256)]
        public static Vector2 Add(Vector2 left, Vector2 right)
        {
            return left + right;
        }

        [MethodImpl(256)]
        public static Vector2 Subtract(Vector2 left, Vector2 right)
        {
            return left - right;
        }

        [MethodImpl(256)]
        public static Vector2 Multiply(Vector2 left, Vector2 right)
        {
            return left * right;
        }

        [MethodImpl(256)]
        public static Vector2 Multiply(Vector2 left, float right)
        {
            return left * right;
        }

        [MethodImpl(256)]
        public static Vector2 Multiply(float left, Vector2 right)
        {
            return left * right;
        }

        [MethodImpl(256)]
        public static Vector2 Divide(Vector2 left, Vector2 right)
        {
            return left / right;
        }

        [MethodImpl(256)]
        public static Vector2 Divide(Vector2 left, float divisor)
        {
            return left / divisor;
        }

        [MethodImpl(256)]
        public static Vector2 Negate(Vector2 value)
        {
            return -value;
        }

        //[JitIntrinsic]
        public Vector2(float value)
        {
            this = new Vector2(value, value);
        }

        //[JitIntrinsic]
        public Vector2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        [MethodImpl(256)]
        public void CopyTo(float[] array)
        {
            this.CopyTo(array, 0);
        }

        public void CopyTo(float[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("values");
            }
            if (index < 0 || index >= array.Length)
            {
                //throw new ArgumentOutOfRangeException(SR.Format(SR.Arg_ArgumentOutOfRangeException, index));
                throw new Exception();
            }
            if (array.Length - index < 2)
            {
                //throw new ArgumentException(SR.Format(SR.Arg_ElementsInSourceIsGreaterThanDestination, index));
                throw new Exception();
            }
            array[index] = this.X;
            array[index + 1] = this.Y;
        }

        //[JitIntrinsic]
        public bool Equals(Vector2 other)
        {
            return this.X == other.X && this.Y == other.Y;
        }

        //[JitIntrinsic]
        [MethodImpl(256)]
        public static float Dot(Vector2 value1, Vector2 value2)
        {
            return value1.X * value2.X + value1.Y * value2.Y;
        }

        //[JitIntrinsic]
        [MethodImpl(256)]
        public static Vector2 Min(Vector2 value1, Vector2 value2)
        {
            return new Vector2((value1.X < value2.X) ? value1.X : value2.X, (value1.Y < value2.Y) ? value1.Y : value2.Y);
        }

        //[JitIntrinsic]
        [MethodImpl(256)]
        public static Vector2 Max(Vector2 value1, Vector2 value2)
        {
            return new Vector2((value1.X > value2.X) ? value1.X : value2.X, (value1.Y > value2.Y) ? value1.Y : value2.Y);
        }

        //[JitIntrinsic]
        [MethodImpl(256)]
        public static Vector2 Abs(Vector2 value)
        {
            return new Vector2(Math.Abs(value.X), Math.Abs(value.Y));
        }

        //[JitIntrinsic]
        [MethodImpl(256)]
        public static Vector2 SquareRoot(Vector2 value)
        {
            return new Vector2((float)Math.Sqrt((double)value.X), (float)Math.Sqrt((double)value.Y));
        }

        //[JitIntrinsic]
        [MethodImpl(256)]
        public static Vector2 operator +(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X + right.X, left.Y + right.Y);
        }

        //[JitIntrinsic]
        [MethodImpl(256)]
        public static Vector2 operator -(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X - right.X, left.Y - right.Y);
        }

        //[JitIntrinsic]
        [MethodImpl(256)]
        public static Vector2 operator *(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X * right.X, left.Y * right.Y);
        }

        //[JitIntrinsic]
        [MethodImpl(256)]
        public static Vector2 operator *(float left, Vector2 right)
        {
            return new Vector2(left, left) * right;
        }

        //[JitIntrinsic]
        [MethodImpl(256)]
        public static Vector2 operator *(Vector2 left, float right)
        {
            return left * new Vector2(right, right);
        }

        //[JitIntrinsic]
        [MethodImpl(256)]
        public static Vector2 operator /(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X / right.X, left.Y / right.Y);
        }

        //[JitIntrinsic]
        [MethodImpl(256)]
        public static Vector2 operator /(Vector2 value1, float value2)
        {
            float num = 1f / value2;
            return new Vector2(value1.X * num, value1.Y * num);
        }

        [MethodImpl(256)]
        public static Vector2 operator -(Vector2 value)
        {
            return Vector2.Zero - value;
        }

        [MethodImpl(256)]
        public static bool operator ==(Vector2 left, Vector2 right)
        {
            return left.Equals(right);
        }

        [MethodImpl(256)]
        public static bool operator !=(Vector2 left, Vector2 right)
        {
            return !(left == right);
        }
    }
}
