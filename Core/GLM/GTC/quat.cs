using System;

namespace GLM.GTC
{
    // ReSharper disable InconsistentNaming
    public struct quat
    {
        private float w;
        private float x;
        private float y;
        private float z;

        private quat(float w, float x, float y, float z)
        {
            this.w = w;
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public float this[int index]
        {
            get
            {
                if(index == 0) return x;
                if(index == 1) return y;
                if(index == 2) return z;
                if(index == 3) return w;
                throw new IndexOutOfRangeException();
            }
            set
            {
                if(index == 0) x = value;
                else if(index == 1) y = value;
                else if(index == 2) z = value;
                else if(index == 3) w = value;
                else throw new IndexOutOfRangeException();
            }
        }

        public static quat angelAxis(float angle, vec3 axis)
        {
            var Result = new quat();

            var a = angle;
            var s = glm.sin(a*0.5f);

            Result.w = glm.cos(a*0.5f);
            Result.x = axis.x*s;
            Result.y = axis.y*s;
            Result.z = axis.z*s;
            return Result;
        }

        public static float dot(quat q1, quat q2)
        {
            return q1.x*q2.x + q1.y*q2.y + q1.z*q2.z + q1.w*q2.w;
        }

        public static quat cross(quat q1, quat q2)
        {
            return new quat(
                q1.w*q2.w - q1.x*q2.x - q1.y*q2.y - q1.z*q2.z,
                q1.w*q2.x + q1.x*q2.w + q1.y*q2.z - q1.z*q2.y,
                q1.w*q2.y + q1.y*q2.w + q1.z*q2.x - q1.x*q2.z,
                q1.w*q2.z + q1.z*q2.w + q1.x*q2.y - q1.y*q2.x);
        }

        public static float length(quat q)
        {
            return (float) Math.Sqrt(q.w);
        }

        public static quat normalize(quat q)
        {
            var length = quat.length(q);
            var oneOverLen = 1/length;
            return new quat(q.w*oneOverLen, q.x*oneOverLen, q.y*oneOverLen, q.z*oneOverLen);
        }

        public quat lerp(quat q1, quat q2, float k)
        {
            // Lerp is only defined in [0, 1]
            if(!(k >= 0 || k <= 1))
            {
                throw new ArgumentOutOfRangeException(string.Format("k should be in the range [0,1], but it is {0}", k));
            }
            return q1*(1 - k) + (q2*k);
        }

        public static quat operator +(quat q, quat p)
        {
            q.w += p.w;
            q.x += p.x;
            q.y += p.y;
            q.z += p.z;
            return q;
        }

        public static quat operator *(quat q, quat p)
        {
            quat result;
            result.w = p.w*q.w - p.x*q.x - p.y*q.y - p.z*q.z;
            result.x = p.w*q.x + p.x*q.w + p.y*q.z - p.z*q.y;
            result.y = p.w*q.y + p.y*q.w + p.z*q.x - p.x*q.z;
            result.z = p.w*q.z + p.z*q.w + p.x*q.y - p.y*q.x;
            return result;
        }

        public static quat operator *(quat q, float k)
        {
            q.w *= k;
            q.x *= k;
            q.y *= k;
            q.z *= k;
            return q;
        }

        public static quat operator /(quat q, float k)
        {
            q.w /= k;
            q.x /= k;
            q.y /= k;
            q.z /= k;
            return q;
        }

        public static quat operator -(quat q)
        {
            return new quat(-q.w, -q.x, -q.y, -q.z);
        }

        public static quat conjugate(quat q)
        {
            return new quat(q.w, -q.x, -q.y, -q.z);
        }

        public static quat inverse(quat q)
        {
            return conjugate(q)/dot(q, q);
        }
    }
    // ReSharper restore InconsistentNaming
}