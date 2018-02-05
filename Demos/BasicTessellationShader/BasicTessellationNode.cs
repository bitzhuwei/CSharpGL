using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;

namespace BasicTessellationShader
{
    public partial class BasicTessellationNode : ModernNode, IRenderable
    {
        private DirectionalLight directionalLight;
        private Texture displacementMap;
        private float dispFactor = 0.25f;
        private Texture colorMap;

        public static BasicTessellationNode Create(ObjVNF model)
        {
            var vs = new VertexShader(renderVert);
            var tc = new TessControlShader(renderTesc);
            var te = new TessEvaluationShader(renderTese);
            var fs = new FragmentShader(renderFrag);
            var provider = new ShaderArray(vs, tc, te, fs);
            var map = new AttributeMap();
            map.Add("Position_VS_in", ObjVNF.strPosition);
            map.Add("TexCoord_VS_in", ObjVNF.strTexCoord);
            map.Add("Normal_VS_in", ObjVNF.strNormal);
            var builder = new RenderMethodBuilder(provider, map);

            var node = new BasicTessellationNode(model, builder);
            node.ModelSize = model.GetSize();
            node.Initialize();

            return node;
        }

        private BasicTessellationNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();
            {
                string folder = System.Windows.Forms.Application.StartupPath;
                var bitmap = new Bitmap(System.IO.Path.Combine(folder, @"heightmap.png"));
                var storage = new TexImageBitmap(bitmap);
                var texture = new Texture(storage);
                texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT));
                texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT));
                texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_REPEAT));
                texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR));
                texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));

                texture.Initialize();
                texture.TextureUnitIndex = 0;
                bitmap.Dispose();
                this.displacementMap = texture;
            }
            {
                string folder = System.Windows.Forms.Application.StartupPath;
                var bitmap = new Bitmap(System.IO.Path.Combine(folder, @"diffuse.png"));
                var storage = new TexImageBitmap(bitmap);
                var texture = new Texture(storage);
                texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT));
                texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT));
                texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_REPEAT));
                texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR));
                texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));

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
                light.direction = new vec3(1, 1, 0);

                this.directionalLight = light;
            }
            {
                RenderMethod method = this.RenderUnit.Methods[0];
                foreach (var vao in method.VertexArrayObjects)
                {
                    IDrawCommand cmd = vao.DrawCommand;
                    cmd.Mode = DrawMode.Patches;
                }

                var polygonModeState = new PolygonModeSwitch(CSharpGL.PolygonMode.Fill);
                method.StateList.Add(polygonModeState);
                this.PolygonMode = polygonModeState;
            }
        }

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children | ThreeFlags.AfterChildren;
        /// <summary>
        /// Render before/after children? Render children? 
        /// RenderAction cares about this property. Other actions, maybe, maybe not, your choice.
        /// </summary>
        public ThreeFlags EnableRendering
        {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }
        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            RenderMethod method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
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

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        public PolygonModeSwitch PolygonMode { get; set; }
    }
}
