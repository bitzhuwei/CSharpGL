using CSharpGL;
using CSharpGL.Objects.Shaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VertexBufferObjects
{
    public class IndexBuffer : BufferBase
    {
        public IndexBuffer(UsageType usage) : base(usage) { }

        public override BufferTargetType Target
        {
            get
            {
                return BufferTargetType.ElementArrayBuffer;
            }
        }

        /// <summary>
        /// 索引数组的长度。
        /// </summary>
        public int Length { get; set; }

        public override void Create(UnmanagedArrayBase values)
        {
            base.Create(values);

            this.Length = values.Length;
        }
        public override void LayoutForVAO(ShaderProgram shaderProgram)
        {
            GL.BindBuffer((uint)Target, this.BufferID);
        }

        public override string ToString()
        {
            return string.Format("{0}, Length: {1}", base.ToString(), Length);
            //return base.ToString();
        }
    }
}
