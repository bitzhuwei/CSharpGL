using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Cast shaow mapping textures for <see cref="ISupportShadowMapping"/>.
    /// </summary>
    public class ShadowMappingAction : ActionBase
    {
        private readonly BlendState blend = new BlendState(BlendingSourceFactor.One, BlendingDestinationFactor.One);
        private Scene scene;

        /// <summary>
        /// 
        /// </summary>
        public BlendState Blend
        {
            get { return blend; }
        }

        /// <summary>
        /// Cast shaow mapping textures for <see cref="ISupportShadowMapping"/>.
        /// </summary>
        /// <param name="scene"></param>
        public ShadowMappingAction(Scene scene)
        {
            this.scene = scene;
        }

        /// <summary>
        /// Cast shadow.(Prepare shadow mapping texture)
        /// </summary>
        /// <param name="param"></param>
        public override void Act(ActionParams param)
        {
            Scene scene = this.scene;
            // TODO: render ambient color.

            foreach (var light in scene.Lights)
            {
                // cast shadow from specified light.
                {
                    light.Begin();
                    var arg = new ShadowMappingCastShadowEventArgs(light);
                    CastShadow(scene.RootNode, arg);
                    light.End();
                }

                // light up the scene with specified light.
                {
                    var arg = new RenderEventArgs(param, scene.Camera);
                    this.blend.On();
                    RenderUnderLight(scene.RootNode, arg, light);
                    this.blend.Off();
                }
            }
        }

        private void CastShadow(SceneNodeBase sceneNodeBase, ShadowMappingCastShadowEventArgs arg)
        {
            if (sceneNodeBase != null)
            {
                var node = sceneNodeBase as ISupportShadowMapping;
                TwoFlags flags = (node != null) ? node.EnableShadowMapping : TwoFlags.None;
                bool before = (node != null) && ((flags & TwoFlags.BeforeChildren) == TwoFlags.BeforeChildren);
                bool children = (node == null) || ((flags & TwoFlags.Children) == TwoFlags.Children);

                if (before)
                {
                    flags = node.EnableCastShadow;
                    before = (flags & TwoFlags.BeforeChildren) == TwoFlags.BeforeChildren;
                }

                if (children)
                {
                    flags = (node != null) ? node.EnableCastShadow : TwoFlags.None;
                    children = (node == null) || ((flags & TwoFlags.Children) == TwoFlags.Children);
                }

                if (before)
                {
                    node.CastShadow(arg);
                }

                if (children)
                {
                    foreach (var item in sceneNodeBase.Children)
                    {
                        CastShadow(item, arg);
                    }
                }
            }
        }

        private void RenderUnderLight(SceneNodeBase sceneNodeBase, RenderEventArgs arg, LightBase light)
        {
            if (sceneNodeBase != null)
            {
                var node = sceneNodeBase as ISupportShadowMapping;
                TwoFlags flags = (node != null) ? node.EnableShadowMapping : TwoFlags.None;
                bool before = (node != null) && ((flags & TwoFlags.BeforeChildren) == TwoFlags.BeforeChildren);
                bool children = (node == null) || ((flags & TwoFlags.Children) == TwoFlags.Children);

                if (before)
                {
                    flags = node.EnableRenderUnderLight;
                    before = (flags & TwoFlags.BeforeChildren) == TwoFlags.BeforeChildren;
                }

                if (children)
                {
                    flags = (node != null) ? node.EnableRenderUnderLight : TwoFlags.None;
                    children = (node == null) || ((flags & TwoFlags.Children) == TwoFlags.Children);
                }

                if (before)
                {
                    node.RenderUnderLight(arg, light);
                }

                if (children)
                {
                    foreach (var item in sceneNodeBase.Children)
                    {
                        RenderUnderLight(item, arg, light);
                    }
                }
            }
        }

    }
}