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
        [Category(strRenderer)]
        [Editor(typeof(UniformVariableListEditor), typeof(UITypeEditor))]
        [Description("maps to uniform variables in shader.")]
        public List<UniformVariable> UniformVariables { get { return uniformVariables; } }

        /// <summary>
        ///
        /// </summary>
        [Category(strRenderer)]
        [Description("OpenGL switches.")]
        public GLSwitchList SwitchList { get { return switchList; } }

        /// <summary>
        ///
        /// </summary>
        [Category(strRenderer)]
        [Description("index buffer(glDrawArrays or glDrawElements).")]
        public IndexBufferPtr IndexBufferPtr { get { return this.indexBufferPtr; } }
    }
}