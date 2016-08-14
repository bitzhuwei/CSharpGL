using System;
using System.Collections.Generic;

namespace CSharpGL
{
    public partial class SceneObject
    {

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
