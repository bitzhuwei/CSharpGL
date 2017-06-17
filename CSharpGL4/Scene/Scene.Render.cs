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
                sceneElement.modelMatrix = GetModelMatrix(sceneElement);

                var renderable = sceneElement as IRenderable;
                if (renderable != null && renderable.RenderingEnabled)
                {
                    renderable.Render(arg);
                }

                var node = sceneElement as ITreeNode;
                if (node != null)
                {
                    foreach (var item in node.Children)
                    {
                        this.Render(item as RendererBase, arg);
                    }
                }
            }
        }

        /// <summary>
        /// Get model matrix.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private static mat4 GetModelMatrix(RendererBase model)
        {
            mat4 matrix = glm.translate(mat4.identity(), model.WorldPosition);
            matrix = glm.scale(matrix, model.Scale);
            matrix = glm.rotate(matrix, model.RotationAngle, model.RotationAxis);

            var node = model as RendererBase;
            if (node != null)
            {
                var parent = node.Parent as RendererBase;
                if (parent != null)
                {
                    matrix = parent.modelMatrix * matrix;
                }

                node.modelMatrix = matrix;
            }

            return matrix;
        }
    }
}