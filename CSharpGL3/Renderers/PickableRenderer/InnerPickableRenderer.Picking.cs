using System;
using System.ComponentModel;
using System.Diagnostics;

namespace CSharpGL
{
    partial class InnerPickableRenderer : IPickable
    {
        /// <summary>
        /// uniform mat4 VMP; (in shader)
        /// </summary>
        protected UniformMat4 uniformmMVP4Picking = new UniformMat4("MVP");

        /// <summary>
        ///
        /// </summary>
        [Browsable(false)]
        public uint PickingBaseId { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        public void Render4Picking(RenderEventArgs arg)
        {
            if (!this.IsInitialized) { this.Initialize(); }

            UpdatePolygonMode(arg.PickingGeometryType);

            ShaderProgram program = this.Program;

            // 绑定shader
            program.Bind();
            program.glUniform("pickingBaseId",
                 (int)this.PickingBaseId);
            UniformMat4 uniformmMVP4Picking = this.uniformmMVP4Picking;
            {
                mat4 projection = arg.Camera.GetProjectionMatrix();
                mat4 view = arg.Camera.GetViewMatrix();
                mat4 model = this.GetModelMatrix().Value;
                uniformmMVP4Picking.Value = projection * view * model;
            }
            uniformmMVP4Picking.SetUniform(program);

            PickingStateesOn();

            this.vertexArrayObject.Render(arg, program);

            PickingStateesOff();

            //if (mvpUpdated) { uniformmMVP4Picking.ResetUniform(program); }

            // 解绑shader
            program.Unbind();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public uint GetVertexCount()
        {
            VertexBuffer positionBuffer = this.PositionBuffer;
            if (positionBuffer == null) { return 0; }
            int byteLength = positionBuffer.ByteLength;
            int vertexLength = positionBuffer.Config.GetDataSize() * positionBuffer.Config.GetDataTypeByteLength();
            uint vertexCount = (uint)(byteLength / vertexLength);
            return vertexCount;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="stageVertexId"></param>
        /// <param name="x">mouse position(Left Down is (0, 0)).</param>
        /// <param name="y">mouse position(Left Down is (0, 0)).</param>
        /// <returns></returns>
        public abstract PickedGeometry GetPickedGeometry(
            RenderEventArgs arg,
            uint stageVertexId,
            int x, int y);

        /// <summary>
        /// 在此Buffer中的图元进行N选1
        /// select a primitive geometry(point, line, triangle, quad, polygon) from points/lines/triangles/quads/polygons in this renderer.
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="indexBuffer">indicates the primitive to pick a line from.</param>
        internal void Render4InnerPicking(RenderEventArgs arg, IndexBuffer indexBuffer)
        {
            arg.UsingViewPort.On();

            // record clear color
            var originalClearColor = new float[4];
            OpenGL.GetFloat(GetTarget.ColorClearValue, originalClearColor);

            // 白色意味着没有拾取到任何对象
            // white color: nothing picked.
            OpenGL.glClearColor(1.0f, 1.0f, 1.0f, 1.0f);
            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            // restore clear color
            OpenGL.glClearColor(originalClearColor[0], originalClearColor[1], originalClearColor[2], originalClearColor[3]);

            this.Render4Picking(arg, indexBuffer);

            OpenGL.Flush();

            arg.UsingViewPort.Off();
            //var filename = string.Format("Render4InnerPicking{0:yyyy-MM-dd_HH-mm-ss.ff}.png", DateTime.Now);
            //Save2PictureHelper.Save2Picture(0, 0,
            //    e.CanvasRect.Width, e.CanvasRect.Height, filename);
        }

        protected vec3[] FillPickedGeometrysPosition(uint firstIndex, int indexCount)
        {
            int offset = (int)(firstIndex * this.PositionBuffer.Config.GetDataSize() * this.PositionBuffer.Config.GetDataTypeByteLength());
            //IntPtr pointer = GL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadOnly);
            IntPtr pointer = this.PositionBuffer.MapBufferRange(
                offset,
                indexCount * this.PositionBuffer.Config.GetDataSize() * this.PositionBuffer.Config.GetDataTypeByteLength(),
                MapBufferRangeAccess.MapReadBit);
            var positions = new vec3[indexCount];
            if (pointer.ToInt64() != 0)
            {
                unsafe
                {
                    var array = (vec3*)pointer.ToPointer();
                    for (uint i = 0; i < indexCount; i++)
                    {
                        positions[i] = array[i];
                    }
                }
            }
            else
            {
                ErrorCode error = (ErrorCode)OpenGL.GetError();
                if (error != ErrorCode.NoError)
                {
                    throw new Exception(string.Format(
                        "Error:[{0}] glMapBufferRange failed: buffer ID: [{1}]", error, this.PositionBuffer.BufferId.ToString()));
                }
            }
            this.PositionBuffer.UnmapBuffer();

            return positions;
        }

        protected vec3[] FillPickedGeometrysPosition(uint[] indexes)
        {
            var positions = new vec3[indexes.Length];

            this.PositionBuffer.Bind();
            for (int i = 0; i < indexes.Length; i++)
            {
                int offset = (int)(indexes[i] * this.PositionBuffer.Config.GetDataSize() * this.PositionBuffer.Config.GetDataTypeByteLength());
                //IntPtr pointer = GL.MapBuffer(BufferTarget.ArrayBuffer, MapBufferAccess.ReadOnly);
                IntPtr pointer = this.PositionBuffer.MapBufferRange(
                    offset,
                    1 * this.PositionBuffer.Config.GetDataSize() * this.PositionBuffer.Config.GetDataTypeByteLength(),
                    MapBufferRangeAccess.MapReadBit, false);
                if (pointer.ToInt64() != 0)
                {
                    unsafe
                    {
                        var array = (vec3*)pointer.ToPointer();
                        positions[i] = array[0];
                    }
                }
                else
                {
                    ErrorCode error = (ErrorCode)OpenGL.GetError();
                    if (error != ErrorCode.NoError)
                    {
                        Debug.WriteLine(string.Format(
                            "Error:[{0}] glMapBufferRange failed: buffer ID: [{1}]", error, this.PositionBuffer.BufferId.ToString()));
                    }
                }
                this.PositionBuffer.UnmapBuffer(false);
            }
            this.PositionBuffer.Unbind();

            return positions;
        }
    }
}