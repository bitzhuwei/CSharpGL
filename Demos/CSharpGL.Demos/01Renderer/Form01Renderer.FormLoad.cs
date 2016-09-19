using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form01Renderer : Form
    {
        private FormIndexBufferPtrBoard frmIndexBufferPtrBoard;
        private UIAxis uiAxis;
        private UIText uiText;
        private UIRoot uiRoot;

        private void Form_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(
                    new vec3(0, 0, 5), new vec3(), new vec3(0, 1, 0),
                    CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                var rotator = new SatelliteManipulater();
                rotator.Bind(camera, this.glCanvas1);
                this.camera = camera;
            }
            {
                List<Tuple<PickableRenderer, string, GeometryModel>> list = new List<Tuple<PickableRenderer, string, GeometryModel>>();
                {
                    EmitNormalLineRenderer pickableRenderer = EmitNormalLineRenderer.Create(new Tetrahedron(), Tetrahedron.strPosition, Tetrahedron.strNormal);
                    list.Add(new Tuple<PickableRenderer, string, GeometryModel>(
                        pickableRenderer, Tetrahedron.strPosition, GeometryModel.Tetrahedron));
                }
                {
                    SimpleRenderer pickableRenderer = SimpleRenderer.Create(new Chain());
                    list.Add(new Tuple<PickableRenderer, string, GeometryModel>(
                        pickableRenderer, Chain.position, GeometryModel.Chain));
                }
                {
                    SimpleRenderer pickableRenderer = SimpleRenderer.Create(new BigDipper());
                    list.Add(new Tuple<PickableRenderer, string, GeometryModel>(
                        pickableRenderer, BigDipper.position, GeometryModel.BigDipper));
                }
                {
                    SimpleRenderer pickableRenderer = SimpleRenderer.Create(new Axis(partCount: 6, radius: 1.0f));
                    list.Add(new Tuple<PickableRenderer, string, GeometryModel>(
                        pickableRenderer, Axis.strPosition, GeometryModel.Axis));
                }
                {
                    SimpleRenderer pickableRenderer = SimpleRenderer.Create(new Cube(new vec3(5, 4, 3)));
                    list.Add(new Tuple<PickableRenderer, string, GeometryModel>(
                        pickableRenderer, Cube.strPosition, GeometryModel.Cube));
                }
                {
                    SimpleRenderer pickableRenderer = SimpleRenderer.Create(new Sphere());
                    list.Add(new Tuple<PickableRenderer, string, GeometryModel>(
                        pickableRenderer, Sphere.strPosition, GeometryModel.Sphere));
                }
                {
                    SimpleRenderer pickableRenderer = SimpleRenderer.Create(new Teapot());
                    list.Add(new Tuple<PickableRenderer, string, GeometryModel>(
                        pickableRenderer, Teapot.strPosition, GeometryModel.Teapot));
                }
                {
                    var points = new List<vec3>(){
                        new vec3(-4.0f, 0.0f, 0.0f),
                        new vec3(-6.0f, 4.0f, 0.0f),
                        new vec3(6.0f, -4.0f, 0.0f),
                        new vec3(4.0f, 0.0f, 0.0f),
                    };
                    BezierRenderer pickableRenderer = BezierRenderer.Create(points, BezierType.Curve);
                    list.Add(new Tuple<PickableRenderer, string, GeometryModel>(
                        pickableRenderer, Points.strposition, GeometryModel.Bezier1D));
                }
                {
                    // note: the points are not centered at (0, 0, 0). Thus the renderer will not be placed at (0, 0, 0).
                    var points = new List<vec3>(){
                        new vec3(  -4.0f, 0.0f, 4.0f),
                        new vec3(-2.0f, 4.0f, 4.0f),
                        new vec3( 4.0f, 0.0f, 4.0f ),
                        new vec3(  -4.0f, 0.0f, 0.0f),
                        new vec3(-2.0f, 4.0f, 0.0f),
                        new vec3( 4.0f, 0.0f, 0.0f),
                        new vec3(  -4.0f, 0.0f, -4.0f),
                        new vec3(-2.0f, 4.0f, -4.0f),
                        new vec3( 4.0f, 0.0f, -4.0f)
                    };
                    BezierRenderer pickableRenderer = BezierRenderer.Create(points, BezierType.Surface);
                    list.Add(new Tuple<PickableRenderer, string, GeometryModel>(
                        pickableRenderer, Points.strposition, GeometryModel.Bezier2D));
                }

                foreach (var item in list)
                {
                    var bufferable = item.Item1.Model;
                    var highlightRenderer = new HighlightRenderer(bufferable, item.Item2);
                    highlightRenderer.Name = string.Format("Highlight: [{0}]", item.Item3);
                    var renderer = new HighlightedPickableRenderer(
                        highlightRenderer, item.Item1);
                    renderer.Initialize();
                    this.rendererDict.Add(item.Item3, renderer);
                }
            }

            this.SelectedModel = GeometryModel.Bezier2D;

            {
                var frmBulletinBoard = new FormBulletinBoard();
                //frmBulletinBoard.Dump = true;
                frmBulletinBoard.Show();
                this.pickedGeometryBoard = frmBulletinBoard;
            }
            {
                var UIRoot = new UIRoot();
                UIRoot.Initialize();
                this.uiRoot = UIRoot;

                var uiAxis = new UIAxis(AnchorStyles.Left | AnchorStyles.Bottom,
                    new Padding(3, 3, 3, 3), new Size(128, 128));
                uiAxis.Initialize();
                UIRoot.Children.Add(uiAxis);
                this.uiAxis = uiAxis;

                var font = new Font("Courier New", 32);
                var uiText = new UIText(AnchorStyles.Left | AnchorStyles.Bottom,
                    new Padding(0, 0, 0, 0), new Size(250, 20), -100, 100,
                   font.GetFontBitmap("[index: 0123456789]").GetFontTexture());
                uiText.Text = "";
                uiRoot.Children.Add(uiText);
                this.uiText = uiText;
            }
            {
                var frmPropertyGrid = new FormProperyGrid(this.rendererDict[this.SelectedModel].PickableRenderer);
                frmPropertyGrid.Show();
                this.pickableRendererPropertyGrid = frmPropertyGrid;
            }
            {
                var frmPropertyGrid = new FormProperyGrid(this.rendererDict[this.SelectedModel].Highlighter);
                frmPropertyGrid.Show();
                this.highlightRendererPropertyGrid = frmPropertyGrid;
            }
            {
                var frmPropertyGrid = new FormProperyGrid(this);
                frmPropertyGrid.Show();
                this.formPropertyGrid = frmPropertyGrid;
            }
            {
                var frmPropertyGrid = new FormProperyGrid(this.uiText);
                frmPropertyGrid.Show();
            }
            {
                var frmIndexBufferPtrBoard = new FormIndexBufferPtrBoard();
                frmIndexBufferPtrBoard.SetTarget(this.rendererDict[this.SelectedModel].PickableRenderer.IndexBufferPtr);
                frmIndexBufferPtrBoard.Show();
                this.frmIndexBufferPtrBoard = frmIndexBufferPtrBoard;
            }
        }
    }
}