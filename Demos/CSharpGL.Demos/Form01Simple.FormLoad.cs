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
    public partial class Form01Simple : Form
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
                };
                var keys = new GeometryModel[] { GeometryModel.BigDipper, GeometryModel.Chain, };
                for (int i = 0; i < bufferables.Length; i++)
                {
                    IBufferable bufferable = bufferables[i];
                    GeometryModel key = keys[i];
                    ShaderCode[] shaders = new ShaderCode[2];
                    shaders[0] = new ShaderCode(File.ReadAllText(@"Shaders\Simple.vert"), ShaderType.VertexShader);
                    shaders[1] = new ShaderCode(File.ReadAllText(@"Shaders\Simple.frag"), ShaderType.FragmentShader);
                    var propertyNameMap = new PropertyNameMap();
                    propertyNameMap.Add("in_Position", "position");
                    propertyNameMap.Add("in_Color", "color");
                    string positionNameInIBufferable = "position";
                    var highlightRenderer = new HighlightModernRenderer(bufferable, positionNameInIBufferable);
                    highlightRenderer.Initialize();
                    var pickableRenderer = PickableModernRendererFactory.GetModernRenderer(bufferable, shaders, propertyNameMap, positionNameInIBufferable);
                    pickableRenderer.Initialize();
                    {
                        GLSwitch lineWidthSwitch = new LineWidthSwitch(4);
                        pickableRenderer.SwitchList.Add(lineWidthSwitch);
                        GLSwitch pointSizeSwitch = new PointSizeSwitch(4);
                        pickableRenderer.SwitchList.Add(pointSizeSwitch);
                        GLSwitch polygonModeSwitch = new PolygonModeSwitch(PolygonModes.Lines);
                        pickableRenderer.SwitchList.Add(polygonModeSwitch);
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
                this.rendererPropertyGrid = frmPropertyGrid;
            }
            {
                var frmPropertyGrid = new FormProperyGrid();
                frmPropertyGrid.DisplayObject(this.camera);
                frmPropertyGrid.Show();
                this.cameraPropertyGrid = frmPropertyGrid;
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
