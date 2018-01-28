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
    public class BlinnPhongAction : DependentActionBase
    {
        /// <summary>
        /// Render <see cref="IRenderable"/> objects.
        /// </summary>
        /// <param name="scene"></param>
        public BlinnPhongAction(Scene scene)
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
            RenderAmbientColor(this.Scene.RootElement, arg, this.Scene.AmbientColor);
            RenderBlinnPhong(this.Scene.RootElement, arg);
        }

        private static void RenderAmbientColor(SceneNodeBase sceneNodeBase, RenderEventArgs arg, vec3 ambient)
        {
            if (sceneNodeBase != null)
            {
                var node = sceneNodeBase as IBlinnPhong;
                ThreeFlags flags = (node != null) ? node.EnableRendering : ThreeFlags.None;
                bool before = (node != null) && ((flags & ThreeFlags.BeforeChildren) == ThreeFlags.BeforeChildren);
                bool children = (node == null) || ((flags & ThreeFlags.Children) == ThreeFlags.Children);
                bool after = (node != null) && ((flags & ThreeFlags.AfterChildren) == ThreeFlags.AfterChildren);

                if (before || after)
                {
                    node.RenderAmbientColor(arg, ambient);
                }

                if (children)
                {
                    foreach (var item in sceneNodeBase.Children)
                    {
                        RenderAmbientColor(item, arg, ambient);
                    }
                }

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneNodeBase"></param>
        /// <param name="arg"></param>
        public static void RenderBlinnPhong(SceneNodeBase sceneNodeBase, RenderEventArgs arg)
        {
            if (sceneNodeBase != null)
            {
                var node = sceneNodeBase as IBlinnPhong;
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
                        RenderBlinnPhong(item, arg);
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