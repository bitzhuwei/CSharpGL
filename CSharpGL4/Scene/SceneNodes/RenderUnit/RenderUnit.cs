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
    public class RenderUnit
    {
        private const string strRenderUnit = "RenderUnit";
        /// <summary>
        /// Shader Program that does the rendering algorithm.
        /// </summary>
        [Category(strRenderUnit)]
        [Description("Shader Program that does the rendering algorithm.")]
        public ShaderProgram Program { get; private set; }

        /// <summary>
        /// Vertex Array Object.
        /// </summary>
        [Category(strRenderUnit)]
        [Description("Vertex Array Object.")]
        public VertexArrayObject VertexArrayObject { get; private set; }

        /// <summary>
        ///
        /// </summary>
        [Category(strRenderUnit)]
        [Description("OpenGL toggles.")]
        public GLStateList StateList { get; private set; }

        /// <summary>
        /// A smallest unit that can render somthing.
        /// </summary>
        /// <param name="program"></param>
        /// <param name="vao"></param>
        /// <param name="states"></param>
        public RenderUnit(ShaderProgram program, VertexArrayObject vao, params GLState[] states)
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

            // 绑定shader
            program.Bind();
            program.PushUniforms();

            this.StateList.On();

            if (transformFeedbackObj != null)
            {
                transformFeedbackObj.Bind();
                if (!transformFeedbackObj.Begin(this.VertexArrayObject.IndexBuffer.Mode))
                {
                    throw new Exception(string.Format("{0} not acceptable as input parameter for glBeginTransformFeedback(uint primitiveMode);", this.VertexArrayObject.IndexBuffer.Mode));
                }
            }
            this.VertexArrayObject.Render();
            if (transformFeedbackObj != null)
            {
                transformFeedbackObj.End();
                transformFeedbackObj.Unbind();
            }

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
