using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL.Demos
{
    class UpdatePointLightPosition : Script
    {
        private SimplexNoiseRenderer simplexNoiseRenderer;

        public UpdatePointLightPosition(SimplexNoiseRenderer simplexNoiseRenderer)
        {
            // TODO: Complete member initialization
            this.simplexNoiseRenderer = simplexNoiseRenderer;
        }

        protected override void DoUpdate()
        {
            var renderer = this.BindingObject.Renderer as PointLightRenderer;
            renderer.LightPosition = this.simplexNoiseRenderer.WorldPosition;// acually is : this.simplexNoiseRenderer.WorldPosition - new vec3(0, 0, 0); 
        }
    }
}
