using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace EZMFileViewer
{
    partial class BoneNode : ModernNode, IRenderable
    {
        public static BoneNode Create(EZMBone[] bones)
        {
            var model = new BoneModel(bones);
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("inPosition", BoneModel.strPosition);
            map.Add("inColor", BoneModel.strColor);
            var builder = new RenderMethodBuilder(array, map, new LineWidthSwitch(5));
            var node = new BoneNode(model, builder);
            node.Initialize();

            return node;
        }

        private BoneNode(IBufferSource model, params RenderMethodBuilder[] builders) : base(model, builders) { }

        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;

        public ThreeFlags EnableRendering
        {
            get { return enableRendering; }
            set { enableRendering = value; }
        }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            ICamera camera = arg.Camera;
            mat4 projectionMat = camera.GetProjectionMatrix();
            mat4 viewMat = camera.GetViewMatrix();
            mat4 modelMat = this.GetModelMatrix();

            ModernRenderUnit unit = this.RenderUnit;
            RenderMethod method = unit.Methods[0];
            ShaderProgram program = method.Program;
            program.SetUniform("mvpMat", projectionMat * viewMat * modelMat);
            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }
}
