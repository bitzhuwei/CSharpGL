namespace CSharpGL
{
    /// <summary>
    /// Decides parameter values for glVertexAttribPointer() and glEnable/DisableVertexAttribArray().
    /// </summary>
    public enum VertexAttributeConfig : uint
    {
        /// <summary>
        /// byte.
        /// </summary>
        Byte,

        /// <summary>
        /// <see cref="bvec2"/>.
        /// </summary>
        BVec2,

        /// <summary>
        /// <see cref="bvec3"/>.
        /// </summary>
        BVec3,

        /// <summary>
        /// <see cref="bvec4"/>.
        /// </summary>
        BVec4,

        /// <summary>
        /// int.
        /// </summary>
        Int,

        /// <summary>
        /// <see cref="ivec2"/>.
        /// </summary>
        IVec2,

        /// <summary>
        /// <see cref="ivec3"/>.
        /// </summary>
        IVec3,

        /// <summary>
        /// <see cref="ivec4"/>.
        /// </summary>
        IVec4,

        /// <summary>
        /// uint.
        /// </summary>
        UInt,

        /// <summary>
        /// <see cref="uvec2"/>.
        /// </summary>
        UVec2,

        /// <summary>
        /// <see cref="uvec3"/>.
        /// </summary>
        UVec3,

        /// <summary>
        /// <see cref="uvec4"/>.
        /// </summary>
        UVec4,

        /// <summary>
        /// float.
        /// </summary>
        Float,

        /// <summary>
        /// <see cref="vec2"/>.
        /// </summary>
        Vec2,

        /// <summary>
        /// <see cref="vec3"/>.
        /// </summary>
        Vec3,

        /// <summary>
        /// <see cref="vec4"/>.
        /// </summary>
        Vec4,

        /// <summary>
        /// double.
        /// </summary>
        Double,

        /// <summary>
        /// d<see cref="vec2"/>.
        /// </summary>
        DVec2,

        /// <summary>
        /// <see cref="dvec3"/>.
        /// </summary>
        DVec3,

        /// <summary>
        /// <see cref="dvec4"/>.
        /// </summary>
        DVec4,

        /// <summary>
        /// <see cref="mat2"/>.
        /// </summary>
        Mat2,

        /// <summary>
        /// <see cref="mat3"/>.
        /// </summary>
        Mat3,

        /// <summary>
        /// <see cref="mat4"/>.
        /// </summary>
        Mat4,
    }
}