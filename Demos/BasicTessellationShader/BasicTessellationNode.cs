using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;

namespace BasicTessellationShader
{
    public partial class BasicTessellationNode : ModernNode
    {
        private DirectionalLight directionalLight;
        private Texture displacementMap;
        private float dispFactor = 0.25f;
        private Texture colorMap;

        public static BasicTessellationNode Create(ObjVNF model)
        {
            var vs = new VertexShader(renderVert, "Position_VS_in", "TexCoord_VS_in", "Normal_VS_in");
            var tc = new TessControlShader(renderTesc);
            var te = new TessEvaluationShader(renderTese);
            var fs = new FragmentShader(renderFrag);
            var provider = new ShaderArray(vs, tc, te, fs);
            var map = new AttributeMap();
            map.Add("Position_VS_in", ObjVNF.strPosition);
            map.Add("TexCoord_VS_in", ObjVNF.strTexCoord);
            map.Add("Normal_VS_in", ObjVNF.strNormal);
            var builder = new RenderUnitBuilder(provider, map);

            var node = new BasicTessellationNode(model, builder);
            node.ModelSize = model.GetSize();
            node.Initialize();

            return node;
        }

        private BasicTessellationNode(IBufferSource model, params RenderUnitBuilder[] builders)
            : base(model, builders)
        {
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();
            {
                var bitmap = new Bitmap(@"heightmap.jpg");
                var storage = new TexImage2D(TexImage2D.Target.Texture2D, 0, GL.GL_RGBA, bitmap.Width, bitmap.Height, 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, new ImageDataProvider(bitmap));
                var texture = new Texture(TextureTarget.Texture2D, storage);
                texture.Initialize();
                texture.TextureUnitIndex = 0;
                bitmap.Dispose();
                this.displacementMap = texture;
            }
            {
                var bitmap = new Bitmap(@"diffuse.jpg");
                var storage = new TexImage2D(TexImage2D.Target.Texture2D, 0, GL.GL_RGBA, bitmap.Width, bitmap.Height, 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, new ImageDataProvider(bitmap));
                var texture = new Texture(TextureTarget.Texture2D, storage);
                texture.Initialize();
                texture.TextureUnitIndex = 1;
                bitmap.Dispose();
                this.colorMap = texture;
            }
            {
                var light = new DirectionalLight();
                light.Color = new vec3(1, 1, 1);
                light.AmbientIntensity = 1.0f;
                light.DiffuseIntensity = 0.01f;
                light.direction = new vec3(1, -1, 0);

                this.directionalLight = light;
            }
            {
                RenderUnit unit = this.RenderUnits[0];
                VertexArrayObject vao = unit.VertexArrayObject;
                IndexBuffer indexBuffer = vao.IndexBuffer;
                indexBuffer.Mode = DrawMode.Patches;
            }
        }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            RenderUnit unit = this.RenderUnits[0];
            ShaderProgram program = unit.Program;
            //program.SetUniform()
            //uniform mat4 gWorld;                                                                           
            program.SetUniform("gWorld", model);
            //uniform vec3 gEyeWorldPos;
            program.SetUniform("gEyeWorldPos", camera.Position);
            //uniform mat4 gVP;
            program.SetUniform("gVP", projection * view);
            //uniform sampler2D gDisplacementMap;
            program.SetUniform("gDisplacementMap", this.displacementMap);
            //uniform float gDispFactor;
            program.SetUniform("gDispFactor", this.dispFactor);
            //uniform DirectionalLight gDirectionalLight;
            program.SetUniform("gDirectionalLight.Base.Color", this.directionalLight.Color);
            program.SetUniform("gDirectionalLight.Base.AmbientIntensity", this.directionalLight.AmbientIntensity);
            program.SetUniform("gDirectionalLight.Base.DiffuseIntensity", this.directionalLight.DiffuseIntensity);
            program.SetUniform("gDirectionalLight.Direction", this.directionalLight.direction);
            //uniform sampler2D gColorMap;
            program.SetUniform("gColorMap", this.colorMap);
            //uniform float gMatSpecularIntensity;
            program.SetUniform("gMatSpecularIntensity", 0.1f);
            //uniform float gSpecularPower;
            program.SetUniform("gSpecularPower", 0.1f);

            unit.Render();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
