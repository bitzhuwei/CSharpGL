using System;
using System.Globalization;

namespace System.Numerics
{
    public struct Matrix3x2 : IEquatable<Matrix3x2>
    {
        public float M11; public float M12;
        public float M21; public float M22;
        public float M31; public float M32;

        public static readonly Matrix3x2 Identity = new Matrix3x2(
            1f, 0f,
            0f, 1f,
            0f, 0f);

        public bool IsIdentity
        {
            get
            {
                return this.M11 == 1f && this.M22 == 1f && this.M12 == 0f && this.M21 == 0f && this.M31 == 0f && this.M32 == 0f;
            }
        }

        public Vector2 Translation
        {
            get
            {
                return new Vector2(this.M31, this.M32);
            }
            set
            {
                this.M31 = value.X;
                this.M32 = value.Y;
            }
        }

        public Matrix3x2(float m11, float m12, float m21, float m22, float m31, float m32)
        {
            this.M11 = m11; this.M12 = m12;
            this.M21 = m21; this.M22 = m22;
            this.M31 = m31; this.M32 = m32;
        }

        public static Matrix3x2 CreateTranslation(Vector2 position)
        {
            Matrix3x2 result;
            result.M11 = 1f; result.M12 = 0f;
            result.M21 = 0f; result.M22 = 1f;
            result.M31 = position.X; result.M32 = position.Y;
            return result;
        }

        public static Matrix3x2 CreateTranslation(float xPosition, float yPosition)
        {
            Matrix3x2 result;
            result.M11 = 1f; result.M12 = 0f;
            result.M21 = 0f; result.M22 = 1f;
            result.M31 = xPosition; result.M32 = yPosition;
            return result;
        }

        public static Matrix3x2 CreateScale(float xScale, float yScale)
        {
            Matrix3x2 result;
            result.M11 = xScale; result.M12 = 0f;
            result.M21 = 0f; result.M22 = yScale;
            result.M31 = 0f; result.M32 = 0f;
            return result;
        }

        public static Matrix3x2 CreateScale(float xScale, float yScale, Vector2 centerPoint)
        {
            float m = centerPoint.X * (1f - xScale);
            float m2 = centerPoint.Y * (1f - yScale);
            Matrix3x2 result;
            result.M11 = xScale; result.M12 = 0f;
            result.M21 = 0f; result.M22 = yScale;
            result.M31 = m; result.M32 = m2;
            return result;
        }

        public static Matrix3x2 CreateScale(Vector2 scales)
        {
            Matrix3x2 result;
            result.M11 = scales.X; result.M12 = 0f;
            result.M21 = 0f; result.M22 = scales.Y;
            result.M31 = 0f; result.M32 = 0f;
            return result;
        }

        public static Matrix3x2 CreateScale(Vector2 scales, Vector2 centerPoint)
        {
            float m = centerPoint.X * (1f - scales.X);
            float m2 = centerPoint.Y * (1f - scales.Y);
            Matrix3x2 result;
            result.M11 = scales.X; result.M12 = 0f;
            result.M21 = 0f; result.M22 = scales.Y;
            result.M31 = m; result.M32 = m2;
            return result;
        }

        public static Matrix3x2 CreateScale(float scale)
        {
            Matrix3x2 result;
            result.M11 = scale; result.M12 = 0f;
            result.M21 = 0f; result.M22 = scale;
            result.M31 = 0f; result.M32 = 0f;
            return result;
        }

        public static Matrix3x2 CreateScale(float scale, Vector2 centerPoint)
        {
            float m = centerPoint.X * (1f - scale);
            float m2 = centerPoint.Y * (1f - scale);
            Matrix3x2 result;
            result.M11 = scale; result.M12 = 0f;
            result.M21 = 0f; result.M22 = scale;
            result.M31 = m; result.M32 = m2;
            return result;
        }

