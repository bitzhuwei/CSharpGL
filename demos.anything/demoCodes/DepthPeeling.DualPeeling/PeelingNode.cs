﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CSharpGL;

namespace DepthPeeling.DualPeeling {
    partial class PeelingNode : SceneNodeBase, IRenderable {
        private int width;
        private int height;
        private PeelingResource resources;
        private Query query;
        private bool bUseOQ = false;
        private QuadNode fullscreenQuad;
        private const int maxPassCount = 16;
        private DepthTestSwitch depthTest = new DepthTestSwitch(enableCapacity: false);
        private BlendSwitch blend = new BlendSwitch(BlendEquationMode.Add, BlendSrcFactor.SrcAlpha, BlendDestFactor.OneMinusSrcAlpha);
        private BlendSwitch blendMax = new BlendSwitch(BlendEquationMode.Max, BlendSrcFactor.SrcAlpha, BlendDestFactor.OneMinusSrcAlpha);

        private bool showDepthPeeling = true;
        /// <summary>
        /// 
        /// </summary>
        public bool ShowDepthPeeling { get { return this.showDepthPeeling; } set { this.showDepthPeeling = value; } }

        //private static readonly GLDelegates.void_uint glBlendEquation;

        //static PeelingNode() {
        //    glBlendEquation = gl.glGetDelegateFor("glBlendEquation", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
        //}

        /// <summary>
        /// max step needed to render everything.
        /// </summary>
        private const int maxStep = 1 + ((maxPassCount - 1) * 2 - 1) * 2;

        private int renderStep = 1 + ((maxPassCount - 1) * 2 - 1) * 2;
        /// <summary>
        /// How many steps will be performed?
        /// </summary>
        public int RenderStep {
            get { return renderStep; }
            set { renderStep = value; }
        }

        private bool dump = true;
        public bool Dump {
            get { return dump; }
            set { dump = value; }
        }

        #region IRenderable 成员

        public ThreeFlags EnableRendering { get { return ThreeFlags.BeforeChildren; } set { } }

