using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// 索引buffer渲染器的基类。
    /// <para>Base type for Vertex Buffer Object' pointer storing vertex' index.</para>
    /// </summary>
    [Browsable(true)]
    [Editor(typeof(IndexBufferEditor), typeof(UITypeEditor))]
    public abstract class IndexBuffer : GLBuffer
    {
        /// <summary>
        /// 用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）
        /// </summary>
        public DrawMode Mode { get; set; }

        /// <summary>
        /// 索引buffer渲染器的基类。
        /// <para>Base type for Vertex Buffer Object' pointer storing vertex' index.</para>
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="bufferId"></param>
        /// <param name="firstVertex">要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para></param>
        /// <param name="vertexCount">此VBO含有多个个元素？<para>How many elements?</para></param>
        /// <param name="byteLength">此VBO中的数据在内存中占用多少个字节？<para>How many bytes in this buffer?</para></param>
        /// <param name="primCount">primCount in instanced rendering.</param>
        /// <param name="frameCount">How many frames are there?</param>
        internal IndexBuffer(DrawMode mode, uint bufferId, int firstVertex, int vertexCount, int byteLength, int primCount, int frameCount)
            : base(bufferId, vertexCount, byteLength)
        {
            this.Mode = mode;
            this.InstanceCount = primCount;
            this.FrameCount = frameCount;

            this.FirstVertex = firstVertex;
            this.RenderingVertexCount = vertexCount;
        }

        /// <summary>
        /// primCount in instanced rendering.
        /// </summary>
        public int InstanceCount { get; private set; }

        /// <summary>
        /// How many frames are there?
        /// </summary>
        [Category("ControlMode.ByFrame")]
        public int FrameCount { get; set; }

        /// <summary>
        /// Gets or sets index of current frame.
        /// </summary>
        [Category("ControlMode.ByFrame")]
        public int CurrentFrame { get; set; }


        /// <summary>
        /// 要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para>
        /// </summary>
        [Category("ControlMode.Random")]
        public int FirstVertex { get; set; }

        /// <summary>
        /// 要渲染多少个元素？<para>How many vertexes to be rendered?</para>
        /// </summary>
        [Category("ControlMode.Random")]
        public int RenderingVertexCount { get; set; }

        /// <summary>
        /// 执行此VBO的渲染操作。
        /// <para>Render using this VBO.</para>
        /// </summary>
        /// <param name="controlMode">index buffer is accessable randomly or only by frame.</param>
        public abstract void Draw(ControlMode controlMode);

        /// <summary>
        /// 
        /// </summary>
        public enum ControlMode
        {
            /// <summary>
            /// 
            /// </summary>
            ByFrame,

            /// <summary>
            /// 
            /// </summary>
            Random,

        }
    }
}