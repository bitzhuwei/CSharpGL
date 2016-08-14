using System;
using System.Collections.Generic;

namespace CSharpGL
{
    public partial class SceneObject
    {
        /// <summary>
        /// Transform about this model's position, rotation or scale.
        /// </summary>
        public IModelTransform Transform
        {
            get
            {
                IRenderable renderer = this.Renderer;
                if (renderer != null)
                { return renderer.Transform; }
                else
                { return null; }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public void Render(RenderEventArg arg)
        {
            if (this.Enabled)
            {
                //RendererComponent renderer = this.RendererComponent;
                IRenderable renderer = this.Renderer;
                if (renderer != null)
                {
                    renderer.Render(arg);
                }
            }
        }

    }
}
