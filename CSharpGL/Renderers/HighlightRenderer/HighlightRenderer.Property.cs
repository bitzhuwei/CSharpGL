namespace CSharpGL
{
    public partial class HighlightRenderer
    {
        /// <summary>
        /// 要渲染多少个索引。
        /// </summary>
        public int ElementCount
        {
            get
            {
                var indexBufferPtr = this.indexBufferPtr as OneIndexBufferPtr;
                if (indexBufferPtr == null)
                { return 0; }
                else
                { return indexBufferPtr.ElementCount; }
            }
            set
            {
                var indexBufferPtr = this.indexBufferPtr as OneIndexBufferPtr;
                if (indexBufferPtr != null)
                {
                    indexBufferPtr.ElementCount = value;
                }
            }
        }

        /// <summary>
        /// type in GL.DrawElements(uint mode, int count, uint type, IntPtr indices);
        /// 只能是OpenGL.UNSIGNED_BYTE, OpenGL.UNSIGNED_SHORT, or OpenGL.UNSIGNED_INT
        /// </summary>
        public IndexElementType Type
        {
            get
            {
                var indexBufferPtr = this.indexBufferPtr as OneIndexBufferPtr;
                if (indexBufferPtr == null)
                { return IndexElementType.UnsignedInt; }
                else
                { return indexBufferPtr.Type; }
            }
        }

        /// <summary>
        ///
        /// </summary>
        protected UniformMat4 uniformMVP = new UniformMat4("MVP");

        /// <summary>
        ///
        /// </summary>
        public mat4 MVP
        {
            get { return this.uniformMVP.Value; }
            set
            {
                if (value != this.uniformMVP.Value)
                {
                    this.uniformMVP.Value = value;
                }
            }
        }
    }
}