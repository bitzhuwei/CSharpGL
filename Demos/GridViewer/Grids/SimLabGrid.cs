using GlmNet;
using SharpGL;
using SharpGL.SceneComponent;
using SharpGL.SceneComponent.Utility;
using SharpGL.SceneGraph.Assets;
using SharpGL.SceneGraph.Core;
using SharpGL.Shaders;
using SimLab.VertexBuffers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimLab
{
    /// <summary>
    /// 3D Visual Object
    /// </summary>
    public abstract class SimLabGrid : SceneElement, IDisposable
    {

        private float brightness = 1.0f;

        /// <summary>
        /// 用于调整模型最终的亮度。默认为1，即不调整。
        /// </summary>
        public float Brightness
        {
            get { return brightness; }
            set { brightness = value; }
        }
        private float opacity = 1.0f;

        public float Opacity
        {
            get { return opacity; }
            set { opacity = value; }
        }
        private bool renderGridWireframe = false;

        /// <summary>
        /// 是否渲染网格的wireframe
        /// </summary>
        public bool RenderGridWireframe
        {
            get { return renderGridWireframe; }
            set { renderGridWireframe = value; }
        }

        private bool renderGrid = true;

        /// <summary>
        /// 是否渲染网格
        /// </summary>
        public bool RenderGrid
        {
            get { return renderGrid; }
            set { renderGrid = value; }
        }

        protected uint[] positionBuffer;
        protected uint[] colorBuffer;

        protected Texture texture;

        protected OpenGL gl;
        protected IScientificCamera camera;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gl">OpenGLControl.OpenGL</param>
        /// <param name="camera"></param>
        public SimLabGrid(OpenGL gl, IScientificCamera camera)
        {
            if (gl == null || camera == null) { throw new ArgumentNullException(); }

            this.gl = gl;
            this.camera = camera;
        }

        protected uint CreateVertexBufferObject(uint mode, VertexBuffer bufferData, uint usage)
        {
            uint[] ids = new uint[1];
            gl.GenBuffers(1, ids);
            gl.BindBuffer(mode, ids[0]);
            gl.BufferData(mode, bufferData.SizeInBytes, bufferData.Data, usage);

            return ids[0];
        }
        /// <summary>
        /// 初始化顶点位置和索引
        /// </summary>
        /// <param name="gridCoords"></param>
        protected void Init(MeshBase geometry)
        {
            ////TODO:如果用此方式，则必须先将此对象加入scene树，然后再调用Init
            //OpenGL gl = this.TraverseToRootElement().ParentScene.OpenGL;
            SetPositions(geometry.Positions);
        }

        public void SetPositions(PositionBuffer positions)
        {
            ////TODO:如果用此方式，则必须先将此对象加入scene树，然后再调用Init
            //OpenGL gl = this.TraverseToRootElement().ParentScene.OpenGL;
            if (positionBuffer == null)
            {
                positionBuffer = new uint[1];
                positionBuffer[0] = CreateVertexBufferObject(OpenGL.GL_ARRAY_BUFFER, positions, OpenGL.GL_STREAM_DRAW);
            }
            else
            {
                UpdateTextureCoords(positions);
            }
        }

        protected void UpdatePositions(PositionBuffer positions)
        {
            gl.BindBuffer(OpenGL.GL_ARRAY_BUFFER, this.positionBuffer[0]);
            IntPtr destVisibles = gl.MapBuffer(OpenGL.GL_ARRAY_BUFFER, OpenGL.GL_READ_WRITE);
            MemoryHelper.CopyMemory(destVisibles, positions.Data, (uint)positions.SizeInBytes);
            gl.UnmapBuffer(OpenGL.GL_ARRAY_BUFFER);
        }

        public void SetTextureCoods(VertexBuffer textureCoords)
        {
            ////TODO:如果用此方式，则必须先将此对象加入scene树，然后再调用Init
            //OpenGL gl = this.TraverseToRootElement().ParentScene.OpenGL;
            if (colorBuffer == null)
            {
                colorBuffer = new uint[1];
                colorBuffer[0] = CreateVertexBufferObject(OpenGL.GL_ARRAY_BUFFER, textureCoords, OpenGL.GL_STREAM_DRAW);
            }
            else
            {
                UpdateTextureCoords(textureCoords);
            }
        }

        protected void UpdateTextureCoords(VertexBuffer textureCoords)
        {
            gl.BindBuffer(OpenGL.GL_ARRAY_BUFFER, this.colorBuffer[0]);
            IntPtr destVisibles = gl.MapBuffer(OpenGL.GL_ARRAY_BUFFER, OpenGL.GL_READ_WRITE);
            MemoryHelper.CopyMemory(destVisibles, textureCoords.Data, (uint)textureCoords.SizeInBytes);
            gl.UnmapBuffer(OpenGL.GL_ARRAY_BUFFER);
        }

        public void SetTexture(Bitmap bitmap)
        {
            ////TODO:如果用此方式，则必须先将此对象加入scene树，然后再调用Init
            //OpenGL gl = this.TraverseToRootElement().ParentScene.OpenGL;

            this.texture = new Texture();
            this.texture.Create(gl, bitmap);

            //参数为GL_CLAMP，则缩限，所有大于1的纹理元素值置为1。所有小于0的纹理元素值置为0。
            gl.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_WRAP_S, OpenGL.GL_CLAMP);
            gl.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_WRAP_T, OpenGL.GL_CLAMP);

        }

        /// <summary>
        /// used store any object associate with the simlab grid source
        /// </summary>
        public object Tag { get; set; }

        #region IDisposable Members

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~SimLabGrid()
        {
            this.Dispose(false);
        }

        private bool disposedValue = false;

        private void Dispose(bool disposing)
        {

            if (this.disposedValue == false)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                    DisposeManagedResources();

                } // end if

                // Dispose unmanaged resources.
                DisposeUnmanagedResources();

            }

            this.disposedValue = true;
        }

        protected virtual void DisposeUnmanagedResources()
        {
            try
            {
                if (this.positionBuffer != null)
                {
                    gl.DeleteBuffers(this.positionBuffer.Length, this.positionBuffer);
                }

                if (this.colorBuffer != null)
                {
                    gl.DeleteBuffers(this.colorBuffer.Length, this.colorBuffer);
                }

                if (this.texture != null)
                {
                    this.texture.Destroy(gl);
                }

                //gl.DeleteVertexArrays(1, new uint[] { this.vertexArrayObject });
            }
            catch (Exception)
            {
            }
        }

        protected virtual void DisposeManagedResources()
        {
        }

        #endregion

    }










}
