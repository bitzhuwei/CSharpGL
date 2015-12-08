using CSharpGL;
using CSharpGL.Objects.Shaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VertexBufferObjects
{
    /// <summary>
    /// 属性buffer，对应shader中的一个in变量。
    /// </summary>
    public class PropertyBuffer : BufferBase
    {
        /// <summary>
        /// 属性buffer，对应shader中的一个in变量。
        /// </summary>
        /// <param name="varNameInShader">在GLSL的shader中的in变量名（例如'in vec3 position;'里的'position'）</param>
        /// <param name="usage">usage in BufferData(uint target, int size, IntPtr data, uint usage)</param>
        /// <param name="size">size in VertexAttribPointer(uint index, int size, uint type, bool normalized, int stride, IntPtr pointer)</param>
        /// <param name="type">type in VertexAttribPointer(uint index, int size, uint type, bool normalized, int stride, IntPtr pointer)</param>
        public PropertyBuffer(string varNameInShader, UsageType usage, int size, uint type)
            : base(usage)
        {
            this.VarNameInShader = VarNameInShader;
            this.Size = size;
            this.Type = type;

            this.AttribLocation = uint.MaxValue;// invalid value for now.
        }

        public override BufferTargetType Target
        {
            get
            {
                return BufferTargetType.ArrayBuffer;
            }
        }

        /// <summary>
        /// 此VBO代表的数组在shader中的对应名称（例如in vec3 positions里的positions）
        /// <para>index in VertexAttribPointer(uint index, int size, uint type, bool normalized, int stride, IntPtr pointer)</para>
        /// </summary>
        private uint AttribLocation;
        
        /// <summary>
        /// 在GLSL的shader中的in变量名（例如'in vec3 position;'里的'position'）
        /// </summary>
        public string VarNameInShader { get; protected set; }

        /// <summary>
        /// size in VertexAttribPointer(uint index, int size, uint type, bool normalized, int stride, IntPtr pointer)
        /// </summary>
        public int Size { get; protected set; }
        /// <summary>
        /// type in VertexAttribPointer(uint index, int size, uint type, bool normalized, int stride, IntPtr pointer)
        /// </summary>
        public uint Type { get; protected set; }

        ///// <summary>
        ///// 从<paramref name="shaderProgram"/>中获取shader中各个in变量的指针。
        ///// </summary>
        ///// <param name="shaderProgram"></param>
        //public void FetchPropertyPointers(ShaderProgram shaderProgram)
        //{
        //    this.AttribLocation = shaderProgram.GetAttributeLocation(this.VarNameInShader);
        //}

        public override void LayoutForVAO(ShaderProgram shaderProgram)
        {
            if (this.AttribLocation == uint.MaxValue)
            { this.AttribLocation = shaderProgram.GetAttributeLocation(this.VarNameInShader); }

            GL.BindBuffer(GL.GL_ARRAY_BUFFER, this.BufferID);
            GL.VertexAttribPointer(this.AttribLocation, this.Size, this.Type, false, 0, IntPtr.Zero);
            GL.EnableVertexAttribArray(this.AttribLocation);
        }

        public override string ToString()
        {
            return string.Format("{0}, AttribLocation: {1}, VarNameInShader: {2}, Size: {3}, Type: {4}",
                base.ToString(), AttribLocation, VarNameInShader, Size, Type);
            //return base.ToString();
        }

    }
}
