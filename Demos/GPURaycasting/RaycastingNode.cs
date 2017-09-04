using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace GPURaycasting
{
    partial class RaycastingNode : ModernNode
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static RaycastingNode Create()
        {
            var model = new RaycastingModel();
            RenderUnitBuilder textureSlicerBuilder;
            {
                var vs = new VertexShader(textureSlicerVert, "vVertex");
                var fs = new FragmentShader(textureSlicerFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("vVertex", RaycastingModel.position);
                textureSlicerBuilder = new RenderUnitBuilder(provider, map, new BlendState(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.OneMinusSourceAlpha));
            }

            var node = new RaycastingNode(model, textureSlicerBuilder);
            node.Initialize();

            return node;
        }

        private RaycastingNode(IBufferSource model, params RenderUnitBuilder[] builders)
            : base(model, builders)
        {
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            {
                Texture volume = Engine256Loader.Load();
                volume.TextureUnitIndex = 0;

                RenderUnit unit = this.RenderUnits[0];
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

            RenderUnit unit = this.RenderUnits[0];
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
