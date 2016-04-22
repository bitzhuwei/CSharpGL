using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class ZeroIndexModernRenderer : ModernRenderer
    {
        protected ZeroIndexBufferPtr zeroIndexBufferPtr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bufferable">一种渲染方式</param>
        /// <param name="shaderCodes">各种类型的shader代码</param>
        /// <param name="propertyNameMap">关联<see cref="VertexBufferPtr"/>和<see cref="ShaderCode"/>中的属性</param>
        /// <param name="positionNameInIBufferable">描述顶点位置信息的buffer的名字</param>
        ///<param name="switches"></param>
        internal ZeroIndexModernRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, string positionNameInIBufferable,
            params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, positionNameInIBufferable, switches)
        {
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            // init index buffer object's renderer
            this.zeroIndexBufferPtr = this.bufferable.GetIndex() as ZeroIndexBufferPtr;
            if (this.zeroIndexBufferPtr == null) { throw new Exception(); }
        }

        protected override void DisposeUnmanagedResources()
        {
            if (this.zeroIndexBufferPtr != null)
            {
                this.zeroIndexBufferPtr.Dispose();
                this.zeroIndexBufferPtr = null;
            }

            base.DisposeUnmanagedResources();
        }

        protected override IndexBufferPtr indexBufferPtr
        {
            get { return this.zeroIndexBufferPtr; }
        }
    }
}
