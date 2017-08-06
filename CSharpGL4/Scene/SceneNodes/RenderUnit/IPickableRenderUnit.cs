using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// A smallest unit that can render somthing.
    /// </summary>
    public class IPickableRenderUnit
    {
        private const string strIPickableRenderUnit = "IPickableRenderUnit";
        /// <summary>
        /// Shader Program that does the rendering algorithm.
        /// </summary>
        [Category(strIPickableRenderUnit)]
        [Description("Shader Program that does the picking algorithm.")]
        public ShaderProgram Program { get; private set; }

        /// <summary>
        /// Vertex Array Object.
        /// </summary>
        [Category(strIPickableRenderUnit)]
        [Description("Vertex Array Object.")]
        public VertexArrayObject VertexArrayObject { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [Category(strIPickableRenderUnit)]
        [Description("Position buffer.")]
        public VertexBuffer PositionBuffer { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [Category(strIPickableRenderUnit)]
        [Description("OpenGL toggles.")]
        public GLStateList StateList { get; private set; }

        /// <summary>
        /// A smallest unit that can render somthing.
        /// </summary>
        /// <param name="program"></param>
        /// <param name="vao"></param>
        /// <param name="positionBuffer"></param>
        /// <param name="states"></param>
        public IPickableRenderUnit(ShaderProgram program, VertexArrayObject vao, VertexBuffer positionBuffer, params GLState[] states)
        {
            this.Program = program;
            this.VertexArrayObject = vao;
            this.PositionBuffer = positionBuffer;
            this.StateList = new GLStateList();
            this.StateList.AddRange(states);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Render()
        {
            ShaderProgram program = this.Program;

            // 绑定shader
            program.Bind();
            program.PushUniforms();

            this.StateList.On();

            this.VertexArrayObject.Render();

            this.StateList.Off();

            // 解绑shader
            program.Unbind();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            VertexArrayObject vao = this.VertexArrayObject;
            if (vao != null)
            {
                vao.Dispose();
            }
            ShaderProgram program = this.Program;
            if (program != null)
            {
                program.Dispose();
            }
        }

    }
}
