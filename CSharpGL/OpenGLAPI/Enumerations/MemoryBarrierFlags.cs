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
        VertexAttribArrayBarrier = OpenGL.GL_VERTEX_ATTRIB_ARRAY_BARRIER_BIT,
        ElementArrayBarrier = OpenGL.GL_ELEMENT_ARRAY_BARRIER_BIT,
        UniformBarrier = OpenGL.GL_UNIFORM_BARRIER_BIT,
        TextureFetchBarrier = OpenGL.GL_TEXTURE_FETCH_BARRIER_BIT,
        ShaderImageAccessBarrier = OpenGL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT,
        CommandBarrier = OpenGL.GL_COMMAND_BARRIER_BIT,
        PixelBufferBarrier = OpenGL.GL_PIXEL_BUFFER_BARRIER_BIT,
        TextureUpdateBarrier = OpenGL.GL_TEXTURE_UPDATE_BARRIER_BIT,
        BufferUpdateBarrier = OpenGL.GL_BUFFER_UPDATE_BARRIER_BIT,
        FramebufferBarrier = OpenGL.GL_FRAMEBUFFER_BARRIER_BIT,
        TransformFeedbackBarrier = OpenGL.GL_TRANSFORM_FEEDBACK_BARRIER_BIT,
        /// <summary>
        /// only gl 4.4 or higher.
        /// </summary>
        QueryBufferBarrier = OpenGL.GL_QUERY_BUFFER_BARRIER_BIT,
        AtomicCounterBarrier = OpenGL.GL_ATOMIC_COUNTER_BARRIER_BIT,
        ClientMappedBufferBarrier = OpenGL.GL_CLIENT_MAPPED_BUFFER_BARRIER_BIT,
        ShaderStorageBarrier = OpenGL.GL_SHADER_STORAGE_BARRIER_BIT,
    }
}
