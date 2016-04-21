using GLM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class ModernRenderer
    {

        public DrawMode DrawMode
        {
            get
            {
                if (this.indexBufferPtr != null)
                {
                    return this.indexBufferPtr.Mode;
                }
                else
                {
                    return CSharpGL.DrawMode.Points;
                }
            }
            set
            {
                if (this.indexBufferPtr != null)
                {
                    this.indexBufferPtr.Mode = value;
                }
            }
        }

        [Editor(typeof(GLSwithListEditor), typeof(UITypeEditor))]
        public List<GLSwitch> SwitchList
        {
            get { return switchList; }
        }

        [Editor(typeof(UniformVariableListEditor), typeof(UITypeEditor))]
        public List<UniformVariable> UniformVariables
        {
            get { return uniformVariables; }
        }
    }
}