        public static Matrix3x2 CreateSkew(float radiansX, float radiansY)
        {
            float m = (float)Math.Tan((double)radiansX);
            float m2 = (float)Math.Tan((double)radiansY);
            Matrix3x2 result;
            result.M11 = 1f; result.M12 = m2;
            result.M21 = m; result.M22 = 1f;
            result.M31 = 0f; result.M32 = 0f;
            return result;
        }

        public static Matrix3x2 CreateSkew(float radiansX, float radiansY, Vector2 centerPoint)
        {
            float num = (float)Math.Tan((double)radiansX);
            float num2 = (float)Math.Tan((double)radiansY);
            float m = -centerPoint.Y * num;
            float m2 = -centerPoint.X * num2;
            Matrix3x2 result;
            result.M11 = 1f; result.M12 = num2;
            result.M21 = num; result.M22 = 1f;
            result.M31 = m; result.M32 = m2;
            return result;
        }

        public static Matrix3x2 CreateRotation(float radians)
        {
            radians = (float)Math.IEEERemainder((double)radians, 6.2831853071795862);
            float num;
            float num2;
            if (radians > -1.74532943E-05f && radians < 1.74532943E-05f)
            {
                num = 1f;
                num2 = 0f;
            }
            else if ((double)radians > 1.5707788735010619 && (double)radians < 1.5708137800887312)
            {
                num = 0f;
                num2 = 1f;
            }
            else if ((double)radians < -3.1415752002959585 || (double)radians > 3.1415752002959585)
            {
                num = -1f;
                num2 = 0f;
            }
            else if ((double)radians > -1.5708137800887312 && (double)radians < -1.5707788735010619)
            {
                num = 0f;
                num2 = -1f;
            }
            else
            {
                num = (float)Math.Cos((double)radians);
                num2 = (float)Math.Sin((double)radians);
            }
            Matrix3x2 result;
            result.M11 = num; result.M12 = num2;
            result.M21 = -num2; result.M22 = num;
            result.M31 = 0f; result.M32 = 0f;
            return result;
        }

        public static Matrix3x2 CreateRotation(float radians, Vector2 centerPoint)
        {
            radians = (float)Math.IEEERemainder((double)radians, 6.2831853071795862);
            float num;
            float num2;
            if (radians > -1.74532943E-05f && radians < 1.74532943E-05f)
            {
                num = 1f;
                num2 = 0f;
            }
            else if ((double)radians > 1.5707788735010619 && (double)radians < 1.5708137800887312)
            {
                num = 0f;
                num2 = 1f;
            }
            else if ((double)radians < -3.1415752002959585 || (double)radians > 3.1415752002959585)
            {
                num = -1f;
                num2 = 0f;
            }
            else if ((double)radians > -1.5708137800887312 && (double)radians < -1.5707788735010619)
            {
                num = 0f;
                num2 = -1f;
            }
            else
            {
                num = (float)Math.Cos((double)radians);
                num2 = (float)Math.Sin((double)radians);
            }
            float m = centerPoint.X * (1f - num) + centerPoint.Y * num2;
            float m2 = centerPoint.Y * (1f - num) - centerPoint.X * num2;
            Matrix3x2 result;
            result.M11 = num; result.M12 = num2;
            result.M21 = -num2; result.M22 = num;
            result.M31 = m; result.M32 = m2;
            return result;
        }

        public float GetDeterminant()
        {
            return this.M11 * this.M22 - this.M21 * this.M12;
        }

        public static bool Invert(Matrix3x2 matrix, out Matrix3x2 result)
        {
            float num = matrix.M11 * matrix.M22 - matrix.M21 * matrix.M12;
            if (Math.Abs(num) < 1.401298E-45f)
            {
                result = new Matrix3x2(float.NaN, float.NaN, float.NaN, float.NaN, float.NaN, float.NaN);
                return false;
            }
            float num2 = 1f / num;
            result.M11 = matrix.M22 * num2; result.M12 = -matrix.M12 * num2;
            result.M21 = -matrix.M21 * num2; result.M22 = matrix.M11 * num2;
            result.M31 = (matrix.M21 * matrix.M32 - matrix.M31 * matrix.M22) * num2; result.M32 = (matrix.M31 * matrix.M12 - matrix.M11 * matrix.M32) * num2;
            return true;
        }

