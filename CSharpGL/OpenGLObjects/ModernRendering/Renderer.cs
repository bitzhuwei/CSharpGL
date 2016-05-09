using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 用Shader+VBO(VAO)进行渲染。
    /// </summary>
    public abstract partial class Renderer : RendererBase
    {
        protected string positionNameInIBufferable;
        internal PropertyBufferPtr positionBufferPtr;
        
        // 算法
        protected ShaderProgram shaderProgram;
        // 数据结构
        protected VertexArrayObject vertexArrayObject;
        protected PropertyBufferPtr[] propertyBufferPtrs;
        protected IndexBufferPtr indexBufferPtr;
        protected List<GLSwitch> switchList = new List<GLSwitch>();

        /// <summary>
        /// 从模型到buffer的pointer
        /// </summary>
        protected IBufferable bufferable;
        /// <summary>
        /// 各种类型的shader代码
        /// </summary>
        protected ShaderCode[] shaderCodes;
        /// <summary>
        /// vertex shader中的in变量与<see cref="propertyBufferPointers"/>中的元素名字的对应关系。
        /// </summary>
        protected PropertyNameMap propertyNameMap;


        /// <summary>
        /// 用Shader+VBO(VAO)进行渲染。
        /// </summary>
        /// <param name="bufferable">将具体模型转换为可被OpenGL拿来渲染的格式</param>
        /// <param name="shaderCodes">各种类型的shader代码</param>
        /// <param name="propertyNameMap">关联<see cref="PropertyBufferPtr"/>和<see cref="shaderCodes"/>中的属性</param>
        /// <param name="positionNameInIBufferable">描述顶点位置信息的buffer的名字</param>
        ///<param name="switches"></param>
        public Renderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, string positionNameInIBufferable,
            params GLSwitch[] switches)
        {
            this.Name = this.GetType().Name;

            this.bufferable = bufferable;
            this.shaderCodes = shaderCodes;
            this.propertyNameMap = propertyNameMap;
            this.positionNameInIBufferable = positionNameInIBufferable;
            this.switchList.AddRange(switches);
        }

    }
}
