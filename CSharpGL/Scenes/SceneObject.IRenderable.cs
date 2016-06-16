using System;
using System.Collections.Generic;

namespace CSharpGL
{
    public partial class SceneObject
    {

        public void Render(RenderEventArgs arg)
        {
            SceneObjectRenderer renderer = this.Renderer;
            if (renderer != null)
            {
                renderer.Render(arg);
            }
        }

    }
}
