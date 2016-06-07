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

namespace CSharpGL.EarthMoonSystem
{
    public partial class FormMain
    {
        private GLAxis glAxis;
        private GLControl uiRoot;

        void FormMain_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                camera.Position = new vec3(0, 0, 5);
                camera.Target = new vec3(0, 0, 0);
                camera.UpVector = new vec3(0, 1, 0);
                IPerspectiveViewCamera perspecitve = camera;
                //perspecitve.Near = 1;
                //perspecitve.Far = Earth.revolutionRadius * 2;
                var rotator = new SatelliteRotator(camera);
                this.camera = camera;
                this.rotator = rotator;
            }
            {
                const int latitude = 180;//从南到北，纬度共有180°
                const int hour = 24;//24小时，24个时区
                const int longitudePerHour = 15;// 每个时区占有的经度为15°
                const int longitude = hour * longitudePerHour;// 从东到西，经度共有360°
                IBufferable bufferable = new CelestialBody((float)Earth.radius, latitude, longitude);
                var shaderCodes = new ShaderCode[2];
                shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\CelestialBody.vert"), ShaderType.VertexShader);
                shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\CelestialBody.frag"), ShaderType.FragmentShader);
                var map = new PropertyNameMap();
                map.Add("inPosition", CelestialBody.strPosition);
                map.Add("inUV", CelestialBody.strUV);
                var cubeRenderer = new PickableRenderer(bufferable, shaderCodes, map, CelestialBody.strPosition);
                cubeRenderer.Initialize();
                this.earthRenderer = cubeRenderer;
            }
            {
                // Ecliptic: 黄道
                IBufferable bufferable = new Circle((float)Earth.revolutionRadius, 360);
                var shaderCodes = new ShaderCode[2];
                shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\Circle.vert"), ShaderType.VertexShader);
                shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\Circle.frag"), ShaderType.FragmentShader);
                var map = new PropertyNameMap();
                map.Add("inPosition", Circle.strPosition);
                var eclipticRenderer = new Renderer(bufferable, shaderCodes, map);
                eclipticRenderer.Initialize();
                this.eclipticRenderer = eclipticRenderer;
            }
            {
                var glAxis = new GLAxis(AnchorStyles.Left | AnchorStyles.Bottom,
                    new Padding(5, 5, 5, 5), new Size(100, 100), -100, 100);
                glAxis.Initialize();
                this.glAxis = glAxis;
            }
            {
                var uiRoot = new GLControl(this.glCanvas1.Size, -100, 100);
                uiRoot.Initialize();
                this.uiRoot = uiRoot;
            }
            {
                this.uiRoot.Controls.Add(this.glAxis);
            }
            {
                var earthColorTexture = new sampler2D();
                var bitmap = new Bitmap(@"Images\earth-color-map-10800-5400.jpg");
                earthColorTexture.Initialize(bitmap);
                bitmap.Dispose();
                this.earthColorTexture = earthColorTexture;
            }
            {
                this.eclipticRenderer.SetUniform("color", new vec4(1.0f, 1.0f, 0.0f, 0.5f));
            }
            {
                this.earthRenderer.SetUniform("colorTexture", new samplerValue(BindTextureTarget.Texture2D, this.earthColorTexture.Id, OpenGL.GL_TEXTURE0));
            }
            {
                var earth = new Earth();
                this.earth = earth;
                this.thingList.Add(earth);
            }

            {
                var frmPropertyGrid = new FormProperyGrid();
                frmPropertyGrid.DisplayObject(this);
                frmPropertyGrid.Show();
            }
            {
                var frmPropertyGrid = new FormProperyGrid();
                frmPropertyGrid.DisplayObject(this.earthRenderer);
                frmPropertyGrid.Show();
            }
        }
    }
}
