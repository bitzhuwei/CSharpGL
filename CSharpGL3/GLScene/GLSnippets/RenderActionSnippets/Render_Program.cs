using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class Render_ProgramNode : GLSnippet
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="glAction"></param>
        /// <param name="glNode"></param>
        public override void BeforeChildren(GLAction glAction, GLNode glNode)
        {
            var action = glAction as RenderAction;
            var node = glNode as GLProgramNode;
            Debug.Assert(action != null);
            Debug.Assert(node != null);

            action.Context.shaderProgram = node.GetShaderProgram();
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="glAction"></param>
        ///// <param name="glNode"></param>
        //public override void AfterChildren(GLAction glAction, GLNode glNode)
        //{
        //    var action = glAction as RenderAction;
        //    var node = glNode as GLProgramNode;
        //    Debug.Assert(action != null);
        //    Debug.Assert(node != null);

        //    throw new NotImplementedException();
        //}
    }
}
