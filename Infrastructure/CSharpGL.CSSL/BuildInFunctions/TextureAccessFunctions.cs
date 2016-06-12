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
        /// <summary>
        /// Returns the width of level lod of the 1D
        /// texture currently specified by sampler.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static int textureSize(sampler1D sampler, int lod) { return 0; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias)
        /// Lod suffix accesses the texture with
        /// explict lod.
        /// Grad suffix accesses the texture with explict
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u texel coordinate before looking up each
        /// texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static vec4 texture(sampler1D sampler, double coord, double bias = 0.0) { return null; }
        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias)
        /// Lod suffix accesses the texture with
        /// explict lod.
        /// Grad suffix accesses the texture with explict
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u texel coordinate before looking up each
        /// texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static vec4 textureProj(sampler1D sampler, vec2 coord, double bias = 0.0) { return null; }
        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias)
        /// Lod suffix accesses the texture with
        /// explict lod.
        /// Grad suffix accesses the texture with explict
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u texel coordinate before looking up each
        /// texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static vec4 textureProj(sampler1D sampler, vec4 coord, double bias = 0.0) { return null; }
        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias)
        /// Lod suffix accesses the texture with
        /// explict lod.
        /// Grad suffix accesses the texture with explict
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u texel coordinate before looking up each
        /// texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static vec4 textureLod(sampler1D sampler, double coord, double lod) { return null; }
        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias)
        /// Lod suffix accesses the texture with
        /// explict lod.
        /// Grad suffix accesses the texture with explict
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u texel coordinate before looking up each
        /// texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static vec4 textureGrad(sampler1D sampler, double coord, double dPdx, double dPdy) { return null; }
        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias)
        /// Lod suffix accesses the texture with
        /// explict lod.
        /// Grad suffix accesses the texture with explict
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u texel coordinate before looking up each
        /// texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static vec4 textureOffset(sampler1D sampler, double coord, int offset, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texel integer coord to lookup a single
        /// texel of the explicit lod to access the 1D
        /// texture currently specified by sampler:
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u texel coordinate before looking up each
        /// texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static vec4 texelFetch(sampler1D sampler, int coord, int lod) { return null; }
        /// <summary>
        /// Use the texel integer coord to lookup a single
        /// texel of the explicit lod to access the 1D
        /// texture currently specified by sampler:
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u texel coordinate before looking up each
        /// texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static vec4 texelFetchOffset(sampler1D sampler, int coord, int lod, int offset) { return null; }

    }
}