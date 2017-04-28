using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// shader program.
    /// </summary>
    public class GLStateNode : GLNode
    {
        private GLState glState;

        private static readonly Type type = typeof(GLStateNode);
        internal override Type ThisTypeCache
        {
            get { return type; }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="glState"></param>
        public GLStateNode(GLState glState)
        {
            this.glState = glState;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public GLState GetState()
        {
            return this.glState;
        }
    }
}
