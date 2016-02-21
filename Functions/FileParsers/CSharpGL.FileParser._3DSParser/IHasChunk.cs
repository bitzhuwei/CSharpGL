using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.FileParser._3DSParser
{
    /// <summary>
    /// 实现此接口的类型里要有一个Chunk属性。
    /// </summary>
    public interface IHasChunk
    {
        /// <summary>
        /// 此类型里的Chunk属性。
        /// </summary>
        ThreeDSChunk Chunk { get; set; }
    }
}
