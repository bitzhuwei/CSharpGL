using System;
using System.Globalization;

namespace System.Numerics
{
	public struct Quaternion : IEquatable<Quaternion>
	{
		public float X;

		public float Y;

		public float Z;

		public float W;

		public static Quaternion Identity
		{
			get
			{
				return new Quaternion(0f, 0f, 0f, 1f);
			}
		}

		public bool IsIdentity
		{
			get
			{
				return this.X == 0f && this.Y == 0f && this.Z == 0f && this.W == 1f;
			}
		}

		public Quaternion(float x, float y, float z, float w)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
			this.W = w;
		}

		public Quaternion(Vector3 vectorPart, float scalarPart)
		{
			this.X = vectorPart.X;
			this.Y = vectorPart.Y;
			this.Z = vectorPart.Z;
			this.W = scalarPart;
		}

		public float Length()
		{
			return (float)Math.Sqrt((double)(this.X * this.X + this.Y * this.Y + this.Z * this.Z + this.W * this.W));
		}

		public float LengthSquared()
		{
			return this.X * this.X + this.Y * this.Y + this.Z * this.Z + this.W * this.W;
		}

		public static Quaternion Normalize(Quaternion value)
		{
			float num = value.X * value.X + value.Y * value.Y + value.Z * value.Z + value.W * value.W;
			float num2 = 1f / (float)Math.Sqrt((double)num);
			Quaternion result;
			result.X = value.X * num2;
			result.Y = value.Y * num2;
			result.Z = value.Z * num2;
			result.W = value.W * num2;
			return result;
		}

		public static Quaternion Conjugate(Quaternion value)
		{
			Quaternion result;
			result.X = -value.X;
			result.Y = -value.Y;
			result.Z = -value.Z;
			result.W = value.W;
			return result;
		}

		public static Quaternion Inverse(Quaternion value)
		{
			float num = value.X * value.X + value.Y * value.Y + value.Z * value.Z + value.W * value.W;
			float num2 = 1f / num;
			Quaternion result;
			result.X = -value.X * num2;
			result.Y = -value.Y * num2;
			result.Z = -value.Z * num2;
			result.W = value.W * num2;
			return result;
		}

		public static Quaternion CreateFromAxisAngle(Vector3 axis, float angle)
		{
			float expr_07 = angle * 0.5f;
			float num = (float)Math.Sin((double)expr_07);
			float w = (float)Math.Cos((double)expr_07);
			Quaternion result;
			result.X = axis.X * num;
			result.Y = axis.Y * num;
			result.Z = axis.Z * num;
			result.W = w;
			return result;
		}

		public static Quaternion CreateFromYawPitchRoll(float yaw, float pitch, float roll)
		{
			float expr_07 = roll * 0.5f;
			float num = (float)Math.Sin((double)expr_07);
			float num2 = (float)Math.Cos((double)expr_07);
			float expr_1F = pitch * 0.5f;
			float num3 = (float)Math.Sin((double)expr_1F);
			float num4 = (float)Math.Cos((double)expr_1F);
			float expr_37 = yaw * 0.5f;
			float num5 = (float)Math.Sin((double)expr_37);
			float num6 = (float)Math.Cos((double)expr_37);
			Quaternion result;
			result.X = num6 * num3 * num2 + num5 * num4 * num;
			result.Y = num5 * num4 * num2 - num6 * num3 * num;
			result.Z = num6 * num4 * num - num5 * num3 * num2;
			result.W = num6 * num4 * num2 + num5 * num3 * num;
			return result;
		}

