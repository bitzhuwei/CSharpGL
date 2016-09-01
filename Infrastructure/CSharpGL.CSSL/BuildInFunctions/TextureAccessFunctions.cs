namespace CSharpGL.CSSL
{
    /// <summary>
    /// 所有CSSL都共有的内容。
    /// </summary>
    public abstract partial class CSShaderCode
    {
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

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static vec4 textureProjLod(sampler1D sampler, vec2 coord, double lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static vec4 textureProjLod(sampler1D sampler, vec4 coord, double lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static vec4 textureProjGrad(sampler1D sampler, vec2 coord, double dPdx, double dPdy) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static vec4 textureProjGrad(sampler1D sampler, vec4 coord, double dPdx, double dPdy) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static vec4 textureProjOffset(sampler1D sampler, vec2 coord, int offset, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static vec4 textureProjOffset(sampler1D sampler, vec4 coord, int offset, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static vec4 textureLodOffset(sampler1D sampler, double coord, double lod, int offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static vec4 textureGradOffset(sampler1D sampler, double coord, double dPdx, double dPdy, int offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static vec4 textureProjLodOffset(sampler1D sampler, vec2 coord, double lod, int offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static vec4 textureProjLodOffset(sampler1D sampler, vec4 coord, double lod, int offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static vec4 textureProjGradOffset(sampler1D sampler, vec2 coord, double dPdx, double dPdy, int offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static vec4 textureProjGradOffset(sampler1D sampler, vec4 coord, double dPdx, double dPdy, int offset) { return null; }

        /// <summary>
        /// Returns the width of level lod of the 1D
        /// texture currently specified by sampler.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static int textureSize(isampler1D sampler, int lod) { return 0; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static ivec4 texture(isampler1D sampler, double coord, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static ivec4 textureProj(isampler1D sampler, vec2 coord, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static ivec4 textureProj(isampler1D sampler, vec4 coord, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static ivec4 textureLod(isampler1D sampler, double coord, double lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static ivec4 textureGrad(isampler1D sampler, double coord, double dPdx, double dPdy) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static ivec4 textureOffset(isampler1D sampler, double coord, int offset, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
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
        public static ivec4 texelFetch(isampler1D sampler, int coord, int lod) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
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
        public static ivec4 texelFetchOffset(isampler1D sampler, int coord, int lod, int offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static ivec4 textureProjLod(isampler1D sampler, vec2 coord, double lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static ivec4 textureProjLod(isampler1D sampler, vec4 coord, double lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static ivec4 textureProjGrad(isampler1D sampler, vec2 coord, double dPdx, double dPdy) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static ivec4 textureProjGrad(isampler1D sampler, vec4 coord, double dPdx, double dPdy) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static ivec4 textureProjOffset(isampler1D sampler, vec2 coord, int offset, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static ivec4 textureProjOffset(isampler1D sampler, vec4 coord, int offset, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static ivec4 textureLodOffset(isampler1D sampler, double coord, double lod, int offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static ivec4 textureGradOffset(isampler1D sampler, double coord, double dPdx, double dPdy, int offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static ivec4 textureProjLodOffset(isampler1D sampler, vec2 coord, double lod, int offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static ivec4 textureProjLodOffset(isampler1D sampler, vec4 coord, double lod, int offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static ivec4 textureProjGradOffset(isampler1D sampler, vec2 coord, double dPdx, double dPdy, int offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static ivec4 textureProjGradOffset(isampler1D sampler, vec4 coord, double dPdx, double dPdy, int offset) { return null; }

        /// <summary>
        /// Returns the width of level lod of the 1D
        /// texture currently specified by sampler.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static int textureSize(usampler1D sampler, int lod) { return 0; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static uvec4 texture(usampler1D sampler, double coord, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static uvec4 textureProj(usampler1D sampler, vec2 coord, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static uvec4 textureProj(usampler1D sampler, vec4 coord, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static uvec4 textureLod(usampler1D sampler, double coord, double lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static uvec4 textureGrad(usampler1D sampler, double coord, double dPdx, double dPdy) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static uvec4 textureOffset(usampler1D sampler, double coord, int offset, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
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
        public static uvec4 texelFetch(usampler1D sampler, int coord, int lod) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
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
        public static uvec4 texelFetchOffset(usampler1D sampler, int coord, int lod, int offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static uvec4 textureProjLod(usampler1D sampler, vec2 coord, double lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static uvec4 textureProjLod(usampler1D sampler, vec4 coord, double lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static uvec4 textureProjGrad(usampler1D sampler, vec2 coord, double dPdx, double dPdy) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static uvec4 textureProjGrad(usampler1D sampler, vec4 coord, double dPdx, double dPdy) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static uvec4 textureProjOffset(usampler1D sampler, vec2 coord, int offset, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static uvec4 textureProjOffset(usampler1D sampler, vec4 coord, int offset, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static uvec4 textureLodOffset(usampler1D sampler, double coord, double lod, int offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static uvec4 textureGradOffset(usampler1D sampler, double coord, double dPdx, double dPdy, int offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static uvec4 textureProjLodOffset(usampler1D sampler, vec2 coord, double lod, int offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static uvec4 textureProjLodOffset(usampler1D sampler, vec4 coord, double lod, int offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static uvec4 textureProjGradOffset(usampler1D sampler, vec2 coord, double dPdx, double dPdy, int offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static uvec4 textureProjGradOffset(usampler1D sampler, vec4 coord, double dPdx, double dPdy, int offset) { return null; }

        /// <summary>
        /// Returns the width and height of level lod of
        /// the 2D texture currently specified by sampler.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static ivec2 textureSize(sampler2D sampler, int lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinates before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static vec4 texture(sampler2D sampler, vec2 coord, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinates before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static vec4 textureProj(sampler2D sampler, vec3 coord, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinates before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static vec4 textureProj(sampler2D sampler, vec4 coord, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinates before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static vec4 textureLod(sampler2D sampler, vec2 coord, double lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinates before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static vec4 textureGrad(sampler2D sampler, vec2 coord, vec2 dPdx, vec2 dPdy) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinates before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static vec4 textureOffset(sampler2D sampler, vec2 coord, ivec2 offset, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the explicit lod to access the 2D
        /// texture currently specified by sampler:
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinate before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static vec4 texelFetch(sampler2D sampler, ivec2 coord, int lod) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the explicit lod to access the 2D
        /// texture currently specified by sampler:
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinate before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static vec4 texelFetchOffset(sampler2D sampler, ivec2 coord, int lod, ivec2 offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static vec4 textureProjLod(sampler2D sampler, vec3 coord, double lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static vec4 textureProjLod(sampler2D sampler, vec4 coord, double lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static vec4 textureProjGrad(sampler2D sampler, vec3 coord, vec2 dPdx, vec2 dPdy) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static vec4 textureProjGrad(sampler2D sampler, vec4 coord, vec2 dPdx, vec2 dPdy) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static vec4 textureProjOffset(sampler2D sampler, vec3 coord, ivec2 offset, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static vec4 textureProjOffset(sampler2D sampler, vec4 coord, ivec2 offset, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static vec4 textureLodOffset(sampler2D sampler, vec2 coord, double lod, ivec2 offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static vec4 textureGradOffset(sampler2D sampler, vec2 coord, vec2 dPdx, vec2 dPdy, ivec2 offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static vec4 textureProjLodOffset(sampler2D sampler, vec3 coord, double lod, ivec2 offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static vec4 textureProjLodOffset(sampler2D sampler, vec4 coord, double lod, ivec2 offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static vec4 textureProjGradOffset(sampler2D sampler, vec3 coord, vec2 dPdx, vec2 dPdy, ivec2 offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static vec4 textureProjGradOffset(sampler2D sampler, vec4 coord, vec2 dPdx, vec2 dPdy, ivec2 offset) { return null; }

        /// <summary>
        /// Returns the width and height of level lod of
        /// the 2D texture currently specified by sampler:
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static ivec2 textureSize(isampler2D sampler, int lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinates before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static ivec4 texture(isampler2D sampler, vec2 coord, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinates before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static ivec4 textureProj(isampler2D sampler, vec3 coord, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinates before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static ivec4 textureProj(isampler2D sampler, vec4 coord, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinates before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static ivec4 textureLod(isampler2D sampler, vec2 coord, double lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinates before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static ivec4 textureGrad(isampler2D sampler, vec2 coord, vec2 dPdx, vec2 dPdy) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinates before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static ivec4 textureOffset(isampler2D sampler, vec2 coord, ivec2 offset, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the explicit lod to access the 2D
        /// texture currently specified by sampler:
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinate before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static ivec4 texelFetch(isampler2D sampler, ivec2 coord, int lod) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the explicit lod to access the 2D
        /// texture currently specified by sampler:
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinate before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static ivec4 texelFetchOffset(isampler2D sampler, ivec2 coord, int lod, ivec2 offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static ivec4 textureProjLod(isampler2D sampler, vec3 coord, double lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static ivec4 textureProjLod(isampler2D sampler, vec4 coord, double lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static ivec4 textureProjGrad(isampler2D sampler, vec3 coord, vec2 dPdx, vec2 dPdy) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static ivec4 textureProjGrad(isampler2D sampler, vec4 coord, vec2 dPdx, vec2 dPdy) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static ivec4 textureProjOffset(isampler2D sampler, vec3 coord, ivec2 offset, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static ivec4 textureProjOffset(isampler2D sampler, vec4 coord, ivec2 offset, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static ivec4 textureLodOffset(isampler2D sampler, vec2 coord, double lod, ivec2 offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static ivec4 textureGradOffset(isampler2D sampler, vec2 coord, vec2 dPdx, vec2 dPdy, ivec2 offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static ivec4 textureProjLodOffset(isampler2D sampler, vec3 coord, double lod, ivec2 offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static ivec4 textureProjLodOffset(isampler2D sampler, vec4 coord, double lod, ivec2 offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static ivec4 textureProjGradOffset(isampler2D sampler, vec3 coord, vec2 dPdx, vec2 dPdy, ivec2 offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static ivec4 textureProjGradOffset(isampler2D sampler, vec4 coord, vec2 dPdx, vec2 dPdy, ivec2 offset) { return null; }

        /// <summary>
        /// Returns the width and height of level lod of
        /// the 2D texture currently specified by sampler.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static ivec2 textureSize(usampler2D sampler, int lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinates before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static uvec4 texture(usampler2D sampler, vec2 coord, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinates before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static uvec4 textureProj(usampler2D sampler, vec3 coord, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinates before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static uvec4 textureProj(usampler2D sampler, vec4 coord, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinates before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static uvec4 textureLod(usampler2D sampler, vec2 coord, double lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinates before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static uvec4 textureGrad(usampler2D sampler, vec2 coord, vec2 dPdx, vec2 dPdy) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinates before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static uvec4 textureOffset(usampler2D sampler, vec2 coord, ivec2 offset, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the explicit lod to access the 2D
        /// texture currently specified by sampler:
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinate before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static uvec4 texelFetch(usampler2D sampler, ivec2 coord, int lod) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the explicit lod to access the 2D
        /// texture currently specified by sampler:
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinate before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static uvec4 texelFetchOffset(usampler2D sampler, ivec2 coord, int lod, ivec2 offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static uvec4 textureProjLod(usampler2D sampler, vec3 coord, double lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static uvec4 textureProjLod(usampler2D sampler, vec4 coord, double lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static uvec4 textureProjGrad(usampler2D sampler, vec3 coord, vec2 dPdx, vec2 dPdy) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static uvec4 textureProjGrad(usampler2D sampler, vec4 coord, vec2 dPdx, vec2 dPdy) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static uvec4 textureProjOffset(usampler2D sampler, vec3 coord, ivec2 offset, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static uvec4 textureProjOffset(usampler2D sampler, vec4 coord, ivec2 offset, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static uvec4 textureLodOffset(usampler2D sampler, vec2 coord, double lod, ivec2 offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static uvec4 textureGradOffset(usampler2D sampler, vec2 coord, vec2 dPdx, vec2 dPdy, ivec2 offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static uvec4 textureProjLodOffset(usampler2D sampler, vec3 coord, double lod, ivec2 offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static uvec4 textureProjLodOffset(usampler2D sampler, vec4 coord, double lod, ivec2 offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static uvec4 textureProjGradOffset(usampler2D sampler, vec3 coord, vec2 dPdx, vec2 dPdy, ivec2 offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static uvec4 textureProjGradOffset(usampler2D sampler, vec4 coord, vec2 dPdx, vec2 dPdy, ivec2 offset) { return null; }

        /// <summary>
        /// Returns the width and height of the rectangle
        /// texture currently specified by sampler.
        /// </summary>
        /// <param name="sampler"></param>
        /// <returns></returns>
        public static ivec2 textureSize(sampler2DRect sampler) { return null; }

        /// <summary>
        /// Use the unnormalized texture coordinate
        /// coord to access the rectangle texture currently
        /// specified by sampler:
        /// Unsuffixed access the texture.
        /// Proj suffix accesses the texture with
        /// projection.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture with the
        /// offset added to the u and v texel coordinates
        /// before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <returns></returns>
        public static vec4 texture(sampler2DRect sampler, vec2 coord) { return null; }

        /// <summary>
        /// Use the unnormalized texture coordinate
        /// coord to access the rectangle texture currently
        /// specified by sampler:
        /// Unsuffixed access the texture.
        /// Proj suffix accesses the texture with
        /// projection.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture with the
        /// offset added to the u and v texel coordinates
        /// before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <returns></returns>
        public static vec4 textureProj(sampler2DRect sampler, vec3 coord) { return null; }

        /// <summary>
        /// Use the unnormalized texture coordinate
        /// coord to access the rectangle texture currently
        /// specified by sampler:
        /// Unsuffixed access the texture.
        /// Proj suffix accesses the texture with
        /// projection.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture with the
        /// offset added to the u and v texel coordinates
        /// before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <returns></returns>
        public static vec4 textureProj(sampler2DRect sampler, vec4 coord) { return null; }

        /// <summary>
        /// Use the unnormalized texture coordinate
        /// coord to access the rectangle texture currently
        /// specified by sampler:
        /// Unsuffixed access the texture.
        /// Proj suffix accesses the texture with
        /// projection.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture with the
        /// offset added to the u and v texel coordinates
        /// before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static vec4 textureGrad(sampler2DRect sampler, vec2 coord, vec2 dPdx, vec2 dPdy) { return null; }

        /// <summary>
        /// Use the unnormalized texture coordinate
        /// coord to access the rectangle texture currently
        /// specified by sampler:
        /// Unsuffixed access the texture.
        /// Proj suffix accesses the texture with
        /// projection.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture with the
        /// offset added to the u and v texel coordinates
        /// before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static vec4 textureOffset(sampler2DRect sampler, vec2 coord, ivec2 offset) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the rectangle texture currently
        /// specified by sampler:
        /// Offset suffix accesses the texture with the
        /// offset added to the u and v texel coordinate
        /// before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <returns></returns>
        public static vec4 texelFetch(sampler2DRect sampler, ivec2 coord) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the rectangle texture currently
        /// specified by sampler:
        /// Offset suffix accesses the texture with the
        /// offset added to the u and v texel coordinate
        /// before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static vec4 texelFetchOffset(sampler2DRect sampler, ivec2 coord, ivec2 offset) { return null; }

        /// <summary>
        /// Use the unnormalized texture coordinate
        /// coord to access the rectangle texture currently
        /// specified by sampler:
        /// Combination of the suffixes Proj, Grad and
        /// Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static vec4 textureProjGrad(sampler2DRect sampler, vec3 coord, vec2 dPdx, vec2 dPdy) { return null; }

        /// <summary>
        /// Use the unnormalized texture coordinate
        /// coord to access the rectangle texture currently
        /// specified by sampler:
        /// Combination of the suffixes Proj, Grad and
        /// Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static vec4 textureProjGrad(sampler2DRect sampler, vec4 coord, vec2 dPdx, vec2 dPdy) { return null; }

        /// <summary>
        /// Use the unnormalized texture coordinate
        /// coord to access the rectangle texture currently
        /// specified by sampler:
        /// Combination of the suffixes Proj, Grad and
        /// Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static vec4 textureProjOffset(sampler2DRect sampler, vec3 coord, ivec2 offset) { return null; }

        /// <summary>
        /// Use the unnormalized texture coordinate
        /// coord to access the rectangle texture currently
        /// specified by sampler:
        /// Combination of the suffixes Proj, Grad and
        /// Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static vec4 textureProjOffset(sampler2DRect sampler, vec4 coord, ivec2 offset) { return null; }

        /// <summary>
        /// Use the unnormalized texture coordinate
        /// coord to access the rectangle texture currently
        /// specified by sampler:
        /// Combination of the suffixes Proj, Grad and
        /// Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static vec4 textureProjGradOffset(sampler2DRect sampler, vec3 coord, vec2 dPdx, vec2 dPdy, ivec2 offset) { return null; }

        /// <summary>
        /// Use the unnormalized texture coordinate
        /// coord to access the rectangle texture currently
        /// specified by sampler:
        /// Combination of the suffixes Proj, Grad and
        /// Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static vec4 textureProjGradOffset(sampler2DRect sampler, vec4 coord, vec2 dPdx, vec2 dPdy, ivec2 offset) { return null; }

        /// <summary>
        /// Returns the width and height of the rectangle
        /// texture currently specified by sampler.
        /// </summary>
        /// <param name="sampler"></param>
        /// <returns></returns>
        public static ivec2 textureSize(isampler2DRect sampler) { return null; }

        /// <summary>
        /// Use the unnormalized texture coordinate
        /// coord to access the rectangle texture currently
        /// specified by sampler:
        /// Unsuffixed access the texture.
        /// Proj suffix accesses the texture with
        /// projection.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture with the
        /// offset added to the u and v texel coordinates
        /// before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <returns></returns>
        public static ivec4 texture(isampler2DRect sampler, vec2 coord) { return null; }

        /// <summary>
        /// Use the unnormalized texture coordinate
        /// coord to access the rectangle texture currently
        /// specified by sampler:
        /// Unsuffixed access the texture.
        /// Proj suffix accesses the texture with
        /// projection.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture with the
        /// offset added to the u and v texel coordinates
        /// before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <returns></returns>
        public static ivec4 textureProj(isampler2DRect sampler, vec3 coord) { return null; }

        /// <summary>
        /// Use the unnormalized texture coordinate
        /// coord to access the rectangle texture currently
        /// specified by sampler:
        /// Unsuffixed access the texture.
        /// Proj suffix accesses the texture with
        /// projection.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture with the
        /// offset added to the u and v texel coordinates
        /// before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <returns></returns>
        public static ivec4 textureProj(isampler2DRect sampler, vec4 coord) { return null; }

        /// <summary>
        /// Use the unnormalized texture coordinate
        /// coord to access the rectangle texture currently
        /// specified by sampler:
        /// Unsuffixed access the texture.
        /// Proj suffix accesses the texture with
        /// projection.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture with the
        /// offset added to the u and v texel coordinates
        /// before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static ivec4 textureGrad(isampler2DRect sampler, vec2 coord, vec2 dPdx, vec2 dPdy) { return null; }

        /// <summary>
        /// Use the unnormalized texture coordinate
        /// coord to access the rectangle texture currently
        /// specified by sampler:
        /// Unsuffixed access the texture.
        /// Proj suffix accesses the texture with
        /// projection.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture with the
        /// offset added to the u and v texel coordinates
        /// before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static ivec4 textureOffset(isampler2DRect sampler, vec2 coord, ivec2 offset) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the rectangle texture currently
        /// specified by sampler:
        /// Offset suffix accesses the texture with the
        /// offset added to the u and v texel coordinate
        /// before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <returns></returns>
        public static ivec4 texelFetch(isampler2DRect sampler, ivec2 coord) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the rectangle texture currently
        /// specified by sampler:
        /// Offset suffix accesses the texture with the
        /// offset added to the u and v texel coordinate
        /// before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static ivec4 texelFetchOffset(isampler2DRect sampler, ivec2 coord, ivec2 offset) { return null; }

        /// <summary>
        /// Use the unnormalized texture coordinate
        /// coord to access the rectangle texture currently
        /// specified by sampler:
        /// Combination of the suffixes Proj, Grad and
        /// Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static ivec4 textureProjGrad(isampler2DRect sampler, vec3 coord, vec2 dPdx, vec2 dPdy) { return null; }

        /// <summary>
        /// Use the unnormalized texture coordinate
        /// coord to access the rectangle texture currently
        /// specified by sampler:
        /// Combination of the suffixes Proj, Grad and
        /// Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static ivec4 textureProjGrad(isampler2DRect sampler, vec4 coord, vec2 dPdx, vec2 dPdy) { return null; }

        /// <summary>
        /// Use the unnormalized texture coordinate
        /// coord to access the rectangle texture currently
        /// specified by sampler:
        /// Combination of the suffixes Proj, Grad and
        /// Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static ivec4 textureProjOffset(isampler2DRect sampler, vec3 coord, ivec2 offset) { return null; }

        /// <summary>
        /// Use the unnormalized texture coordinate
        /// coord to access the rectangle texture currently
        /// specified by sampler:
        /// Combination of the suffixes Proj, Grad and
        /// Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static ivec4 textureProjOffset(isampler2DRect sampler, vec4 coord, ivec2 offset) { return null; }

        /// <summary>
        /// Use the unnormalized texture coordinate
        /// coord to access the rectangle texture currently
        /// specified by sampler:
        /// Combination of the suffixes Proj, Grad and
        /// Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static ivec4 textureProjGradOffset(isampler2DRect sampler, vec3 coord, vec2 dPdx, vec2 dPdy, ivec2 offset) { return null; }

        /// <summary>
        /// Use the unnormalized texture coordinate
        /// coord to access the rectangle texture currently
        /// specified by sampler:
        /// Combination of the suffixes Proj, Grad and
        /// Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static ivec4 textureProjGradOffset(isampler2DRect sampler, vec4 coord, vec2 dPdx, vec2 dPdy, ivec2 offset) { return null; }

        /// <summary>
        /// Returns the width and height of the rectangle
        /// texture currently specified by sampler.
        /// </summary>
        /// <param name="sampler"></param>
        /// <returns></returns>
        public static ivec2 textureSize(usampler2DRect sampler) { return null; }

        /// <summary>
        /// Use the unnormalized texture coordinate
        /// coord to access the rectangle texture currently
        /// specified by sampler:
        /// Unsuffixed access the texture.
        /// Proj suffix accesses the texture with
        /// projection.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture with the
        /// offset added to the u and v texel coordinates
        /// before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <returns></returns>
        public static uvec4 texture(usampler2DRect sampler, vec2 coord) { return null; }

        /// <summary>
        /// Use the unnormalized texture coordinate
        /// coord to access the rectangle texture currently
        /// specified by sampler:
        /// Unsuffixed access the texture.
        /// Proj suffix accesses the texture with
        /// projection.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture with the
        /// offset added to the u and v texel coordinates
        /// before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <returns></returns>
        public static uvec4 textureProj(usampler2DRect sampler, vec3 coord) { return null; }

        /// <summary>
        /// Use the unnormalized texture coordinate
        /// coord to access the rectangle texture currently
        /// specified by sampler:
        /// Unsuffixed access the texture.
        /// Proj suffix accesses the texture with
        /// projection.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture with the
        /// offset added to the u and v texel coordinates
        /// before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <returns></returns>
        public static uvec4 textureProj(usampler2DRect sampler, vec4 coord) { return null; }

        /// <summary>
        /// Use the unnormalized texture coordinate
        /// coord to access the rectangle texture currently
        /// specified by sampler:
        /// Unsuffixed access the texture.
        /// Proj suffix accesses the texture with
        /// projection.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture with the
        /// offset added to the u and v texel coordinates
        /// before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static uvec4 textureGrad(usampler2DRect sampler, vec2 coord, vec2 dPdx, vec2 dPdy) { return null; }

        /// <summary>
        /// Use the unnormalized texture coordinate
        /// coord to access the rectangle texture currently
        /// specified by sampler:
        /// Unsuffixed access the texture.
        /// Proj suffix accesses the texture with
        /// projection.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture with the
        /// offset added to the u and v texel coordinates
        /// before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static uvec4 textureOffset(usampler2DRect sampler, vec2 coord, ivec2 offset) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the rectangle texture currently
        /// specified by sampler:
        /// Offset suffix accesses the texture with the
        /// offset added to the u and v texel coordinate
        /// before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <returns></returns>
        public static uvec4 texelFetch(usampler2DRect sampler, ivec2 coord) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the rectangle texture currently
        /// specified by sampler:
        /// Offset suffix accesses the texture with the
        /// offset added to the u and v texel coordinate
        /// before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static uvec4 texelFetchOffset(usampler2DRect sampler, ivec2 coord, ivec2 offset) { return null; }

        /// <summary>
        /// Use the unnormalized texture coordinate
        /// coord to access the rectangle texture currently
        /// specified by sampler:
        /// Combination of the suffixes Proj, Grad and
        /// Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static uvec4 textureProjGrad(usampler2DRect sampler, vec3 coord, vec2 dPdx, vec2 dPdy) { return null; }

        /// <summary>
        /// Use the unnormalized texture coordinate
        /// coord to access the rectangle texture currently
        /// specified by sampler:
        /// Combination of the suffixes Proj, Grad and
        /// Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static uvec4 textureProjGrad(usampler2DRect sampler, vec4 coord, vec2 dPdx, vec2 dPdy) { return null; }

        /// <summary>
        /// Use the unnormalized texture coordinate
        /// coord to access the rectangle texture currently
        /// specified by sampler:
        /// Combination of the suffixes Proj, Grad and
        /// Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static uvec4 textureProjOffset(usampler2DRect sampler, vec3 coord, ivec2 offset) { return null; }

        /// <summary>
        /// Use the unnormalized texture coordinate
        /// coord to access the rectangle texture currently
        /// specified by sampler:
        /// Combination of the suffixes Proj, Grad and
        /// Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static uvec4 textureProjOffset(usampler2DRect sampler, vec4 coord, ivec2 offset) { return null; }

        /// <summary>
        /// Use the unnormalized texture coordinate
        /// coord to access the rectangle texture currently
        /// specified by sampler:
        /// Combination of the suffixes Proj, Grad and
        /// Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static uvec4 textureProjGradOffset(usampler2DRect sampler, vec3 coord, vec2 dPdx, vec2 dPdy, ivec2 offset) { return null; }

        /// <summary>
        /// Use the unnormalized texture coordinate
        /// coord to access the rectangle texture currently
        /// specified by sampler:
        /// Combination of the suffixes Proj, Grad and
        /// Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static uvec4 textureProjGradOffset(usampler2DRect sampler, vec4 coord, vec2 dPdx, vec2 dPdy, ivec2 offset) { return null; }

        /// <summary>
        /// Returns the width, height and depth of level
        /// lod of the 3D texture currently specified by sampler.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static ivec3 textureSize(sampler3D sampler, int lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with explict lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u, v, and w texel coordinates before looking
        /// up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static vec4 texture(sampler3D sampler, vec3 coord, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with explict lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u, v, and w texel coordinates before looking
        /// up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static vec4 textureProj(sampler3D sampler, vec4 coord, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with explict lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u, v, and w texel coordinates before looking
        /// up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static vec4 textureLod(sampler3D sampler, vec3 coord, double lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with explict lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u, v, and w texel coordinates before looking
        /// up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static vec4 textureGrad(sampler3D sampler, vec3 coord, vec3 dPdx, vec3 dPdy) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with explict lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u, v, and w texel coordinates before looking
        /// up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static vec4 textureOffset(sampler3D sampler, vec3 coord, ivec3 offset, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the explicit lod to access the 3D
        /// texture currently specified by sampler:
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u, v, and w texel coordinate before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static vec4 texelFetch(sampler3D sampler, ivec3 coord, int lod) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the explicit lod to access the 3D
        /// texture currently specified by sampler:
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u, v, and w texel coordinate before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static vec4 texelFetchOffset(sampler3D sampler, ivec3 coord, int lod, ivec3 offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static vec4 textureProjLod(sampler3D sampler, vec4 coord, double lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static vec4 textureProjGrad(sampler3D sampler, vec4 coord, vec3 dPdx, vec3 dPdy) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static vec4 textureProjOffset(sampler3D sampler, vec4 coord, ivec3 offset, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static vec4 textureLodOffset(sampler3D sampler, vec3 coord, double lod, ivec3 offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static vec4 textureGradOffset(sampler3D sampler, vec3 coord, vec3 dPdx, vec3 dPdy, ivec3 offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static vec4 textureProjLodOffset(sampler3D sampler, vec4 coord, double lod, ivec3 offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static vec4 textureProjGradOffset(sampler3D sampler, vec4 coord, vec3 dPdx, vec3 dPdy, ivec3 offset) { return null; }

        /// <summary>
        /// Returns the width, height and depth of level
        /// lod of the 3D texture currently specified by
        /// sampler.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static ivec3 textureSize(isampler3D sampler, int lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u, v, and w texel coordinates before looking
        /// up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static ivec4 texture(isampler3D sampler, vec3 coord, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u, v, and w texel coordinates before looking
        /// up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static ivec4 textureProj(isampler3D sampler, vec4 coord, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u, v, and w texel coordinates before looking
        /// up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static ivec4 textureLod(isampler3D sampler, vec3 coord, double lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u, v, and w texel coordinates before looking
        /// up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static ivec4 textureGrad(isampler3D sampler, vec3 coord, vec3 dPdx, vec3 dPdy) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u, v, and w texel coordinates before looking
        /// up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static ivec4 textureOffset(isampler3D sampler, vec3 coord, ivec3 offset, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the explicit lod to access the 3D
        /// texture currently specified by sampler:
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinate before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static ivec4 texelFetch(isampler3D sampler, ivec3 coord, int lod) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the explicit lod to access the 3D
        /// texture currently specified by sampler:
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinate before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static ivec4 texelFetchOffset(isampler3D sampler, ivec3 coord, int lod, ivec3 offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static ivec4 textureProjLod(isampler3D sampler, vec4 coord, double lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static ivec4 textureProjGrad(isampler3D sampler, vec4 coord, vec3 dPdx, vec3 dPdy) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static ivec4 textureProjOffset(isampler3D sampler, vec4 coord, ivec3 offset, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static ivec4 textureLodOffset(isampler3D sampler, vec3 coord, double lod, ivec3 offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static ivec4 textureGradOffset(isampler3D sampler, vec3 coord, vec3 dPdx, vec3 dPdy, ivec3 offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static ivec4 textureProjLodOffset(isampler3D sampler, vec4 coord, double lod, ivec3 offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static ivec4 textureProjGradOffset(isampler3D sampler, vec4 coord, vec3 dPdx, vec3 dPdy, ivec3 offset) { return null; }

        /// <summary>
        /// Returns the width, height and depth of level
        /// lod of the 3D texture currently specified by
        /// sampler.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static ivec3 textureSize(usampler3D sampler, int lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinates before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static uvec4 texture(usampler3D sampler, vec3 coord, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinates before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static uvec4 textureProj(usampler3D sampler, vec4 coord, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinates before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static uvec4 textureLod(usampler3D sampler, vec3 coord, double lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinates before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static uvec4 textureGrad(usampler3D sampler, vec3 coord, vec3 dPdx, vec3 dPdy) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinates before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static uvec4 textureOffset(usampler3D sampler, vec3 coord, ivec3 offset, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the explicit lod to access the 3D
        /// texture currently specified by sampler:
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u, v, and w texel coordinate before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static uvec4 texelFetch(usampler3D sampler, ivec3 coord, int lod) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the explicit lod to access the 3D
        /// texture currently specified by sampler:
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u, v, and w texel coordinate before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static uvec4 texelFetchOffset(usampler3D sampler, ivec3 coord, int lod, ivec3 offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static uvec4 textureProjLod(usampler3D sampler, vec4 coord, double lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static uvec4 textureProjGrad(usampler3D sampler, vec4 coord, vec3 dPdx, vec3 dPdy) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static uvec4 textureProjOffset(usampler3D sampler, vec4 coord, ivec3 offset, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static uvec4 textureLodOffset(usampler3D sampler, vec3 coord, double lod, ivec3 offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static uvec4 textureGradOffset(usampler3D sampler, vec3 coord, vec3 dPdx, vec3 dPdy, ivec3 offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static uvec4 textureProjLodOffset(usampler3D sampler, vec4 coord, double lod, ivec3 offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 3D texture currently specified by sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static uvec4 textureProjGradOffset(usampler3D sampler, vec4 coord, vec3 dPdx, vec3 dPdy, ivec3 offset) { return null; }

        /// <summary>
        /// Returns the width and height of level lod of
        /// the cube map texture currently specified by
        /// sampler.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static ivec2 textureSize(samplerCube sampler, int lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// cube map texture currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Lod suffix accesses the texture with explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Table 5.7 Texture access functions, continued
        /// Syntax Description
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static vec4 texture(samplerCube sampler, vec3 coord, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// cube map texture currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Lod suffix accesses the texture with explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Table 5.7 Texture access functions, continued
        /// Syntax Description
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static vec4 textureLod(samplerCube sampler, vec3 coord, double lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// cube map texture currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Lod suffix accesses the texture with explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Table 5.7 Texture access functions, continued
        /// Syntax Description
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static vec4 textureGrad(samplerCube sampler, vec3 coord, vec3 dPdx, vec3 dPdy) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the explicit lod to access the cube
        /// map texture currently specified by sampler.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static vec4 texelFetch(samplerCube sampler, ivec3 coord, int lod) { return null; }

        /// <summary>
        /// Returns the width and height of level lod of
        /// the cube map texture currently specified by
        /// sampler.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static ivec2 textureSize(isamplerCube sampler, int lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// cube map texture currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static ivec4 texture(isamplerCube sampler, vec3 coord, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// cube map texture currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static ivec4 textureLod(isamplerCube sampler, vec3 coord, double lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// cube map texture currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static ivec4 textureGrad(isamplerCube sampler, vec3 coord, vec3 dPdx, vec3 dPdy) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the explicit lod to access the cube
        /// map texture currently specified by sampler.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static ivec4 texelFetch(isamplerCube sampler, ivec3 coord, int lod) { return null; }

        /// <summary>
        /// Returns the width and height of level lod of
        /// the cube map texture currently specified by sampler.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static ivec2 textureSize(usamplerCube sampler, int lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// cube map texture currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static uvec4 texture(usamplerCube sampler, vec3 coord, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// cube map texture currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static uvec4 textureLod(usamplerCube sampler, vec3 coord, double lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// cube map texture currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static uvec4 textureGrad(usamplerCube sampler, vec3 coord, vec3 dPdx, vec3 dPdy) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the explicit lod to access the cube
        /// map texture currently specified by sampler.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static uvec4 texelFetch(usamplerCube sampler, ivec3 coord, int lod) { return null; }

        /// <summary>
        /// Returns the width of level lod of the 1D
        /// texture array currently specified by sampler.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static int textureSize(sampler1DArray sampler, int lod) { return 0; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture array currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Lod suffix accesses the texture with explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static vec4 texture(sampler1DArray sampler, vec2 coord, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture array currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Lod suffix accesses the texture with explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static vec4 textureLod(sampler1DArray sampler, vec2 coord, double lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture array currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Lod suffix accesses the texture with explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static vec4 textureGrad(sampler1DArray sampler, vec2 coord, double dPdx, double dPdy) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture array currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Lod suffix accesses the texture with explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static vec4 textureOffset(sampler1DArray sampler, vec2 coord, int offset, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
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
        public static vec4 texelFetch(sampler1DArray sampler, ivec2 coord, int lod) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
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
        public static vec4 texelFetchOffset(sampler1DArray sampler, ivec2 coord, int lod, int offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Lod, Grad, and
        /// Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static vec4 textureLodOffset(sampler1DArray sampler, vec2 coord, double lod, int offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture currently specified by sampler:
        /// Combinations of the suffixes Lod, Grad, and
        /// Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static vec4 textureGradOffset(sampler1DArray sampler, vec2 coord, double dPdx, double dPdy, int offset) { return null; }

        /// <summary>
        /// Returns the width of level lod of the 1D
        /// texture array currently specified by sampler.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static int textureSize(isampler1DArray sampler, int lod) { return 0; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture array currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static ivec4 texture(isampler1DArray sampler, vec2 coord, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture array currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static ivec4 textureLod(isampler1DArray sampler, vec2 coord, double lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture array currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static ivec4 textureGrad(isampler1DArray sampler, vec2 coord, double dPdx, double dPdy) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture array currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static ivec4 textureOffset(isampler1DArray sampler, vec2 coord, int offset, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the explicit lod to access the 1D
        /// texture array currently specified by sampler:
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u texel coordinate before looking up each
        /// texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static ivec4 texelFetch(isampler1DArray sampler, ivec2 coord, int lod) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the explicit lod to access the 1D
        /// texture array currently specified by sampler:
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
        public static ivec4 texelFetchOffset(isampler1DArray sampler, ivec2 coord, int lod, int offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture array currently specified by
        /// sampler:
        /// Combinations of the suffixes Lod, Grad, and
        /// Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static ivec4 textureLodOffset(isampler1DArray sampler, vec2 coord, double lod, int offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture array currently specified by
        /// sampler:
        /// Combinations of the suffixes Lod, Grad, and
        /// Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static ivec4 textureGradOffset(isampler1DArray sampler, vec2 coord, double dPdx, double dPdy, int offset) { return null; }

        /// <summary>
        /// Returns the width of level lod of the 1D
        /// texture array currently specified by sampler.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static int textureSize(usampler1DArray sampler, int lod) { return 0; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture array currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Lod suffix accesses the texture with explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static uvec4 texture(usampler1DArray sampler, vec2 coord, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture array currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Lod suffix accesses the texture with explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static uvec4 textureLod(usampler1DArray sampler, vec2 coord, double lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture array currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Lod suffix accesses the texture with explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static uvec4 textureGrad(usampler1DArray sampler, vec2 coord, double dPdx, double dPdy) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture array currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Lod suffix accesses the texture with explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static uvec4 textureOffset(usampler1DArray sampler, vec2 coord, int offset, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the explicit lod to access the 1D
        /// texture array currently specified by sampler:
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u texel coordinate before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static uvec4 texelFetch(usampler1DArray sampler, ivec2 coord, int lod) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the explicit lod to access the 1D
        /// texture array currently specified by sampler:
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u texel coordinate before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static uvec4 texelFetchOffset(usampler1DArray sampler, ivec2 coord, int lod, int offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture array currently specified by
        /// sampler:
        /// Combinations of the suffixes Lod, Grad, and
        /// Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static uvec4 textureLodOffset(usampler1DArray sampler, vec2 coord, double lod, int offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture array currently specified by
        /// sampler:
        /// Combinations of the suffixes Lod, Grad, and
        /// Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static uvec4 textureGradOffset(usampler1DArray sampler, vec2 coord, double dPdx, double dPdy, int offset) { return null; }

        /// <summary>
        /// Returns the width and height of level lod of
        /// the 1D texture array currently specified by
        /// sampler.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static ivec2 textureSize(sampler2DArray sampler, int lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture array currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static vec4 texture(sampler2DArray sampler, vec3 coord, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture array currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static vec4 textureLod(sampler2DArray sampler, vec3 coord, double lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture array currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static vec4 textureGrad(sampler2DArray sampler, vec3 coord, vec2 dPdx, vec2 dPdy) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture array currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static vec4 textureOffset(sampler2DArray sampler, vec3 coord, vec2 offset, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the explicit lod to access the 1D
        /// texture array currently specified by sampler:
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u texel coordinate before looking up each
        /// texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static vec4 texelFetch(sampler2DArray sampler, ivec3 coord, int lod) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the explicit lod to access the 1D
        /// texture array currently specified by sampler:
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
        public static vec4 texelFetchOffset(sampler2DArray sampler, ivec3 coord, int lod, ivec2 offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access
        /// the 1D texture array currently specified by
        /// sampler:
        /// Combinations of the suffixes Lod, Grad, and
        /// Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static vec4 textureLodOffset(sampler2DArray sampler, vec3 coord, double lod, int offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access
        /// the 1D texture array currently specified by
        /// sampler:
        /// Combinations of the suffixes Lod, Grad, and
        /// Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static vec4 textureGradOffset(sampler2DArray sampler, vec3 coord, vec2 dPdx, vec2 dPdy, ivec2 offset) { return null; }

        /// <summary>
        /// Returns the width and height of level lod of
        /// the 1D texture array currently specified by
        /// sampler.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static ivec2 textureSize(isampler2DArray sampler, int lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture array currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Lod suffix accesses the texture with explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static ivec4 texture(isampler2DArray sampler, vec3 coord, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture array currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Lod suffix accesses the texture with explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static ivec4 textureLod(isampler2DArray sampler, vec3 coord, double lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture array currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Lod suffix accesses the texture with explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static ivec4 textureGrad(isampler2DArray sampler, vec3 coord, vec2 dPdx, vec2 dPdy) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture array currently specified by sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Lod suffix accesses the texture with explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static ivec4 textureOffset(isampler2DArray sampler, vec3 coord, vec2 offset, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the explicit lod to access the 1D
        /// texture array currently specified by sampler:
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u texel coordinate before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static ivec4 texelFetch(isampler2DArray sampler, ivec3 coord, int lod) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the explicit lod to access the 1D
        /// texture array currently specified by sampler:
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u texel coordinate before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static ivec4 texelFetchOffset(isampler2DArray sampler, ivec3 coord, int lod, ivec2 offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture array currently specified by
        /// sampler:
        /// Combinations of the suffixes Lod, Grad, and
        /// Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static ivec4 textureLodOffset(isampler2DArray sampler, vec3 coord, double lod, int offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture array currently specified by
        /// sampler:
        /// Combinations of the suffixes Lod, Grad, and
        /// Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static ivec4 textureGradOffset(isampler2DArray sampler, vec3 coord, vec2 dPdx, vec2 dPdy, ivec2 offset) { return null; }

        /// <summary>
        /// Returns the width and height of level lod of
        /// the 1D texture array currently specified by sampler.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static ivec2 textureSize(usampler2DArray sampler, int lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture array currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinate before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static uvec4 texture(usampler2DArray sampler, vec3 coord, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture array currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinate before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static uvec4 textureLod(usampler2DArray sampler, vec3 coord, double lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture array currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinate before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static uvec4 textureGrad(usampler2DArray sampler, vec3 coord, vec2 dPdx, vec2 dPdy) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture array currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinate before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static uvec4 textureOffset(usampler2DArray sampler, vec3 coord, vec2 offset, double bias = 0.0) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the explicit lod to access the 1D
        /// texture array currently specified by sampler:
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinate before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static uvec4 texelFetch(usampler2DArray sampler, ivec3 coord, int lod) { return null; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the explicit lod to access the 1D
        /// texture array currently specified by sampler:
        /// Offset suffix accesses the texture (with
        /// optional lod bias) with the offset added to the
        /// u and v texel coordinate before looking up
        /// each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static uvec4 texelFetchOffset(usampler2DArray sampler, ivec3 coord, int lod, ivec2 offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture array currently specified by
        /// sampler:
        /// Combinations of the suffixes Lod, Grad, and
        /// Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static uvec4 textureLodOffset(usampler2DArray sampler, vec3 coord, double lod, int offset) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D texture array currently specified by
        /// sampler:
        /// Combinations of the suffixes Lod, Grad, and
        /// Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static uvec4 textureGradOffset(usampler2DArray sampler, vec3 coord, vec2 dPdx, vec2 dPdy, ivec2 offset) { return null; }

        /// <summary>
        /// Returns the size of the buffer texture
        /// currently specified by sampler.
        /// </summary>
        /// <param name="sampler"></param>
        /// <returns></returns>
        public static int textureSize(samplerBuffer sampler) { return 0; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the buffer texture currently specified
        /// by sampler.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static vec4 texelFetch(samplerBuffer sampler, int coord, int lod) { return null; }

        /// <summary>
        /// Returns the size of the buffer texture
        /// currently specified by sampler.
        /// </summary>
        /// <param name="sampler"></param>
        /// <returns></returns>
        public static int textureSize(isamplerBuffer sampler) { return 0; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the buffer texture currently specified
        /// by sampler.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static ivec4 texelFetch(isamplerBuffer sampler, int coord, int lod) { return null; }

        /// <summary>
        /// Returns the size of the buffer texture
        /// currently specified by sampler.
        /// </summary>
        /// <param name="sampler"></param>
        /// <returns></returns>
        public static int textureSize(usamplerBuffer sampler) { return 0; }

        /// <summary>
        /// Use the texel integer coord to look up a single
        /// texel of the buffer texture currently specified by sampler.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static uvec4 texelFetch(usamplerBuffer sampler, int coord, int lod) { return null; }

        /// <summary>
        /// Returns the width of level lod of the 1D
        /// shadow texture currently specified by sampler.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static int textureSize(sampler1DShadow sampler, int lod) { return 0; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D shadow texture currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static float texture(sampler1DShadow sampler, vec3 coord, double bias = 0.0) { return 0.0f; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D shadow texture currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static float textureProj(sampler1DShadow sampler, vec4 coord, double bias = 0.0) { return 0.0f; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D shadow texture currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static float textureLod(sampler1DShadow sampler, vec3 coord, double lod) { return 0; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D shadow texture currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static float textureGrad(sampler1DShadow sampler, vec3 coord, double dPdx, double dPdy) { return 0.0f; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D shadow texture currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
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
        public static float textureOffset(sampler1DShadow sampler, vec3 coord, int offset, double bias = 0.0) { return 0.0f; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D shadow texture currently specified by
        /// sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static float textureProjLod(sampler1DShadow sampler, vec4 coord, double lod) { return 0.0f; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D shadow texture currently specified by
        /// sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static float textureProjGrad(sampler1DShadow sampler, vec4 coord, double dPdx, double dPdy) { return 0.0f; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D shadow texture currently specified by
        /// sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static float textureProjOffset(sampler1DShadow sampler, vec4 coord, int offset, double bias = 0.0) { return 0.0f; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D shadow texture currently specified by
        /// sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static float textureLodOffset(sampler1DShadow sampler, vec3 coord, double lod, int offset) { return 0.0f; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D shadow texture currently specified by
        /// sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static float textureGradOffset(sampler1DShadow sampler, vec3 coord, double dPdx, double dPdy, int offset) { return 0.0f; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D shadow texture currently specified by
        /// sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static float textureProjLodOffset(sampler1DShadow sampler, vec4 coord, double lod, int offset) { return 0.0f; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 1D shadow texture currently specified by
        /// sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static float textureProjGradOffset(sampler1DShadow sampler, vec4 coord, double dPdx, double dPdy, int offset) { return 0.0f; }

        /// <summary>
        /// Returns the width and height of level lod of
        /// the 2D shadow texture currently specified by sampler.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static ivec2 textureSize(sampler2DShadow sampler, int lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D shadow texture currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with optional
        /// lod bias) with the offset added to the u and v
        /// texel coordinate before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static float texture(sampler2DShadow sampler, vec3 coord, double bias = 0.0) { return 0.0f; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D shadow texture currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with optional
        /// lod bias) with the offset added to the u and v
        /// texel coordinate before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static float textureProj(sampler2DShadow sampler, vec4 coord, double bias = 0.0) { return 0.0f; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D shadow texture currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with optional
        /// lod bias) with the offset added to the u and v
        /// texel coordinate before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static float textureLod(sampler2DShadow sampler, vec3 coord, double lod) { return 0.0f; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D shadow texture currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with optional
        /// lod bias) with the offset added to the u and v
        /// texel coordinate before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static float textureGrad(sampler2DShadow sampler, vec3 coord, vec2 dPdx, vec2 dPdy) { return 0.0f; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D shadow texture currently specified by
        /// sampler:
        /// Unsuffixed access the texture (with optional
        /// lod bias).
        /// Proj suffix accesses the texture with
        /// projection (with optional lod bias).
        /// Lod suffix accesses the texture with
        /// explicit lod.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture (with optional
        /// lod bias) with the offset added to the u and v
        /// texel coordinate before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static float textureOffset(sampler2DShadow sampler, vec3 coord, ivec2 offset, double bias = 0.0) { return 0.0f; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D shadow texture currently specified by
        /// sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static float textureProjLod(sampler2DShadow sampler, vec4 coord, double lod) { return 0.0f; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D shadow texture currently specified by
        /// sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static float textureProjGrad(sampler2DShadow sampler, vec4 coord, vec2 dPdx, vec2 dPdy) { return 0.0f; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D shadow texture currently specified by
        /// sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <param name="bias"></param>
        /// <returns></returns>
        public static float textureProjOffset(sampler2DShadow sampler, vec4 coord, ivec2 offset, double bias = 0.0) { return 0.0f; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D shadow texture currently specified by
        /// sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static float textureLodOffset(sampler2DShadow sampler, vec3 coord, double lod, ivec2 offset) { return 0.0f; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D shadow texture currently specified by
        /// sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static float textureGradOffset(sampler2DShadow sampler, vec3 coord, vec2 dPdx, vec2 dPdy, ivec2 offset) { return 0.0f; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D shadow texture currently specified by
        /// sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="lod"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static float textureProjLodOffset(sampler2DShadow sampler, vec4 coord, double lod, ivec2 offset) { return 0.0f; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// 2D shadow texture currently specified by
        /// sampler:
        /// Combinations of the suffixes Proj, Lod,
        /// Grad, and Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static float textureProjGradOffset(sampler2DShadow sampler, vec4 coord, vec2 dPdx, vec2 dPdy, ivec2 offset) { return 0.0f; }

        /// <summary>
        /// Returns the width and height of level lod of
        /// the rect shadow texture currently specified by sampler.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="lod"></param>
        /// <returns></returns>
        public static ivec2 textureSize(sampler2DRectShadow sampler, int lod) { return null; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// rect shadow texture currently specified by
        /// sampler:
        /// Unsuffixed access the texture.
        /// Proj suffix accesses the texture with projection.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture with the
        /// offset added to the u and v texel coordinate
        /// before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <returns></returns>
        public static float texture(sampler2DRectShadow sampler, vec3 coord) { return 0.0f; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// rect shadow texture currently specified by
        /// sampler:
        /// Unsuffixed access the texture.
        /// Proj suffix accesses the texture with projection.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture with the
        /// offset added to the u and v texel coordinate
        /// before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <returns></returns>
        public static float textureProj(sampler2DRectShadow sampler, vec4 coord) { return 0.0f; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// rect shadow texture currently specified by
        /// sampler:
        /// Unsuffixed access the texture.
        /// Proj suffix accesses the texture with projection.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture with the
        /// offset added to the u and v texel coordinate
        /// before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static float textureGrad(sampler2DRectShadow sampler, vec3 coord, vec2 dPdx, vec2 dPdy) { return 0.0f; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// rect shadow texture currently specified by
        /// sampler:
        /// Unsuffixed access the texture.
        /// Proj suffix accesses the texture with projection.
        /// Grad suffix accesses the texture with explicit
        /// partial derivatives dPdx and dPdy.
        /// Offset suffix accesses the texture with the
        /// offset added to the u and v texel coordinate
        /// before looking up each texel.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static float textureOffset(sampler2DRectShadow sampler, vec3 coord, ivec2 offset) { return 0.0f; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// rect shadow texture currently specified by
        /// sampler:
        /// Combinations of the suffixes Proj, Grad, and
        /// Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <returns></returns>
        public static float textureProjGrad(sampler2DRectShadow sampler, vec4 coord, vec2 dPdx, vec2 dPdy) { return 0.0f; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// rect shadow texture currently specified by
        /// sampler:
        /// Combinations of the suffixes Proj, Grad, and
        /// Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static float textureProjOffset(sampler2DRectShadow sampler, vec4 coord, ivec2 offset) { return 0.0f; }

        /// <summary>
        /// Use the texture coordinate coord to access the
        /// rect shadow texture currently specified by
        /// sampler:
        /// Combinations of the suffixes Proj, Grad, and
        /// Offset are as described earlier.
        /// </summary>
        /// <param name="sampler"></param>
        /// <param name="coord"></param>
        /// <param name="dPdx"></param>
        /// <param name="dPdy"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static float textureGradOffset(sampler2DRectShadow sampler, vec3 coord, vec2 dPdx, vec2 dPdy, ivec2 offset) { return 0.0f; }

        ///// <summary>
        ///// Use the texture coordinate coord to access the
        ///// rect shadow texture currently specified by
        ///// sampler:
        ///// Combinations of the suffixes Proj, Grad, and
        ///// Offset are as described earlier.
        ///// </summary>
        ///// <param name="sampler"></param>
        ///// <param name="coord"></param>
        ///// <param name="dPdx"></param>
        ///// <param name="dPdy"></param>
        ///// <param name="offset"></param>
        ///// <returns></returns>
        //public static float textureProjGradOffset(sampler2DShadow sampler, vec4 coord, vec2 dPdx, vec2 dPdy, ivec2 offset) { return 0.0f; }
    }
}