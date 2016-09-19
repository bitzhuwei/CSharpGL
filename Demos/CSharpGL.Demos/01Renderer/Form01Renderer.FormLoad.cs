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
                // build several models
                Random random = new Random();
                var bufferables = new IBufferable[]{
                    new Chain(new ChainModel(random.Next(7, 100), 5, 5)),
                    new Tetrahedron(),
                };
                var keys = new GeometryModel[]
                {
                    GeometryModel.Chain,
                    GeometryModel.Tetrahedron,
                };
                ShaderCode[] simpleShader = new ShaderCode[2];
                simpleShader[0] = new ShaderCode(File.ReadAllText(@"shaders\Simple.vert"), ShaderType.VertexShader);
                simpleShader[1] = new ShaderCode(File.ReadAllText(@"shaders\Simple.frag"), ShaderType.FragmentShader);
                ShaderCode[] emitNormalLineShader = new ShaderCode[3];
                emitNormalLineShader[0] = new ShaderCode(File.ReadAllText(@"shaders\EmitNormalLine.vert"), ShaderType.VertexShader);
                emitNormalLineShader[1] = new ShaderCode(File.ReadAllText(@"shaders\EmitNormalLine.geom"), ShaderType.GeometryShader);
                emitNormalLineShader[2] = new ShaderCode(File.ReadAllText(@"shaders\EmitNormalLine.frag"), ShaderType.FragmentShader);
                var shaderCodesGroup = new ShaderCode[][]
                {
                    simpleShader,
                    emitNormalLineShader,
                };
                var simpleShaderPropertyNameMap = new PropertyNameMap();
                simpleShaderPropertyNameMap.Add("in_Position", "position");
                simpleShaderPropertyNameMap.Add("in_Color", "color");
                var emitNormalLineShaderPropertyNameMap = new PropertyNameMap();
                emitNormalLineShaderPropertyNameMap.Add("in_Position", "position");
                emitNormalLineShaderPropertyNameMap.Add("in_Normal", "normal");
                var propertyNameMaps = new PropertyNameMap[]
                {
                    simpleShaderPropertyNameMap,
                    emitNormalLineShaderPropertyNameMap,
                };
                var positionNameInIBufferables = new string[]
                {
                    "position",
                    "position",
                };
                for (int i = 0; i < bufferables.Length; i++)
                {
                    GeometryModel key = keys[i];
                    IBufferable bufferable = bufferables[i];
                    ShaderCode[] shaders = shaderCodesGroup[i];
                    var propertyNameMap = propertyNameMaps[i];
                    string positionNameInIBufferable = positionNameInIBufferables[i];
                    var highlightRenderer = new HighlightRenderer(
                        bufferable, positionNameInIBufferable);
                    highlightRenderer.Name = string.Format("Highlight: [{0}]", key);
                    highlightRenderer.Initialize();
                    var pickableRenderer = new PickableRenderer(
                        bufferable, shaders, propertyNameMap, positionNameInIBufferable);
                    pickableRenderer.Name = string.Format("Pickable: [{0}]", key);
                    pickableRenderer.Initialize();
                    if (i > 0)
                    {
                        pickableRenderer.SetUniform("normalLength", 0.5f);
                        pickableRenderer.SetUniform("showModel", true);
                        pickableRenderer.SetUniform("showNormal", false);
                    }

                    HighlightedPickableRenderer renderer = new HighlightedPickableRenderer(
                        highlightRenderer, pickableRenderer);
                    renderer.Initialize();
                    {
                        GLSwitch lineWidthSwitch = new LineWidthSwitch(5);
                        pickableRenderer.SwitchList.Add(lineWidthSwitch);
                        GLSwitch pointSizeSwitch = new PointSizeSwitch(10);
                        pickableRenderer.SwitchList.Add(pointSizeSwitch);
                        GLSwitch polygonModeSwitch = new PolygonModeSwitch(PolygonMode.Fill);
                        pickableRenderer.SwitchList.Add(polygonModeSwitch);
                        //GLSwitch blendSwitch = new BlendSwitch();
                        //pickableRenderer.SwitchList.Add(blendSwitch);
                    }
                    this.rendererDict.Add(key, renderer);
                }
                {
                    SimpleRenderer pickableRenderer = SimpleRenderer.Create(new BigDipper());
                    pickableRenderer.Initialize();
                    var bufferable = pickableRenderer.Model;
                    var highlightRenderer = new HighlightRenderer(
                        bufferable, Points.strposition);
                    highlightRenderer.Name = string.Format("Highlight: [{0}]", GeometryModel.BigDipper);
                    highlightRenderer.Initialize();
                    HighlightedPickableRenderer renderer = new HighlightedPickableRenderer(
                        highlightRenderer, pickableRenderer);
                    renderer.Initialize();
                    this.rendererDict.Add(GeometryModel.BigDipper, renderer);
                }
                {
                    SimpleRenderer pickableRenderer = SimpleRenderer.Create(new Axis(partCount: 6, radius: 1.0f));
                    pickableRenderer.Initialize();
                    var bufferable = pickableRenderer.Model;
                    var highlightRenderer = new HighlightRenderer(
                        bufferable, Points.strposition);
                    highlightRenderer.Name = string.Format("Highlight: [{0}]", GeometryModel.Axis);
                    highlightRenderer.Initialize();
                    HighlightedPickableRenderer renderer = new HighlightedPickableRenderer(
                        highlightRenderer, pickableRenderer);
                    renderer.Initialize();
                    this.rendererDict.Add(GeometryModel.Axis, renderer);
                }
                {
                    SimpleRenderer pickableRenderer = SimpleRenderer.Create(new Cube(new vec3(5, 4, 3)));
                    pickableRenderer.Initialize();
                    var bufferable = pickableRenderer.Model;
                    var highlightRenderer = new HighlightRenderer(
                        bufferable, Points.strposition);
                    highlightRenderer.Name = string.Format("Highlight: [{0}]", GeometryModel.Cube);
                    highlightRenderer.Initialize();
                    HighlightedPickableRenderer renderer = new HighlightedPickableRenderer(
                        highlightRenderer, pickableRenderer);
                    renderer.Initialize();
                    this.rendererDict.Add(GeometryModel.Cube, renderer);
                }
                {
                    SimpleRenderer pickableRenderer = SimpleRenderer.Create(new Sphere());
                    pickableRenderer.Initialize();
                    var bufferable = pickableRenderer.Model;
                    var highlightRenderer = new HighlightRenderer(
                        bufferable, Points.strposition);
                    highlightRenderer.Name = string.Format("Highlight: [{0}]", GeometryModel.Sphere);
                    highlightRenderer.Initialize();
                    HighlightedPickableRenderer renderer = new HighlightedPickableRenderer(
                        highlightRenderer, pickableRenderer);
                    renderer.Initialize();
                    this.rendererDict.Add(GeometryModel.Sphere, renderer);
                }
                {
                    SimpleRenderer pickableRenderer = SimpleRenderer.Create(new Teapot());
                    pickableRenderer.Initialize();
                    var bufferable = pickableRenderer.Model;
                    var highlightRenderer = new HighlightRenderer(
                        bufferable, Points.strposition);
                    highlightRenderer.Name = string.Format("Highlight: [{0}]", GeometryModel.Teapot);
                    highlightRenderer.Initialize();
                    HighlightedPickableRenderer renderer = new HighlightedPickableRenderer(
                        highlightRenderer, pickableRenderer);
                    renderer.Initialize();
                    this.rendererDict.Add(GeometryModel.Teapot, renderer);
                }
                {
                    var points = new List<vec3>(){
                        new vec3(-4.0f, 0.0f, 0.0f),
                        new vec3(-6.0f, 4.0f, 0.0f),
                        new vec3(6.0f, -4.0f, 0.0f),
                        new vec3(4.0f, 0.0f, 0.0f),
                    };
                    BezierRenderer pickableRenderer = BezierRenderer.Create(points, BezierType.Curve);
                    pickableRenderer.Initialize();
                    var bufferable = pickableRenderer.Model;
                    var highlightRenderer = new HighlightRenderer(
                        bufferable, Points.strposition);
                    highlightRenderer.Name = string.Format("Highlight: [{0}]", GeometryModel.Bezier1D);
                    highlightRenderer.Initialize();
                    HighlightedPickableRenderer renderer = new HighlightedPickableRenderer(
                        highlightRenderer, pickableRenderer);
                    renderer.Initialize();
                    this.rendererDict.Add(GeometryModel.Bezier1D, renderer);
                }
                {
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
                    pickableRenderer.Initialize();
                    var bufferable = pickableRenderer.Model;
                    var highlightRenderer = new HighlightRenderer(
                        bufferable, Points.strposition);
                    highlightRenderer.Name = string.Format("Highlight: [{0}]", GeometryModel.Bezier2D);
                    highlightRenderer.Initialize();
                    HighlightedPickableRenderer renderer = new HighlightedPickableRenderer(
                        highlightRenderer, pickableRenderer);
                    renderer.Initialize();
                    this.rendererDict.Add(GeometryModel.Bezier2D, renderer);
                }
                this.SelectedModel = GeometryModel.Tetrahedron;
            }
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