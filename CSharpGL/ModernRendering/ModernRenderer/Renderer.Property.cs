using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class Renderer
    {

        public DrawMode Mode
        {
            get
            {
                if (this.GetIndexBufferPtr() != null)
                {
                    return this.GetIndexBufferPtr().Mode;
                }
                else
                {
                    return CSharpGL.DrawMode.Points;
                }
            }
            set
            {
                if (this.GetIndexBufferPtr() != null)
                {
                    this.GetIndexBufferPtr().Mode = value;
                }
            }
        }

        /// <summary>
        /// 用GL.GenBuffers()得到的VBO的ID。
        /// </summary>
        public uint BufferId
        {
            get
            {
                if (this.GetIndexBufferPtr() != null)
                {
                    return this.GetIndexBufferPtr().BufferId;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 此VBO含有多个个元素？
        /// </summary>
        public int Length
        {
            get
            {
                if (this.GetIndexBufferPtr() != null)
                {
                    return this.GetIndexBufferPtr().Length;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 此VBO含有多个个字节？
        /// </summary>
        public int ByteLength
        {
            get
            {
                if (this.GetIndexBufferPtr() != null)
                {
                    return this.GetIndexBufferPtr().ByteLength;
                }
                else
                {
                    return 0;
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
