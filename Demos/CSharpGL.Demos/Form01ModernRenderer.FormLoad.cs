using CSharpGL.ModelAdapters;
using CSharpGL.Models;
using GLM;
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
    public partial class Form01ModernRenderer : Form
    {

        private void Form01ModernRenderer_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                camera.Position = new vec3(0, 0, 5);
                var rotator = new SatelliteRotator(camera);
                this.camera = camera;
                this.rotator = rotator;
            }
            {
                Random random = new Random();
                var bufferables = new IBufferable[]{
                    new BigDipperAdapter(new BigDipper()),
                    new ChainModelAdapter(new ChainModel(random.Next(7, 100), 5, 5)),
                    new TetrahedronModelAdapter(new TetrahedronModel(1.0f)),
                    new CubeModelAdapter(new CubeModel(1.0f)),
                    new SphereModelAdapter(new SphereModel(1.0f)),
                    new TeapotModelAdapter(TeapotModel.GetModel(1.0f)),
                };
                var keys = new GeometryModel[] 
                { 
                    GeometryModel.BigDipper, 
                    GeometryModel.Chain,
                    GeometryModel.Tetrahedron, 
                    GeometryModel.Cube, 
                    GeometryModel.Sphere, 
                    GeometryModel.Teapot, 
                };
                ShaderCode[] simpleShader = new ShaderCode[2];
                simpleShader[0] = new ShaderCode(File.ReadAllText(@"Shaders\Simple.vert"), ShaderType.VertexShader);
                simpleShader[1] = new ShaderCode(File.ReadAllText(@"Shaders\Simple.frag"), ShaderType.FragmentShader);
                ShaderCode[] emitNormalLineShader = new ShaderCode[3];
                emitNormalLineShader[0] = new ShaderCode(File.ReadAllText(@"Shaders\EmitNormalLine.vert"), ShaderType.VertexShader);
                emitNormalLineShader[1] = new ShaderCode(File.ReadAllText(@"Shaders\EmitNormalLine.geom"), ShaderType.GeometryShader);
                emitNormalLineShader[2] = new ShaderCode(File.ReadAllText(@"Shaders\EmitNormalLine.frag"), ShaderType.FragmentShader);
                var shaderCodesGroup = new ShaderCode[][]
                {
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
                };
                var uniformTupleList = new List<Tuple<string, ValueType>>()
                {
                    new Tuple<string, ValueType>("normalLength", 0.5f),
                    new Tuple<string, ValueType>("showModel", true),
                    new Tuple<string, ValueType>("showNormal", true),
                };
                var uniformVariablesList = new List<List<Tuple<string, ValueType>>>()
                {
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
                    var highlightRenderer = new HighlightModernRenderer(
                        bufferable, positionNameInIBufferable);
                    highlightRenderer.Name = string.Format("Highlight: [{0}]", key);
                    highlightRenderer.Initialize();
                    var pickableRenderer = PickableModernRendererFactory.GetModernRenderer(
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
                        GLSwitch primitiveRestartSwitch = new PrimitiveRestartSwitch(uint.MaxValue);
                        pickableRenderer.SwitchList.Add(primitiveRestartSwitch);
                    }
                    HighlightedPickableRenderer renderer = new HighlightedPickableRenderer(
                        highlightRenderer, pickableRenderer);

                    this.rendererDict.Add(key, renderer);
                }
                this.SelectedModel = GeometryModel.BigDipper;
            }
            {
                var frmBulletinBoard = new FormBulletinBoard();
                //frmBulletinBoard.Dump = true;
                frmBulletinBoard.Show();
                this.RunPickingBoard = frmBulletinBoard;
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

        }

    }
}
