using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;

namespace VolumeRendering.ISOSurface
{
    partial class RaycastingNode : ModernNode, IRenderable
    {
        public enum RenderMode { Default = 0, ISOSurface = 1 };

        /// <summary>
        /// 
        /// </summary>
        public RenderMode CurrentMode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static RaycastingNode Create()
        {
            var model = new RaycastingModel();
            RenderMethodBuilder defaultBuilder, isosurfaceBuilder;
            {
                var vs = new VertexShader(defaultVert);
                var fs = new FragmentShader(defaultFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("vVertex", RaycastingModel.position);
                defaultBuilder = new RenderMethodBuilder(provider, map, new BlendFuncSwitch(BlendSrcFactor.SourceAlpha, BlendDestFactor.OneMinusSourceAlpha));
            }
            {
                var vs = new VertexShader(isourfaceVert);
                var fs = new FragmentShader(isosurfaceFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("vVertex", RaycastingModel.position);
                isosurfaceBuilder = new RenderMethodBuilder(provider, map, new BlendFuncSwitch(BlendSrcFactor.SourceAlpha, BlendDestFactor.OneMinusSourceAlpha));
            }

            var node = new RaycastingNode(model, defaultBuilder, isosurfaceBuilder);
            node.Initialize();

            return node;
        }

        private RaycastingNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
            this.CurrentMode = RenderMode.ISOSurface;
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            var bmp = new Bitmap(1, 1);
            var bmpG = Graphics.FromImage(bmp);
            var font = new Font("Arial", 256, GraphicsUnit.Pixel);
            string text = "煮";
            SizeF bigSize = bmpG.MeasureString(text, font);
            var bitmap = new Bitmap((int)Math.Ceiling(bigSize.Width), (int)Math.Ceiling(bigSize.Height));
            using (var g = Graphics.FromImage(bitmap))
            { g.DrawString(text, font, Brushes.White, 0, 0); }
            Texture volume = AmberLoader.Load(bitmap);
            volume.TextureUnitIndex = 0;

            for (int i = 0; i < this.RenderUnit.Methods.Length; i++)
            {
                RenderMethod method = this.RenderUnit.Methods[i];
                ShaderProgram program = method.Program;
                program.SetUniform("volume", volume);
                program.SetUniform("step_size", new vec3(1.0f / AmberLoader.length, 1.0f / AmberLoader.length, 1.0f / AmberLoader.length));
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

            mat4 mv = view * model;
            vec3 cameraPos = new vec3(glm.inverse(mv) * new vec4(0, 0, 0, 1));

            RenderMethod method = this.RenderUnit.Methods[(int)this.CurrentMode];
            ShaderProgram program = method.Program;
            program.SetUniform("MVP", projection * view * model);
            program.SetUniform("camPos", cameraPos);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