        private const float maxDepth = 1.0f;
        public unsafe void RenderBeforeChildren(RenderEventArgs arg) {
            var gl = GL.Current; Debug.Assert(gl != null);
            var viewport = stackalloc int[4]; gl.glGetIntegerv((uint)GetTarget.Viewport, viewport);

            if (this.width != viewport[2] || this.height != viewport[3]) {
                Resize(viewport[2], viewport[3]);

                this.width = viewport[2];
                this.height = viewport[3];
            }

            //int currentStep = 0, totalStep = this.RenderStep;
            //Texture targetTexture = null;
            //this.resources.backBlenderFBO.Bind();
            //GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            //this.resources.backBlenderFBO.Unbind();
            //targetTexture = this.resources.backBlenderTexture;

            if (this.ShowDepthPeeling) {
                // remember clear color.
                var clearColor = stackalloc float[4];
                gl.glGetFloatv((uint)GetTarget.ColorClearValue, clearColor);

                this.depthTest.On();
                gl.glEnable(GL.GL_BLEND);//this.blend.On();

                Framebuffer fbo = this.resources.peelingSingleFBO;
                fbo.Bind();

                bool dump = this.Dump;

                {
                    // 1. Initialize Min-Max Depth Buffer
                    // Render targets 1 and 2 store the front and back colors
                    // Clear to 0.0 and use MAX blending to filter written color
                    // At most one front color and one back color can be written every pass
                    fbo.SetDrawBuffers(GL.GL_COLOR_ATTACHMENT0 + 1, GL.GL_COLOR_ATTACHMENT0 + 2);
                    gl.glClearColor(0, 0, 0, 0);
                    gl.glClear(GL.GL_COLOR_BUFFER_BIT);
                    if (dump) {
                        var image = this.resources.frontBlenderTextures[0].GetImage(width, height);
                        var bmp = new Bitmap(width, height, width * image.PixelBytes,
                            System.Drawing.Imaging.PixelFormat.Format32bppArgb, image.Scan0);
                        bmp.Save(string.Format("0.init.0.frontBlenders[0].png"));
                    }
                    // Render target 0 stores (-minDepth, maxDepth, alphaMultiplier)
                    fbo.SetDrawBuffer(GL.GL_COLOR_ATTACHMENT0);
                    gl.glClearColor(-maxDepth, -maxDepth, 0, 0);
                    gl.glClear(GL.GL_COLOR_BUFFER_BIT);
                    if (dump) {
                        var image = this.resources.depthTextures[0].GetImage(width, height);
                        var bmp = new Bitmap(width, height, width * image.PixelBytes,
                            System.Drawing.Imaging.PixelFormat.Format32bppArgb, image.Scan0);
                        bmp.Save(string.Format("0.init.1.depths[0].png"));
                    }
                    gl.glBlendEquation(GL.GL_MAX); //this.blendMax.On();
                    this.DrawScene(arg, CubeNode.RenderMode.Init);
                    if (dump) {
                        var image = this.resources.depthTextures[0].GetImage(width, height);
                        var bmp = new Bitmap(width, height, width * image.PixelBytes,
                            System.Drawing.Imaging.PixelFormat.Format32bppArgb, image.Scan0);
                        bmp.Save(string.Format("0.init.2.depths[0].png"));
                    }
                }
                uint currId = 0;
                {
                    // 2. Dual Depth Peeling + Blending
                    // Since we cannot blend the back colors in the geometry passes,
                    // we use another render target to do the alpha blending
                    //glBindFramebuffer(GL_FRAMEBUFFER, backBlenderFBO);
                    fbo.SetDrawBuffer(GL.GL_COLOR_ATTACHMENT0 + 6);
                    gl.glClearColor(clearColor[0], clearColor[1], clearColor[2], 0);
                    gl.glClear(GL.GL_COLOR_BUFFER_BIT);
                    if (dump) {
                        var image = this.resources.backBlenderTexture.GetImage(width, height);
                        var bmp = new Bitmap(width, height, width * image.PixelBytes,
                            System.Drawing.Imaging.PixelFormat.Format32bppArgb, image.Scan0);
                        bmp.Save(string.Format("0.init.2.backBlender.png"));
                    }

                    const uint passCount = 4;

                    for (uint pass = 1; bUseOQ || pass < passCount; pass++) {
                        currId = pass % 2;
                        uint prevId = 1 - currId;
                        uint bufId = currId * 3;

                        //glBindFramebuffer(GL_FRAMEBUFFER, g_dualPeelingFboId[currId]);
                        fbo.SetDrawBuffers(GL.GL_COLOR_ATTACHMENT0 + bufId + 1, GL.GL_COLOR_ATTACHMENT0 + bufId + 2);
                        gl.glClearColor(0, 0, 0, 0);
                        gl.glClear(GL.GL_COLOR_BUFFER_BIT);

                        fbo.SetDrawBuffer(GL.GL_COLOR_ATTACHMENT0 + bufId);
                        gl.glClearColor(-maxDepth, -maxDepth, 0, 0);
                        gl.glClear(GL.GL_COLOR_BUFFER_BIT);

                        // Render target 0: RG32F MAX blending
                        // Render target 1: RGBA MAX blending
                        // Render target 2: RGBA MAX blending
                        fbo.SetDrawBuffers(GL.GL_COLOR_ATTACHMENT0 + bufId + 0, GL.GL_COLOR_ATTACHMENT0 + bufId + 1, GL.GL_COLOR_ATTACHMENT0 + bufId + 2);
                        gl.glBlendEquation(GL.GL_MAX);

                        this.DrawScene(arg, CubeNode.RenderMode.Init, this.resources.depthTextures[prevId], this.resources.frontBlenderTextures[prevId]);
                        if (dump) {
                            var image = this.resources.depthTextures[bufId / 3].GetImage(width, height);
                            var bmp = new Bitmap(width, height, width * image.PixelBytes,
                            System.Drawing.Imaging.PixelFormat.Format32bppArgb, image.Scan0);
                            bmp.Save(string.Format("1.[{0}].1.depths[{1}].png", pass, bufId / 3));
                        }
                        if (dump) {
                            var image = this.resources.frontBlenderTextures[bufId / 3].GetImage(width, height);
                            var bmp = new Bitmap(width, height, width * image.PixelBytes,
                            System.Drawing.Imaging.PixelFormat.Format32bppArgb, image.Scan0);
                            bmp.Save(string.Format("1.[{0}].2.frontBlenders[{1}].png", pass, bufId / 3));
                        }
                        if (dump) {
                            var image = this.resources.backTmpTextures[bufId / 3].GetImage(width, height);
                            var bmp = new Bitmap(width, height, width * image.PixelBytes,
                            System.Drawing.Imaging.PixelFormat.Format32bppArgb, image.Scan0);
                            bmp.Save(string.Format("1.[{0}].3.backTmps[{1}].png", pass, bufId / 3));
                        }

                        // TODO: not finished yet.
                        // Full screen pass to alpha-blend the back color
                        fbo.SetDrawBuffer(GL.GL_COLOR_ATTACHMENT0 + 6);

                        gl.glBlendEquation(GL.GL_FUNC_ADD);
                        gl.glBlendFunc(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA);

                        if (bUseOQ) {
                            this.query.BeginQuery(QueryTarget.SamplesPassed);
                        }

                        this.DrawFullScreenQuad(arg, QuadNode.RenderMode.Blend, this.resources.backTmpTextures[currId]);
                        if (dump) {
                            var image = this.resources.backBlenderTexture.GetImage(width, height);
                            var bmp = new Bitmap(width, height, width * image.PixelBytes,
                            System.Drawing.Imaging.PixelFormat.Format32bppArgb, image.Scan0);
                            bmp.Save(string.Format("1.[{0}].4.backBlender.png", pass));
                        }

                        //CHECK_GL_ERRORS;

                        if (bUseOQ) {
                            this.query.EndQuery(QueryTarget.SamplesPassed);
                            int sampleCount = this.query.SampleCount();
                            if (sampleCount == 0) { break; }
                        }
                    }
                }

                fbo.Unbind();

                gl.glDisable(GL.GL_BLEND);//this.blend.Off();
                this.depthTest.Off();

                {
                    // 3. Final Pass
                    //glDrawBuffer(GL_BACK);
                    this.DrawFullScreenQuad(arg, QuadNode.RenderMode.Final,
                        this.resources.depthTextures[currId],
                        this.resources.frontBlenderTextures[currId],
                        this.resources.backBlenderTexture);
                }

                this.Dump = false;

                // restore clear color.
                gl.glClearColor(clearColor[0], clearColor[1], clearColor[2], clearColor[3]);
            }
            else {
                this.DrawScene(arg, CubeNode.RenderMode.Init);
            }
        }

