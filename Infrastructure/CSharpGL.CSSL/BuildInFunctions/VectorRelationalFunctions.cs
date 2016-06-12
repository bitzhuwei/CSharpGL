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

        /// <summary>
        /// Returns the component-wise
        /// compare of x &lt; y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec2 lessThan(vec2 x, vec2 y) { return null; }
        /// <summary>
        /// Returns the component-wise
        /// compare of x &lt; y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec3 lessThan(vec3 x, vec3 y) { return null; }
        /// <summary>
        /// Returns the component-wise
        /// compare of x &lt; y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec4 lessThan(vec4 x, vec4 y) { return null; }
        /// <summary>
        /// Returns the component-wise
        /// compare of x &lt; y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec2 lessThan(ivec2 x, ivec2 y) { return null; }
        /// <summary>
        /// Returns the component-wise
        /// compare of x &lt; y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec3 lessThan(ivec3 x, ivec3 y) { return null; }
        /// <summary>
        /// Returns the component-wise
        /// compare of x &lt; y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec4 lessThan(ivec4 x, ivec4 y) { return null; }

        /// <summary>
        /// Returns the component-wise
        /// compare of x &lt;= y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec2 lessThanEqual(vec2 x, vec2 y) { return null; }
        /// <summary>
        /// Returns the component-wise
        /// compare of x &lt;= y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec3 lessThanEqual(vec3 x, vec3 y) { return null; }
        /// <summary>
        /// Returns the component-wise
        /// compare of x &lt;= y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec4 lessThanEqual(vec4 x, vec4 y) { return null; }
        /// <summary>
        /// Returns the component-wise
        /// compare of x &lt;= y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec2 lessThanEqual(ivec2 x, ivec2 y) { return null; }
        /// <summary>
        /// Returns the component-wise
        /// compare of x &lt;= y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec3 lessThanEqual(ivec3 x, ivec3 y) { return null; }
        /// <summary>
        /// Returns the component-wise
        /// compare of x &lt;= y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec4 lessThanEqual(ivec4 x, ivec4 y) { return null; }

        /// <summary>
        /// Returns the component-wise compare of x &gt; y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec2 greaterThan(vec2 x, vec2 y) { return null; }
        /// <summary>
        /// Returns the component-wise compare of x &gt; y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec3 greaterThan(vec3 x, vec3 y) { return null; }
        /// <summary>
        /// Returns the component-wise compare of x &gt; y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec4 greaterThan(vec4 x, vec4 y) { return null; }
        /// <summary>
        /// Returns the component-wise compare of x &gt; y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec2 greaterThan(ivec2 x, ivec2 y) { return null; }
        /// <summary>
        /// Returns the component-wise compare of x &gt; y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec3 greaterThan(ivec3 x, ivec3 y) { return null; }
        /// <summary>
        /// Returns the component-wise compare of x &gt; y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec4 greaterThan(ivec4 x, ivec4 y) { return null; }

        /// <summary>
        /// Returns the component-wise compare of x &gt;= y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec2 greaterThanEqual(vec2 x, vec2 y) { return null; }
        /// <summary>
        /// Returns the component-wise compare of x &gt;= y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec3 greaterThanEqual(vec3 x, vec3 y) { return null; }
        /// <summary>
        /// Returns the component-wise compare of x &gt;= y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec4 greaterThanEqual(vec4 x, vec4 y) { return null; }
        /// <summary>
        /// Returns the component-wise compare of x &gt;= y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec2 greaterThanEqual(ivec2 x, ivec2 y) { return null; }
        /// <summary>
        /// Returns the component-wise compare of x &gt;= y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec3 greaterThanEqual(ivec3 x, ivec3 y) { return null; }
        /// <summary>
        /// Returns the component-wise compare of x &gt;= y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec4 greaterThanEqual(ivec4 x, ivec4 y) { return null; }

        /// <summary>
        /// Returns the component-wise compare of x == y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec2 equal(vec2 x, vec2 y) { return null; }
        /// <summary>
        /// Returns the component-wise compare of x == y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec3 equal(vec3 x, vec3 y) { return null; }
        /// <summary>
        /// Returns the component-wise compare of x == y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec4 equal(vec4 x, vec4 y) { return null; }
        /// <summary>
        /// Returns the component-wise compare of x == y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec2 equal(ivec2 x, ivec2 y) { return null; }
        /// <summary>
        /// Returns the component-wise compare of x == y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec3 equal(ivec3 x, ivec3 y) { return null; }
        /// <summary>
        /// Returns the component-wise compare of x == y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec4 equal(ivec4 x, ivec4 y) { return null; }
        /// <summary>
        /// Returns the component-wise compare of x == y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec2 equal(bvec2 x, bvec2 y) { return null; }
        /// <summary>
        /// Returns the component-wise compare of x == y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec3 equal(bvec3 x, bvec3 y) { return null; }
        /// <summary>
        /// Returns the component-wise compare of x == y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec4 equal(bvec4 x, bvec4 y) { return null; }

        /// <summary>
        /// Returns the component-wise compare of x != y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec2 notEqual(vec2 x, vec2 y) { return null; }
        /// <summary>
        /// Returns the component-wise compare of x != y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec3 notEqual(vec3 x, vec3 y) { return null; }
        /// <summary>
        /// Returns the component-wise compare of x != y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec4 notEqual(vec4 x, vec4 y) { return null; }
        /// <summary>
        /// Returns the component-wise compare of x != y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec2 notEqual(ivec2 x, ivec2 y) { return null; }
        /// <summary>
        /// Returns the component-wise compare of x != y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec3 notEqual(ivec3 x, ivec3 y) { return null; }
        /// <summary>
        /// Returns the component-wise compare of x != y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec4 notEqual(ivec4 x, ivec4 y) { return null; }
        /// <summary>
        /// Returns the component-wise compare of x != y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec2 notEqual(bvec2 x, bvec2 y) { return null; }
        /// <summary>
        /// Returns the component-wise compare of x != y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec3 notEqual(bvec3 x, bvec3 y) { return null; }
        /// <summary>
        /// Returns the component-wise compare of x != y.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bvec4 notEqual(bvec4 x, bvec4 y) { return null; }

        /// <summary>
        /// Returns true if any component of x is true.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool any(bvec2 x) { return false; }
        /// <summary>
        /// Returns true if any component of x is true.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool any(bvec3 x) { return false; }
        /// <summary>
        /// Returns true if any component of x is true.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool any(bvec4 x) { return false; }

        /// <summary>
        /// Returns true only if all components of x are true.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool all(bvec2 x) { return false; }
        /// <summary>
        /// Returns true only if all components of x are true.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool all(bvec3 x) { return false; }
        /// <summary>
        /// Returns true only if all components of x are true.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool all(bvec4 x) { return false; }

        /// <summary>
        /// Returns the component-wise logical complement of x.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bvec2 not(bvec2 x) { return null; }
        /// <summary>
        /// Returns the component-wise logical complement of x.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bvec3 not(bvec3 x) { return null; }
        /// <summary>
        /// Returns the component-wise logical complement of x.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bvec4 not(bvec4 x) { return null; }

    }
}