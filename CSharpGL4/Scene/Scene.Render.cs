using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public partial class Scene
    {
        /// <summary>
        /// 
        /// </summary>
        public void Render()
        {
            GL.Instance.ClearColor(clearColor.x, clearColor.y, clearColor.z, 1.0f);
            GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

            var arg = new RenderEventArgs(this);
            this.Render(this.RootElement, arg);
        }

        private void Render(RendererBase sceneElement, RenderEventArgs arg)
        {
            if (sceneElement != null)
            {
                sceneElement.modelMatrix = sceneElement.GetModelMatrix();

                var renderable = sceneElement as IRenderable;
                if (renderable != null && renderable.RenderingEnabled)
                {
                    renderable.RenderBeforeChildren(arg);
                }

                foreach (var item in sceneElement.Children)
                {
                    this.Render(item as RendererBase, arg);
                }
            }
        }

    }
}