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
    public abstract partial class FragmentCSShaderCode
    {

        /// <summary>
        /// Returns the derivative in x for the input argument p
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static float dFdx(double p) { return 0.0f; }
        /// <summary>
        /// Returns the derivative in x for the input argument p
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static vec2 dFdx(vec2 p) { return null; }
        /// <summary>
        /// Returns the derivative in x for the input argument p
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static vec3 dFdx(vec3 p) { return null; }
        /// <summary>
        /// Returns the derivative in x for the input argument p
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static vec4 dFdx(vec4 p) { return null; }

        /// <summary>
        /// Returns the derivative in y for the input argument p
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static float dFdy(double p) { return 0.0f; }
        /// <summary>
        /// Returns the derivative in y for the input argument p
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static vec2 dFdy(vec2 p) { return null; }
        /// <summary>
        /// Returns the derivative in y for the input argument p
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static vec3 dFdy(vec3 p) { return null; }
        /// <summary>
        /// Returns the derivative in y for the input argument p
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static vec4 dFdy(vec4 p) { return null; }

        /// <summary>
        /// Returns the sum of the absolute derivative in x and y for
        /// the input argument p, i.e.,
        /// return = abs( dFdx( p ) ) + abs( dFdy( p ) );
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static float fwidth(double p) { return 0.0f; }
        /// <summary>
        /// Returns the sum of the absolute derivative in x and y for
        /// the input argument p, i.e.,
        /// return = abs( dFdx( p ) ) + abs( dFdy( p ) );
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static vec2 fwidth(vec2 p) { return null; }
        /// <summary>
        /// Returns the sum of the absolute derivative in x and y for
        /// the input argument p, i.e.,
        /// return = abs( dFdx( p ) ) + abs( dFdy( p ) );
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static vec3 fwidth(vec3 p) { return null; }
        /// <summary>
        /// Returns the sum of the absolute derivative in x and y for
        /// the input argument p, i.e.,
        /// return = abs( dFdx( p ) ) + abs( dFdy( p ) );
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static vec4 fwidth(vec4 p) { return null; }

    }
}