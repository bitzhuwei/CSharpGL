using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    partial class ZeroIndexRenderer
    {

        /// <summary>
        /// 此渲染器的索引Buffer。
        /// </summary>
        public new ZeroIndexBufferPtr IndexBufferPtr { get { return this.indexBufferPtr as ZeroIndexBufferPtr; } }
    }
}
