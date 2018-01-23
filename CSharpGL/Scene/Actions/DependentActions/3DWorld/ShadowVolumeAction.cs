using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Render depth buffer, extrude shadow volume, record occlusions by stencil operation, light up the scene according to stencil test and finally render the ambient color.
    /// </summary>
    public class ShadowVolumeAction : DependentActionBase
    {
        /// <summary>
        /// Render depth buffer, extrude shadow volume, record occlusions by stencil operation, light up the scene according to stencil test and finally render the ambient color.
        /// </summary>
        /// <param name="scene"></param>
        public ShadowVolumeAction(Scene scene)
            : base(scene)
        {
            this.clearStencilNode = ClearStencilNode.Create();
            {
                var stencilTest = new StencilTestState(enableCapacity: true);
                var depthClamp = new DepthClampState(enableCapacity: true);
                var cullFace = new CullFaceState(CullFaceMode.Back, false);// CullFaceMode is useless here.
                var blend = new BlendState(BlendingSourceFactor.One, BlendingDestinationFactor.One);
                this.stateList = new GLStateList(stencilTest, depthClamp, cullFace, blend);
            }
        }

        private readonly DepthMaskState depthMask = new DepthMaskState(writable: false);
        private readonly GLStateList stateList;
        private readonly ClearStencilNode clearStencilNode;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public override void Act(ActionParams param)
        {
            {
                var arg = new RenderEventArgs(this.Scene, param);
                RenderDepthBuffer(this.Scene.RootElement, arg);
            }
            this.depthMask.On();

            this.stateList.On();
            foreach (var light in this.Scene.Lights)
            {
                // clear stencil buffer.
                //GL.Instance.Clear(GL.GL_STENCIL_BUFFER_BIT); // this seems not working.
                this.clearStencilNode.RenderBeforeChildren(null); // this helps clear stencil buffer because `glClear(GL_STENCIL_BUFFER_BIT);` doesn't work on my laptop.

                {
                    GL.Instance.StencilFunc(GL.GL_ALWAYS, 0, 0xFF);
                    GL.Instance.StencilOpSeparate(GL.GL_BACK, GL.GL_KEEP, GL.GL_INCR_WRAP, GL.GL_KEEP);
                    GL.Instance.StencilOpSeparate(GL.GL_FRONT, GL.GL_KEEP, GL.GL_DECR_WRAP, GL.GL_KEEP);

                    var arg = new ShadowVolumeEventArgs(light);
                    Extrude(this.Scene.RootElement, arg);
                }
                {
                    // Draw only if the corresponding stencil value is zero
                    GL.Instance.StencilFunc(GL.GL_EQUAL, 0x0, 0xFF);
                    // prevent update to the stencil buffer
                    GL.Instance.StencilOp(GL.GL_KEEP, GL.GL_KEEP, GL.GL_KEEP);

                    var arg = new RenderEventArgs(this.Scene, param);
                    RenderUnderLight(this.Scene.RootElement, arg, light);
                }
            }
            this.stateList.Off();

            {
                var arg = new RenderEventArgs(this.Scene, param);
                RenderAmbientColor(this.Scene.RootElement, arg);
            }

            this.depthMask.Off();
        }

        private void RenderAmbientColor(SceneNodeBase sceneNodeBase, RenderEventArgs arg)
        {
            if (sceneNodeBase != null)
            {
                var node = sceneNodeBase as ISupportShadowVolume;
                TwoFlags flags = (node != null) ? node.EnableShadowVolume : TwoFlags.None;
                bool before = (node != null) && ((flags & TwoFlags.BeforeChildren) == TwoFlags.BeforeChildren);
                bool children = (node == null) || ((flags & TwoFlags.Children) == TwoFlags.Children);

                if (before)
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

        private void RenderUnderLight(SceneNodeBase sceneNodeBase, RenderEventArgs arg, LightBase light)
        {
            if (sceneNodeBase != null)
            {
                var node = sceneNodeBase as ISupportShadowVolume;
                TwoFlags flags = (node != null) ? node.EnableShadowVolume : TwoFlags.None;
                bool before = (node != null) && ((flags & TwoFlags.BeforeChildren) == TwoFlags.BeforeChildren);
                bool children = (node == null) || ((flags & TwoFlags.Children) == TwoFlags.Children);

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneNodeBase"></param>
        /// <param name="arg"></param>
        static void Extrude(SceneNodeBase sceneNodeBase, ShadowVolumeEventArgs arg)
        {
            if (sceneNodeBase != null)
            {
                var node = sceneNodeBase as ISupportShadowVolume;
                TwoFlags flags = (node != null) ? node.EnableShadowVolume : TwoFlags.None;
                bool before = (node != null) && ((flags & TwoFlags.BeforeChildren) == TwoFlags.BeforeChildren);
                bool children = (node == null) || ((flags & TwoFlags.Children) == TwoFlags.Children);

                if (before)
                {
                    node.ExtrudeShadow(arg);
                }

                if (children)
                {
                    foreach (var item in sceneNodeBase.Children)
                    {
                        Extrude(item, arg);
                    }
                }
            }
        }

        private void RenderDepthBuffer(SceneNodeBase sceneNodeBase, RenderEventArgs arg)
        {
            if (sceneNodeBase != null)
            {
                var node = sceneNodeBase as ISupportShadowVolume;
                TwoFlags flags = (node != null) ? node.EnableShadowVolume : TwoFlags.None;
                bool before = (node != null) && ((flags & TwoFlags.BeforeChildren) == TwoFlags.BeforeChildren);
                bool children = (node == null) || ((flags & TwoFlags.Children) == TwoFlags.Children);

                if (before)
                {
                    node.RenderToDepthBuffer(arg);
                }

                if (children)
                {
                    foreach (var item in sceneNodeBase.Children)
                    {
                        RenderDepthBuffer(item, arg);
                    }
                }
            }
        }

    }
}