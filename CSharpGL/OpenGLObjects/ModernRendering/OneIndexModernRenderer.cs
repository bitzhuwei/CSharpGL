using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class OneIndexModernRenderer : PickableModernRenderer
    {
        protected OneIndexBufferPtr oneIndexBufferPtr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bufferable">一种渲染方式</param>
        /// <param name="shaderCodes">各种类型的shader代码</param>
        /// <param name="propertyNameMap">关联<see cref="VertexBufferPtr"/>和<see cref="ShaderCode"/>中的属性</param>
        /// <param name="positionNameInIBufferable">描述顶点位置信息的buffer的名字</param>
        ///<param name="switches"></param>
        internal OneIndexModernRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, string positionNameInIBufferable,
            params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, positionNameInIBufferable, switches)
        {
        }

        protected override void DoInitialize()
        {
            // init index buffer 
            this.oneIndexBufferPtr = this.bufferable.GetIndex() as OneIndexBufferPtr;
            if (this.oneIndexBufferPtr == null) { throw new Exception(); }

            base.DoInitialize();
        }

        protected override void DisposeUnmanagedResources()
        {
            if (this.oneIndexBufferPtr != null)
            {
                this.oneIndexBufferPtr.Dispose();
                this.oneIndexBufferPtr = null;
            }

            base.DisposeUnmanagedResources();
        }

        protected override IndexBufferPtr GetIndexBufferPtr()
        {
            return this.oneIndexBufferPtr;
        }

    }
}