		public static Quaternion CreateFromRotationMatrix(Matrix4x4 matrix)
		{
			float num = matrix.M11 + matrix.M22 + matrix.M33;
			Quaternion result = default(Quaternion);
			if (num > 0f)
			{
				float num2 = (float)Math.Sqrt((double)(num + 1f));
				result.W = num2 * 0.5f;
				num2 = 0.5f / num2;
				result.X = (matrix.M23 - matrix.M32) * num2;
				result.Y = (matrix.M31 - matrix.M13) * num2;
				result.Z = (matrix.M12 - matrix.M21) * num2;
			}
			else if (matrix.M11 >= matrix.M22 && matrix.M11 >= matrix.M33)
			{
				float num3 = (float)Math.Sqrt((double)(1f + matrix.M11 - matrix.M22 - matrix.M33));
				float num4 = 0.5f / num3;
				result.X = 0.5f * num3;
				result.Y = (matrix.M12 + matrix.M21) * num4;
				result.Z = (matrix.M13 + matrix.M31) * num4;
				result.W = (matrix.M23 - matrix.M32) * num4;
			}
			else if (matrix.M22 > matrix.M33)
			{
				float num5 = (float)Math.Sqrt((double)(1f + matrix.M22 - matrix.M11 - matrix.M33));
				float num6 = 0.5f / num5;
				result.X = (matrix.M21 + matrix.M12) * num6;
				result.Y = 0.5f * num5;
				result.Z = (matrix.M32 + matrix.M23) * num6;
				result.W = (matrix.M31 - matrix.M13) * num6;
			}
			else
			{
				float num7 = (float)Math.Sqrt((double)(1f + matrix.M33 - matrix.M11 - matrix.M22));
				float num8 = 0.5f / num7;
				result.X = (matrix.M31 + matrix.M13) * num8;
				result.Y = (matrix.M32 + matrix.M23) * num8;
				result.Z = 0.5f * num7;
				result.W = (matrix.M12 - matrix.M21) * num8;
			}
			return result;
		}

		public static float Dot(Quaternion quaternion1, Quaternion quaternion2)
		{
			return quaternion1.X * quaternion2.X + quaternion1.Y * quaternion2.Y + quaternion1.Z * quaternion2.Z + quaternion1.W * quaternion2.W;
		}

		public static Quaternion Slerp(Quaternion quaternion1, Quaternion quaternion2, float amount)
		{
			float num = quaternion1.X * quaternion2.X + quaternion1.Y * quaternion2.Y + quaternion1.Z * quaternion2.Z + quaternion1.W * quaternion2.W;
			bool flag = false;
			if (num < 0f)
			{
				flag = true;
				num = -num;
			}
			float num2;
			float num3;
			if (num > 0.999999f)
			{
				num2 = 1f - amount;
				num3 = (flag ? (-amount) : amount);
			}
			else
			{
				float num4 = (float)Math.Acos((double)num);
				float num5 = (float)(1.0 / Math.Sin((double)num4));
				num2 = (float)Math.Sin((double)((1f - amount) * num4)) * num5;
				num3 = (flag ? ((float)(-(float)Math.Sin((double)(amount * num4))) * num5) : ((float)Math.Sin((double)(amount * num4)) * num5));
			}
			Quaternion result;
			result.X = num2 * quaternion1.X + num3 * quaternion2.X;
			result.Y = num2 * quaternion1.Y + num3 * quaternion2.Y;
			result.Z = num2 * quaternion1.Z + num3 * quaternion2.Z;
			result.W = num2 * quaternion1.W + num3 * quaternion2.W;
			return result;
		}

		public static Quaternion Lerp(Quaternion quaternion1, Quaternion quaternion2, float amount)
		{
			float num = 1f - amount;
			Quaternion quaternion3 = default(Quaternion);
			if (quaternion1.X * quaternion2.X + quaternion1.Y * quaternion2.Y + quaternion1.Z * quaternion2.Z + quaternion1.W * quaternion2.W >= 0f)
			{
				quaternion3.X = num * quaternion1.X + amount * quaternion2.X;
				quaternion3.Y = num * quaternion1.Y + amount * quaternion2.Y;
				quaternion3.Z = num * quaternion1.Z + amount * quaternion2.Z;
				quaternion3.W = num * quaternion1.W + amount * quaternion2.W;
			}
			else
			{
				quaternion3.X = num * quaternion1.X - amount * quaternion2.X;
				quaternion3.Y = num * quaternion1.Y - amount * quaternion2.Y;
				quaternion3.Z = num * quaternion1.Z - amount * quaternion2.Z;
				quaternion3.W = num * quaternion1.W - amount * quaternion2.W;
			}
			float num2 = quaternion3.X * quaternion3.X + quaternion3.Y * quaternion3.Y + quaternion3.Z * quaternion3.Z + quaternion3.W * quaternion3.W;
			float num3 = 1f / (float)Math.Sqrt((double)num2);
			quaternion3.X *= num3;
			quaternion3.Y *= num3;
			quaternion3.Z *= num3;
			quaternion3.W *= num3;
			return quaternion3;
		}

