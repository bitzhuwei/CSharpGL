using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    [Flags]
    public enum MapBufferRangeAccess : uint
    {
        MapReadBit = OpenGL.GL_MAP_READ_BIT ,
        MapWriteBit = OpenGL.GL_MAP_WRITE_BIT ,
        MapInvalidateRangeBit = OpenGL.GL_MAP_INVALIDATE_RANGE_BIT,
        MapInvalidateBufferBit = OpenGL.GL_MAP_INVALIDATE_BUFFER_BIT,
        MapFlushExplicitBit = OpenGL.GL_MAP_FLUSH_EXPLICIT_BIT,
        MapUnsynchronizedBit = OpenGL.GL_MAP_UNSYNCHRONIZED_BIT,
        //MapPersistentBit = GL.GL_MAP_PERSISTENT_BIT,
        //MapCoherentBit = GL.GL_MAP_COHERENT_BIT,
    }
}
