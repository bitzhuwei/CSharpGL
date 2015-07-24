using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.VertexArrayObject
{
    /// <summary>
    /// 用VAO渲染一个元素。
    /// </summary>
    public abstract class VAOElement
    {
        public VAOElement()
        {

        }

        private bool initialized = false;

        /// <summary>
        /// VAO
        /// </summary>
        protected uint[] vao;

        /// <summary>
        /// 图元类型
        /// </summary>
        protected PrimitiveMode primitiveMode;

        /// <summary>
        /// 顶点数
        /// </summary>
        protected int vertexCount;

        /// <summary>
        /// shader
        /// </summary>
        protected Shader.ShaderProgram shader;

        /// <summary>
        /// 初始化此VAOElement
        /// </summary>
        public void Initialize()
        {
            if (!initialized)
            {
                InitializeShader(out shader);

                InitializeVAO(out vao, out primitiveMode, out vertexCount);

                initialized = true;
            }
        }

        /// <summary>
        /// 初始化Shader
        /// </summary>
        /// <param name="shader"></param>
        protected abstract void InitializeShader(out Shader.ShaderProgram shader);

        /// <summary>
        /// 初始化VAO
        /// </summary>
        /// <param name="vao"></param>
        /// <param name="primitiveMode"></param>
        /// <param name="vertexCount"></param>
        protected abstract void InitializeVAO(out uint[] vao, out PrimitiveMode primitiveMode, out int vertexCount);

        /// <summary>
        /// 在Render前更新Shader和其它状态
        /// </summary>
        /// <param name="renderMode"></param>
        protected abstract void BeforeRendering(RenderModes renderMode);

        public void Render(RenderModes renderMode)
        {
            if (!initialized) { return; }

            BeforeRendering(renderMode);

            GL.BindVertexArray(vao[0]);

            GL.DrawArrays(primitiveMode, 0, vertexCount);

            GL.BindVertexArray(0);

            AfterRendering(renderMode);
        }

        /// <summary>
        /// 在Render后恢复Shader和其它状态
        /// </summary>
        /// <param name="renderMode"></param>
        protected abstract void AfterRendering(RenderModes renderMode);
    }
}
