using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolumeRendering.Raycast
{
    public partial class RaycastNode : PickableNode, IRenderable
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
                backfaceBuilder = new RenderMethodBuilder(provider, map, new CullFaceSwitch(CullFaceMode.Front, true));
            }
            {
                var vs = new VertexShader(raycastingVert);
                var fs = new FragmentShader(raycastingFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("position", RaycastModel.strposition);
                map.Add("boundingBox", RaycastModel.strcolor);
                raycastingBuilder = new RenderMethodBuilder(provider, map, new CullFaceSwitch(CullFaceMode.Back, true));
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
            Viewport viewport = arg.Param.Viewport;

            if (this.width != viewport.width || this.height != viewport.height)
            {
                this.Resize(viewport.width, viewport.height);

                this.width = viewport.width;
                this.height = viewport.height;
            }
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            this.UpdateRotation();
            mat4 model = this.GetModelMatrix();
            mat4 mvp = projection * view * model;
            {
                RenderMethod method = this.RenderUnit.Methods[0];// backface.
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
                RenderMethod method = this.RenderUnit.Methods[1];// raycasting.
                ShaderProgram program = method.Program;
                program.SetUniform("MVP", mvp);

                method.Render();
            }
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        int cycle = 1600;
        public int Cycle
        {
            get
            {
                return cycle;
            }
            set
            {
                this.cycle = value;
                if (this.IsInitialized)
                {
                    RenderMethod method = this.RenderUnit.Methods[1];// raycasting.
                    ShaderProgram program = method.Program;
                    program.SetUniform("cycle", value);
                }
            }
        }
    }
}
