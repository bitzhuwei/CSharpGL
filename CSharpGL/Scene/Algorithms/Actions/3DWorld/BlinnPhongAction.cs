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
        private SceneNodeBase rootNode;
        private ICamera camera;
        private vec3 ambient;

        /// <summary>
        /// Render nodes using Blinn-Phong shading model.
        /// </summary>
        /// <param name="rootNode"></param>
        /// <param name="camera"></param>
        /// <param name="ambient"></param>
        public BlinnPhongAction(SceneNodeBase rootNode, ICamera camera, vec3 ambient)
        {
            this.rootNode = rootNode;
            this.camera = camera;
            this.ambient = ambient;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public override void Act(ActionParams param)
        {
            var arg = new RenderEventArgs(param, this.camera);
            RenderAmbientColor(this.rootNode, arg, this.ambient);
            RenderBlinnPhong(this.rootNode, arg);
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
        private static void RenderBlinnPhong(SceneNodeBase sceneNodeBase, RenderEventArgs arg)
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