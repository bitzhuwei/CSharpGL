using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Extrude shadow volume, record occlusions by stencil operation, and light up nodes according to stencil test.
    /// </summary>
    public class ExtrudeShadowVolumeAction : DependentActionBase
    {
        /// <summary>
        /// Extrude shadow volume, record occlusions by stencil operation, and light up nodes according to stencil test.
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
            foreach (var light in this.Scene.Lights)
            {
                var arg = new ShadowVolumeEventArgs(light);
                Extrude(this.Scene.RootElement, arg);


            }
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