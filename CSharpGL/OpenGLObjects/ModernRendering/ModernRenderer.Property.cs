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

        public int VertexCount
        {
            get
            {
                if (this.indexBufferPtr == null) { return 0; }

                {
                    var indexBufferPtr = this.indexBufferPtr as OneIndexBufferPtr;
                    if (indexBufferPtr != null)
                    {
                        return indexBufferPtr.ElementCount;
                    }
                }
                {
                    var indexBufferPtr = this.indexBufferPtr as ZeroIndexBufferPtr;
                    if (indexBufferPtr != null)
                    {
                        return indexBufferPtr.VertexCount;
                    }
                }
                { throw new NotImplementedException(); }
            }
            set
            {
                {
                    var indexBufferPtr = this.indexBufferPtr as OneIndexBufferPtr;
                    if (indexBufferPtr != null)
                    {
                        if (indexBufferPtr.ElementCount > 0)
                        {
                            indexBufferPtr.ElementCount = value;
                        }
                        return;
                    }
                }
                {
                    var indexBufferPtr = this.indexBufferPtr as ZeroIndexBufferPtr;
                    if (indexBufferPtr != null)
                    {
                        if (indexBufferPtr.VertexCount > 0)
                        {
                            indexBufferPtr.VertexCount = value;
                        }
                        return;
                    }
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
