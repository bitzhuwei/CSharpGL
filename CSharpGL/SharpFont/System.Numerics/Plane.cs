using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace System.Numerics
{
	public struct Plane : IEquatable<Plane>
	{
		public Vector3 Normal;

		public float D;

		public Plane(float x, float y, float z, float d)
		{
			this.Normal = new Vector3(x, y, z);
			this.D = d;
		}

		public Plane(Vector3 normal, float d)
		{
			this.Normal = normal;
			this.D = d;
		}

		public Plane(Vector4 value)
		{
			this.Normal = new Vector3(value.X, value.Y, value.Z);
			this.D = value.W;
		}

		[MethodImpl(256)]
		public static Plane CreateFromVertices(Vector3 point1, Vector3 point2, Vector3 point3)
		{
			if (Vector.IsHardwareAccelerated)
			{
				Vector3 arg_17_0 = point2 - point1;
				Vector3 vector = point3 - point1;
				Vector3 expr_21 = Vector3.Normalize(Vector3.Cross(arg_17_0, vector));
				float d = -Vector3.Dot(expr_21, point1);
				return new Plane(expr_21, d);
			}
			float num = point2.X - point1.X;
			float num2 = point2.Y - point1.Y;
			float num3 = point2.Z - point1.Z;
			float num4 = point3.X - point1.X;
			float num5 = point3.Y - point1.Y;
			float num6 = point3.Z - point1.Z;
			float num7 = num2 * num6 - num3 * num5;
			float num8 = num3 * num4 - num * num6;
			float num9 = num * num5 - num2 * num4;
			float expr_AE = num7;
			float arg_B4_0 = expr_AE * expr_AE;
			float expr_B2 = num8;
			float arg_B9_0 = arg_B4_0 + expr_B2 * expr_B2;
			float expr_B7 = num9;
			float num10 = arg_B9_0 + expr_B7 * expr_B7;
			float num11 = 1f / (float)Math.Sqrt((double)num10);
			Vector3 vector2 = new Vector3(num7 * num11, num8 * num11, num9 * num11);
			Vector3 expr_E5 = vector2;
			return new Plane(expr_E5, -(expr_E5.X * point1.X + vector2.Y * point1.Y + vector2.Z * point1.Z));
		}

		[MethodImpl(256)]
		public static Plane Normalize(Plane value)
		{
			if (Vector.IsHardwareAccelerated)
			{
				float num = value.Normal.LengthSquared();
				if (Math.Abs(num - 1f) < 1.1920929E-07f)
				{
					return value;
				}
				float num2 = (float)Math.Sqrt((double)num);
				return new Plane(value.Normal / num2, value.D / num2);
			}
			else
			{
				float num3 = value.Normal.X * value.Normal.X + value.Normal.Y * value.Normal.Y + value.Normal.Z * value.Normal.Z;
				if (Math.Abs(num3 - 1f) < 1.1920929E-07f)
				{
					return value;
				}
				float num4 = 1f / (float)Math.Sqrt((double)num3);
				return new Plane(value.Normal.X * num4, value.Normal.Y * num4, value.Normal.Z * num4, value.D * num4);
			}
		}

		[MethodImpl(256)]
		public static Plane Transform(Plane plane, Matrix4x4 matrix)
		{
			Matrix4x4 matrix4x;
			Matrix4x4.Invert(matrix, out matrix4x);
			float x = plane.Normal.X;
			float y = plane.Normal.Y;
			float z = plane.Normal.Z;
			float d = plane.D;
			return new Plane(x * matrix4x.M11 + y * matrix4x.M12 + z * matrix4x.M13 + d * matrix4x.M14, x * matrix4x.M21 + y * matrix4x.M22 + z * matrix4x.M23 + d * matrix4x.M24, x * matrix4x.M31 + y * matrix4x.M32 + z * matrix4x.M33 + d * matrix4x.M34, x * matrix4x.M41 + y * matrix4x.M42 + z * matrix4x.M43 + d * matrix4x.M44);
		}

		[MethodImpl(256)]
		public static Plane Transform(Plane plane, Quaternion rotation)
		{
			float num = rotation.X + rotation.X;
			float num2 = rotation.Y + rotation.Y;
			float num3 = rotation.Z + rotation.Z;
			float num4 = rotation.W * num;
			float num5 = rotation.W * num2;
			float num6 = rotation.W * num3;
			float num7 = rotation.X * num;
			float arg_8E_0 = rotation.X * num2;
			float num8 = rotation.X * num3;
			float num9 = rotation.Y * num2;
			float num10 = rotation.Y * num3;
			float num11 = rotation.Z * num3;
			float num12 = 1f - num9 - num11;
			float num13 = arg_8E_0 - num6;
			float num14 = num8 + num5;
			float num15 = arg_8E_0 + num6;
			float num16 = 1f - num7 - num11;
			float num17 = num10 - num4;
			float num18 = num8 - num5;
			float num19 = num10 + num4;
			float num20 = 1f - num7 - num9;
			float x = plane.Normal.X;
			float y = plane.Normal.Y;
			float z = plane.Normal.Z;
			return new Plane(x * num12 + y * num13 + z * num14, x * num15 + y * num16 + z * num17, x * num18 + y * num19 + z * num20, plane.D);
		}

		[MethodImpl(256)]
		public static float Dot(Plane plane, Vector4 value)
		{
			return plane.Normal.X * value.X + plane.Normal.Y * value.Y + plane.Normal.Z * value.Z + plane.D * value.W;
		}

		[MethodImpl(256)]
		public static float DotCoordinate(Plane plane, Vector3 value)
		{
			if (Vector.IsHardwareAccelerated)
			{
				return Vector3.Dot(plane.Normal, value) + plane.D;
			}
			return plane.Normal.X * value.X + plane.Normal.Y * value.Y + plane.Normal.Z * value.Z + plane.D;
		}

		[MethodImpl(256)]
		public static float DotNormal(Plane plane, Vector3 value)
		{
			if (Vector.IsHardwareAccelerated)
			{
				return Vector3.Dot(plane.Normal, value);
			}
			return plane.Normal.X * value.X + plane.Normal.Y * value.Y + plane.Normal.Z * value.Z;
		}

		[MethodImpl(256)]
		public static bool operator ==(Plane value1, Plane value2)
		{
			return value1.Normal.X == value2.Normal.X && value1.Normal.Y == value2.Normal.Y && value1.Normal.Z == value2.Normal.Z && value1.D == value2.D;
		}

		[MethodImpl(256)]
		public static bool operator !=(Plane value1, Plane value2)
		{
			return value1.Normal.X != value2.Normal.X || value1.Normal.Y != value2.Normal.Y || value1.Normal.Z != value2.Normal.Z || value1.D != value2.D;
		}

		[MethodImpl(256)]
		public bool Equals(Plane other)
		{
			if (Vector.IsHardwareAccelerated)
			{
				return this.Normal.Equals(other.Normal) && this.D == other.D;
			}
			return this.Normal.X == other.Normal.X && this.Normal.Y == other.Normal.Y && this.Normal.Z == other.Normal.Z && this.D == other.D;
		}

		[MethodImpl(256)]
		public override bool Equals(object obj)
		{
			return obj is Plane && this.Equals((Plane)obj);
		}

		public override string ToString()
		{
			CultureInfo currentCulture = CultureInfo.get_CurrentCulture();
			return string.Format(currentCulture, "{{Normal:{0} D:{1}}}", this.Normal.ToString(), this.D.ToString(currentCulture));
		}

		public override int GetHashCode()
		{
			return this.Normal.GetHashCode() + this.D.GetHashCode();
		}
	}
}
