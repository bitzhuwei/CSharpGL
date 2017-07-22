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
        public ShadowMappingAction(SceneNodeBase rootElement, ICamera camera)
            : base(rootElement, camera)
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

            var arg = new ShdowMappingEventArgs(this.Camera);
            ShadowMappingAction.CastShadow(this.RootElement, arg, firstPass);
        }

        public static void CastShadow(SceneNodeBase sceneElement, ShdowMappingEventArgs arg, bool firstPass)
        {
            if (sceneElement != null)
            {
                if (firstPass)
                {
                    mat4 parentCascadeModelMatrix = arg.ModelMatrixStack.Peek();
                    sceneElement.cascadeModelMatrix = sceneElement.GetModelMatrix(parentCascadeModelMatrix);
                }

                var lightListContainer = sceneElement as ILocalLightContainer;
                if (lightListContainer != null)
                {
                    foreach (var item in lightListContainer.LightList)
                    {

                    }
                }

                var renderable = sceneElement as IShadowMapping;
                if (renderable != null && renderable.EnableShadowMapping)
                {
                    renderable.CastShadow(arg);
                }
                {
                    if (firstPass) { arg.ModelMatrixStack.Push(sceneElement.cascadeModelMatrix); }
                    foreach (var item in sceneElement.Children)
                    {
                        ShadowMappingAction.CastShadow(item, arg, firstPass);
                    }
                    if (firstPass) { arg.ModelMatrixStack.Pop(); }
                }
            }
        }

    }
}