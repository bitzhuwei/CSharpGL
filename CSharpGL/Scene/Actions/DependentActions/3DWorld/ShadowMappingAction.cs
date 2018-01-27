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
            var arg = new ShadowMappingEventArgs();
            this.ShadowMapping(this.Scene.RootElement, arg);
        }

        private void ShadowMapping(SceneNodeBase sceneElement, ShadowMappingEventArgs arg)
        {
            if (sceneElement != null)
            {
                var lightContainer = sceneElement as ILocalLightContainer;
                if (lightContainer != null)
                {
                    foreach (var light in lightContainer.LightList)
                    {
                        arg.CurrentLight = light;
                        light.Begin();
                        foreach (var child in sceneElement.Children)
                        {
                            this.CastShadow(child, arg);
                        }
                        light.End();
                        arg.CurrentLight = null;
                    }
                }

                foreach (var child in sceneElement.Children)
                {
                    this.ShadowMapping(child, arg);
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

    }
}