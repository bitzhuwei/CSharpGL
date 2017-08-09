using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class TransformFeedbackObjectHelper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transformFeedbackObj"></param>
        /// <param name="unit"></param>
        public static void Draw(this TransformFeedbackObject transformFeedbackObj, RenderUnit unit)
        {
            if (transformFeedbackObj == null || unit == null)
            {
                throw new ArgumentNullException();
            }

            ShaderProgram program = unit.Program;
            GLStateList stateList = unit.StateList;

            // 绑定shader
            program.Bind();
            program.PushUniforms(); // push new uniform values to GPU side.

            stateList.On();

            DrawMode mode = unit.VertexArrayObject.IndexBuffer.Mode;
            transformFeedbackObj.Bind();
            transformFeedbackObj.Begin(mode);
            transformFeedbackObj.Draw(mode);
            transformFeedbackObj.End();
            transformFeedbackObj.Unbind();

            stateList.Off();

            // 解绑shader
            program.Unbind();
        }
    }
}
