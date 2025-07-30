using System;
using System.Collections.Generic;

namespace SoftGLImpl {
    enum BindBufferTarget : uint {
        ArrayBuffer = GL.GL_ARRAY_BUFFER,
        AtomicCounterBuffer = GL.GL_ATOMIC_COUNTER_BUFFER,
        //CopyReadBuffer = GL.GL_COPY_READ_BUFFER,
        //CopyWriteBuffer = GL.GL_COPY_WRITE_BUFFER,
        //DrawIndirectBuffer = GL.GL_DRAW_INDIRECT_BUFFER,
        //DispatchIndirectBuffer = GL.GL_DISPATCH_INDIRECT_BUFFER,
        ElementArrayBuffer = GL.GL_ELEMENT_ARRAY_BUFFER,
        PixelPackBuffer = GL.GL_PIXEL_PACK_BUFFER,
        PixelUnpackBuffer = GL.GL_PIXEL_UNPACK_BUFFER,
        //QueryBuffer = GL.GL_QUERY_BUFFER,
        ShaderStorageBuffer = GL.GL_SHADER_STORAGE_BUFFER,
        TextureBuffer = GL.GL_TEXTURE_BUFFER,
        TransformFeedbackBuffer = GL.GL_TRANSFORM_FEEDBACK_BUFFER,
        UniformBuffer = GL.GL_UNIFORM_BUFFER
    }

    enum Usage : uint {
        StreamDraw = GL.GL_STREAM_DRAW,
        StreamRead = GL.GL_STREAM_READ,
        SteramCopy = GL.GL_STREAM_COPY,
        StaticDraw = GL.GL_STATIC_DRAW,
        StaticRead = GL.GL_STATIC_READ,
        StaticCopy = GL.GL_STATIC_COPY,
        DynamicDraw = GL.GL_DYNAMIC_DRAW,
        DynamicRead = GL.GL_DYNAMIC_READ,
        DynamicCopy = GL.GL_DYNAMIC_COPY
    }
}
