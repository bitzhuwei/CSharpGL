using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Render <see cref="IRenderable"/> objects.
    /// </summary>
    public class RenderAction : DependentActionBase
    {
        /// <summary>
        /// Render <see cref="IRenderable"/> objects.
        /// </summary>
        /// <param name="scene"></param>
        public RenderAction(Scene scene)
            : base(scene)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public override void Act(ActionParams param)
        {
            var arg = new RenderEventArgs(this.Scene, param, this.Scene.Camera);
            Render(this.Scene.RootElement, arg);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneNodeBase"></param>
        /// <param name="arg"></param>
        public static void Render(SceneNodeBase sceneNodeBase, RenderEventArgs arg)
        {
            if (sceneNodeBase != null)
            {
                var node = sceneNodeBase as IRenderable;
                ThreeFlags flags = (node != null) ? node.EnableRendering : ThreeFlags.None;
                bool before = (node != null) && ((flags & ThreeFlags.BeforeChildren) == ThreeFlags.BeforeChildren);
                bool children = (node == null) || ((flags & ThreeFlags.Children) == ThreeFlags.Children);
                bool after = (node != null) && ((flags & ThreeFlags.AfterChildren) == ThreeFlags.AfterChildren);

                if (before)
                {
                    node.RenderBeforeChildren(arg);
                }

                if (children)
                {
                    foreach (var item in sceneNodeBase.Children)
                    {
                        Render(item, arg);
                    }
                }

                if (after)
                {
                    node.RenderAfterChildren(arg);
                }
            }
        }

    }
}