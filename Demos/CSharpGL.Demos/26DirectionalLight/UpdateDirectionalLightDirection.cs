using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL.Demos
{
    class UpdateDirectionalLightDirection : Script
    {
        private SimplexNoiseRenderer simplexNoiseRenderer;

        public UpdateDirectionalLightDirection(SimplexNoiseRenderer simplexNoiseRenderer)
        {
            // TODO: Complete member initialization
            this.simplexNoiseRenderer = simplexNoiseRenderer;
        }

        protected override void DoUpdate()
        {
            var renderer = this.BindingObject.Renderer as DirectonalLightRenderer;
            renderer.DirectionalLightDirection = this.simplexNoiseRenderer.WorldPosition;// acually is : this.simplexNoiseRenderer.WorldPosition - new vec3(0, 0, 0); 
        }
    }
}
