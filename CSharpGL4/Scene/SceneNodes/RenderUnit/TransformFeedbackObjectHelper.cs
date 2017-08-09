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

            transformFeedbackObj.Draw(unit.Program, unit.VertexArrayObject, unit.StateList);
        }
    }
}
