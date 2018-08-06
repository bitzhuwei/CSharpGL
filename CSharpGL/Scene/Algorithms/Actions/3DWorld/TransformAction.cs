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
        private Scene scene;
        /// <summary>
        /// Render <see cref="IWorldSpace"/> objects.
        /// </summary>
        /// <param name="rootNode"></param>
        public TransformAction(Scene scene)
        {
            if (scene == null) { throw new ArgumentNullException("scene"); }

            this.scene = scene;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public override void Act(ActionParams param)
        {
            var arg = new TransformEventArgs();
            this.Render(this.scene.RootNode, arg);
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