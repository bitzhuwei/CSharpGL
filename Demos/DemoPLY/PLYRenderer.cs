using CSharpGL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPLY
{
    class PLYRenderer : Renderer
    {
        public static PLYRenderer Create(PLYModel model)
        {
            var vertexShader = new VertexShader(File.ReadAllText(@"PLY.vert"), "in_Position", "in_Color");
            var fragmentShader = new FragmentShader(File.ReadAllText(@"PLY.frag"));
            var provider = new ShaderArray(vertexShader, fragmentShader);
            var map = new AttributeMap();
            map.Add("in_Position", PLYModel.strPosition);
            map.Add("in_Color", PLYModel.strColor);
            var renderer = new PLYRenderer(model, provider, map);
            renderer.Initialize();
            return renderer;
        }

        private PLYRenderer(IBufferable model, IShaderProgramProvider shaderProgramProvider,
            AttributeMap attributeMap, params GLState[] switches)
            : base(model, shaderProgramProvider, attributeMap, switches)
        {
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 projection = arg.Scene.Camera.GetProjectionMatrix();
            mat4 view = arg.Scene.Camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            this.SetUniform("projection", projection);
            this.SetUniform("view", view);
            this.SetUniform("model", model);

            base.DoRender(arg);
        }
    }
}
