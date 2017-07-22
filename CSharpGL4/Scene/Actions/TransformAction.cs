using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Render <see cref="IWorldSpace"/> objects.
    /// </summary>
    public class TransformAction : ActionBase
    {
        /// <summary>
        /// Render <see cref="IWorldSpace"/> objects.
        /// </summary>
        /// <param name="rootElement"></param>
        /// <param name="camera"></param>
        public TransformAction(SceneNodeBase rootElement)
            : base(rootElement, null)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstPass">Update all objects' model matrix if <paramref name="firstPass"/> is true.</param>
        public override void Render(bool firstPass)
        {
            if (firstPass)
            {
                var arg = new TransformEventArgs();
                this.Render(this.RootElement, arg);
            }
        }

        private void Render(SceneNodeBase sceneElement, TransformEventArgs arg)
        {
            if (sceneElement != null)
            {
                mat4 parentCascadeModelMatrix = arg.ModelMatrixStack.Peek();
                sceneElement.cascadeModelMatrix = sceneElement.GetModelMatrix(parentCascadeModelMatrix);

                arg.ModelMatrixStack.Push(sceneElement.cascadeModelMatrix);
                foreach (var item in sceneElement.Children)
                {
                    this.Render(item, arg);
                }
                arg.ModelMatrixStack.Pop();
            }
        }

    }
}