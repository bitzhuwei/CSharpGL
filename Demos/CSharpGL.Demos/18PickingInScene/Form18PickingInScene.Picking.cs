using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form18PickingInScene
    {
        private PickedGeometry pickedGeometry;
        private HighlightedPickableRenderer highlightedRenderer;
        private DragParam dragParam;
        private Point lastMousePosition;
        private Point lastMouseDownPosition;
        public PickingGeometryType PickingGeometryType { get; set; }

        private void glCanvas1_MouseDown(object sender, MouseEventArgs e)
        {
            this.lastMousePosition = e.Location;
            this.lastMouseDownPosition = e.Location;

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
                    ViewPort viewPort = pickedGeometry.FromViewPort;
                    ICamera camera = viewPort.Camera;
                    var dragParam = new DragParam(
                        camera.GetPerspectiveProjectionMatrix(),
                        camera.GetViewMatrix(),
                        viewPort.Rect.ToViewport(),
                        new Point(e.X, glCanvas1.Height - e.Y - 1));
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
                if (dragParam != null)
                {
                    var current = new Point(e.X, glCanvas1.Height - e.Y - 1);
                    Point differenceOnScreen = new Point(
                        current.X - dragParam.lastMousePositionOnScreen.X,
                        current.Y - dragParam.lastMousePositionOnScreen.Y);
                    dragParam.lastMousePositionOnScreen = current;
                    PickableRenderer renderer = null;
                    {
                        var tmp = this.pickedGeometry.FromRenderer as HighlightedPickableRenderer;
                        if (tmp != null) { renderer = tmp.PickableRenderer; }
                    }

                    if (renderer == null) { renderer = this.pickedGeometry.FromRenderer as PickableRenderer; }

                    renderer.MovePositions(
                        differenceOnScreen,
                        dragParam.viewMatrix, dragParam.projectionMatrix,
                        dragParam.viewport,
                        dragParam.pickedVertexIds);
                }
            }
            else
            {
                if (this.controlDown)
                {
                    List<Tuple<Point, PickedGeometry>> allPickedGeometrys = this.scene.Pick(
                        e.Location, this.PickingGeometryType);
                    PickedGeometry pickedGeometry = null;
                    if (allPickedGeometrys != null && allPickedGeometrys.Count > 0)
                    { pickedGeometry = allPickedGeometrys[0].Item2; }

                    if (pickedGeometry != null)
                    {
                        PickableRenderer pickableRenderer = null;
                        var renderer = pickedGeometry.FromRenderer as HighlightedPickableRenderer;
                        if (renderer != null)
                        {
                            renderer.Highlighter.SetHighlightIndexes(
                                this.PickingGeometryType.ToDrawMode(), pickedGeometry.VertexIds);
                            this.highlightedRenderer = renderer;
                            pickableRenderer = renderer.PickableRenderer;
                        }
                        else
                        {
                            pickableRenderer = pickedGeometry.FromRenderer as PickableRenderer;
                        }

                        FormBulletinBoard bulletinBoard = this.bulletinBoard;
                        if ((bulletinBoard != null) && (!bulletinBoard.IsDisposed))
                        {
                            ICamera camera = this.scene.FirstCamera;
                            mat4 projection = camera.GetProjectionMatrix();
                            mat4 view = camera.GetViewMatrix();
                            mat4 model = pickableRenderer.GetModelMatrix().Value;
                            this.bulletinBoard.SetContent(pickedGeometry.ToString(
                                projection, view, model));
                        }

                        this.glCanvas1.Cursor = Cursors.Hand;
                    }
                    else
                    {
                        HighlightedPickableRenderer renderer = this.highlightedRenderer;
                        if (renderer != null)
                        {
                            renderer.Highlighter.ClearHighlightIndexes();
                        }
                        this.bulletinBoard.SetContent("picked nothing.");

                        this.glCanvas1.Cursor = Cursors.Default;
                    }
                    this.pickedGeometry = pickedGeometry;
                }
            }

            UpdateColorInformationAtMouse(e.X, e.Y);

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
                // move vertex

                PickedGeometry geometry = this.pickedGeometry;
                if (geometry != null && this.lastMouseDownPosition == e.Location)
                {
                    var frm = new FormProperyGrid(geometry.FromRenderer);
                    frm.Show();
                    var frmIndexBufferPtrBoard = new FormIndexBufferPtrBoard();
                    HighlightedPickableRenderer renderer = this.highlightedRenderer;
                    if (renderer != null)
                    {
                        frmIndexBufferPtrBoard.SetTarget(renderer.PickableRenderer.IndexBufferPtr);
                    }
                    else
                    {
                        var tmp = geometry.FromRenderer as PickableRenderer;
                        if (tmp != null)
                        {
                            frmIndexBufferPtrBoard.SetTarget(tmp.IndexBufferPtr);
                            //frmIndexBufferPtrBoard.SetTarget((geometry.From as PickableRenderer).IndexBufferPtr);
                        }
                    }
                    frmIndexBufferPtrBoard.Show();
                }
                {
                    HighlightedPickableRenderer renderer = this.highlightedRenderer;
                    if (renderer != null)
                    {
                        renderer.Highlighter.ClearHighlightIndexes();
                        this.highlightedRenderer = null;
                    }
                }
                this.dragParam = null;
            }

            this.lastMousePosition = e.Location;
        }

        private void UpdateColorInformationAtMouse(int x, int y)
        {
            //this.RenderersDraw(this.RenderMode, true, false);
            Color c = OpenGL.ReadPixel(x, this.glCanvas1.Height - y - 1);
            c = Color.FromArgb(255, c);
            this.lblColor.BackColor = c;
            string content = string.Format(
                @"{0} @ Winform[{1}]\OpenGL[{2}]", c,
                new Point(x, this.glCanvas1.Height - y - 1),
                new Point(x, y));
            this.lblReadColor.Text = content;
        }
    }
}