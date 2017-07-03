using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class ShadowMappingAction
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rootElement"></param>
        /// <param name="camera"></param>
        public static void CastShadow(RendererBase rootElement, ICamera camera)
        {
            GL.Instance.ClearColor(1, 1, 1, 1);
            GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

            var arg = new RenderEventArgs(camera);
            ShadowMappingAction.CastShadow(rootElement, arg);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rootElement"></param>
        /// <param name="camera"></param>
        public ShadowMappingAction(RendererBase rootElement, ICamera camera)
        {
            this.RootElement = rootElement;
            this.Camera = camera;
        }

        /// <summary>
        /// 
        /// </summary>
        public void CastShadow()
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
                        ShadowMappingAction.CastShadow(item, arg);
                    }
                    arg.ModelMatrixStack.Pop();
                }
            }
        }

        public RendererBase RootElement { get; set; }

        public ICamera Camera { get; set; }
    }
}