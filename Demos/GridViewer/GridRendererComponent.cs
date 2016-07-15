using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GridViewer
{
    public class GridRendererComponent : RendererComponent
    {

        const string strprojection = "projectionMatrix";
        const string strview = "viewMatrix";
        const string strmodel = "modelMatrix";

        public GridViewRenderer Renderer { get; private set; }

        public GridRendererComponent(GridViewRenderer renderer, SceneObject bindingObject = null)
            : base(bindingObject)
        {
            this.Renderer = renderer;
        }

        public override void Render(RenderEventArg arg)
        {
            GridViewRenderer renderer = this.Renderer;
            if (renderer != null)
            {
                mat4 projection, view, model;
                if (this.TryGetMatrix(arg, out projection, out view, out model))
                {
                    renderer.SetUniform(strprojection, projection);
                    renderer.SetUniform(strview, view);
                    renderer.SetUniform(strmodel, model);
                }

                renderer.Render(arg);
            }
        }

        protected override void DisposeUnmanagedResource()
        {
            GridViewRenderer renderer = this.Renderer;
            if (renderer != null) { renderer.Dispose(); }
        }
    }
}
