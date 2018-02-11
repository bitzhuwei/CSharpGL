using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace DepthPeeling.FrontToBackPeeling
{
    partial class PeelingNode : SceneNodeBase, IRenderable
    {
        private int width;
        private int height;
        private PeelingResource resources;
        private Query query;
        private bool bUseOQ = true;
        private QuadNode fullscreenQuad;
        private const int NUM_PASSES = 16;
        private DepthTestSwitch depthTest = new DepthTestSwitch(enableCapacity: false);
        private BlendSwitch blend = new BlendSwitch(BlendEquationMode.Add, BlendSrcFactor.DstAlpha, BlendDestFactor.One, BlendSrcFactor.Zero, BlendDestFactor.OneMinusSrcAlpha);

        private bool showDepthPeeling = true;
        /// <summary>
        /// 
        /// </summary>
        public bool ShowDepthPeeling { get { return this.showDepthPeeling; } set { this.showDepthPeeling = value; } }

        private static readonly GLDelegates.void_uint glBlendEquation;
        private static readonly GLDelegates.void_uint_uint_uint_uint glBlendFuncSeparate;

        static PeelingNode()
        {
            glBlendEquation = GL.Instance.GetDelegateFor("glBlendEquation", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
            glBlendFuncSeparate = GL.Instance.GetDelegateFor("glBlendFuncSeparate", GLDelegates.typeof_void_uint_uint_uint_uint) as GLDelegates.void_uint_uint_uint_uint;
        }

        public PeelingNode(params SceneNodeBase[] children)
        {
            this.query = new Query();
            this.Children.AddRange(children);
            {
                var quad = QuadNode.Create();
                this.fullscreenQuad = quad;
            }
        }

        /// <summary>
        /// max step needed to render everything.
        /// </summary>
        private const int maxStep = 1 + ((NUM_PASSES - 1) * 2 - 1) * 2;

        private int renderStep = 1 + ((NUM_PASSES - 1) * 2 - 1) * 2;
        /// <summary>
        /// How many steps will be performed?
        /// </summary>
        public int RenderStep
        {
            get { return renderStep; }
            set { renderStep = value; }
        }

        #region IRenderable 成员

        public ThreeFlags EnableRendering { get { return ThreeFlags.BeforeChildren; } set { } }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            var viewport = new int[4]; GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);

            if (this.width != viewport[2] || this.height != viewport[3])
            {
                Resize(viewport[2], viewport[3]);

                this.width = viewport[2];
                this.height = viewport[3];
            }

            int currentStep = 0, totalStep = this.RenderStep;
            Texture targetTexture = null;
            this.resources.blenderFBO.Bind();
            GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            this.resources.blenderFBO.Unbind();
            targetTexture = this.resources.blenderColorTexture;

            if (this.ShowDepthPeeling)
            {
                // remember clear color.
                var clearColor = new float[4];
                GL.Instance.GetFloatv((uint)GetTarget.ColorClearValue, clearColor);

                // init.
                if (currentStep <= totalStep)
                {
                    currentStep++;
                    this.resources.blenderFBO.Bind();
                    GL.Instance.ClearColor(0, 0, 0, 1);
                    GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
                    this.DrawScene(arg, CubeNode.RenderMode.Init, null);
                    this.resources.blenderFBO.Unbind();
                    targetTexture = this.resources.blenderColorTexture;
                }

                int numLayers = (NUM_PASSES - 1) * 2;
                // for each pass
                for (int layer = 1; bUseOQ || layer < numLayers; layer++)
                {
                    int currId = layer % 2;
                    int prevId = 1 - currId;
                    // peel.
                    if (currentStep <= totalStep)
                    {
                        currentStep++;
                        this.resources.FBOs[currId].Bind();
                        GL.Instance.ClearColor(0, 0, 0, 0);
                        GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
                        if (bUseOQ) { this.query.BeginQuery(QueryTarget.SamplesPassed); }
                        this.DrawScene(arg, CubeNode.RenderMode.Peel, this.resources.depthTextures[prevId]);
                        if (bUseOQ) { this.query.EndQuery(QueryTarget.SamplesPassed); }
                        this.resources.FBOs[currId].Unbind();
                        targetTexture = this.resources.colorTextures[currId];
                    }
                    // blend.
                    if (currentStep <= totalStep)
                    {
                        currentStep++;
                        this.resources.blenderFBO.Bind();
                        this.depthTest.On();
                        this.blend.On();
                        this.DrawFullScreenQuad(arg, QuadNode.RenderMode.Blend, this.resources.colorTextures[currId], false);
                        this.blend.Off();
                        this.depthTest.Off();
                        this.resources.blenderFBO.Unbind();
                        targetTexture = this.resources.blenderColorTexture;
                    }

                    if (bUseOQ)
                    {
                        int sampleCount = this.query.SampleCount();
                        if (sampleCount == 0) { break; }
                    }
                }

                // restore clear color.
                GL.Instance.ClearColor(clearColor[0], clearColor[1], clearColor[2], clearColor[3]);
                // final.
                this.DrawFullScreenQuad(arg, QuadNode.RenderMode.Final, targetTexture, this.renderStep >= maxStep);
            }
            else
            {
                this.DrawScene(arg, CubeNode.RenderMode.Init, null);
            }
        }

        private void Resize(int width, int height)
        {
            if (this.resources != null) { this.resources.Dispose(); }
            this.resources = new PeelingResource(width, height);
        }

        private void DrawScene(RenderEventArgs arg, CubeNode.RenderMode renderMode, Texture texture)
        {
            foreach (var item in this.Children)
            {
                var node = item as CubeNode;
                node.Mode = renderMode;
                if (texture != null)
                {
                    node.DepthTexture = texture;
                }
                node.RenderBeforeChildren(arg);
            }
        }

        private void DrawFullScreenQuad(RenderEventArgs arg, QuadNode.RenderMode renderMode, Texture tempTexture, bool useBackground)
        {
            if (tempTexture == null) { throw new Exception(); }

            this.fullscreenQuad.TempTexture = tempTexture;
            this.fullscreenQuad.Mode = renderMode;
            this.fullscreenQuad.UseBackground = useBackground;

            this.fullscreenQuad.RenderBeforeChildren(arg);
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }
}
