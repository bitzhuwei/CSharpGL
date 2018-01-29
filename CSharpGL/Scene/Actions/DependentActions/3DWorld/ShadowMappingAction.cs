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
    public class ShadowMappingAction : DependentActionBase
    {
        private readonly BlendState blend = new BlendState(BlendingSourceFactor.One, BlendingDestinationFactor.One);

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
        public ShadowMappingAction(Scene scene) : base(scene) { }

        /// <summary>
        /// Cast shadow.(Prepare shadow mapping texture)
        /// </summary>
        /// <param name="param"></param>
        public override void Act(ActionParams param)
        {
            // TODO: render ambient color.

            foreach (var light in this.Scene.Lights)
            {
                // cast shadow from specified light.
                {
                    light.Begin();
                    var arg = new ShadowMappingEventArgs(light);
                    CastShadow(this.Scene.RootNode, arg);
                    light.End();
                }

                // light up the scene with specified light.
                {
                    var arg = new RenderEventArgs(this.Scene.RootNode, param, this.Scene.Camera);
                    this.blend.On();
                    RenderUnderLight(this.Scene.RootNode, arg, light);
                    this.blend.Off();
                }
            }
        }

        private void CastShadow(SceneNodeBase sceneNodeBase, ShadowMappingEventArgs arg)
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