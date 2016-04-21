using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// , , , , , , , , , , , , , , or GL_SHADER_STORAGE_BARRIER_BIT
    /// </summary>
    [Flags]
    public enum MemoryBarrierFlags : uint
    {
        VertexAttribArrayBarrier = GL.GL_VERTEX_ATTRIB_ARRAY_BARRIER_BIT,
        ElementArrayBarrier = GL.GL_ELEMENT_ARRAY_BARRIER_BIT,
        UniformBarrier = GL.GL_UNIFORM_BARRIER_BIT,
        TextureFetchBarrier = GL.GL_TEXTURE_FETCH_BARRIER_BIT,
        ShaderImageAccessBarrier = GL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT,
        CommandBarrier = GL.GL_COMMAND_BARRIER_BIT,
        PixelBufferBarrier = GL.GL_PIXEL_BUFFER_BARRIER_BIT,
        TextureUpdateBarrier = GL.GL_TEXTURE_UPDATE_BARRIER_BIT,
        BufferUpdateBarrier = GL.GL_BUFFER_UPDATE_BARRIER_BIT,
        FramebufferBarrier = GL.GL_FRAMEBUFFER_BARRIER_BIT,
        TransformFeedbackBarrier = GL.GL_TRANSFORM_FEEDBACK_BARRIER_BIT,
        /// <summary>
        /// only gl 4.4 or higher.
        /// </summary>
        QueryBufferBarrier = GL.GL_QUERY_BUFFER_BARRIER_BIT,
        AtomicCounterBarrier = GL.GL_ATOMIC_COUNTER_BARRIER_BIT,
        ClientMappedBufferBarrier = GL.GL_CLIENT_MAPPED_BUFFER_BARRIER_BIT,
        ShaderStorageBarrier = GL.GL_SHADER_STORAGE_BARRIER_BIT,
    }
}
