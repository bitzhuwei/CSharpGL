using System;

namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    [Flags]
    public enum MemoryBarrierFlags : uint
    {
        /// <summary>
        ///
        /// </summary>
        VertexAttribArrayBarrier = OpenGL.GL_VERTEX_ATTRIB_ARRAY_BARRIER_BIT,

        /// <summary>
        ///
        /// </summary>
        ElementArrayBarrier = OpenGL.GL_ELEMENT_ARRAY_BARRIER_BIT,

        /// <summary>
        ///
        /// </summary>
        UniformBarrier = OpenGL.GL_UNIFORM_BARRIER_BIT,

        /// <summary>
        ///
        /// </summary>
        TextureFetchBarrier = OpenGL.GL_TEXTURE_FETCH_BARRIER_BIT,

        /// <summary>
        ///
        /// </summary>
        ShaderImageAccessBarrier = OpenGL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT,

        /// <summary>
        ///
        /// </summary>
        CommandBarrier = OpenGL.GL_COMMAND_BARRIER_BIT,

        /// <summary>
        ///
        /// </summary>
        PixelBufferBarrier = OpenGL.GL_PIXEL_BUFFER_BARRIER_BIT,

        /// <summary>
        ///
        /// </summary>
        TextureUpdateBarrier = OpenGL.GL_TEXTURE_UPDATE_BARRIER_BIT,

        /// <summary>
        ///
        /// </summary>
        BufferUpdateBarrier = OpenGL.GL_BUFFER_UPDATE_BARRIER_BIT,

        /// <summary>
        ///
        /// </summary>
        FramebufferBarrier = OpenGL.GL_FRAMEBUFFER_BARRIER_BIT,

        /// <summary>
        ///
        /// </summary>
        TransformFeedbackBarrier = OpenGL.GL_TRANSFORM_FEEDBACK_BARRIER_BIT,

        /// <summary>
        /// only gl 4.4 or higher.
        /// </summary>
        QueryBufferBarrier = OpenGL.GL_QUERY_BUFFER_BARRIER_BIT,

        /// <summary>
        ///
        /// </summary>
        AtomicCounterBarrier = OpenGL.GL_ATOMIC_COUNTER_BARRIER_BIT,

        /// <summary>
        ///
        /// </summary>
        ClientMappedBufferBarrier = OpenGL.GL_CLIENT_MAPPED_BUFFER_BARRIER_BIT,

        /// <summary>
        ///
        /// </summary>
        ShaderStorageBarrier = OpenGL.GL_SHADER_STORAGE_BARRIER_BIT,
    }
}