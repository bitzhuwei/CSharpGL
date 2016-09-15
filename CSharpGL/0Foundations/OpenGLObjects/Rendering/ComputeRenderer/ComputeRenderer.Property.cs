using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    public partial class ComputeRenderer
    {
        /// <summary>
        ///
        /// </summary>
        [Editor(typeof(UniformVariableListEditor), typeof(UITypeEditor))]
        public List<UniformVariable> UniformVariables
        {
            get { return uniformVariables; }
        }
    }
}