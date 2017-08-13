using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaycastVolumeRendering
{
    public partial class RaycastNode : PickableNode
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static RaycastNode Create()
        {
            var model = new RaycastModel();
            RenderUnitBuilder backfaceBuilder, raycastingBuilder;
            {
                var vs = new VertexShader(backfaceVert, "position", "boundingBox");
                var fs = new FragmentShader(backfaceFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("position", RaycastModel.strposition);
                map.Add("boundingBox", RaycastModel.strcolor);
                backfaceBuilder = new RenderUnitBuilder(provider, map, new CullFaceState(CullFaceMode.Front, true));
            }
            {
                var vs = new VertexShader(raycastingVert, "position", "boundingBox");
                var fs = new FragmentShader(raycastingFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("position", RaycastModel.strposition);
                map.Add("boundingBox", RaycastModel.strcolor);
                raycastingBuilder = new RenderUnitBuilder(provider, map, new CullFaceState(CullFaceMode.Back, true));
            }

            var node = new RaycastNode(model, RaycastModel.strposition, backfaceBuilder, raycastingBuilder);
            node.Initialize();

            return node;
        }

        private RaycastNode(IBufferSource model, string positionNameInIBufferSource, params RenderUnitBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders)
        {
        }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            var viewport = new int[4]; GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);

            if (this.width != viewport[2] || this.height != viewport[3])
            {
                Resize(viewport[2], viewport[3]);

                this.width = viewport[2];
                this.height = viewport[3];
            }
            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            mat4 mvp = projection * view * model;
            {
                RenderUnit unit = this.RenderUnits[0];
                ShaderProgram program = unit.Program;
                program.SetUniform("MVP", mvp);

                // render to texture
                this.framebuffer.Bind(FramebufferTarget.Framebuffer);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);
                {
                    unit.Render();
                }
                this.framebuffer.Unbind(FramebufferTarget.Framebuffer);
            }
            {
                RenderUnit unit = this.RenderUnits[1];
                ShaderProgram program = unit.Program;
                program.SetUniform("MVP", mvp);

                unit.Render();
            }
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
