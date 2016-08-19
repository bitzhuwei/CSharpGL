using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpGL
{
    public partial class SceneObject
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public void Render(RenderEventArgs arg)
        {
            if (this.Enabled)
            {
                //RendererComponent renderer = this.RendererComponent;
                IRenderable renderer = this.Renderer;
                if (renderer != null)
                {
                    renderer.Render(arg);
                }

                // render objects.
                if (this.Children.Count > 0)
                {
                    var list = this.Children.ToArray();
                    foreach (var item in list)
                    {
                        item.Render(arg);
                    }
                }
            }
        }

    }
}
