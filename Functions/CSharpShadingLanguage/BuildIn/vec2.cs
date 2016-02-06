using System;
using System.Runtime.InteropServices;

namespace CSharpShadingLanguage
{
    /// <summary>
    /// Represents a two dimensional vector.
    /// </summary>
    public struct vec2
    {

        public float x { get { return 0.0f; } set { } }
        public float y { get { return 0.0f; } set { } }

        public vec2 xx { get { return default(vec2); } set { } }
        public vec2 xy { get { return default(vec2); } set { } }
        public vec2 yx { get { return default(vec2); } set { } }
        public vec2 yy { get { return default(vec2); } set { } }

        public float r { get { return 0.0f; } set { } }
        public float g { get { return 0.0f; } set { } }

        public vec2 rr { get { return default(vec2); } set { } }
        public vec2 rg { get { return default(vec2); } set { } }
        public vec2 gr { get { return default(vec2); } set { } }
        public vec2 gg { get { return default(vec2); } set { } }

        public float s { get { return 0.0f; } set { } }
        public float t { get { return 0.0f; } set { } }

        public vec2 ss { get { return default(vec2); } set { } }
        public vec2 st { get { return default(vec2); } set { } }
        public vec2 ts { get { return default(vec2); } set { } }
        public vec2 tt { get { return default(vec2); } set { } }


        public float this[int index] { get { throw new NotNeedToImplementException(); } set { } }

        public static vec2 operator +(vec2 lhs, vec2 rhs) { throw new NotNeedToImplementException(); }
        public static vec2 operator +(vec2 lhs, float rhs) { throw new NotNeedToImplementException(); }
        public static vec2 operator -(vec2 lhs, vec2 rhs) { throw new NotNeedToImplementException(); }
        public static vec2 operator -(vec2 lhs, float rhs) { throw new NotNeedToImplementException(); }
        public static vec2 operator *(vec2 self, float s) { throw new NotNeedToImplementException(); }
        public static vec2 operator *(float lhs, vec2 rhs) { throw new NotNeedToImplementException(); }
        public static vec2 operator *(vec2 lhs, vec2 rhs) { throw new NotNeedToImplementException(); }
        public static vec2 operator /(vec2 lhs, float rhs) { throw new NotNeedToImplementException(); }

    }
}