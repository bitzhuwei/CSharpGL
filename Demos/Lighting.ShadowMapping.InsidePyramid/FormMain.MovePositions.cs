using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lighting.ShadowMapping.InsidePyramid
{
    public partial class FormMain
    {
        private PickedGeometry pickedGeometry;
        private DragParam dragParam;
        private Point lastMousePosition;

        private void glCanvas1_MouseDown(object sender, MouseEventArgs e)
        {
            this.lastMousePosition = e.Location;

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                //// operate camera
                //rotator.SetBounds(this.glCanvas1.Width, this.glCanvas1.Height);
                //rotator.MouseDown(e.X, e.Y);
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // move vertex
                if (pickedGeometry != null)
                {
                    IGLCanvas canvas = this.winGLCanvas1;
                    var viewport = new vec4(0, 0, canvas.Width, canvas.Height);
                    var lastWindowSpacePos = new vec3(e.X, this.winGLCanvas1.Height - e.Y - 1, pickedGeometry.PickedPosition.z);
                    mat4 projectionMatrix = this.scene.Camera.GetProjectionMatrix();
                    mat4 viewMatrix = this.scene.Camera.GetViewMatrix();
                    mat4 modelMatrix = (pickedGeometry.FromRenderer as PickableNode).GetModelMatrix();
                    var lastModelSpacePos = glm.unProject(lastWindowSpacePos, viewMatrix * modelMatrix, projectionMatrix, viewport);

                    var dragParam = new DragParam(
                        lastModelSpacePos,
                        this.scene.Camera.GetProjectionMatrix(),
                        this.scene.Camera.GetViewMatrix(),
                        viewport,
                        new ivec2(e.X, this.winGLCanvas1.Height - e.Y - 1));
                    dragParam.pickedVertexIds.AddRange(pickedGeometry.VertexIds);
                    this.dragParam = dragParam;
                }
            }
        }

        private void glCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            if (lastMousePosition == e.Location) { return; }


            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                //// operate camera
                //rotator.MouseMove(e.X, e.Y);
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // move vertex
                DragParam dragParam = this.dragParam;
                if (dragParam != null && this.pickedGeometry != null)
                {
                    var node = this.pickedGeometry.FromRenderer as PickableNode;
                    var currentWindowSpacePos = new vec3(e.X, this.winGLCanvas1.Height - e.Y - 1, this.pickedGeometry.PickedPosition.z);
                    var currentModelSpacePos = glm.unProject(currentWindowSpacePos, dragParam.viewMatrix * node.GetModelMatrix(), dragParam.projectionMatrix, dragParam.viewport);
                    var modelSpacePositionDiff = currentModelSpacePos - dragParam.lastModelSpacePos;
                    dragParam.lastModelSpacePos = currentModelSpacePos;
                    IList<vec3> newPositions = node.MovePositions(
                          modelSpacePositionDiff,
                          dragParam.pickedVertexIds);

                    this.UpdateHightlight(newPositions);
                }
            }
            else
            {
                int x = e.X;
                int y = this.winGLCanvas1.Height - e.Y - 1;
                this.pickedGeometry = this.pickingAction.Pick(x, y, PickingGeometryTypes.Point, this.winGLCanvas1.Width, this.winGLCanvas1.Height);

                if (this.pickedGeometry != null)
                {
                    this.pickedGeometry = this.pickingAction.Pick(x, y, PickingGeometryTypes.Point, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
                }

                this.UpdateHightlight();
            }

            this.lastMousePosition = e.Location;
        }

        private void glCanvas1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                //// operate camera
                //rotator.MouseUp(e.X, e.Y);
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.dragParam = null;
            }

            this.lastMousePosition = e.Location;
        }

        private Color GetColorAtMouse(int x, int y)
        {
            byte[] colors = new byte[4];
            GL.Instance.ReadPixels(x, y, 1, 1, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, colors);
            Color c = Color.FromArgb(colors[3], colors[0], colors[1], colors[2]);

            return c;
        }

        private void UpdateHightlight(IList<vec3> newPositions)
        {
            switch (this.pickedGeometry.Type)
            {
                case GeometryType.Point:
                    pointTip.Vertex = newPositions[0];
                    break;
                case GeometryType.Line:
                    throw new NotImplementedException();
                case GeometryType.Triangle:
                    throw new NotImplementedException();
                case GeometryType.Quad:
                    throw new NotImplementedException();
                case GeometryType.Polygon:
                    throw new NotImplementedException();
                default:
                    throw new NotDealWithNewEnumItemException(typeof(GeometryType));
            }
        }

        private void UpdateHightlight()
        {
            PickedGeometry picked = this.pickedGeometry;
            if (picked != null)
            {
                switch (picked.Type)
                {
                    case GeometryType.Point:
                        pointTip.Vertex = picked.Positions[0];
                        pointTip.Parent = picked.FromRenderer as SceneNodeBase;
                        break;
                    case GeometryType.Line:
                        throw new NotImplementedException();
                    case GeometryType.Triangle:
                        throw new NotImplementedException();
                    case GeometryType.Quad:
                        throw new NotImplementedException();
                    case GeometryType.Polygon:
                        throw new NotImplementedException();
                    default:
                        throw new NotDealWithNewEnumItemException(typeof(GeometryType));
                }

            }
            else
            {
                pointTip.Parent = null;
            }
        }

    }
}
