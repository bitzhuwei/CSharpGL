using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    public partial class glm {
        private static float clamp(float value, float min, float max) {
            if (value < min) { return min; }
            if (max < value) { return max; }

            return value;
        }

        public static double clamp(double value, double min, double max) {
            if (value < min) { return min; }
            if (max < value) { return max; }

            return value;
        }

        public static T clamp<T>(T value, T min, T max) where T : IComparable {
            if (value.CompareTo(min) < 0) { return min; }
            if (max.CompareTo(value) < 0) { return max; }

            return value;
        }
    }
}
