using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.CSSL
{
    /// <summary>
    /// 所有CSSL都共有的内容。
    /// </summary>
    public abstract partial class CSShaderCode
    {
        //TODO: add build in functions
        // TODO: rename 􀀍 to *
        // TODO: rename – to -
        /// <summary>
        /// Returns the length of vector x, i.e.,
        /// sqrt(x[0] 􀀍 x[0] + x[1] 􀀍 x[1] + ...).
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float length(double x) { return 0.0f; }
        /// <summary>
        /// Returns the length of vector x, i.e.,
        /// sqrt(x[0] 􀀍 x[0] + x[1] 􀀍 x[1] + ...).
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float length(vec2 x) { return 0.0f; }
        /// <summary>
        /// Returns the length of vector x, i.e.,
        /// sqrt(x[0] 􀀍 x[0] + x[1] 􀀍 x[1] + ...).
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float length(vec3 x) { return 0.0f; }
        /// <summary>
        /// Returns the length of vector x, i.e.,
        /// sqrt(x[0] 􀀍 x[0] + x[1] 􀀍 x[1] + ...).
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float length(vec4 x) { return 0.0f; }

        /// <summary>
        /// Returns the distance between p0 and p1,
        /// i.e., length(p0 – p1).
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <returns></returns>
        public static float distance(double p0, double p1) { return 0.0f; }
        /// <summary>
        /// Returns the distance between p0 and p1,
        /// i.e., length(p0 – p1).
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <returns></returns>
        public static float distance(vec2 p0, vec2 p1) { return 0.0f; }
        /// <summary>
        /// Returns the distance between p0 and p1,
        /// i.e., length(p0 – p1).
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <returns></returns>
        public static float distance(vec3 p0, vec3 p1) { return 0.0f; }
        /// <summary>
        /// Returns the distance between p0 and p1,
        /// i.e., length(p0 – p1).
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <returns></returns>
        public static float distance(vec4 p0, vec4 p1) { return 0.0f; }

        /// <summary>
        /// Returns the dot product of x and y, i.e.,
        /// result = x[0] 􀀍􀀃y[0] + x[1] 􀀍 y[1] + ....
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static float dot(double x, double y) { return 0.0f; }
        public static float dot(vec2 x, vec2 y) { return 0.0f; }
        public static float dot(vec3 x, vec3 y) { return 0.0f; }
        public static float dot(vec4 x, vec4 y) { return 0.0f; }

        /// <summary>
        /// Returns the cross product of x and y, i.e.,
        /// result[0] = x[1] 􀀍􀀃y[2] - y[1] 􀀍 x[2]
        /// result[1] = x[2] 􀀍􀀃y[0] - y[2] 􀀍 x[0]
        /// result[2] = x[0] 􀀍􀀃y[1] - y[0] 􀀍 x[1]
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static vec3 cross(vec3 x, vec3 y) { return null; }

        /// <summary>
        /// Returns a vector in the same direction as x
        /// but with a length of 1.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float normalize(double x) { return 0.0f; }
        /// <summary>
        /// Returns a vector in the same direction as x
        /// but with a length of 1.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec2 normalize(vec2 x) { return null; }
        /// <summary>
        /// Returns a vector in the same direction as x
        /// but with a length of 1.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        /// <summary>
        /// Returns a vector in the same direction as x
        /// but with a length of 1.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec3 normalize(vec3 x) { return null; }

        /// <summary>
        /// Returns a vector in the same direction as x
        /// but with a length of 1.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static vec4 normalize(vec4 x) { return null; }

        /// <summary>
        /// If dot (Nref, I) &lt; 0.0, return N; otherwise,
        /// return –N.
        /// </summary>
        /// <param name="N"></param>
        /// <param name="I"></param>
        /// <param name="Nref"></param>
        /// <returns></returns>
        public static float faceforward(double N, double I, double Nref) { return 0.0f; }
        /// <summary>
        /// If dot (Nref, I) &lt; 0.0, return N; otherwise,
        /// return –N.
        /// </summary>
        /// <param name="N"></param>
        /// <param name="I"></param>
        /// <param name="Nref"></param>
        /// <returns></returns>
        public static vec2 faceforward(vec2 N, vec2 I, vec2 Nref) { return null; }
        /// <summary>
        /// If dot (Nref, I) &lt; 0.0, return N; otherwise,
        /// return –N.
        /// </summary>
        /// <param name="N"></param>
        /// <param name="I"></param>
        /// <param name="Nref"></param>
        /// <returns></returns>
        public static vec3 faceforward(vec3 N, vec3 I, vec3 Nref) { return null; }
        /// <summary>
        /// If dot (Nref, I) &lt; 0.0, return N; otherwise,
        /// return –N.
        /// </summary>
        /// <param name="N"></param>
        /// <param name="I"></param>
        /// <param name="Nref"></param>
        /// <returns></returns>
        public static vec4 faceforward(vec4 N, vec4 I, vec4 Nref) { return null; }

        /// <summary>
        /// For the incident vector I and surface
        /// orientation N, returns the reflection
        /// direction:
        /// result = I – 2.0 􀀍 dot (N, I ) 􀀍􀀃N
        /// N must already be normalized to achieve the
        /// desired result. I need not be normalized.
        /// </summary>
        /// <param name="I"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static float reflect(double I, double N) { return 0.0f; }
        /// <summary>
        /// For the incident vector I and surface
        /// orientation N, returns the reflection
        /// direction:
        /// result = I – 2.0 􀀍 dot (N, I ) 􀀍􀀃N
        /// N must already be normalized to achieve the
        /// desired result. I need not be normalized.
        /// </summary>
        /// <param name="I"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static vec2 reflect(vec2 I, vec2 N) { return null; }
        /// <summary>
        /// For the incident vector I and surface
        /// orientation N, returns the reflection
        /// direction:
        /// result = I – 2.0 􀀍 dot (N, I ) 􀀍􀀃N
        /// N must already be normalized to achieve the
        /// desired result. I need not be normalized.
        /// </summary>
        /// <param name="I"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static vec3 reflect(vec3 I, vec3 N) { return null; }
        /// <summary>
        /// For the incident vector I and surface
        /// orientation N, returns the reflection
        /// direction:
        /// result = I – 2.0 􀀍 dot (N, I ) 􀀍􀀃N
        /// N must already be normalized to achieve the
        /// desired result. I need not be normalized.
        /// </summary>
        /// <param name="I"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static vec4 reflect(vec4 I, vec4 N) { return null; }

        /// <summary>
        /// For the incident vector I and surface normal
        /// N and the ratio of indices of refraction eta,
        /// returns the refraction vector. The returned
        /// result is computed as
        /// k = 1.0 – eta * eta *
        ///     (1.0 – dot (N, I) * dot (N, I))
        /// if (k &lt; 0.0)
        ///     result = 0.0;
        ///     //(result type is float or vec2/3/4)
        /// else
        ///     result = eta * I–
        ///         (eta * dot (N, I) * sqrt (k)) * N
        /// The input parameters for the incident
        /// vector I and surface normal N must already
        /// be normalized to achieve the desired result.
        /// </summary>
        /// <param name="I"></param>
        /// <param name="N"></param>
        /// <param name="eta"></param>
        /// <returns></returns>
        public static float refract(double I, double N, double eta) { return 0.0f; }
        /// <summary>
        /// For the incident vector I and surface normal
        /// N and the ratio of indices of refraction eta,
        /// returns the refraction vector. The returned
        /// result is computed as
        /// k = 1.0 – eta * eta *
        ///     (1.0 – dot (N, I) * dot (N, I))
        /// if (k &lt; 0.0)
        ///     result = 0.0;
        ///     //(result type is float or vec2/3/4)
        /// else
        ///     result = eta * I–
        ///         (eta * dot (N, I) * sqrt (k)) * N
        /// The input parameters for the incident
        /// vector I and surface normal N must already
        /// be normalized to achieve the desired result.
        /// </summary>
        /// <param name="I"></param>
        /// <param name="N"></param>
        /// <param name="eta"></param>
        /// <returns></returns>
        public static vec2 refract(vec2 I, vec2 N, float eta) { return null; }
        /// <summary>
        /// For the incident vector I and surface normal
        /// N and the ratio of indices of refraction eta,
        /// returns the refraction vector. The returned
        /// result is computed as
        /// k = 1.0 – eta * eta *
        ///     (1.0 – dot (N, I) * dot (N, I))
        /// if (k &lt; 0.0)
        ///     result = 0.0;
        ///     //(result type is float or vec2/3/4)
        /// else
        ///     result = eta * I–
        ///         (eta * dot (N, I) * sqrt (k)) * N
        /// The input parameters for the incident
        /// vector I and surface normal N must already
        /// be normalized to achieve the desired result.
        /// </summary>
        /// <param name="I"></param>
        /// <param name="N"></param>
        /// <param name="eta"></param>
        /// <returns></returns>
        public static vec3 refract(vec3 I, vec3 N, float eta) { return null; }
        /// <summary>
        /// For the incident vector I and surface normal
        /// N and the ratio of indices of refraction eta,
        /// returns the refraction vector. The returned
        /// result is computed as
        /// k = 1.0 – eta * eta *
        ///     (1.0 – dot (N, I) * dot (N, I))
        /// if (k &lt; 0.0)
        ///     result = 0.0;
        ///     //(result type is float or vec2/3/4)
        /// else
        ///     result = eta * I–
        ///         (eta * dot (N, I) * sqrt (k)) * N
        /// The input parameters for the incident
        /// vector I and surface normal N must already
        /// be normalized to achieve the desired result.
        /// </summary>
        /// <param name="I"></param>
        /// <param name="N"></param>
        /// <param name="eta"></param>
        /// <returns></returns>
        public static vec4 refract(vec4 I, vec4 N, float eta) { return null; }



    }
}