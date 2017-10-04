using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// A smallest unit that can render somthing.
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public class RenderMethod
    {
        private const string strRenderMethod = "RenderMethod";
        /// <summary>
        /// Shader Program that does the rendering algorithm.
        /// </summary>
        [Category(strRenderMethod)]
        [Description("Shader Program that does the rendering algorithm.")]
        public ShaderProgram Program { get; private set; }

        /// <summary>
        /// Vertex Array Object.
        /// </summary>
        [Category(strRenderMethod)]
        [Description("Vertex Array Object.")]
        public VertexArrayObject VertexArrayObject { get; private set; }

        /// <summary>
        ///
        /// </summary>
        [Category(strRenderMethod)]
        [Description("OpenGL toggles.")]
        public GLStateList StateList { get; private set; }

        /// <summary>
        /// A smallest unit that can render somthing.
        /// </summary>
        /// <param name="program"></param>
        /// <param name="vao"></param>
        /// <param name="states"></param>
        public RenderMethod(ShaderProgram program, VertexArrayObject vao, params GLState[] states)
        {
            this.Program = program;
            this.VertexArrayObject = vao;
            this.StateList = new GLStateList();
            this.StateList.AddRange(states);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transformFeedbackObj"></param>
        public void Render(TransformFeedbackObject transformFeedbackObj = null)
        {
            ShaderProgram program = this.Program;
            GLStateList stateList = this.StateList;

            // 绑定shader
            program.Bind();
            program.PushUniforms(); // push new uniform values to GPU side.

            stateList.On();

            if (transformFeedbackObj != null)
            {
                transformFeedbackObj.Bind();
                transformFeedbackObj.Begin(this.VertexArrayObject.IndexBuffer.Mode);
                this.VertexArrayObject.Draw();
                transformFeedbackObj.End();
                transformFeedbackObj.Unbind();
            }
            else
            {
                this.VertexArrayObject.Draw();
            }

            stateList.Off();

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
