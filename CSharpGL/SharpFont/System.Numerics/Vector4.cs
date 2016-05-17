using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace System.Numerics
{
	public struct Vector4 : IEquatable<Vector4>, IFormattable
	{
		public float X;

		public float Y;

		public float Z;

		public float W;

		public static Vector4 Zero
		{
			get
			{
				return default(Vector4);
			}
		}

		public static Vector4 One
		{
			get
			{
				return new Vector4(1f, 1f, 1f, 1f);
			}
		}

		public static Vector4 UnitX
		{
			get
			{
				return new Vector4(1f, 0f, 0f, 0f);
			}
		}

		public static Vector4 UnitY
		{
			get
			{
				return new Vector4(0f, 1f, 0f, 0f);
			}
		}

		public static Vector4 UnitZ
		{
			get
			{
				return new Vector4(0f, 0f, 1f, 0f);
			}
		}

		public static Vector4 UnitW
		{
			get
			{
				return new Vector4(0f, 0f, 0f, 1f);
			}
		}

		public override int GetHashCode()
		{
			return HashCodeHelper.CombineHashCodes(HashCodeHelper.CombineHashCodes(HashCodeHelper.CombineHashCodes(this.X.GetHashCode(), this.Y.GetHashCode()), this.Z.GetHashCode()), this.W.GetHashCode());
		}

		[MethodImpl(256)]
		public override bool Equals(object obj)
		{
			return obj is Vector4 && this.Equals((Vector4)obj);
		}

		public override string ToString()
		{
			return this.ToString("G", CultureInfo.get_CurrentCulture());
		}

		public string ToString(string format)
		{
			return this.ToString(format, CultureInfo.get_CurrentCulture());
		}

		public string ToString(string format, IFormatProvider formatProvider)
		{
			StringBuilder arg_11_0 = new StringBuilder();
			string numberGroupSeparator = NumberFormatInfo.GetInstance(formatProvider).get_NumberGroupSeparator();
			arg_11_0.Append('<');
			arg_11_0.Append(this.X.ToString(format, formatProvider));
			arg_11_0.Append(numberGroupSeparator);
			arg_11_0.Append(' ');
			arg_11_0.Append(this.Y.ToString(format, formatProvider));
			arg_11_0.Append(numberGroupSeparator);
			arg_11_0.Append(' ');
			arg_11_0.Append(this.Z.ToString(format, formatProvider));
			arg_11_0.Append(numberGroupSeparator);
			arg_11_0.Append(' ');
			arg_11_0.Append(this.W.ToString(format, formatProvider));
			arg_11_0.Append('>');
			return arg_11_0.ToString();
		}

		[MethodImpl(256)]
		public float Length()
		{
			if (Vector.IsHardwareAccelerated)
			{
				return (float)Math.Sqrt((double)Vector4.Dot(this, this));
			}
			return (float)Math.Sqrt((double)(this.X * this.X + this.Y * this.Y + this.Z * this.Z + this.W * this.W));
		}

		[MethodImpl(256)]
		public float LengthSquared()
		{
			if (Vector.IsHardwareAccelerated)
			{
				return Vector4.Dot(this, this);
			}
			return this.X * this.X + this.Y * this.Y + this.Z * this.Z + this.W * this.W;
		}

		[MethodImpl(256)]
		public static float Distance(Vector4 value1, Vector4 value2)
		{
			if (Vector.IsHardwareAccelerated)
			{
				Vector4 expr_0E = value1 - value2;
				return (float)Math.Sqrt((double)Vector4.Dot(expr_0E, expr_0E));
			}
			float arg_53_0 = value1.X - value2.X;
			float num = value1.Y - value2.Y;
			float num2 = value1.Z - value2.Z;
			float num3 = value1.W - value2.W;
			double arg_58_0 = (double)(arg_53_0 * arg_53_0);
			float expr_56 = num;
			double arg_5C_0 = arg_58_0 + (double)(expr_56 * expr_56);
			float expr_5A = num2;
			double arg_60_0 = arg_5C_0 + (double)(expr_5A * expr_5A);
			float expr_5E = num3;
			return (float)Math.Sqrt(arg_60_0 + (double)(expr_5E * expr_5E));
		}

		[MethodImpl(256)]
		public static float DistanceSquared(Vector4 value1, Vector4 value2)
		{
			if (Vector.IsHardwareAccelerated)
			{
				Vector4 expr_0E = value1 - value2;
				return Vector4.Dot(expr_0E, expr_0E);
			}
			float arg_4C_0 = value1.X - value2.X;
			float num = value1.Y - value2.Y;
			float num2 = value1.Z - value2.Z;
			float num3 = value1.W - value2.W;
			float arg_51_0 = arg_4C_0 * arg_4C_0;
			float expr_4F = num;
			float arg_55_0 = arg_51_0 + expr_4F * expr_4F;
			float expr_53 = num2;
			float arg_59_0 = arg_55_0 + expr_53 * expr_53;
			float expr_57 = num3;
			return arg_59_0 + expr_57 * expr_57;
		}

		[MethodImpl(256)]
		public static Vector4 Normalize(Vector4 vector)
		{
			if (Vector.IsHardwareAccelerated)
			{
				float value = vector.Length();
				return vector / value;
			}
			float num = vector.X * vector.X + vector.Y * vector.Y + vector.Z * vector.Z + vector.W * vector.W;
			float num2 = 1f / (float)Math.Sqrt((double)num);
			return new Vector4(vector.X * num2, vector.Y * num2, vector.Z * num2, vector.W * num2);
		}

		[MethodImpl(256)]
		public static Vector4 Clamp(Vector4 value1, Vector4 min, Vector4 max)
		{
			float num = value1.X;
			num = ((num > max.X) ? max.X : num);
			num = ((num < min.X) ? min.X : num);
			float num2 = value1.Y;
			num2 = ((num2 > max.Y) ? max.Y : num2);
			num2 = ((num2 < min.Y) ? min.Y : num2);
			float num3 = value1.Z;
			num3 = ((num3 > max.Z) ? max.Z : num3);
			num3 = ((num3 < min.Z) ? min.Z : num3);
			float num4 = value1.W;
			num4 = ((num4 > max.W) ? max.W : num4);
			num4 = ((num4 < min.W) ? min.W : num4);
			return new Vector4(num, num2, num3, num4);
		}

		[MethodImpl(256)]
		public static Vector4 Lerp(Vector4 value1, Vector4 value2, float amount)
		{
			return new Vector4(value1.X + (value2.X - value1.X) * amount, value1.Y + (value2.Y - value1.Y) * amount, value1.Z + (value2.Z - value1.Z) * amount, value1.W + (value2.W - value1.W) * amount);
		}

		[MethodImpl(256)]
		public static Vector4 Transform(Vector2 position, Matrix4x4 matrix)
		{
			return new Vector4(position.X * matrix.M11 + position.Y * matrix.M21 + matrix.M41, position.X * matrix.M12 + position.Y * matrix.M22 + matrix.M42, position.X * matrix.M13 + position.Y * matrix.M23 + matrix.M43, position.X * matrix.M14 + position.Y * matrix.M24 + matrix.M44);
		}

		[MethodImpl(256)]
		public static Vector4 Transform(Vector3 position, Matrix4x4 matrix)
		{
			return new Vector4(position.X * matrix.M11 + position.Y * matrix.M21 + position.Z * matrix.M31 + matrix.M41, position.X * matrix.M12 + position.Y * matrix.M22 + position.Z * matrix.M32 + matrix.M42, position.X * matrix.M13 + position.Y * matrix.M23 + position.Z * matrix.M33 + matrix.M43, position.X * matrix.M14 + position.Y * matrix.M24 + position.Z * matrix.M34 + matrix.M44);
		}

		[MethodImpl(256)]
		public static Vector4 Transform(Vector4 vector, Matrix4x4 matrix)
		{
			return new Vector4(vector.X * matrix.M11 + vector.Y * matrix.M21 + vector.Z * matrix.M31 + vector.W * matrix.M41, vector.X * matrix.M12 + vector.Y * matrix.M22 + vector.Z * matrix.M32 + vector.W * matrix.M42, vector.X * matrix.M13 + vector.Y * matrix.M23 + vector.Z * matrix.M33 + vector.W * matrix.M43, vector.X * matrix.M14 + vector.Y * matrix.M24 + vector.Z * matrix.M34 + vector.W * matrix.M44);
		}

		[MethodImpl(256)]
		public static Vector4 Transform(Vector2 value, Quaternion rotation)
		{
			float num = rotation.X + rotation.X;
			float num2 = rotation.Y + rotation.Y;
			float num3 = rotation.Z + rotation.Z;
			float num4 = rotation.W * num;
			float num5 = rotation.W * num2;
			float num6 = rotation.W * num3;
			float num7 = rotation.X * num;
			float num8 = rotation.X * num2;
			float num9 = rotation.X * num3;
			float num10 = rotation.Y * num2;
			float num11 = rotation.Y * num3;
			float num12 = rotation.Z * num3;
			return new Vector4(value.X * (1f - num10 - num12) + value.Y * (num8 - num6), value.X * (num8 + num6) + value.Y * (1f - num7 - num12), value.X * (num9 - num5) + value.Y * (num11 + num4), 1f);
		}

		[MethodImpl(256)]
		public static Vector4 Transform(Vector3 value, Quaternion rotation)
		{
			float num = rotation.X + rotation.X;
			float num2 = rotation.Y + rotation.Y;
			float num3 = rotation.Z + rotation.Z;
			float num4 = rotation.W * num;
			float num5 = rotation.W * num2;
			float num6 = rotation.W * num3;
			float num7 = rotation.X * num;
			float num8 = rotation.X * num2;
			float num9 = rotation.X * num3;
			float num10 = rotation.Y * num2;
			float num11 = rotation.Y * num3;
			float num12 = rotation.Z * num3;
			return new Vector4(value.X * (1f - num10 - num12) + value.Y * (num8 - num6) + value.Z * (num9 + num5), value.X * (num8 + num6) + value.Y * (1f - num7 - num12) + value.Z * (num11 - num4), value.X * (num9 - num5) + value.Y * (num11 + num4) + value.Z * (1f - num7 - num10), 1f);
		}

		[MethodImpl(256)]
		public static Vector4 Transform(Vector4 value, Quaternion rotation)
		{
			float num = rotation.X + rotation.X;
			float num2 = rotation.Y + rotation.Y;
			float num3 = rotation.Z + rotation.Z;
			float num4 = rotation.W * num;
			float num5 = rotation.W * num2;
			float num6 = rotation.W * num3;
			float num7 = rotation.X * num;
			float num8 = rotation.X * num2;
			float num9 = rotation.X * num3;
			float num10 = rotation.Y * num2;
			float num11 = rotation.Y * num3;
			float num12 = rotation.Z * num3;
			return new Vector4(value.X * (1f - num10 - num12) + value.Y * (num8 - num6) + value.Z * (num9 + num5), value.X * (num8 + num6) + value.Y * (1f - num7 - num12) + value.Z * (num11 - num4), value.X * (num9 - num5) + value.Y * (num11 + num4) + value.Z * (1f - num7 - num10), value.W);
		}

		[MethodImpl(256)]
		public static Vector4 Add(Vector4 left, Vector4 right)
		{
			return left + right;
		}

		[MethodImpl(256)]
		public static Vector4 Subtract(Vector4 left, Vector4 right)
		{
			return left - right;
		}

		[MethodImpl(256)]
		public static Vector4 Multiply(Vector4 left, Vector4 right)
		{
			return left * right;
		}

		[MethodImpl(256)]
		public static Vector4 Multiply(Vector4 left, float right)
		{
			return left * new Vector4(right, right, right, right);
		}

		[MethodImpl(256)]
		public static Vector4 Multiply(float left, Vector4 right)
		{
			return new Vector4(left, left, left, left) * right;
		}

		[MethodImpl(256)]
		public static Vector4 Divide(Vector4 left, Vector4 right)
		{
			return left / right;
		}

		[MethodImpl(256)]
		public static Vector4 Divide(Vector4 left, float divisor)
		{
			return left / divisor;
		}

		[MethodImpl(256)]
		public static Vector4 Negate(Vector4 value)
		{
			return -value;
		}

		[JitIntrinsic]
		public Vector4(float value)
		{
			this = new Vector4(value, value, value, value);
		}

		[JitIntrinsic]
		public Vector4(float x, float y, float z, float w)
		{
			this.W = w;
			this.X = x;
			this.Y = y;
			this.Z = z;
		}

		public Vector4(Vector2 value, float z, float w)
		{
			this.X = value.X;
			this.Y = value.Y;
			this.Z = z;
			this.W = w;
		}

		public Vector4(Vector3 value, float w)
		{
			this.X = value.X;
			this.Y = value.Y;
			this.Z = value.Z;
			this.W = w;
		}

		[MethodImpl(256)]
		public void CopyTo(float[] array)
		{
			this.CopyTo(array, 0);
		}

		[JitIntrinsic]
		[MethodImpl(256)]
		public void CopyTo(float[] array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("values");
			}
			if (index < 0 || index >= array.Length)
			{
				throw new ArgumentOutOfRangeException(SR.Format(SR.Arg_ArgumentOutOfRangeException, index));
			}
			if (array.Length - index < 4)
			{
				throw new ArgumentException(SR.Format(SR.Arg_ElementsInSourceIsGreaterThanDestination, index));
			}
			array[index] = this.X;
			array[index + 1] = this.Y;
			array[index + 2] = this.Z;
			array[index + 3] = this.W;
		}

		[JitIntrinsic]
		public bool Equals(Vector4 other)
		{
			return this.X == other.X && this.Y == other.Y && this.Z == other.Z && this.W == other.W;
		}

		[JitIntrinsic]
		[MethodImpl(256)]
		public static float Dot(Vector4 vector1, Vector4 vector2)
		{
			return vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z + vector1.W * vector2.W;
		}

		[JitIntrinsic]
		[MethodImpl(256)]
		public static Vector4 Min(Vector4 value1, Vector4 value2)
		{
			return new Vector4((value1.X < value2.X) ? value1.X : value2.X, (value1.Y < value2.Y) ? value1.Y : value2.Y, (value1.Z < value2.Z) ? value1.Z : value2.Z, (value1.W < value2.W) ? value1.W : value2.W);
		}

		[JitIntrinsic]
		[MethodImpl(256)]
		public static Vector4 Max(Vector4 value1, Vector4 value2)
		{
			return new Vector4((value1.X > value2.X) ? value1.X : value2.X, (value1.Y > value2.Y) ? value1.Y : value2.Y, (value1.Z > value2.Z) ? value1.Z : value2.Z, (value1.W > value2.W) ? value1.W : value2.W);
		}

		[JitIntrinsic]
		[MethodImpl(256)]
		public static Vector4 Abs(Vector4 value)
		{
			return new Vector4(Math.Abs(value.X), Math.Abs(value.Y), Math.Abs(value.Z), Math.Abs(value.W));
		}

		[JitIntrinsic]
		[MethodImpl(256)]
		public static Vector4 SquareRoot(Vector4 value)
		{
			return new Vector4((float)Math.Sqrt((double)value.X), (float)Math.Sqrt((double)value.Y), (float)Math.Sqrt((double)value.Z), (float)Math.Sqrt((double)value.W));
		}

		[JitIntrinsic]
		[MethodImpl(256)]
		public static Vector4 operator +(Vector4 left, Vector4 right)
		{
			return new Vector4(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);
		}

		[JitIntrinsic]
		[MethodImpl(256)]
		public static Vector4 operator -(Vector4 left, Vector4 right)
		{
			return new Vector4(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);
		}

		[JitIntrinsic]
		[MethodImpl(256)]
		public static Vector4 operator *(Vector4 left, Vector4 right)
		{
			return new Vector4(left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.W * right.W);
		}

		[JitIntrinsic]
		[MethodImpl(256)]
		public static Vector4 operator *(Vector4 left, float right)
		{
			return left * new Vector4(right);
		}

		[JitIntrinsic]
		[MethodImpl(256)]
		public static Vector4 operator *(float left, Vector4 right)
		{
			return new Vector4(left) * right;
		}

		[JitIntrinsic]
		[MethodImpl(256)]
		public static Vector4 operator /(Vector4 left, Vector4 right)
		{
			return new Vector4(left.X / right.X, left.Y / right.Y, left.Z / right.Z, left.W / right.W);
		}

		[JitIntrinsic]
		[MethodImpl(256)]
		public static Vector4 operator /(Vector4 value1, float value2)
		{
			float num = 1f / value2;
			return new Vector4(value1.X * num, value1.Y * num, value1.Z * num, value1.W * num);
		}

		[MethodImpl(256)]
		public static Vector4 operator -(Vector4 value)
		{
			return Vector4.Zero - value;
		}

		[JitIntrinsic]
		[MethodImpl(256)]
		public static bool operator ==(Vector4 left, Vector4 right)
		{
			return left.Equals(right);
		}

		[MethodImpl(256)]
		public static bool operator !=(Vector4 left, Vector4 right)
		{
			return !(left == right);
		}
	}
}
