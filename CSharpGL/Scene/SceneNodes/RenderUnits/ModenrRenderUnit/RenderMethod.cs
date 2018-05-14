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
    public partial class RenderMethod
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
        public VertexArrayObject[] VertexArrayObjects { get; private set; }

        /// <summary>
        ///
        /// </summary>
        [Category(strRenderMethod)]
        [Description("OpenGL toggles.")]
        public GLSwitchList SwitchList { get; private set; }

        /// <summary>
        /// A smallest unit that can render somthing.
        /// </summary>
        /// <param name="program"></param>
        /// <param name="vaos"></param>
        /// <param name="switches"></param>
        public RenderMethod(ShaderProgram program, VertexArrayObject[] vaos, params GLSwitch[] switches)
        {
            this.Program = program;
            this.VertexArrayObjects = vaos;
            this.SwitchList = new GLSwitchList();
            this.SwitchList.AddRange(switches);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Render()
        {
            this.Render(null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transformFeedbackObj"></param>
        public void Render(TransformFeedbackObject transformFeedbackObj)
        {
            ShaderProgram program = this.Program;
            GLSwitchList switchList = this.SwitchList;

            // 绑定shader
            program.Bind();
            program.PushUniforms(); // push new uniform values to GPU side.

            switchList.On();

            if (transformFeedbackObj != null)
            {
                transformFeedbackObj.Bind();
                foreach (var vao in this.VertexArrayObjects)
                {
                    transformFeedbackObj.Begin(vao.DrawCommand.CurrentMode);
                    vao.Draw();
                    transformFeedbackObj.End();
                }
                transformFeedbackObj.Unbind();
            }
            else
            {
                foreach (var vao in this.VertexArrayObjects)
                {
                    vao.Draw();
                }
            }

            switchList.Off();

            // 解绑shader
            program.Unbind();
        }
    }
}
