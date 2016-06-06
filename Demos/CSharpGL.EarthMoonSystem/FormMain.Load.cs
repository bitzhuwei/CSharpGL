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


        void FormMain_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                camera.Position = new vec3(0, 0, 5);
                camera.Target = new vec3(0, 0, 0);
                camera.UpVector = new vec3(0, 1, 0);
                var rotator = new SatelliteRotator(camera);
                this.camera = camera;
                this.rotator = rotator;
            }
            {
                IBufferable bufferable = new CelestialBody(1, 10, 8);
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
                var earthColorTexture = new sampler2D();
                var bitmap = new Bitmap(@"Images\earth-color-map-10800-5400.jpg");
                earthColorTexture.Initialize(bitmap);
                bitmap.Dispose();
                this.earthColorTexture = earthColorTexture;
            }
            {
                this.earthRenderer.SetUniform("colorTexture", new samplerValue(BindTextureTarget.Texture2D, this.earthColorTexture.Id, OpenGL.GL_TEXTURE0));
            }
        }
    }
}
