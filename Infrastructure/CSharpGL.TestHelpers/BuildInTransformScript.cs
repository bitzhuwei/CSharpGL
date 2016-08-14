using CSharpGL.TestHelpers;
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
        private TransformScript transformScript;
        private IModelTransform modelTransform;

        protected override void DoInitialize()
        {
            this.transformScript = this.BindingObject.GetScript<TransformScript>();
            this.modelTransform = this.BindingObject.Renderer as IModelTransform;
        }

        protected override void DoUpdate(double elapsedTime)
        {
            this.modelTransform.ModelMatrix = this.transformScript.GetModelMatrix();
        }
    }
}
