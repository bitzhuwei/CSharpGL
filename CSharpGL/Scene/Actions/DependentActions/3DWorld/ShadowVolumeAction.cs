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
        }

        private readonly DepthTestState depthTest = new DepthTestState(enableCapacity: false);
        private readonly StencilTestState stencilTest = new StencilTestState(enableCapacity: true);
        private readonly CullFaceState cullFace = new CullFaceState(CullFaceMode.Back, false);// CullFaceMode is useless here.
        private readonly ColorMaskState colorMask = new ColorMaskState(false, false, false, false);
        private readonly DepthMaskState depthMask = new DepthMaskState(writable: false);
        private readonly DepthClampState depthClamp = new DepthClampState(enableCapacity: true);
        private readonly BlendState blend = new BlendState(BlendingSourceFactor.One, BlendingDestinationFactor.One);
        //private readonly GLStateList stateList;
        private readonly ClearStencilNode clearStencilNode;

        private static readonly GLDelegates.void_uint_uint_uint_uint glStencilOpSeparate;
        static ShadowVolumeAction()
        {
            glStencilOpSeparate = GL.Instance.GetDelegateFor("glStencilOpSeparate", GLDelegates.typeof_void_uint_uint_uint_uint) as GLDelegates.void_uint_uint_uint_uint;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public override void Act(ActionParams param)
        {
            this.depthClamp.On();// for infinite back cap of shadow volumes.

            // Render depth info into depth buffer and ambient color into color buffer.
            {
                var arg = new RenderEventArgs(this.Scene, param, this.Scene.Camera);
                RenderAmbientColor(this.Scene.RootElement, arg);
            }

            this.stencilTest.On(); // enable stencil test.
            foreach (var light in this.Scene.Lights)
            {
                // Clear stencil buffer.
                {
                    GL.Instance.Clear(GL.GL_STENCIL_BUFFER_BIT); // this seems not working.
                    // do the same thing.
                    this.depthTest.On(); // Disable depth test to make sure this node works for every stencil point.
                    this.depthMask.On(); // Disable writing to depth buffer.
                    this.clearStencilNode.RenderBeforeChildren(null); // this helps clear stencil buffer because `glClear(GL_STENCIL_BUFFER_BIT);` doesn't work on my laptop.
                    this.depthMask.Off();
                    this.depthTest.Off();
                }
                // Extrude shadow volume and save shadow info into stencil buffer.
                {
                    this.depthMask.On(); // Disable writing to depth buffer.
                    this.colorMask.On(); // Disable writing to color buffer.
                    this.cullFace.On();  // Disable culling face.
                    GL.Instance.StencilFunc(GL.GL_ALWAYS, 0, 0xFF); // always pass stencil test.
                    // If depth test fails for back face, increase value in stencil buffer.
                    glStencilOpSeparate(GL.GL_BACK, GL.GL_KEEP, GL.GL_INCR_WRAP, GL.GL_KEEP);
                    // If depth test fails for front face, decrease value in stencil buffer.
                    glStencilOpSeparate(GL.GL_FRONT, GL.GL_KEEP, GL.GL_DECR_WRAP, GL.GL_KEEP);

                    // Extrude shadow volume. And shadow info will be saved into stencil buffer automatically according to `glStencilOp...`.
                    var arg = new ShadowVolumeEventArgs(this.Scene.Camera, light);
                    Extrude(this.Scene.RootElement, arg);

                    this.cullFace.Off();
                    this.colorMask.Off();
                    this.depthMask.Off();
                }
                // 
                {
                    // Draw only if the corresponding stencil value is zero.
                    GL.Instance.StencilFunc(GL.GL_EQUAL, 0x0, 0xFF);
                    // prevent updating to the stencil buffer.
                    GL.Instance.StencilOp(GL.GL_KEEP, GL.GL_KEEP, GL.GL_KEEP);

                    this.blend.On(); // add illuminated color to ambient color.

                    // light the scene up.
                    var arg = new RenderEventArgs(this.Scene, param, this.Scene.Camera);
                    RenderUnderLight(this.Scene.RootElement, arg, light);

                    this.blend.Off();
                }
            }
            this.stencilTest.Off();

            this.depthClamp.Off();
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
                    if (node.EnableExtrude)
                    {
                        node.ExtrudeShadow(arg);
                    }
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