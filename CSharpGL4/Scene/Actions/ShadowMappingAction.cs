using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Cast shaow mapping textures for <see cref="IShadowMapping"/>.
    /// </summary>
    public class ShadowMappingAction : ActionBase
    {
        /// <summary>
        /// Cast shaow mapping textures for <see cref="IShadowMapping"/>.
        /// </summary>
        /// <param name="rootElement"></param>
        public ShadowMappingAction(SceneNodeBase rootElement)
            : base(rootElement)
        {
        }

        /// <summary>
        /// Cast shadow.(Prepare shadow mapping texture)
        /// </summary>
        /// <param name="firstPass">Update all objects' model matrix if <paramref name="firstPass"/> is true.</param>
        public override void Render(bool firstPass)
        {
            GL.Instance.ClearColor(1, 1, 1, 1);
            GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

            var arg = new ShdowMappingEventArgs();
            this.ShadowMapping(this.RootElement, arg);
        }

        private void ShadowMapping(SceneNodeBase sceneElement, ShdowMappingEventArgs arg)
        {
            if (sceneElement != null)
            {
                var lightContainer = sceneElement as ILocalLightContainer;
                if (lightContainer != null)
                {
                    foreach (var light in lightContainer.LightList)
                    {
                        arg.CurrentLight = light;
                        light.Begin();
                        foreach (var child in sceneElement.Children)
                        {
                            this.CastShadow(child, arg);
                        }
                        light.End();
                        arg.CurrentLight = null;
                    }
                }

                foreach (var child in sceneElement.Children)
                {
                    this.ShadowMapping(child, arg);
                }

            }
        }

        private void CastShadow(SceneNodeBase sceneElement, ShdowMappingEventArgs arg)
        {
            if (sceneElement != null)
            {
                var renderable = sceneElement as IShadowMapping;
                if (renderable != null && renderable.EnableShadowMapping)
                {
                    renderable.CastShadow(arg);
                }

                foreach (var item in sceneElement.Children)
                {
                    CastShadow(item, arg);
                }
            }
        }

    }
}