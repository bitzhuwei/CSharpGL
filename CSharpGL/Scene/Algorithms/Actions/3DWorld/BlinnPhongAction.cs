using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Render nodes using Blinn-Phong shading model.
    /// </summary>
    public class BlinnPhongAction : ActionBase
    {
        private Scene scene;
        private readonly BlendFuncSwitch blend = new BlendFuncSwitch(BlendSrcFactor.One, BlendDestFactor.One);

        /// <summary>
        /// 
        /// </summary>
        public BlendFuncSwitch Blend
        {
            get { return blend; }
        }

        /// <summary>
        /// Render nodes using Blinn-Phong shading model.
        /// </summary>
        /// <param name="scene"></param>
        public BlinnPhongAction(Scene scene)
        {
            this.scene = scene;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public override void Act(ActionParams param)
        {
            {
                var arg = new BlinnPhongAmbientEventArgs(param, this.scene.Camera, this.scene.AmbientColor);
                RenderAmbientColor(this.scene.RootNode, arg);
            }

            this.blend.On();
            foreach (var light in this.scene.Lights)
            {
                var arg = new RenderEventArgs(param, this.scene.Camera);
                RenderBlinnPhong(this.scene.RootNode, arg, light);
            }
            this.blend.Off();
        }

        private static void RenderAmbientColor(SceneNodeBase sceneNodeBase, BlinnPhongAmbientEventArgs arg)
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
                    node.RenderAmbientColor(arg);
                }

                if (children)
                {
                    foreach (var item in sceneNodeBase.Children)
                    {
                        RenderAmbientColor(item, arg);
                    }
                }

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneNodeBase"></param>
        /// <param name="arg"></param>
        /// <param name="light"></param>
        private static void RenderBlinnPhong(SceneNodeBase sceneNodeBase, RenderEventArgs arg, LightBase light)
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
                    node.RenderBeforeChildren(arg, light);
                }

                if (children)
                {
                    foreach (var item in sceneNodeBase.Children)
                    {
                        RenderBlinnPhong(item, arg, light);
                    }
                }

                if (after)
                {
                    node.RenderAfterChildren(arg, light);
                }
            }
        }

    }
}