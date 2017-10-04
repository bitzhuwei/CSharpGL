using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace GPURaycasting
{
    partial class RaycastingNode : ModernNode
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
                var vs = new VertexShader(defaultVert, "vVertex");
                var fs = new FragmentShader(defaultFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("vVertex", RaycastingModel.position);
                defaultBuilder = new RenderMethodBuilder(provider, map, new BlendState(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.OneMinusSourceAlpha));
            }
            {
                var vs = new VertexShader(isourfaceVert, "vVertex");
                var fs = new FragmentShader(isosurfaceFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("vVertex", RaycastingModel.position);
                isosurfaceBuilder = new RenderMethodBuilder(provider, map, new BlendState(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.OneMinusSourceAlpha));
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

            Texture volume = Engine256Loader.Load();
            volume.TextureUnitIndex = 0;

            for (int i = 0; i < this.RenderUnit.Methods.Length; i++)
            {
                RenderMethod unit = this.RenderUnit.Methods[i];
                ShaderProgram program = unit.Program;
                program.SetUniform("volume", volume);
                program.SetUniform("step_size", new vec3(1.0f / Engine256Loader.XDIM, 1.0f / Engine256Loader.YDIM, 1.0f / Engine256Loader.ZDIM));
            }
        }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            mat4 mv = view * model;
            vec3 cameraPos = new vec3(glm.inverse(mv) * new vec4(0, 0, 0, 1));

            RenderMethod unit = this.RenderUnit.Methods[(int)this.CurrentMode];
            ShaderProgram program = unit.Program;
            program.SetUniform("MVP", projection * view * model);
            program.SetUniform("camPos", cameraPos);

            unit.Render();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
