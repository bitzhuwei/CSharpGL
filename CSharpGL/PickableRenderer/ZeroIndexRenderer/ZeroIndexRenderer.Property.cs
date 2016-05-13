using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class ZeroIndexRenderer : PickableRenderer
    {

        /// <summary>
        /// 此渲染器的索引Buffer。
        /// </summary>
        public new ZeroIndexBufferPtr IndexBufferPtr { get { return this.indexBufferPtr as ZeroIndexBufferPtr; } }
    }
}
