using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public abstract partial class ModernRenderer : RendererBase
    {
        protected string positionNameInIBufferable;
        protected PropertyBufferPtr positionBufferPtr;
        
        // normal rendering
        // 算法
        protected ShaderProgram shaderProgram;
        // 数据结构
        protected VertexArrayObject vertexArrayObject;
        protected PropertyBufferPtr[] propertyBufferPtrs;
        //protected IndexBufferPtr indexBufferPtr;
        protected List<GLSwitch> switchList = new List<GLSwitch>();

        /// <summary>
        /// 从模型到buffer的pointer
        /// </summary>
        protected IBufferable bufferable;
        protected ShaderCode[] shaderCode;
        /// <summary>
        /// vertex shader中的in变量与<see cref="propertyBufferPointers"/>中的元素名字的对应关系。
        /// </summary>
        protected PropertyNameMap propertyNameMap;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="bufferable">一种渲染方式</param>
        /// <param name="shaderCodes">各种类型的shader代码</param>
        /// <param name="propertyNameMap">关联<see cref="VertexBufferPtr"/>和<see cref="ShaderCode"/>中的属性</param>
        /// <param name="positionNameInIBufferable">描述顶点位置信息的buffer的名字</param>
        ///<param name="switches"></param>
        public ModernRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, string positionNameInIBufferable,
            params GLSwitch[] switches)
        {
            this.bufferable = bufferable;
            this.shaderCode = shaderCodes;
            this.propertyNameMap = propertyNameMap;
            this.positionNameInIBufferable = positionNameInIBufferable;
            this.switchList.AddRange(switches);
        }

    }
}
