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
                var indexBuffer = this.indexBuffer as OneIndexBuffer;
                if (indexBuffer == null)
                { return 0; }
                else
                { return indexBuffer.ElementCount; }
            }
            set
            {
                var indexBuffer = this.indexBuffer as OneIndexBuffer;
                if (indexBuffer != null)
                {
                    indexBuffer.ElementCount = value;
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
                var indexBuffer = this.indexBuffer as OneIndexBuffer;
                if (indexBuffer == null)
                { return IndexElementType.UInt; }
                else
                { return indexBuffer.Type; }
            }
        }

        /// <summary>
        ///
        /// </summary>
        protected UniformMat4 uniformMVP = new UniformMat4("MVP");
    }
}