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
    public class TransformAction : DependentActionBase
    {
        /// <summary>
        /// Render <see cref="IWorldSpace"/> objects.
        /// </summary>
        /// <param name="scene"></param>
        public TransformAction(Scene scene) : base(scene) { }

        /// <summary>
        /// 
        /// </summary>
        public override void Act()
        {
            var arg = new TransformEventArgs();
            this.Render(this.Scene.RootElement, arg);
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