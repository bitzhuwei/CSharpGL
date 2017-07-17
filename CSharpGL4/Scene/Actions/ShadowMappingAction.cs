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
        /// <param name="camera"></param>
        public ShadowMappingAction(RendererBase rootElement, ICamera camera)
            : base(rootElement, camera)
        {
        }

        /// <summary>
        /// Cast shadow.(Prepare shadow mapping texture)
        /// </summary>
        public override void Render()
        {
            GL.Instance.ClearColor(1, 1, 1, 1);
            GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

            var arg = new RenderEventArgs(this.Camera);
            ShadowMappingAction.CastShadow(this.RootElement, arg);
        }

        public static void CastShadow(RendererBase sceneElement, RenderEventArgs arg)
        {
            if (sceneElement != null)
            {
                mat4 parentCascadeModelMatrix = arg.ModelMatrixStack.Peek();
                sceneElement.cascadeModelMatrix = sceneElement.GetModelMatrix(parentCascadeModelMatrix);

                var renderable = sceneElement as IShadowMapping;
                if (renderable != null && renderable.EnableShadowMapping)
                {
                    renderable.CastShadow(arg);
                }

                {
                    arg.ModelMatrixStack.Push(sceneElement.cascadeModelMatrix);
                    foreach (var item in sceneElement.Children)
                    {
                        ShadowMappingAction.CastShadow(item as RendererBase, arg);
                    }
                    arg.ModelMatrixStack.Pop();
                }
            }
        }

    }
}