        public static Matrix3x2 Lerp(Matrix3x2 matrix1, Matrix3x2 matrix2, float amount)
        {
            Matrix3x2 result;
            result.M11 = matrix1.M11 + (matrix2.M11 - matrix1.M11) * amount;
            result.M12 = matrix1.M12 + (matrix2.M12 - matrix1.M12) * amount;
            result.M21 = matrix1.M21 + (matrix2.M21 - matrix1.M21) * amount;
            result.M22 = matrix1.M22 + (matrix2.M22 - matrix1.M22) * amount;
            result.M31 = matrix1.M31 + (matrix2.M31 - matrix1.M31) * amount;
            result.M32 = matrix1.M32 + (matrix2.M32 - matrix1.M32) * amount;
            return result;
        }

        public static Matrix3x2 Negate(Matrix3x2 value)
        {
            Matrix3x2 result;
            result.M11 = -value.M11; result.M12 = -value.M12;
            result.M21 = -value.M21; result.M22 = -value.M22;
            result.M31 = -value.M31; result.M32 = -value.M32;
            return result;
        }

        public static Matrix3x2 Add(Matrix3x2 value1, Matrix3x2 value2)
        {
            Matrix3x2 result;
            result.M11 = value1.M11 + value2.M11; result.M12 = value1.M12 + value2.M12;
            result.M21 = value1.M21 + value2.M21; result.M22 = value1.M22 + value2.M22;
            result.M31 = value1.M31 + value2.M31; result.M32 = value1.M32 + value2.M32;
            return result;
        }

        public static Matrix3x2 Subtract(Matrix3x2 value1, Matrix3x2 value2)
        {
            Matrix3x2 result;
            result.M11 = value1.M11 - value2.M11; result.M12 = value1.M12 - value2.M12;
            result.M21 = value1.M21 - value2.M21; result.M22 = value1.M22 - value2.M22;
            result.M31 = value1.M31 - value2.M31; result.M32 = value1.M32 - value2.M32;
            return result;
        }

        public static Matrix3x2 Multiply(Matrix3x2 value1, Matrix3x2 value2)
        {
            Matrix3x2 result;
            result.M11 = value1.M11 * value2.M11 + value1.M12 * value2.M21;
            result.M12 = value1.M11 * value2.M12 + value1.M12 * value2.M22;
            result.M21 = value1.M21 * value2.M11 + value1.M22 * value2.M21;
            result.M22 = value1.M21 * value2.M12 + value1.M22 * value2.M22;
            result.M31 = value1.M31 * value2.M11 + value1.M32 * value2.M21 + value2.M31;
            result.M32 = value1.M31 * value2.M12 + value1.M32 * value2.M22 + value2.M32;
            return result;
        }

        public static Matrix3x2 Multiply(Matrix3x2 value1, float value2)
        {
            Matrix3x2 result;
            result.M11 = value1.M11 * value2; result.M12 = value1.M12 * value2;
            result.M21 = value1.M21 * value2; result.M22 = value1.M22 * value2;
            result.M31 = value1.M31 * value2; result.M32 = value1.M32 * value2;
            return result;
        }

        public static Matrix3x2 operator -(Matrix3x2 value)
        {
            Matrix3x2 result;
            result.M11 = -value.M11; result.M12 = -value.M12;
            result.M21 = -value.M21; result.M22 = -value.M22;
            result.M31 = -value.M31; result.M32 = -value.M32;
            return result;
        }

