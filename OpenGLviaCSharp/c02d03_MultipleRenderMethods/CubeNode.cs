using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c02d03_MultipleRenderMethods
{
    partial class CubeNode : ModernNode, IRenderable
    {
        public enum MethodType
        {
            SingleColor,
            MultiTexture,
        };

        public MethodType CurrentMethod { get; set; }

        public static CubeNode Create(Texture texture0, Texture texture1)
        {
            // vertex buffer and index buffer.
            var model = new CubeModel();
            RenderMethodBuilder singleColorBuilder, multiTextureBuilder;
            {
                // vertex shader and fragment shader.
                var vs = new VertexShader(singleColorVert);
                var fs = new FragmentShader(singleColorFrag);
                var array = new ShaderArray(vs, fs);
                // which vertex buffer maps to which attribute in shader.
                var map = new PropertyMap();
                map.Add("inPosition", CubeModel.strPosition);
                // build a render method.
                var polygonModeSwitch = new PolygonModeSwitch(PolygonMode.Line);
                var lineWidth = new LineWidthSwitch(4);
                singleColorBuilder = new RenderMethodBuilder(array, map, polygonModeSwitch, lineWidth);
            }
            {
                // vertex shader and fragment shader.
                var vs = new VertexShader(multiTextureVert);
                var fs = new FragmentShader(multiTextureFrag);
                var array = new ShaderArray(vs, fs);
                // which vertex buffer maps to which attribute in shader.
                var map = new PropertyMap();
                map.Add("inPosition", CubeModel.strPosition);
                map.Add("inTexCoord", CubeModel.strTexCoord);
                // build a render method.
                multiTextureBuilder = new RenderMethodBuilder(array, map);
            }
            // create node.
            var node = new CubeNode(model, singleColorBuilder, multiTextureBuilder);
            node.SetTextures(texture0, texture1);
            // initialize node.
            node.Initialize();

            return node;
        }

        private Texture texture0;
        private Texture texture1;
        private void SetTextures(Texture texture0, Texture texture1)
        {
            this.texture0 = texture0;
            this.texture1 = texture1;
        }

        private CubeNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
        }

        #region IRenderable 成员

        // render this before render children. Call RenderBeforeChildren();
        // render children.
        // not Call RenderAfterChildren();
        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
        public ThreeFlags EnableRendering
        {
            get { return enableRendering; }
            set { enableRendering = value; }
        }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            // gets mvpMatrix.
            ICamera camera = arg.Camera;
            mat4 projectionMat = camera.GetProjectionMatrix();
            mat4 viewMat = camera.GetViewMatrix();
            mat4 modelMat = this.GetModelMatrix();
            mat4 mvpMatrix = projectionMat * viewMat * modelMat;
            // a render uint wraps everything(model data, shaders, glswitches, etc.) for rendering.
            ModernRenderUnit unit = this.RenderUnit;
            // gets render method.
            // There could be more than 1 method(vertex shader + fragment shader) to render the same model data. Thus we need an method array.
            RenderMethod method = unit.Methods[(int)this.CurrentMethod];
            // shader program wraps vertex shader and fragment shader.
            ShaderProgram program = method.Program;
            //set value for 'uniform mat4 mvpMatrix'; in shader.
            program.SetUniform("mvpMatrix", mvpMatrix);
            switch (this.CurrentMethod)
            {
                case MethodType.SingleColor:
                    break;
                case MethodType.MultiTexture:
                    program.SetUniform("texture0", this.texture0);
                    program.SetUniform("texture1", this.texture1);
                    break;
                default:
                    break;
            }
            // render the cube model via OpenGL.
            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }
}
