using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    public partial class Renderer
    {
        /// <summary>
        ///
        /// </summary>
        [Editor(typeof(UniformVariableListEditor), typeof(UITypeEditor))]
        public List<UniformVariable> UniformVariables { get { return uniformVariables; } }

        /// <summary>
        ///
        /// </summary>
        public GLSwitchList SwitchList { get { return switchList; } }

        /// <summary>
        ///
        /// </summary>
        public IndexBufferPtr IndexBufferPtr { get { return this.indexBufferPtr; } }
    }
}