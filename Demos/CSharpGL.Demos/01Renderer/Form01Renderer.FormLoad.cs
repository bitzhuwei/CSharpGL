using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form01Renderer : Form
    {
        private FormIndexBufferPtrBoard frmIndexBufferPtrBoard;
        private UIAxis glAxis;
        private UIRoot uiRoot;

        private void Form01Renderer_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(
                    new vec3(0, 0, 5), new vec3(), new vec3(0, 1, 0),
                    CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                var rotator = new SatelliteRotator(camera);
                this.camera = camera;
                this.rotator = rotator;
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
                simpleShader[0] = new ShaderCode(File.ReadAllText(@"shaders\Simple.vert"), ShaderType.VertexShader);
                simpleShader[1] = new ShaderCode(File.ReadAllText(@"shaders\Simple.frag"), ShaderType.FragmentShader);
                ShaderCode[] emitNormalLineShader = new ShaderCode[3];
                emitNormalLineShader[0] = new ShaderCode(File.ReadAllText(@"shaders\EmitNormalLine.vert"), ShaderType.VertexShader);
                emitNormalLineShader[1] = new ShaderCode(File.ReadAllText(@"shaders\EmitNormalLine.geom"), ShaderType.GeometryShader);
                emitNormalLineShader[2] = new ShaderCode(File.ReadAllText(@"shaders\EmitNormalLine.frag"), ShaderType.FragmentShader);
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
                    var pickableRenderer = new PickableRenderer(
                        bufferable, shaders, propertyNameMap, positionNameInIBufferable);
                    pickableRenderer.Name = string.Format("Pickable: [{0}]", key);
                    pickableRenderer.Initialize();
                    var uniformVariables = uniformVariablesList[i];
                    foreach (var item in uniformVariables)
                    {
                        pickableRenderer.SetUniform(item.Item1, item.Item2);
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
                        //GLSwitch blendSwitch = new BlendSwitch();
                        //pickableRenderer.SwitchList.Add(blendSwitch);
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
                simpleShader[0] = new ShaderCode(File.ReadAllText(@"shaders\Simple.vert"), ShaderType.VertexShader);
                simpleShader[1] = new ShaderCode(File.ReadAllText(@"shaders\Simple.frag"), ShaderType.FragmentShader);
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
                    var pickableRenderer = new PickableRenderer(
                        bufferable, shaders, propertyNameMap, positionNameInIBufferable);
                    pickableRenderer.Name = string.Format("Pickable: [{0}]", key);
                    pickableRenderer.Initialize();
                    var uniformVariables = uniformVariablesList[i];
                    foreach (var item in uniformVariables)
                    {
                        pickableRenderer.SetUniform(item.Item1, item.Item2);
                    }
                }
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

                var glAxis = new UIAxis(AnchorStyles.Right | AnchorStyles.Bottom,
                    new Padding(3, 3, 3, 3), new Size(70, 70), -100, 100);
                glAxis.Initialize();
                this.glAxis = glAxis;

                UIRoot.Children.Add(glAxis);
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
