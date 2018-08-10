using System;

namespace CSharpGL
{
    public static partial class glm
    {
        public static uint packUnorm4x8(this vec4 v)
        {
            uint A = (uint)(Math.Round(clamp(v.x, 0.0f, 1.0f) * 255.0));
            uint B = (uint)(Math.Round(clamp(v.y, 0.0f, 1.0f) * 255.0));
            uint C = (uint)(Math.Round(clamp(v.z, 0.0f, 1.0f) * 255.0));
            uint D = (uint)(Math.Round(clamp(v.w, 0.0f, 1.0f) * 255.0));

            uint result = (D << 24) | (C << 16) | (B << 8) | (A);

            return result;
        }

        public static vec4 unpackUnorm4x8(this uint p)
        {
            const uint mask8 = (1 << 8) - 1;
            uint A = (p >> 0) & mask8;
            uint B = (p >> 8) & mask8;
            uint C = (p >> 16) & mask8;
            uint D = (p >> 24) & mask8;

            var result = new vec4(A / 255.0f, B / 255.0f, C / 255.0f, D / 255.0f);

            return result;
        }

        private static float clamp(float value, float min, float max)
        {
            if (value < min) { return min; }
            if (max < value) { return max; }

            return value;
        }
    }
}
