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
        private CameraTracer tracer;

        void FormMain_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                camera.Position = new vec3(0, 0, (float)(Earth.revolutionRadius * 1.1));
                camera.Target = new vec3(0, 0, 0);
                camera.UpVector = new vec3(0, 1, 0);
                IPerspectiveViewCamera perspecitve = camera;
                perspecitve.Near = 1;
                perspecitve.Far = Earth.revolutionRadius * 5;
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
                var earthRenderer = new PickableRenderer(bufferable, shaderCodes, map, CelestialBody.strPosition);
                earthRenderer.Initialize();
                earthRenderer.Name = "Earth 地球";
                this.earthRenderer = earthRenderer;
            }
            {
                // Ecliptic: 黄道
                IBufferable bufferable = new Circle((float)Earth.revolutionRadius);
                var shaderCodes = new ShaderCode[2];
                shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\Circle.vert"), ShaderType.VertexShader);
                shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\Circle.frag"), ShaderType.FragmentShader);
                var map = new PropertyNameMap();
                map.Add("inPosition", Circle.strPosition);
                var eclipticRenderer = new Renderer(bufferable, shaderCodes, map);
                eclipticRenderer.Initialize();
                eclipticRenderer.Name = "Ecliptic 黄道";
                this.eclipticRenderer = eclipticRenderer;
            }
            {
                const int latitude = 180;//从南到北，纬度共有180°
                const int hour = 24;//24小时，24个时区
                const int longitudePerHour = 15;// 每个时区占有的经度为15°
                const int longitude = hour * longitudePerHour;// 从东到西，经度共有360°
                IBufferable bufferable = new CelestialBody((float)Sun.radius, latitude, longitude);
                var shaderCodes = new ShaderCode[2];
                shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\Sun.vert"), ShaderType.VertexShader);
                shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\Sun.frag"), ShaderType.FragmentShader);
                var map = new PropertyNameMap();
                map.Add("inPosition", CelestialBody.strPosition);
                map.Add("inUV", CelestialBody.strUV);
                var sunRenderer = new PickableRenderer(bufferable, shaderCodes, map, CelestialBody.strPosition);
                sunRenderer.Initialize();
                sunRenderer.Name = "Sun 太阳";
                this.sunRenderer = sunRenderer;
            }
            {
                var backgroundStars = new BackgroundStarsRenderer(1000, Earth.revolutionRadius);
                backgroundStars.Initialize();
                backgroundStars.Name = "stars 星星";
                this.backgroundStars = backgroundStars;
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
                var sunColorTexture = new sampler2D();
                var bitmap = new Bitmap(@"Images\sun-4096-2048.png");
                sunColorTexture.Initialize(bitmap);
                bitmap.Dispose();
                this.sunColorTexture = sunColorTexture;
            }
            {
                this.eclipticRenderer.SetUniform("color", new vec4(1.0f, 1.0f, 0.0f, 0.1f));
                this.eclipticRenderer.SwitchList.Add(new PolygonModeSwitch(PolygonModes.Points));
            }
            {
                this.earthRenderer.SetUniform("colorTexture", new samplerValue(BindTextureTarget.Texture2D, this.earthColorTexture.Id, OpenGL.GL_TEXTURE0));
                this.earthRenderer.SwitchList.Add(new CullFaceSwitch());
                this.sunRenderer.SetUniform("colorTexture", new samplerValue(BindTextureTarget.Texture2D, this.sunColorTexture.Id, OpenGL.GL_TEXTURE0));
                this.sunRenderer.SwitchList.Add(new CullFaceSwitch());
            }
            {
                var earth = new Earth();
                this.earth = earth;
                this.thingList.Add(earth);
            }
            {
                var sun = new Sun();
                this.sun = sun;
                this.thingList.Add(sun);
            }
            {
                var tracer = new CameraTracer(this.camera, this.earth, this.sun);
                this.tracer = tracer;
                this.thingList.Add(tracer);
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
            {
                var frmPropertyGrid = new FormProperyGrid();
                frmPropertyGrid.DisplayObject(this.eclipticRenderer);
                frmPropertyGrid.Show();
            }
            {
                var frmPropertyGrid = new FormProperyGrid();
                frmPropertyGrid.DisplayObject(this.tracer);
                frmPropertyGrid.Show();
            }
            {
                this.TimeSpeed = 14400;
            }
        }
    }
}
