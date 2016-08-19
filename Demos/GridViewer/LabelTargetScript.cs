using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GridViewer
{
    class LabelTargetScript : ScriptComponent
    {
        private IModelTransform target;
        private IModelTransform self;
        public LabelTargetScript(IModelTransform target)
        {
            // TODO: Complete member initialization
            this.target = target;
        }

        protected override void DoInitialize()
        {
            this.self = this.BindingObject.Renderer as IModelTransform;
        }

        protected override void DoUpdate(double elapsedTime)
        {
            //vec3 position = this.target.ModelMatrix * 
            //this.self=glm
        }
    }
}
