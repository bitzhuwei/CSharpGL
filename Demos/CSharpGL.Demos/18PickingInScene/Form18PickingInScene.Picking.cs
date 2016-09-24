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
        public GeometryType PickingGeometryType { get; set; }

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
                    var dragParam = new DragParam(
                        this.scene.Camera.GetProjectionMatrix(),
                        this.scene.Camera.GetViewMatrix(),
                        new Point(e.X, glCanvas1.Height - e.Y - 1));
                    dragParam.pickedIndexes.AddRange(pickedGeometry.Indexes);
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
                        var tmp = this.pickedGeometry.From as HighlightedPickableRenderer;
                        if (tmp != null) { renderer = tmp.PickableRenderer; }
                    }

                    if (renderer == null) { renderer = this.pickedGeometry.From as PickableRenderer; }

                    renderer.MovePositions(
                        differenceOnScreen,
                        dragParam.viewMatrix, dragParam.projectionMatrix,
                        dragParam.viewport,
                        dragParam.pickedIndexes);
                }
            }
            else
            {
                UpdateColorInformationAtMouse(e.X, e.Y);

                //PickedGeometry pickedGeometry = RunPicking(
                //    new RenderEventArgs(
                //        RenderModes.ColorCodedPicking,
                //        this.glCanvas1.ClientRectangle,
                //        this.scene.Camera, this.PickingGeometryType),
                //    e.X, e.Y);
                PickedGeometry pickedGeometry = this.scene.ColorCodedPicking(
                    e.Location, this.PickingGeometryType);
                if (pickedGeometry != null)
                {
                    PickableRenderer pickableRenderer = null;
                    var renderer = pickedGeometry.From as HighlightedPickableRenderer;
                    if (renderer != null)
                    {
                        renderer.Highlighter.SetHighlightIndexes(
                            this.PickingGeometryType.ToDrawMode(), pickedGeometry.Indexes);
                        this.highlightedRenderer = renderer;
                        pickableRenderer = renderer.PickableRenderer;
                    }
                    else
                    {
                        pickableRenderer = pickedGeometry.From as PickableRenderer;
                    }

                    FormBulletinBoard bulletinBoard = this.bulletinBoard;
                    if ((bulletinBoard != null) && (!bulletinBoard.IsDisposed))
                    {
                        ICamera camera = this.scene.Camera;
                        mat4 projection = camera.GetProjectionMatrix();
                        mat4 view = camera.GetViewMatrix();
                        mat4 model = pickableRenderer.GetModelMatrix();
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
                    var frm = new FormProperyGrid(geometry.From);
                    frm.Show();
                    var frmIndexBufferPtrBoard = new FormIndexBufferPtrBoard();
                    HighlightedPickableRenderer renderer = this.highlightedRenderer;
                    if (renderer != null)
                    {
                        frmIndexBufferPtrBoard.SetTarget(renderer.PickableRenderer.IndexBufferPtr);
                    }
                    else
                    {
                        frmIndexBufferPtrBoard.SetTarget((geometry.From as PickableRenderer).IndexBufferPtr);
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
                "{0} @ {1}", c,
                new Point(x, this.glCanvas1.Height - y - 1));
            this.lblReadColor.Text = content;
        }
    }
}