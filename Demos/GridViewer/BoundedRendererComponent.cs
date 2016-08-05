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

        public override void Render(RenderEventArg arg)
        {
            BoundedRenderer renderer = this.Renderer;
            if (renderer != null)
            {
                mat4 projection, view, model;
                if (this.TryGetMatrix(arg, out projection, out view, out model))
                {
                    renderer.BoxRenderer.SetUniform(strprojection, projection);
                    renderer.BoxRenderer.SetUniform(strview, view);
                    renderer.BoxRenderer.SetUniform(strmodel, model);
                    renderer.Renderer.SetUniform(strprojection, projection);
                    renderer.Renderer.SetUniform(strview, view);
                    renderer.Renderer.SetUniform(strmodel, model);
                }

                renderer.Render(arg);
            }
        }

        protected override void DisposeUnmanagedResource()
        {
            BoundedRenderer renderer = this.Renderer;
            if (renderer != null) { renderer.Dispose(); }
        }
    }
}
