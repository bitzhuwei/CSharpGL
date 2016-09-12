using System;

namespace CSharpGL
{
    /// <summary>
    /// VAO是用来管理VBO的。可以进一步减少DrawCall。
    /// <para>VAO is used to reduce draw-call.</para>
    /// </summary>
    public sealed class VertexArrayObject : IDisposable
    {
        /// <summary>
        ///
        /// </summary>
        public VertexAttributeBufferPtr[] PropertyBufferPtrs { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public IndexBufferPtr IndexBufferPtr { get; private set; }

        private uint[] ids = new uint[1];
        /// <summary>
        /// 此VAO的ID，由OpenGL给出。
        /// <para>Id gets from glGenVertexArrays().</para>
        /// </summary>
        public uint Id { get { return ids[0]; } }

        private static OpenGL.glGenVertexArrays glGenVertexArrays;
        private static OpenGL.glBindVertexArray glBindVertexArray;
        private static OpenGL.glDeleteVertexArrays glDeleteVertexArrays;

        /// <summary>
        /// VAO是用来管理VBO的。可以进一步减少DrawCall。
        /// <para>VAO is used to reduce draw-call.</para>
        /// </summary>
        /// <param name="indexBufferPtr">index buffer pointer that used to invoke draw command.</param>
        /// <param name="propertyBufferPtrs">给出此VAO要管理的所有VBO。<para>All VBOs that are managed by this VAO.</para></param>
        public VertexArrayObject(IndexBufferPtr indexBufferPtr, params VertexAttributeBufferPtr[] propertyBufferPtrs)
        {
            if (indexBufferPtr == null)
            {
                throw new ArgumentNullException("indexBufferPtr");
            }
            if (propertyBufferPtrs == null || propertyBufferPtrs.Length == 0)
            {
                throw new ArgumentNullException("propertyBufferPtrs");
            }

            this.IndexBufferPtr = indexBufferPtr;
            this.PropertyBufferPtrs = propertyBufferPtrs;
        }

        /// <summary>
        /// 在OpenGL中创建VAO。
        /// 创建的过程就是执行一次渲染的过程。
        /// <para>Creates VAO and bind it to specified VBOs.</para>
        /// <para>The whole process of binding is also the process of rendering.</para>
        /// </summary>
        /// <param name="shaderProgram"></param>
        public void Create(ShaderProgram shaderProgram)
        {
            if (this.Id != 0)
            { throw new Exception(string.Format("Id[{0}] is already generated!", this.Id)); }

            if (glGenVertexArrays == null)
            {
                glGenVertexArrays = OpenGL.GetDelegateFor<OpenGL.glGenVertexArrays>();
                glBindVertexArray = OpenGL.GetDelegateFor<OpenGL.glBindVertexArray>();
                glDeleteVertexArrays = OpenGL.GetDelegateFor<OpenGL.glDeleteVertexArrays>();
            }

            glGenVertexArrays(1, ids);

            this.Bind();
            VertexAttributeBufferPtr[] propertyBufferPtrs = this.PropertyBufferPtrs;
            if (propertyBufferPtrs != null)
            {
                foreach (var item in propertyBufferPtrs)
                {
                    item.Standby(shaderProgram);
                }
            }
            this.Unbind();
        }

        private void Bind()
        {
            glBindVertexArray(this.Id);
        }

        private void Unbind()
        {
            glBindVertexArray(0);
        }

        /// <summary>
        /// 执行一次渲染的过程。
        /// <para>Execute rendering command.</para>
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="shaderProgram"></param>
        /// <param name="temporaryIndexBufferPtr">render by a temporary index buffer</param>
        public void Render(RenderEventArgs arg, ShaderProgram shaderProgram, IndexBufferPtr temporaryIndexBufferPtr = null)
        {
            if (temporaryIndexBufferPtr == null)
            {
                IndexBufferPtr indexBufferPtr = this.IndexBufferPtr;
                this.Bind();
                indexBufferPtr.Render(arg);
                this.Unbind();
            }
            else
            {
                this.Bind();
                temporaryIndexBufferPtr.Render(arg);
                this.Unbind();
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override string ToString()
        {
            return string.Format("VAO Id: {0}", this.Id);
        }

        /// <summary>
        ///
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///
        /// </summary>
        ~VertexArrayObject()
        {
            this.Dispose(false);
        }

        private bool disposedValue;

        private void Dispose(bool disposing)
        {
            if (this.disposedValue == false)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                }

                // Dispose unmanaged resources.
                IntPtr ptr = Win32.wglGetCurrentContext();
                if (ptr != IntPtr.Zero)
                {
                    {
                        glDeleteVertexArrays(1, this.ids);
                        this.ids[0] = 0;
                    }
                    {
                        VertexAttributeBufferPtr[] propertyBufferPtrs = this.PropertyBufferPtrs;
                        if (propertyBufferPtrs != null)
                        {
                            foreach (var item in propertyBufferPtrs)
                            {
                                item.Dispose();
                            }
                        }
                    }
                    {
                        IndexBufferPtr indexBufferPtr = this.IndexBufferPtr;
                        indexBufferPtr.Dispose();
                    }
                }
            }

            this.disposedValue = true;
        }
    }
}