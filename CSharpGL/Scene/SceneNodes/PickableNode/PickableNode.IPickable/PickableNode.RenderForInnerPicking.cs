﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    partial class PickableNode {

        /// <summary>
        /// 在此Buffer中的图元进行N选1
        /// select a primitive geometry(point, line, triangle, quad, polygon) from points/lines/triangles/quads/polygons in this node.
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="drawCmd">indicates the primitive to pick a line from.</param>
        internal unsafe void Render4InnerPicking(PickingEventArgs arg, IDrawCommand drawCmd) {
            // record clear color
            var originalClearColor = new float[4];
            var gl = GL.current; if (gl != null) {
                fixed (float* p = originalClearColor) {
                    gl.glGetFloatv((GLenum)GetTarget.ColorClearValue, p);
                }

                // 白色意味着没有拾取到任何对象
                // white color: nothing picked.
                gl.glClearColor(1.0f, 1.0f, 1.0f, 1.0f);
                gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                // restore clear color
                gl.glClearColor(originalClearColor[0], originalClearColor[1], originalClearColor[2], originalClearColor[3]);

                this.RenderForPicking(arg, drawCmd);

                gl.glFlush();
            }

            //var filename = string.Format("Render4InnerPicking{0:yyyy-MM-dd_HH-mm-ss.ff}.png", DateTime.Now);
            //Save2PictureHelper.Save2Picture(0, 0,
            //    e.CanvasRect.Width, e.CanvasRect.Height, filename);
        }

        private void RenderForPicking(PickingEventArgs arg, IDrawCommand? tmpCmd) {
            if (!this.IsInitialized) { this.Initialize(); }

            this.polygonModeState.mode = arg.GeometryType.GetPolygonMode();

            GLProgram program = this.PickingRenderMethod.Program;

            // 绑定shader
            program.Bind();
            {
                mat4 projection = arg.Scene.camera.GetProjectionMatrix();
                mat4 view = arg.Scene.camera.GetViewMatrix();
                mat4 model = this.GetModelMatrix();
                program.glUniform("MVP", projection * view * model);
            }

            this.polygonModeState.On();
            this.lineWidthState.On();
            this.pointSizeState.On();

            //PrimitiveRestartState restart = null;
            //var hasIndexBuffer = tmpCmd as IHasIndexBuffer;
            //if (hasIndexBuffer != null)
            //{
            //    restart = this.GetPrimitiveRestartState(hasIndexBuffer.IndexBufferObject.ElementType);
            //}
            //if (restart != null)
            //{
            //    restart.On();
            //}
            {
                var pickable = this as IPickable;
                uint baseId = pickable.PickingBaseId;
                foreach (var vao in this.PickingRenderMethod.VertexArrayObjects) {
                    program.glUniform("pickingBaseId", (int)(baseId));
                    if (tmpCmd != null) { vao.Draw(tmpCmd); }
                    else { vao.Draw(); }
                    baseId += (uint)vao.VertexAttributes[0].buffer.count;
                }
            }
            //if (restart != null)
            //{
            //    restart.Off();
            //}

            this.pointSizeState.Off();
            this.lineWidthState.Off();
            this.polygonModeState.Off();

            // 解绑shader
            program.Unbind();
        }

        //private PrimitiveRestartState ubyteRestartIndexState = null;
        //private PrimitiveRestartState ushortRestartIndexState = null;
        //private PrimitiveRestartState uintRestartIndexState = null;

        //private PrimitiveRestartState GetPrimitiveRestartState(IndexBuffer.ElementType type)
        //{
        //    PrimitiveRestartState result = null;
        //    switch (type)
        //    {
        //        case IndexBuffer.ElementType.UByte:
        //            if (this.ubyteRestartIndexState == null)
        //            { this.ubyteRestartIndexState = new PrimitiveRestartState(type); }
        //            result = this.ubyteRestartIndexState;
        //            break;

        //        case IndexBuffer.ElementType.UShort:
        //            if (this.ushortRestartIndexState == null)
        //            { this.ushortRestartIndexState = new PrimitiveRestartState(type); }
        //            result = this.ushortRestartIndexState;
        //            break;

        //        case IndexBuffer.ElementType.UInt:
        //            if (this.uintRestartIndexState == null)
        //            { this.uintRestartIndexState = new PrimitiveRestartState(type); }
        //            result = this.uintRestartIndexState;
        //            break;

        //        default:
        //            throw new NotDealWithNewEnumItemException(typeof(IndexBuffer.ElementType));
        //    }

        //    return result;
        //}
    }
}
