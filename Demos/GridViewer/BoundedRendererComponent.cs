using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GridViewer
{
    public class BoundedRendererComponent : RendererComponent
    {

        const string strprojection = "projectionMatrix";
        const string strview = "viewMatrix";
        const string strmodel = "modelMatrix";

        public BoundedRenderer Renderer { get; private set; }

        public BoundedRendererComponent(BoundedRenderer renderer, SceneObject bindingObject = null)
            : base(bindingObject)
        {
            this.Renderer = renderer;
        }

        public override void Render(RenderEventArgs arg)
        {
            BoundedRenderer renderer = this.Renderer;
            if (renderer != null)
            {
                mat4 projection, view, model;
                if (this.TryGetMatrix(arg, out projection, out view, out model))
                {
                    renderer.BoundingBoxRenderer.SetUniform(strprojection, projection);
                    renderer.BoundingBoxRenderer.SetUniform(strview, view);
                    renderer.BoundingBoxRenderer.SetUniform(strmodel, model);
                    renderer.ScientificRenderer.SetUniform(strprojection, projection);
                    renderer.ScientificRenderer.SetUniform(strview, view);
                    renderer.ScientificRenderer.SetUniform(strmodel, model);
                }

                renderer.Render(arg);
            }
        }
    }
}
