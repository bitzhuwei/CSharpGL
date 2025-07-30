using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// A smallest unit that can render somthing.
    /// </summary>

    public partial class RenderMethod {
        /// <summary>
        /// Shader Program that does the rendering algorithm.
        /// </summary>
        public GLProgram Program { get; private set; }

        /// <summary>
        /// Vertex Array Object.
        /// </summary>
        public VertexArrayObject[] VertexArrayObjects { get; private set; }

        /// <summary>
        /// OpenGL toggles.
        /// </summary>
        public GLSwitchList SwitchList { get; private set; }

        /// <summary>
        /// A smallest unit that can render somthing.
        /// </summary>
        /// <param name="program"></param>
        /// <param name="vaos"></param>
        /// <param name="switches"></param>
        public RenderMethod(GLProgram program, VertexArrayObject[] vaos, params GLSwitch[] switches) {
            this.Program = program;
            this.VertexArrayObjects = vaos;
            this.SwitchList = new GLSwitchList();
            this.SwitchList.AddRange(switches);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Render(params IDrawCommand[] drawCmds) {
            this.Render(null, drawCmds);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transformFeedbackObj"></param>
        public void Render(TransformFeedbackObject? transformFeedbackObj, params IDrawCommand[] drawCmds) {
            GLProgram program = this.Program;
            GLSwitchList switchList = this.SwitchList;

            // 绑定shader
            program.Bind();
            program.PushUniforms(); // push new uniform values to GPU side.

            switchList.On();

            if (transformFeedbackObj != null) {
                GL.StopAtError();
                transformFeedbackObj.Bind();
                GL.StopAtError();
                foreach (var vao in this.VertexArrayObjects) {
                    GL.StopAtError();
                    transformFeedbackObj.Begin(vao.DrawCommand.Mode);
                    GL.StopAtError();
                    vao.Draw(drawCmds);
                    GL.StopAtError();
                    transformFeedbackObj.End();
                    GL.StopAtError();
                }
                GL.StopAtError();
                transformFeedbackObj.Unbind();
                GL.StopAtError();
            }
            else {
                foreach (var vao in this.VertexArrayObjects) {
                    vao.Draw(drawCmds);
                }
            }

            switchList.Off();

            // 解绑shader
            program.Unbind();
        }
    }
}