        public static Matrix3x2 operator +(Matrix3x2 value1, Matrix3x2 value2)
        {
            Matrix3x2 result;
            result.M11 = value1.M11 + value2.M11; result.M12 = value1.M12 + value2.M12;
            result.M21 = value1.M21 + value2.M21; result.M22 = value1.M22 + value2.M22;
            result.M31 = value1.M31 + value2.M31; result.M32 = value1.M32 + value2.M32;
            return result;
        }

        public static Matrix3x2 operator -(Matrix3x2 value1, Matrix3x2 value2)
        {
            Matrix3x2 result;
            result.M11 = value1.M11 - value2.M11; result.M12 = value1.M12 - value2.M12;
            result.M21 = value1.M21 - value2.M21; result.M22 = value1.M22 - value2.M22;
            result.M31 = value1.M31 - value2.M31; result.M32 = value1.M32 - value2.M32;
            return result;
        }

        public static Matrix3x2 operator *(Matrix3x2 value1, Matrix3x2 value2)
        {
            Matrix3x2 result;
            result.M11 = value1.M11 * value2.M11 + value1.M12 * value2.M21;
            result.M12 = value1.M11 * value2.M12 + value1.M12 * value2.M22;
            result.M21 = value1.M21 * value2.M11 + value1.M22 * value2.M21;
            result.M22 = value1.M21 * value2.M12 + value1.M22 * value2.M22;
            result.M31 = value1.M31 * value2.M11 + value1.M32 * value2.M21 + value2.M31;
            result.M32 = value1.M31 * value2.M12 + value1.M32 * value2.M22 + value2.M32;
            return result;
        }

        public static Matrix3x2 operator *(Matrix3x2 value1, float value2)
        {
            Matrix3x2 result;
            result.M11 = value1.M11 * value2; result.M12 = value1.M12 * value2;
            result.M21 = value1.M21 * value2; result.M22 = value1.M22 * value2;
            result.M31 = value1.M31 * value2; result.M32 = value1.M32 * value2;
            return result;
        }

        public static bool operator ==(Matrix3x2 value1, Matrix3x2 value2)
        {
            return value1.M11 == value2.M11 && value1.M22 == value2.M22 && value1.M12 == value2.M12 && value1.M21 == value2.M21 && value1.M31 == value2.M31 && value1.M32 == value2.M32;
        }

        public static bool operator !=(Matrix3x2 value1, Matrix3x2 value2)
        {
            return value1.M11 != value2.M11 || value1.M12 != value2.M12 || value1.M21 != value2.M21 || value1.M22 != value2.M22 || value1.M31 != value2.M31 || value1.M32 != value2.M32;
        }

        public bool Equals(Matrix3x2 other)
        {
            return this.M11 == other.M11 && this.M22 == other.M22 && this.M12 == other.M12 && this.M21 == other.M21 && this.M31 == other.M31 && this.M32 == other.M32;
        }

        public override bool Equals(object obj)
        {
            return obj is Matrix3x2 && this.Equals((Matrix3x2)obj);
        }

        //public override string ToString()
        //{
        //    CultureInfo currentCulture = CultureInfo.get_CurrentCulture();
        //    return string.Format(currentCulture, "{{ {{M11:{0} M12:{1}}} {{M21:{2} M22:{3}}} {{M31:{4} M32:{5}}} }}", new object[]
        //    {
        //        this.M11.ToString(currentCulture),
        //        this.M12.ToString(currentCulture),
        //        this.M21.ToString(currentCulture),
        //        this.M22.ToString(currentCulture),
        //        this.M31.ToString(currentCulture),
        //        this.M32.ToString(currentCulture)
        //    });
        //}

        public override int GetHashCode()
        {
            return this.M11.GetHashCode() + this.M12.GetHashCode() + this.M21.GetHashCode() + this.M22.GetHashCode() + this.M31.GetHashCode() + this.M32.GetHashCode();
        }
    }
}
