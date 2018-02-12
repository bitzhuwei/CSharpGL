using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace DepthPeeling.DualPeeling
{
    partial class PeelingNode : SceneNodeBase, IRenderable
    {
        private int width;
        private int height;
        private PeelingResource resources;
        private Query query;
        private bool bUseOQ = false;
        private QuadNode fullscreenQuad;
        private const int NUM_PASSES = 16;
        private DepthTestSwitch depthTest = new DepthTestSwitch(enableCapacity: false);
        private BlendSwitch blend = new BlendSwitch(BlendEquationMode.Add, BlendSrcFactor.SrcAlpha, BlendDestFactor.OneMinusSrcAlpha);
        private BlendSwitch blendMax = new BlendSwitch(BlendEquationMode.Max, BlendSrcFactor.SrcAlpha, BlendDestFactor.OneMinusSrcAlpha);

        private bool showDepthPeeling = true;
        /// <summary>
        /// 
        /// </summary>
        public bool ShowDepthPeeling { get { return this.showDepthPeeling; } set { this.showDepthPeeling = value; } }

        private static readonly GLDelegates.void_uint glBlendEquation;

        static PeelingNode()
        {
            glBlendEquation = GL.Instance.GetDelegateFor("glBlendEquation", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
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

        private const float MAX_DEPTH = 1.0f;
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
            this.resources.backBlenderFBO.Bind();
            GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            this.resources.backBlenderFBO.Unbind();
            targetTexture = this.resources.backBlenderTexture;

            if (this.ShowDepthPeeling)
            {
                // remember clear color.
                var clearColor = new float[4];
                GL.Instance.GetFloatv((uint)GetTarget.ColorClearValue, clearColor);

                this.depthTest.On();
                GL.Instance.Enable(GL.GL_BLEND);//this.blend.On();

                Framebuffer fbo = this.resources.peelingSingleFBO;
                fbo.Bind();

                {
                    // 1. Initialize Min-Max Depth Buffer
                    // Render targets 1 and 2 store the front and back colors
                    // Clear to 0.0 and use MAX blending to filter written color
                    // At most one front color and one back color can be written every pass
                    fbo.SetDrawBuffers(GL.GL_COLOR_ATTACHMENT0 + 1, GL.GL_COLOR_ATTACHMENT0 + 2);
                    GL.Instance.ClearColor(0, 0, 0, 0);
                    GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT);
                    // Render target 0 stores (-minDepth, maxDepth, alphaMultiplier)
                    fbo.SetDrawBuffer(GL.GL_COLOR_ATTACHMENT0);
                    GL.Instance.ClearColor(-MAX_DEPTH, -MAX_DEPTH, 0, 0);
                    GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT);
                    glBlendEquation(GL.GL_MAX); //this.blendMax.On();
                    this.DrawScene(arg, CubeNode.RenderMode.Init, null);
                }
                {
                    // 2. Dual Depth Peeling + Blending
                    // Since we cannot blend the back colors in the geometry passes,
                    // we use another render target to do the alpha blending
                    //glBindFramebuffer(GL_FRAMEBUFFER, backBlenderFBO);
                    fbo.SetDrawBuffer(GL.GL_COLOR_ATTACHMENT0 + 6);
                    GL.Instance.ClearColor(clearColor[0], clearColor[1], clearColor[2], 0);
                    GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT);

                    const uint g_numPasses = 4;
                    uint currId = 0;

                    for (uint pass = 1; bUseOQ || pass < g_numPasses; pass++)
                    {
                        currId = pass % 2;
                        uint prevId = 1 - currId;
                        uint bufId = currId * 3;

                        //glBindFramebuffer(GL_FRAMEBUFFER, g_dualPeelingFboId[currId]);
                        fbo.SetDrawBuffers(GL.GL_COLOR_ATTACHMENT0 + bufId + 1, GL.GL_COLOR_ATTACHMENT0 + bufId + 2);
                        GL.Instance.ClearColor(0, 0, 0, 0);
                        GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT);

                        fbo.SetDrawBuffer(GL.GL_COLOR_ATTACHMENT0 + bufId);
                        GL.Instance.ClearColor(-MAX_DEPTH, -MAX_DEPTH, 0, 0);
                        GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT);

                        // Render target 0: RG32F MAX blending
                        // Render target 1: RGBA MAX blending
                        // Render target 2: RGBA MAX blending
                        fbo.SetDrawBuffers(GL.GL_COLOR_ATTACHMENT0 + bufId + 0, GL.GL_COLOR_ATTACHMENT0 + bufId + 1, GL.GL_COLOR_ATTACHMENT0 + bufId + 2);
                        glBlendEquation(GL.GL_MAX);

                        // TODO: not finished yet.
                        //peelProgram.bind();
                        //peelProgram.bindTextureRECT("DepthBlenderTex", depthTextures[prevId], 0);
                        //peelProgram.bindTextureRECT("FrontBlenderTex", frontBlenderTextures[prevId], 1);
                        //peelProgram.setUniform("Alpha", (float*)&g_opacity, 1);
                        //DrawModel();
                        //peelProgram.unbind();

                        //CHECK_GL_ERRORS;

                        //// Full screen pass to alpha-blend the back color
                        //glDrawBuffer(g_drawBuffers[6]);

                        //glBlendEquation(GL_FUNC_ADD);
                        //glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);

                        //if (bUseOQ)
                        //{
                        //    glBeginQuery(GL_SAMPLES_PASSED, g_queryId);
                        //}

                        //blendProgram.bind();
                        //blendProgram.bindTextureRECT("TempTex", backTmpTextures[currId], 0);
                        //glCallList(g_quadDisplayList);
                        //blendProgram.unbind();

                        //CHECK_GL_ERRORS;

                        //if (bUseOQ)
                        //{
                        //    glEndQuery(GL_SAMPLES_PASSED);
                        //    GLuint sample_count;
                        //    glGetQueryObjectuiv(g_queryId, GL_QUERY_RESULT, &sample_count);
                        //    if (sample_count == 0)
                        //    {
                        //        break;
                        //    }
                        //}
                    }
                }

                fbo.Unbind();

                GL.Instance.Disable(GL.GL_BLEND);//this.blend.Off();
                this.depthTest.Off();

                {
                    // 3. Final Pass

                }
                // restore clear color.
                GL.Instance.ClearColor(clearColor[0], clearColor[1], clearColor[2], clearColor[3]);
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
