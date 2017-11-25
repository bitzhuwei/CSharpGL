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
            RenderMethodBuilder backfaceBuilder, raycastingBuilder;
            {
                var vs = new VertexShader(backfaceVert);
                var fs = new FragmentShader(backfaceFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("position", RaycastModel.strposition);
                map.Add("boundingBox", RaycastModel.strcolor);
                backfaceBuilder = new RenderMethodBuilder(provider, map, new CullFaceState(CullFaceMode.Front, true));
            }
            {
                var vs = new VertexShader(raycastingVert);
                var fs = new FragmentShader(raycastingFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("position", RaycastModel.strposition);
                map.Add("boundingBox", RaycastModel.strcolor);
                raycastingBuilder = new RenderMethodBuilder(provider, map, new CullFaceState(CullFaceMode.Back, true));
            }

            var node = new RaycastNode(model, RaycastModel.strposition, backfaceBuilder, raycastingBuilder);
            node.Initialize();

            return node;
        }

        private RaycastNode(IBufferSource model, string positionNameInIBufferSource, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders)
        {
        }

        private ArcBallManipulater manipulater;

        public void BindManipulater(ArcBallManipulater manipulater)
        {
            this.manipulater = manipulater;
        }

        private void UpdateRotation()
        {
            var manipulater = this.manipulater;
            if (manipulater != null)
            {
                mat4 model = this.manipulater.GetRotationMatrix();
                Quaternion quaternion = model.ToQuaternion();
                float angleDegree;
                vec3 axis;
                quaternion.Parse(out angleDegree, out axis);

                this.RotationAngle = angleDegree;
                this.RotationAxis = axis;
            }
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
            this.UpdateRotation();
            mat4 model = this.GetModelMatrix();
            mat4 mvp = projection * view * model;
            {
                RenderMethod method = this.RenderUnit.Methods[0];
                ShaderProgram program = method.Program;
                program.SetUniform("MVP", mvp);

                // render to texture
                this.framebuffer.Bind(FramebufferTarget.Framebuffer);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);
                {
                    method.Render();
                }
                this.framebuffer.Unbind(FramebufferTarget.Framebuffer);
            }
            {
                RenderMethod method = this.RenderUnit.Methods[1];
                ShaderProgram program = method.Program;
                program.SetUniform("MVP", mvp);

                method.Render();
            }
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
