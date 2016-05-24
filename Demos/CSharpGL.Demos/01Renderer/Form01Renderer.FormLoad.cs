using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form01Renderer : Form
    {
        private DummyUIRenderer uiRenderer;
        private FormIndexBufferPtrBoard frmIndexBufferPtrBoard;

        private void Form01Renderer_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                camera.Position = new vec3(0, 0, 5);
                var rotator = new SatelliteRotator(camera);
                this.camera = camera;
                this.rotator = rotator;
            }
            {
                var camera = new Camera(CameraType.Ortho, this.glCanvas1.Width, this.glCanvas1.Height);
                camera.Position = new vec3(this.glCanvas1.Width / 2, this.glCanvas1.Height / 2, 5);
                camera.Target = new vec3(this.glCanvas1.Width / 2, this.glCanvas1.Height / 2, 0);
                camera.UpVector = new vec3(0, 1, 0);
                this.uiCamera = camera;
            }
            {
                // build several models
                Random random = new Random();
                var bufferables = new IBufferable[]{
                    new Axis(),
                    new BigDipper(),
                    new Chain(new ChainModel(random.Next(7, 100), 5, 5)),
                    new Tetrahedron(),
                    new Cube(),
                    new Sphere(),
                    new Teapot(),
                };
                var keys = new GeometryModel[] 
                { 
                    GeometryModel.Axis,
                    GeometryModel.BigDipper, 
                    GeometryModel.Chain,
                    GeometryModel.Tetrahedron, 
                    GeometryModel.Cube, 
                    GeometryModel.Sphere, 
                    GeometryModel.Teapot, 
                };
                ShaderCode[] simpleShader = new ShaderCode[2];
                simpleShader[0] = new ShaderCode(File.ReadAllText(@"01Renderer\Simple.vert"), ShaderType.VertexShader);
                simpleShader[1] = new ShaderCode(File.ReadAllText(@"01Renderer\Simple.frag"), ShaderType.FragmentShader);
                ShaderCode[] emitNormalLineShader = new ShaderCode[3];
                emitNormalLineShader[0] = new ShaderCode(File.ReadAllText(@"01Renderer\EmitNormalLine.vert"), ShaderType.VertexShader);
                emitNormalLineShader[1] = new ShaderCode(File.ReadAllText(@"01Renderer\EmitNormalLine.geom"), ShaderType.GeometryShader);
                emitNormalLineShader[2] = new ShaderCode(File.ReadAllText(@"01Renderer\EmitNormalLine.frag"), ShaderType.FragmentShader);
                var shaderCodesGroup = new ShaderCode[][]
                {
                    simpleShader,
                    simpleShader,
                    simpleShader,
                    emitNormalLineShader,
                    emitNormalLineShader,
                    emitNormalLineShader,
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
                    simpleShaderPropertyNameMap,
                    simpleShaderPropertyNameMap,
                    emitNormalLineShaderPropertyNameMap,
                    emitNormalLineShaderPropertyNameMap,
                    emitNormalLineShaderPropertyNameMap,
                    emitNormalLineShaderPropertyNameMap,
                };
                var positionNameInIBufferables = new string[]
                {
                    "position", 
                    "position", 
                    "position", 
                    "position", 
                    "position", 
                    "position", 
                    "position", 
                };
                var uniformTupleList = new List<Tuple<string, ValueType>>()
                {
                    new Tuple<string, ValueType>("normalLength", 0.5f),
                    new Tuple<string, ValueType>("showModel", true),
                    new Tuple<string, ValueType>("showNormal", false),
                };
                var uniformVariablesList = new List<List<Tuple<string, ValueType>>>()
                {
                    new List<Tuple<string, ValueType>>(),
                    new List<Tuple<string, ValueType>>(),
                    new List<Tuple<string, ValueType>>(),
                    uniformTupleList,
                    uniformTupleList,
                    uniformTupleList,
                    uniformTupleList,
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
                    var pickableRenderer = PickableRendererFactory.GetRenderer(
                        bufferable, shaders, propertyNameMap, positionNameInIBufferable);
                    pickableRenderer.Name = string.Format("Pickable: [{0}]", key);
                    pickableRenderer.Initialize();
                    var uniformVariables = uniformVariablesList[i];
                    foreach (var item in uniformVariables)
                    {
                        pickableRenderer.SetUniformValue(item.Item1, item.Item2);
                    }

                    HighlightedPickableRenderer renderer = new HighlightedPickableRenderer(
                        highlightRenderer, pickableRenderer);
                    renderer.Initialize();
                    {
                        GLSwitch lineWidthSwitch = new LineWidthSwitch(5);
                        pickableRenderer.SwitchList.Add(lineWidthSwitch);
                        GLSwitch pointSizeSwitch = new PointSizeSwitch(10);
                        pickableRenderer.SwitchList.Add(pointSizeSwitch);
                        GLSwitch polygonModeSwitch = new PolygonModeSwitch(PolygonModes.Filled);
                        pickableRenderer.SwitchList.Add(polygonModeSwitch);
                        if (pickableRenderer is OneIndexRenderer)
                        {
                            GLSwitch primitiveRestartSwitch = new PrimitiveRestartSwitch((pickableRenderer as OneIndexRenderer).IndexBufferPtr);
                            pickableRenderer.SwitchList.Add(primitiveRestartSwitch);
                        }
                        GLSwitch blendSwitch = new BlendSwitch();
                        pickableRenderer.SwitchList.Add(blendSwitch);
                    }
                    this.rendererDict.Add(key, renderer);
                }
                this.SelectedModel = GeometryModel.Tetrahedron;
            }
            {
                // build the axis
                var bufferables = new IBufferable[]{
                    new Axis(),
                };
                var keys = new GeometryModel[] 
                { 
                    GeometryModel.Axis, 
                };
                ShaderCode[] simpleShader = new ShaderCode[2];
                simpleShader[0] = new ShaderCode(File.ReadAllText(@"01Renderer\Simple.vert"), ShaderType.VertexShader);
                simpleShader[1] = new ShaderCode(File.ReadAllText(@"01Renderer\Simple.frag"), ShaderType.FragmentShader);
                var shaderCodesGroup = new ShaderCode[][]
                {
                    simpleShader,
                };
                var simpleShaderPropertyNameMap = new PropertyNameMap();
                simpleShaderPropertyNameMap.Add("in_Position", "position");
                simpleShaderPropertyNameMap.Add("in_Color", "color");
                var propertyNameMaps = new PropertyNameMap[]
                {
                    simpleShaderPropertyNameMap,
                };
                var positionNameInIBufferables = new string[]
                {
                    "position", 
                };
                var uniformVariablesList = new List<List<Tuple<string, ValueType>>>()
                {
                    new List<Tuple<string, ValueType>>(),
                };
                for (int i = 0; i < bufferables.Length; i++)
                {
                    GeometryModel key = keys[i];
                    IBufferable bufferable = bufferables[i];
                    ShaderCode[] shaders = shaderCodesGroup[i];
                    var propertyNameMap = propertyNameMaps[i];
                    string positionNameInIBufferable = positionNameInIBufferables[i];
                    var pickableRenderer = PickableRendererFactory.GetRenderer(
                        bufferable, shaders, propertyNameMap, positionNameInIBufferable);
                    pickableRenderer.Name = string.Format("Pickable: [{0}]", key);
                    pickableRenderer.Initialize();
                    var uniformVariables = uniformVariablesList[i];
                    foreach (var item in uniformVariables)
                    {
                        pickableRenderer.SetUniformValue(item.Item1, item.Item2);
                    }
                    {
                        GLSwitch lineWidthSwitch = new LineWidthSwitch(5);
                        pickableRenderer.SwitchList.Add(lineWidthSwitch);
                        GLSwitch pointSizeSwitch = new PointSizeSwitch(10);
                        pickableRenderer.SwitchList.Add(pointSizeSwitch);
                        GLSwitch polygonModeSwitch = new PolygonModeSwitch(PolygonModes.Filled);
                        pickableRenderer.SwitchList.Add(polygonModeSwitch);
                        if (pickableRenderer is OneIndexRenderer)
                        {
                            GLSwitch primitiveRestartSwitch = new PrimitiveRestartSwitch((pickableRenderer as OneIndexRenderer).IndexBufferPtr);
                            pickableRenderer.SwitchList.Add(primitiveRestartSwitch);
                        }
                    }
                    var uiRenderer = new DummyUIRenderer(
                        pickableRenderer,
                        AnchorStyles.Left | AnchorStyles.Bottom,
                        new Padding(26, 26, 26, 26),
                        new Size(50, 50));
                    uiRenderer.Initialize();
                    //var uiRenderer = new UIAxisRenderer(
                    //    AnchorStyles.Left | AnchorStyles.Bottom,
                    //    new Padding(26, 26, 26, 26),
                    //    new Size(50, 50));
                    this.uiRenderer = uiRenderer;
                }
            }
            {
                var frmBulletinBoard = new FormBulletinBoard();
                //frmBulletinBoard.Dump = true;
                frmBulletinBoard.Show();
                this.pickedGeometryBoard = frmBulletinBoard;
            }
            {
                var frmPropertyGrid = new FormProperyGrid();
                frmPropertyGrid.DisplayObject(this.rendererDict[this.SelectedModel].PickableRenderer);
                frmPropertyGrid.Show();
                this.pickableRendererPropertyGrid = frmPropertyGrid;
            }
            {
                var frmPropertyGrid = new FormProperyGrid();
                frmPropertyGrid.DisplayObject(this.rendererDict[this.SelectedModel].Highlighter);
                frmPropertyGrid.Show();
                this.highlightRendererPropertyGrid = frmPropertyGrid;
            }
            {
                var frmPropertyGrid = new FormProperyGrid();
                frmPropertyGrid.DisplayObject(this);
                frmPropertyGrid.Show();
                this.formPropertyGrid = frmPropertyGrid;
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