        private void Resize(int width, int height) {
            if (this.resources != null) { this.resources.Dispose(); }
            this.resources = new PeelingResource(width, height);
        }

        private void DrawScene(RenderEventArgs arg, CubeNode.RenderMode renderMode) {
            foreach (var item in this.Children) {
                var node = item as CubeNode;
                node.Mode = renderMode;

                node.RenderBeforeChildren(arg);
            }
        }

        private void DrawScene(RenderEventArgs arg, CubeNode.RenderMode renderMode, Texture depthTexture, Texture frontBlenderTexture) {
            foreach (var item in this.Children) {
                var node = item as CubeNode;
                node.Mode = renderMode;
                node.DepthTexture = depthTexture;
                node.FrontBlenderTexture = frontBlenderTexture;

                node.RenderBeforeChildren(arg);
            }
        }

        private void DrawFullScreenQuad(RenderEventArgs arg, QuadNode.RenderMode renderMode, Texture depthTex, Texture frontBlenderTex, Texture backBlenderTex) {
            this.fullscreenQuad.Mode = renderMode;
            this.fullscreenQuad.DepthTexture = depthTex;
            this.fullscreenQuad.FrontBlenderTexture = frontBlenderTex;
            this.fullscreenQuad.BackBlenderTexture = backBlenderTex;

            this.fullscreenQuad.RenderBeforeChildren(arg);
        }

        private void DrawFullScreenQuad(RenderEventArgs arg, QuadNode.RenderMode renderMode, Texture tempTexture) {
            this.fullscreenQuad.Mode = renderMode;
            this.fullscreenQuad.TempTexture = tempTexture;

            this.fullscreenQuad.RenderBeforeChildren(arg);
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }

        #endregion
    }
}