		public static Quaternion Concatenate(Quaternion value1, Quaternion value2)
		{
			float x = value2.X;
			float y = value2.Y;
			float z = value2.Z;
			float w = value2.W;
			float x2 = value1.X;
			float y2 = value1.Y;
			float z2 = value1.Z;
			float w2 = value1.W;
			float num = y * z2 - z * y2;
			float num2 = z * x2 - x * z2;
			float num3 = x * y2 - y * x2;
			float num4 = x * x2 + y * y2 + z * z2;
			Quaternion result;
			result.X = x * w2 + x2 * w + num;
			result.Y = y * w2 + y2 * w + num2;
			result.Z = z * w2 + z2 * w + num3;
			result.W = w * w2 - num4;
			return result;
		}

		public static Quaternion Negate(Quaternion value)
		{
			Quaternion result;
			result.X = -value.X;
			result.Y = -value.Y;
			result.Z = -value.Z;
			result.W = -value.W;
			return result;
		}

		public static Quaternion Add(Quaternion value1, Quaternion value2)
		{
			Quaternion result;
			result.X = value1.X + value2.X;
			result.Y = value1.Y + value2.Y;
			result.Z = value1.Z + value2.Z;
			result.W = value1.W + value2.W;
			return result;
		}

		public static Quaternion Subtract(Quaternion value1, Quaternion value2)
		{
			Quaternion result;
			result.X = value1.X - value2.X;
			result.Y = value1.Y - value2.Y;
			result.Z = value1.Z - value2.Z;
			result.W = value1.W - value2.W;
			return result;
		}

		public static Quaternion Multiply(Quaternion value1, Quaternion value2)
		{
			float x = value1.X;
			float y = value1.Y;
			float z = value1.Z;
			float w = value1.W;
			float x2 = value2.X;
			float y2 = value2.Y;
			float z2 = value2.Z;
			float w2 = value2.W;
			float num = y * z2 - z * y2;
			float num2 = z * x2 - x * z2;
			float num3 = x * y2 - y * x2;
			float num4 = x * x2 + y * y2 + z * z2;
			Quaternion result;
			result.X = x * w2 + x2 * w + num;
			result.Y = y * w2 + y2 * w + num2;
			result.Z = z * w2 + z2 * w + num3;
			result.W = w * w2 - num4;
			return result;
		}

		public static Quaternion Multiply(Quaternion value1, float value2)
		{
			Quaternion result;
			result.X = value1.X * value2;
			result.Y = value1.Y * value2;
			result.Z = value1.Z * value2;
			result.W = value1.W * value2;
			return result;
		}

		public static Quaternion Divide(Quaternion value1, Quaternion value2)
		{
			float x = value1.X;
			float y = value1.Y;
			float z = value1.Z;
			float w = value1.W;
			float num = value2.X * value2.X + value2.Y * value2.Y + value2.Z * value2.Z + value2.W * value2.W;
			float num2 = 1f / num;
			float num3 = -value2.X * num2;
			float num4 = -value2.Y * num2;
			float num5 = -value2.Z * num2;
			float num6 = value2.W * num2;
			float num7 = y * num5 - z * num4;
			float num8 = z * num3 - x * num5;
			float num9 = x * num4 - y * num3;
			float num10 = x * num3 + y * num4 + z * num5;
			Quaternion result;
			result.X = x * num6 + num3 * w + num7;
			result.Y = y * num6 + num4 * w + num8;
			result.Z = z * num6 + num5 * w + num9;
			result.W = w * num6 - num10;
			return result;
		}

