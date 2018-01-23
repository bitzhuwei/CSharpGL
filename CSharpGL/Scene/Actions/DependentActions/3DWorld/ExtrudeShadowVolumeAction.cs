using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Extrude shadow volume and record occlusions by stencil operation.
    /// </summary>
    public class ExtrudeShadowVolumeAction : DependentActionBase
    {
        /// <summary>
        /// Extrude shadow volume and record occlusions by stencil operation.
        /// </summary>
        /// <param name="scene"></param>
        public ExtrudeShadowVolumeAction(Scene scene)
            : base(scene)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public override void Act(ActionParams param)
        {
            var arg = new ShadowVolumeEventArgs();
            Extrude(this.Scene.RootElement, arg);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneElement"></param>
        /// <param name="arg"></param>
        static void Extrude(SceneNodeBase sceneElement, ShadowVolumeEventArgs arg)
        {
            if (sceneElement != null)
            {
                var node = sceneElement as ISupportShadowVolume;
                TwoFlags flags = (node != null) ? node.EnableShadowVolume : TwoFlags.None;
                bool before = (node != null) && ((flags & TwoFlags.BeforeChildren) == TwoFlags.BeforeChildren);
                bool children = (node == null) || ((flags & TwoFlags.Children) == TwoFlags.Children);

                if (before)
                {
                    node.ExtrudeShadow(arg);
                }

                if (children)
                {
                    foreach (var item in sceneElement.Children)
                    {
                        Extrude(item, arg);
                    }
                }
            }
        }

    }
}