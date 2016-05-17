using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace System.Numerics
{
	public struct Vector3 : IEquatable<Vector3>, IFormattable
	{
		public float X;

		public float Y;

		public float Z;

		public static Vector3 Zero
		{
			get
			{
				return default(Vector3);
			}
		}

		public static Vector3 One
		{
			get
			{
				return new Vector3(1f, 1f, 1f);
			}
		}

		public static Vector3 UnitX
		{
			get
			{
				return new Vector3(1f, 0f, 0f);
			}
		}

		public static Vector3 UnitY
		{
			get
			{
				return new Vector3(0f, 1f, 0f);
			}
		}

		public static Vector3 UnitZ
		{
			get
			{
				return new Vector3(0f, 0f, 1f);
			}
		}

		public override int GetHashCode()
		{
			return HashCodeHelper.CombineHashCodes(HashCodeHelper.CombineHashCodes(this.X.GetHashCode(), this.Y.GetHashCode()), this.Z.GetHashCode());
		}

		[MethodImpl(256)]
		public override bool Equals(object obj)
		{
			return obj is Vector3 && this.Equals((Vector3)obj);
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
			arg_11_0.Append('>');
			return arg_11_0.ToString();
		}

		[MethodImpl(256)]
		public float Length()
		{
			if (Vector.IsHardwareAccelerated)
			{
				return (float)Math.Sqrt((double)Vector3.Dot(this, this));
			}
			return (float)Math.Sqrt((double)(this.X * this.X + this.Y * this.Y + this.Z * this.Z));
		}

		[MethodImpl(256)]
		public float LengthSquared()
		{
			if (Vector.IsHardwareAccelerated)
			{
				return Vector3.Dot(this, this);
			}
			return this.X * this.X + this.Y * this.Y + this.Z * this.Z;
		}

		[MethodImpl(256)]
		public static float Distance(Vector3 value1, Vector3 value2)
		{
			if (Vector.IsHardwareAccelerated)
			{
				Vector3 expr_0E = value1 - value2;
				return (float)Math.Sqrt((double)Vector3.Dot(expr_0E, expr_0E));
			}
			float arg_45_0 = value1.X - value2.X;
			float num = value1.Y - value2.Y;
			float num2 = value1.Z - value2.Z;
			double arg_4A_0 = (double)(arg_45_0 * arg_45_0);
			float expr_48 = num;
			double arg_4E_0 = arg_4A_0 + (double)(expr_48 * expr_48);
			float expr_4C = num2;
			return (float)Math.Sqrt(arg_4E_0 + (double)(expr_4C * expr_4C));
		}

		[MethodImpl(256)]
		public static float DistanceSquared(Vector3 value1, Vector3 value2)
		{
			if (Vector.IsHardwareAccelerated)
			{
				Vector3 expr_0E = value1 - value2;
				return Vector3.Dot(expr_0E, expr_0E);
			}
			float arg_3E_0 = value1.X - value2.X;
			float num = value1.Y - value2.Y;
			float num2 = value1.Z - value2.Z;
			float arg_43_0 = arg_3E_0 * arg_3E_0;
			float expr_41 = num;
			float arg_47_0 = arg_43_0 + expr_41 * expr_41;
			float expr_45 = num2;
			return arg_47_0 + expr_45 * expr_45;
		}

		[MethodImpl(256)]
		public static Vector3 Normalize(Vector3 value)
		{
			if (Vector.IsHardwareAccelerated)
			{
				float value2 = value.Length();
				return value / value2;
			}
			float num = (float)Math.Sqrt((double)(value.X * value.X + value.Y * value.Y + value.Z * value.Z));
			return new Vector3(value.X / num, value.Y / num, value.Z / num);
		}

		[MethodImpl(256)]
		public static Vector3 Cross(Vector3 vector1, Vector3 vector2)
		{
			return new Vector3(vector1.Y * vector2.Z - vector1.Z * vector2.Y, vector1.Z * vector2.X - vector1.X * vector2.Z, vector1.X * vector2.Y - vector1.Y * vector2.X);
		}

		[MethodImpl(256)]
		public static Vector3 Reflect(Vector3 vector, Vector3 normal)
		{
			if (Vector.IsHardwareAccelerated)
			{
				float right = Vector3.Dot(vector, normal);
				Vector3 right2 = normal * right * 2f;
				return vector - right2;
			}
			float num = vector.X * normal.X + vector.Y * normal.Y + vector.Z * normal.Z;
			float num2 = normal.X * num * 2f;
			float num3 = normal.Y * num * 2f;
			float num4 = normal.Z * num * 2f;
			return new Vector3(vector.X - num2, vector.Y - num3, vector.Z - num4);
		}

		[MethodImpl(256)]
		public static Vector3 Clamp(Vector3 value1, Vector3 min, Vector3 max)
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
			return new Vector3(num, num2, num3);
		}

		[MethodImpl(256)]
		public static Vector3 Lerp(Vector3 value1, Vector3 value2, float amount)
		{
			if (Vector.IsHardwareAccelerated)
			{
				Vector3 arg_1D_0 = value1 * (1f - amount);
				Vector3 right = value2 * amount;
				return arg_1D_0 + right;
			}
			return new Vector3(value1.X + (value2.X - value1.X) * amount, value1.Y + (value2.Y - value1.Y) * amount, value1.Z + (value2.Z - value1.Z) * amount);
		}

		[MethodImpl(256)]
		public static Vector3 Transform(Vector3 position, Matrix4x4 matrix)
		{
			return new Vector3(position.X * matrix.M11 + position.Y * matrix.M21 + position.Z * matrix.M31 + matrix.M41, position.X * matrix.M12 + position.Y * matrix.M22 + position.Z * matrix.M32 + matrix.M42, position.X * matrix.M13 + position.Y * matrix.M23 + position.Z * matrix.M33 + matrix.M43);
		}

		[MethodImpl(256)]
		public static Vector3 TransformNormal(Vector3 normal, Matrix4x4 matrix)
		{
			return new Vector3(normal.X * matrix.M11 + normal.Y * matrix.M21 + normal.Z * matrix.M31, normal.X * matrix.M12 + normal.Y * matrix.M22 + normal.Z * matrix.M32, normal.X * matrix.M13 + normal.Y * matrix.M23 + normal.Z * matrix.M33);
		}

		[MethodImpl(256)]
		public static Vector3 Transform(Vector3 value, Quaternion rotation)
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
			return new Vector3(value.X * (1f - num10 - num12) + value.Y * (num8 - num6) + value.Z * (num9 + num5), value.X * (num8 + num6) + value.Y * (1f - num7 - num12) + value.Z * (num11 - num4), value.X * (num9 - num5) + value.Y * (num11 + num4) + value.Z * (1f - num7 - num10));
		}

		[MethodImpl(256)]
		public static Vector3 Add(Vector3 left, Vector3 right)
		{
			return left + right;
		}

		[MethodImpl(256)]
		public static Vector3 Subtract(Vector3 left, Vector3 right)
		{
			return left - right;
		}

		[MethodImpl(256)]
		public static Vector3 Multiply(Vector3 left, Vector3 right)
		{
			return left * right;
		}

		[MethodImpl(256)]
		public static Vector3 Multiply(Vector3 left, float right)
		{
			return left * right;
		}

		[MethodImpl(256)]
		public static Vector3 Multiply(float left, Vector3 right)
		{
			return left * right;
		}

		[MethodImpl(256)]
		public static Vector3 Divide(Vector3 left, Vector3 right)
		{
			return left / right;
		}

		[MethodImpl(256)]
		public static Vector3 Divide(Vector3 left, float divisor)
		{
			return left / divisor;
		}

		[MethodImpl(256)]
		public static Vector3 Negate(Vector3 value)
		{
			return -value;
		}

		[JitIntrinsic]
		public Vector3(float value)
		{
			this = new Vector3(value, value, value);
		}

		public Vector3(Vector2 value, float z)
		{
			this = new Vector3(value.X, value.Y, z);
		}

		[JitIntrinsic]
		public Vector3(float x, float y, float z)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
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
			if (array.Length - index < 3)
			{
				throw new ArgumentException(SR.Format(SR.Arg_ElementsInSourceIsGreaterThanDestination, index));
			}
			array[index] = this.X;
			array[index + 1] = this.Y;
			array[index + 2] = this.Z;
		}

		[JitIntrinsic]
		public bool Equals(Vector3 other)
		{
			return this.X == other.X && this.Y == other.Y && this.Z == other.Z;
		}

		[JitIntrinsic]
		[MethodImpl(256)]
		public static float Dot(Vector3 vector1, Vector3 vector2)
		{
			return vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z;
		}

		[JitIntrinsic]
		public static Vector3 Min(Vector3 value1, Vector3 value2)
		{
			return new Vector3((value1.X < value2.X) ? value1.X : value2.X, (value1.Y < value2.Y) ? value1.Y : value2.Y, (value1.Z < value2.Z) ? value1.Z : value2.Z);
		}

		[JitIntrinsic]
		[MethodImpl(256)]
		public static Vector3 Max(Vector3 value1, Vector3 value2)
		{
			return new Vector3((value1.X > value2.X) ? value1.X : value2.X, (value1.Y > value2.Y) ? value1.Y : value2.Y, (value1.Z > value2.Z) ? value1.Z : value2.Z);
		}

		[JitIntrinsic]
		[MethodImpl(256)]
		public static Vector3 Abs(Vector3 value)
		{
			return new Vector3(Math.Abs(value.X), Math.Abs(value.Y), Math.Abs(value.Z));
		}

		[JitIntrinsic]
		[MethodImpl(256)]
		public static Vector3 SquareRoot(Vector3 value)
		{
			return new Vector3((float)Math.Sqrt((double)value.X), (float)Math.Sqrt((double)value.Y), (float)Math.Sqrt((double)value.Z));
		}

		[JitIntrinsic]
		[MethodImpl(256)]
		public static Vector3 operator +(Vector3 left, Vector3 right)
		{
			return new Vector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
		}

		[JitIntrinsic]
		[MethodImpl(256)]
		public static Vector3 operator -(Vector3 left, Vector3 right)
		{
			return new Vector3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
		}

		[JitIntrinsic]
		[MethodImpl(256)]
		public static Vector3 operator *(Vector3 left, Vector3 right)
		{
			return new Vector3(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
		}

		[JitIntrinsic]
		[MethodImpl(256)]
		public static Vector3 operator *(Vector3 left, float right)
		{
			return left * new Vector3(right);
		}

		[JitIntrinsic]
		[MethodImpl(256)]
		public static Vector3 operator *(float left, Vector3 right)
		{
			return new Vector3(left) * right;
		}

		[JitIntrinsic]
		[MethodImpl(256)]
		public static Vector3 operator /(Vector3 left, Vector3 right)
		{
			return new Vector3(left.X / right.X, left.Y / right.Y, left.Z / right.Z);
		}

		[JitIntrinsic]
		[MethodImpl(256)]
		public static Vector3 operator /(Vector3 value1, float value2)
		{
			float num = 1f / value2;
			return new Vector3(value1.X * num, value1.Y * num, value1.Z * num);
		}

		[MethodImpl(256)]
		public static Vector3 operator -(Vector3 value)
		{
			return Vector3.Zero - value;
		}

		[JitIntrinsic]
		[MethodImpl(256)]
		public static bool operator ==(Vector3 left, Vector3 right)
		{
			return left.X == right.X && left.Y == right.Y && left.Z == right.Z;
		}

		[MethodImpl(256)]
		public static bool operator !=(Vector3 left, Vector3 right)
		{
			return left.X != right.X || left.Y != right.Y || left.Z != right.Z;
		}
	}
}