		public static Quaternion operator -(Quaternion value)
		{
			Quaternion result;
			result.X = -value.X;
			result.Y = -value.Y;
			result.Z = -value.Z;
			result.W = -value.W;
			return result;
		}

		public static Quaternion operator +(Quaternion value1, Quaternion value2)
		{
			Quaternion result;
			result.X = value1.X + value2.X;
			result.Y = value1.Y + value2.Y;
			result.Z = value1.Z + value2.Z;
			result.W = value1.W + value2.W;
			return result;
		}

		public static Quaternion operator -(Quaternion value1, Quaternion value2)
		{
			Quaternion result;
			result.X = value1.X - value2.X;
			result.Y = value1.Y - value2.Y;
			result.Z = value1.Z - value2.Z;
			result.W = value1.W - value2.W;
			return result;
		}

		public static Quaternion operator *(Quaternion value1, Quaternion value2)
		{
			float x = value1.X;
			float y = value1.Y;
			float z = value1.Z;
			float w = value1.W;
			float x2 = value2.X;
			float y2 = value2.Y;
			float z2 = value2.Z;
			float w2 = value2.W;
			float num = y * z2 - z * y2;
			float num2 = z * x2 - x * z2;
			float num3 = x * y2 - y * x2;
			float num4 = x * x2 + y * y2 + z * z2;
			Quaternion result;
			result.X = x * w2 + x2 * w + num;
			result.Y = y * w2 + y2 * w + num2;
			result.Z = z * w2 + z2 * w + num3;
			result.W = w * w2 - num4;
			return result;
		}

		public static Quaternion operator *(Quaternion value1, float value2)
		{
			Quaternion result;
			result.X = value1.X * value2;
			result.Y = value1.Y * value2;
			result.Z = value1.Z * value2;
			result.W = value1.W * value2;
			return result;
		}

		public static Quaternion operator /(Quaternion value1, Quaternion value2)
		{
			float x = value1.X;
			float y = value1.Y;
			float z = value1.Z;
			float w = value1.W;
			float num = value2.X * value2.X + value2.Y * value2.Y + value2.Z * value2.Z + value2.W * value2.W;
			float num2 = 1f / num;
			float num3 = -value2.X * num2;
			float num4 = -value2.Y * num2;
			float num5 = -value2.Z * num2;
			float num6 = value2.W * num2;
			float num7 = y * num5 - z * num4;
			float num8 = z * num3 - x * num5;
			float num9 = x * num4 - y * num3;
			float num10 = x * num3 + y * num4 + z * num5;
			Quaternion result;
			result.X = x * num6 + num3 * w + num7;
			result.Y = y * num6 + num4 * w + num8;
			result.Z = z * num6 + num5 * w + num9;
			result.W = w * num6 - num10;
			return result;
		}

		public static bool operator ==(Quaternion value1, Quaternion value2)
		{
			return value1.X == value2.X && value1.Y == value2.Y && value1.Z == value2.Z && value1.W == value2.W;
		}

		public static bool operator !=(Quaternion value1, Quaternion value2)
		{
			return value1.X != value2.X || value1.Y != value2.Y || value1.Z != value2.Z || value1.W != value2.W;
		}

		public bool Equals(Quaternion other)
		{
			return this.X == other.X && this.Y == other.Y && this.Z == other.Z && this.W == other.W;
		}

		public override bool Equals(object obj)
		{
			return obj is Quaternion && this.Equals((Quaternion)obj);
		}

		public override string ToString()
		{
			CultureInfo currentCulture = CultureInfo.get_CurrentCulture();
			return string.Format(currentCulture, "{{X:{0} Y:{1} Z:{2} W:{3}}}", new object[]
			{
				this.X.ToString(currentCulture),
				this.Y.ToString(currentCulture),
				this.Z.ToString(currentCulture),
				this.W.ToString(currentCulture)
			});
		}

		public override int GetHashCode()
		{
			return this.X.GetHashCode() + this.Y.GetHashCode() + this.Z.GetHashCode() + this.W.GetHashCode();
		}
	}
}
