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
    public class RenderAction : ActionBase
    {
        private Scene scene;
        /// <summary>
        /// Render <see cref="IRenderable"/> objects.
        /// </summary>
        /// <param name="scene"></param>
        public RenderAction(Scene scene)
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
            Scene scene = this.scene;
            var arg = new RenderEventArgs(param, scene.Camera);
            Render(scene.RootNode, arg);
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