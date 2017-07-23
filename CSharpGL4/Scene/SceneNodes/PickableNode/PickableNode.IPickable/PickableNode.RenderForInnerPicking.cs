using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    partial class PickableNode
    {

        /// <summary>
        /// 在此Buffer中的图元进行N选1
        /// select a primitive geometry(point, line, triangle, quad, polygon) from points/lines/triangles/quads/polygons in this renderer.
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="indexBuffer">indicates the primitive to pick a line from.</param>
        internal void Render4InnerPicking(PickingEventArgs arg, IndexBuffer indexBuffer)
        {
            // record clear color
            var originalClearColor = new float[4];
            GL.Instance.GetFloatv((uint)GetTarget.ColorClearValue, originalClearColor);

            // 白色意味着没有拾取到任何对象
            // white color: nothing picked.
            GL.Instance.ClearColor(1.0f, 1.0f, 1.0f, 1.0f);
            GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

            // restore clear color
            GL.Instance.ClearColor(originalClearColor[0], originalClearColor[1], originalClearColor[2], originalClearColor[3]);

            this.RenderForPicking(arg, indexBuffer);

            GL.Instance.Flush();

            //var filename = string.Format("Render4InnerPicking{0:yyyy-MM-dd_HH-mm-ss.ff}.png", DateTime.Now);
            //Save2PictureHelper.Save2Picture(0, 0,
            //    e.CanvasRect.Width, e.CanvasRect.Height, filename);
        }

        private void RenderForPicking(PickingEventArgs arg, IndexBuffer tempIndexBuffer)
        {
            if (!this.IsInitialized) { this.Initialize(); }

            this.polygonModeState.Mode = arg.GeometryType.GetPolygonMode();

            ShaderProgram program = this.PickingRenderUnit.Program;

            // 绑定shader
            program.Bind();
            program.glUniform("pickingBaseId", (int)(((IPickable)this).PickingBaseId));
            {
                mat4 projection = arg.Scene.Camera.GetProjectionMatrix();
                mat4 view = arg.Scene.Camera.GetViewMatrix();
                mat4 model = this.GetModelMatrix();
                program.glUniform("MVP", projection * view * model);
            }

            this.polygonModeState.On();
            this.lineWidthState.On();
            this.pointSizeState.On();

            var oneIndexBuffer = tempIndexBuffer as OneIndexBuffer;
            if (oneIndexBuffer != null)
            {
                PrimitiveRestartState glState = this.GetPrimitiveRestartState(oneIndexBuffer);
                glState.On();
                this.PickingRenderUnit.VertexArrayObject.Render(program, tempIndexBuffer);
                glState.Off();
            }
            else
            {
                this.PickingRenderUnit.VertexArrayObject.Render(program, tempIndexBuffer);
            }

            this.pointSizeState.Off();
            this.lineWidthState.Off();
            this.polygonModeState.Off();

            // 解绑shader
            program.Unbind();
        }

        private PrimitiveRestartState ubyteRestartIndexState = null;
        private PrimitiveRestartState ushortRestartIndexState = null;
        private PrimitiveRestartState uintRestartIndexState = null;

        private PrimitiveRestartState GetPrimitiveRestartState(OneIndexBuffer indexBuffer)
        {
            PrimitiveRestartState result = null;
            switch (indexBuffer.ElementType)
            {
                case IndexBufferElementType.UByte:
                    if (this.ubyteRestartIndexState == null)
                    { this.ubyteRestartIndexState = new PrimitiveRestartState(indexBuffer.ElementType); }
                    result = this.ubyteRestartIndexState;
                    break;

                case IndexBufferElementType.UShort:
                    if (this.ushortRestartIndexState == null)
                    { this.ushortRestartIndexState = new PrimitiveRestartState(indexBuffer.ElementType); }
                    result = this.ushortRestartIndexState;
                    break;

                case IndexBufferElementType.UInt:
                    if (this.uintRestartIndexState == null)
                    { this.uintRestartIndexState = new PrimitiveRestartState(indexBuffer.ElementType); }
                    result = this.uintRestartIndexState;
                    break;

                default:
                    throw new Exception("Unexpected IndexBufferElementType!");
            }

            return result;
        }
    }
}
