using CSharpGL;
using CSharpGL.Objects;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.Shaders;
using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VertexBufferObjects
{
    public abstract class RenderableElementBase : IVertexBuffers, IShaderProgram, IRenderable, IDisposable
    {

        #region 初始化和更新VBO

        /// <summary>
        /// 记录VBO的key和VBO对象的对应关系。
        /// </summary>
        Dictionary<string, PropertyBuffer> propertyBufferDict;
        IndexBuffer indexBuffer;

        PropertyBuffer IVertexBuffers.AddPropertyBuffer(string varNameInShader, UnmanagedArrayBase values, UsageType usage, int size, uint type)
        {
            if (this.propertyBufferDict == null) { this.propertyBufferDict = new Dictionary<string, PropertyBuffer>(); }

            if (this.propertyBufferDict.ContainsKey(varNameInShader))
            { throw new ArgumentException(string.Format("key[{0}] already exists!")); }

            var result = new PropertyBuffer(varNameInShader, usage, size, type);
            result.Create(values);

            this.propertyBufferDict.Add(varNameInShader, result);

            return result;
        }

        IndexBuffer IVertexBuffers.SetupIndexBuffer(UnmanagedArrayBase indexes, UsageType usage)
        {
            if (this.indexBuffer != null) { throw new Exception(string.Format("index buffer already exists!")); }

            var indexBuffer = new IndexBuffer(usage);
            indexBuffer.Create(indexes);

            this.indexBuffer = indexBuffer;

            return indexBuffer;
        }

        void IVertexBuffers.UpdateVertexBuffer(string key, UnmanagedArrayBase newValues)
        {
            if (this.propertyBufferDict == null)
            { throw new Exception(string.Format("property buffer dict not exists!")); }

            PropertyBuffer vbo = null;
            if (this.propertyBufferDict.TryGetValue(key, out vbo))
            {
                vbo.Update(newValues);
            }
            else
            {
                throw new ArgumentException(string.Format("key[{0}] NOT exists!"));
            }
        }

        void IVertexBuffers.UpdateVertexBuffer(string key, UnmanagedArrayBase newValues, int startIndex)
        {
            if (this.propertyBufferDict == null)
            { throw new Exception(string.Format("property buffer dict not exists!")); }

            PropertyBuffer vbo = null;
            if (this.propertyBufferDict.TryGetValue(key, out vbo))
            {
                vbo.Update(newValues, startIndex);
            }
            else
            {
                throw new ArgumentException(string.Format("key[{0}] NOT exists!"));
            }
        }

        void IVertexBuffers.UpdateIndexBuffer(UnmanagedArrayBase newValues)
        {
            IndexBuffer indexBuffer = this.indexBuffer;
            if (indexBuffer == null) { throw new Exception(string.Format("index buffer not setup yet!")); }

            indexBuffer.Update(newValues);
        }

        void IVertexBuffers.UpdateIndexBuffer(UnmanagedArrayBase newValues, int startIndex)
        {
            IndexBuffer indexBuffer = this.indexBuffer;
            if (indexBuffer == null) { throw new Exception(string.Format("index buffer not setup yet!")); }

            indexBuffer.Update(newValues, startIndex);
        }

        #endregion 初始化和更新VBO

        #region 初始化shader、VAO和渲染

        /// <summary>
        /// 
        /// </summary>
        /// <param name="renderer">指定renderer（用MultiDrawArrays或DrawElements）</param>
        public RenderableElementBase(Renderer renderer, ICamera camera)
        {
            this.renderer = renderer;
            this.camera = camera;
        }

        ShaderProgram shaderProgram;
        uint[] vertexBufferArray;
        Renderer renderer;

        void IRenderable.Render(RenderEventArgs e)
        {
            //if (vertexBufferArray == null)
            //{
            //    lock (this)
            //    {
            //        if (vertexBufferArray == null)
            //        {
            //            this.shaderProgram = GetShaderProgram();

            //            GenerateVAO(shaderProgram);
            //        }
            //    }
            //}

            //ICamera camera = this.camera;
            //if (camera != null)
            //{
            //    if (camera.CameraType == CameraType.Perspecitive)
            //    {
            //        IPerspectiveViewCamera perspective = camera;
            //        this.projectionMatrix = perspective.GetProjectionMat4();
            //        this.viewMatrix = perspective.GetViewMat4();
            //    }
            //    else if (camera.CameraType == CameraType.Ortho)
            //    {
            //        IOrthoViewCamera ortho = camera;
            //        this.projectionMatrix = ortho.GetProjectionMat4();
            //        this.viewMatrix = ortho.GetViewMat4();
            //    }
            //    else
            //    { throw new NotImplementedException(); }
            //}

            //modelMatrix = mat4.identity();
            ////  Bind the shader, set the matrices.
            //shaderProgram.Bind();
            //shaderProgram.SetUniformMatrix4("projectionMatrix", projectionMatrix.to_array());
            //shaderProgram.SetUniformMatrix4("viewMatrix", viewMatrix.to_array());
            //shaderProgram.SetUniformMatrix4("modelMatrix", modelMatrix.to_array());

            //GL.Enable(GL.GL_POLYGON_SMOOTH);
            //GL.Hint(GL.GL_POLYGON_SMOOTH_HINT, GL.GL_NICEST);

            //this.renderer.Render(new RenderEventArgs(RenderModes.Render, camera));

            //GL.Disable(GL.GL_POLYGON_SMOOTH);

            //shaderProgram.Unbind();
        }

        //private ShaderProgram InitShader()
        //{
        //    String vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"HexahedronElement.vert");
        //    String fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"HexahedronElement.frag");
        //    ShaderProgram shaderProgram = new ShaderProgram();
        //    shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

        //    shaderProgram.AssertValid();
        //    return shaderProgram;
        //}

        private void GenerateVAO(ShaderProgram shaderProgram)
        {
            vertexBufferArray = new uint[1];
            GL.GenVertexArrays(1, vertexBufferArray);
            GL.BindVertexArray(vertexBufferArray[0]);

            foreach (var vbo in propertyBufferDict)
            {
                vbo.Value.LayoutForVAO(shaderProgram);
            }

            if (indexBuffer != null)
            { indexBuffer.LayoutForVAO(shaderProgram); }

            GL.BindVertexArray(0);
        }

        #endregion 初始化shader、VAO和渲染

        #region 释放VBO和VAO

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~RenderableElementBase()
        {
            this.Dispose(false);
        }

        private bool disposedValue = false;
        private ICamera camera;
        private mat4 projectionMatrix;
        private mat4 viewMatrix;
        private mat4 modelMatrix;

        protected virtual void Dispose(bool disposing)
        {

            if (this.disposedValue == false)
            {
                if (disposing)
                {
                    // Dispose managed resources.

                }

                // Dispose unmanaged resources.

                try
                {
                    if (this.propertyBufferDict != null)
                    {
                        uint[] buffers = new uint[this.propertyBufferDict.Count];
                        int i = 0;
                        foreach (var vbo in propertyBufferDict)
                        {
                            buffers[i++] = vbo.Value.BufferID;
                        }

                        GL.DeleteBuffers(buffers.Length, buffers);
                    }

                    if (this.indexBuffer != null)
                    {
                        GL.DeleteBuffers(1, new uint[] { this.indexBuffer.BufferID });
                    }

                    if (this.vertexBufferArray != null)
                    {
                        GL.DeleteVertexArrays(this.vertexBufferArray.Length, this.vertexBufferArray);
                    }
                }
                catch (Exception)
                {
                }
            }

            this.disposedValue = true;
        }


        #endregion 释放VBO和VAO





        public abstract ShaderProgram GetShaderProgram();
    }
}
