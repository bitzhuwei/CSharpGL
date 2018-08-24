using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace fuluDD01_LayeredEngraving.PNG
{
    public partial class RaycastNode : PickableNode, IRenderable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static RaycastNode Create(IVolumeData volumeDataProvider)
        {
            var model = new BoundingBoxModel();
            RenderMethodBuilder backfaceBuilder, raycastingBuilder;
            {
                var vs = new VertexShader(backfaceVert);
                var fs = new FragmentShader(backfaceFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("position", BoundingBoxModel.strPosition);
                map.Add("boundingBox", BoundingBoxModel.strColor);
                backfaceBuilder = new RenderMethodBuilder(provider, map, new CullFaceSwitch(CullFaceMode.Front, true));
            }
            {
                var vs = new VertexShader(raycastingVert);
                var fs = new FragmentShader(raycastingFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("position", BoundingBoxModel.strPosition);
                map.Add("boundingBox", BoundingBoxModel.strColor);
                raycastingBuilder = new RenderMethodBuilder(provider, map, new CullFaceSwitch(CullFaceMode.Back, true));
            }

            var node = new RaycastNode(model, BoundingBoxModel.strPosition, backfaceBuilder, raycastingBuilder);
            node.volumeDataProvider = volumeDataProvider;
            node.Initialize();

            return node;
        }

        private RaycastNode(IBufferSource model, string positionNameInIBufferSource, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders)
        {
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
            if (this.volume3DTexture == null)
            {
                {
                    var provider = this.volumeDataProvider;
                    int width = provider.Width, height = provider.Height, depth = provider.Depth;
                    byte[] volumeData = provider.VolumeData;
                    this.volume3DTexture = InitVolume3DTexture(volumeData, width, height, depth);
                    //this.volume3DTexture = provider.TexVolumeData;
                }
                //{
                //    int width = 128, height = 128, depth = 128;
                //    byte[] volumeData = VolumeData.GetData(width, height, depth);
                //    this.volume3DTexture = InitVolume3DTexture(volumeData, width, height, depth);
                //}

                RenderMethod method = this.RenderUnit.Methods[1];
                ShaderProgram program = method.Program;
                program.SetUniform("texVolume", this.volume3DTexture);
            }

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
            mat4 model = this.GetModelMatrix();
            mat4 mvp = projection * view * model;
            {
                RenderMethod method = this.RenderUnit.Methods[0];// backface.
                ShaderProgram program = method.Program;
                program.SetUniform("mvpMat", mvp);

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
                program.SetUniform("mvpMat", mvp);

                method.Render();
            }
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        int cycle = 1600;
        private IVolumeData volumeDataProvider;
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
