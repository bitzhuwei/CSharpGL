using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 用glDrawElements进行渲染。
    /// </summary>
    partial class OneIndexRenderer : InnerPickableRenderer
    {

        PrimitiveRestartSwitch primitiveRestartSwitch4Picking;

        /// <summary>
        /// 用glDrawElements进行渲染。
        /// </summary>
        /// <param name="bufferable">一种渲染方式</param>
        /// <param name="shaderCodes">各种类型的shader代码</param>
        /// <param name="propertyNameMap">关联<see cref="PropertyBufferPtr"/>和<see cref="shaderCode"/>中的属性</param>
        /// <param name="positionNameInIBufferable">描述顶点位置信息的buffer的名字</param>
        ///<param name="switches"></param>
        internal OneIndexRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, string positionNameInIBufferable,
            params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, positionNameInIBufferable, switches)
        {
            
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            // init index buffer 
            var primitiveRestartSwitch4Picking = new PrimitiveRestartSwitch(this.indexBufferPtr as OneIndexBufferPtr);
            this.primitiveRestartSwitch4Picking = primitiveRestartSwitch4Picking;
            this.switchList.Add(primitiveRestartSwitch4Picking);
        }


    }
}
