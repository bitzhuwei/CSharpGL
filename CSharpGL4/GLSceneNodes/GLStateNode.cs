using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// shader program.
    /// </summary>
    public class GLStateNode : GLSceneNode
    {

        private static readonly Type type = typeof(GLStateNode);
        internal override Type SelfTypeCache { get { return type; } }

        private List<IGLState> stateList = new List<IGLState>();

        /// <summary>
        /// 
        /// </summary>
        public IList<IGLState> StateList { get { return this.stateList; } }

    }
}
