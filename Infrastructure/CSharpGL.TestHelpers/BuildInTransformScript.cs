using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Apply <see cref="TransformScript"/>'s model matrix to build in renderer.
    /// </summary>
    public class BuildInTransformScript : ScriptComponent
    {
        private TransformScript transform;
        private BuildInRenderer renderer;

        protected override void DoInitialize()
        {
            this.transform = this.BindingObject.GetScript<TransformScript>();
            this.renderer = this.BindingObject.Renderer as BuildInRenderer;
        }

        protected override void DoUpdate(double elapsedTime)
        {
            this.renderer.ModelMatrix = this.transform.GetModelMatrix();
        }
    }
}
