using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;
using System.Diagnostics;

namespace DepthPeeling.FrontToBackPeeling {
    partial class PeelingNode : SceneNodeBase, IRenderable {
        private int width;
        private int height;
        private PeelingResource resources;
        private Query query;
        private bool bUseOQ = true;
        private QuadNode fullscreenQuad;
        private const int maxPassCount = 16;
        private DepthTestSwitch depthTest = new DepthTestSwitch(enableCapacity: false);
        private BlendSwitch blend = new BlendSwitch(BlendEquationMode.Add, BlendSrcFactor.DstAlpha, BlendDestFactor.One, BlendSrcFactor.Zero, BlendDestFactor.OneMinusSrcAlpha);

        private bool showDepthPeeling = true;
        /// <summary>
        /// 
        /// </summary>
        public bool ShowDepthPeeling { get { return this.showDepthPeeling; } set { this.showDepthPeeling = value; } }

        //private static readonly GLDelegates.void_uint glBlendEquation;
        //private static readonly GLDelegates.void_uint_uint_uint_uint glBlendFuncSeparate;

        //static PeelingNode() {
        //    glBlendEquation = gl.glGetDelegateFor("glBlendEquation", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
        //    glBlendFuncSeparate = gl.glGetDelegateFor("glBlendFuncSeparate", GLDelegates.typeof_void_uint_uint_uint_uint) as GLDelegates.void_uint_uint_uint_uint;
        //}

        public PeelingNode(params SceneNodeBase[] children) {
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
        private const int maxStep = 1 + ((maxPassCount - 1) * 2 - 1) * 2;

        private int renderStep = 1 + ((maxPassCount - 1) * 2 - 1) * 2;
        /// <summary>
        /// How many steps will be performed?
        /// </summary>
        public int RenderStep {
            get { return renderStep; }
            set { renderStep = value; }
        }

        #region IRenderable 成员

        public ThreeFlags EnableRendering { get { return ThreeFlags.BeforeChildren; } set { } }

        private bool firstRun = true;

        public bool FirstRun {
            get { return firstRun; }
            set { firstRun = value; }
        }

        public unsafe void RenderBeforeChildren(RenderEventArgs arg) {
            var gl = GL.Current; Debug.Assert(gl != null);

            var viewport = stackalloc int[4]; gl.glGetIntegerv((uint)GetTarget.Viewport, viewport);

            if (this.width != viewport[2] || this.height != viewport[3]) {
                Resize(viewport[2], viewport[3]);

                this.width = viewport[2];
                this.height = viewport[3];
            }

            int currentStep = 0, totalStep = this.RenderStep;
            this.resources.blenderFBO.Bind();
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            this.resources.blenderFBO.Unbind();
            Texture targetTexture = this.resources.blenderColorTexture;

            if (this.ShowDepthPeeling) {
                // remember clear color.
                var clearColor = stackalloc float[4];
                gl.glGetFloatv((uint)GetTarget.ColorClearValue, clearColor);

                // init.
                if (currentStep <= totalStep) {
                    currentStep++;
                    this.resources.blenderFBO.Bind();
                    gl.glClearColor(0, 0, 0, 1);
                    gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
                    this.DrawScene(arg, CubeNode.RenderMode.Init, null);
                    this.resources.blenderFBO.Unbind();
                    targetTexture = this.resources.blenderColorTexture;

                    if (firstRun) {
                        var winGLBitmap = targetTexture.GetImage(this.width, this.height);
                        var bmp = new Bitmap(this.width, this.height, this.width * winGLBitmap.PixelBytes,
                            System.Drawing.Imaging.PixelFormat.Format32bppArgb, winGLBitmap.Scan0);
                        bmp.Save("0.init.png");
                    }
                }

                int numLayers = (maxPassCount - 1) * 2;
                int finalId = 2;
                // for each pass
                for (int layer = 1; (bUseOQ || layer < numLayers) && (currentStep <= totalStep); layer++) {
                    finalId = layer * 2 + 1;
                    int currId = layer % 2;
                    int prevId = 1 - currId;
                    bool sampled = true;
                    // peel.
                    if (currentStep <= totalStep) {
                        currentStep++;
                        this.resources.FBOs[currId].Bind();
                        gl.glClearColor(0, 0, 0, 0);
                        gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
                        if (bUseOQ) { this.query.BeginQuery(QueryTarget.SamplesPassed); }
                        this.DrawScene(arg, CubeNode.RenderMode.Peel, this.resources.depthTextures[prevId]);
                        if (bUseOQ) { this.query.EndQuery(QueryTarget.SamplesPassed); }
                        this.resources.FBOs[currId].Unbind();
                        targetTexture = this.resources.colorTextures[currId];

                        if (bUseOQ) {
                            int sampleCount = this.query.SampleCount();
                            sampled = (sampleCount > 0);
                        }

                        if (firstRun && sampled) {
                            var winGLBitmap = targetTexture.GetImage(this.width, this.height);
                            var bmp = new Bitmap(this.width, this.height, this.width * winGLBitmap.PixelBytes,
                            System.Drawing.Imaging.PixelFormat.Format32bppArgb, winGLBitmap.Scan0);
                            bmp.Save(string.Format(
                                "{0}.peel.png", layer * 2 - 1));
                        }
                    }


                    // blend.
                    if (currentStep <= totalStep) {
                        currentStep++;
                        this.resources.blenderFBO.Bind();
                        this.depthTest.On();
                        this.blend.On();
                        this.DrawFullScreenQuad(arg, QuadNode.RenderMode.Blend, this.resources.colorTextures[currId], false);
                        this.blend.Off();
                        this.depthTest.Off();
                        this.resources.blenderFBO.Unbind();
                        targetTexture = this.resources.blenderColorTexture;
                        if (firstRun && sampled) {
                            var winGLBitmap = targetTexture.GetImage(this.width, this.height);
                            var bmp = new Bitmap(this.width, this.height, this.width * winGLBitmap.PixelBytes,
                                System.Drawing.Imaging.PixelFormat.Format32bppArgb, winGLBitmap.Scan0);
                            bmp.Save(string.Format(
                                "{0}.blend.png", layer * 2));
                        }
                    }

                    if (!sampled) { break; }
                }

                // restore clear color.
                gl.glClearColor(clearColor[0], clearColor[1], clearColor[2], clearColor[3]);
                // final.
                this.DrawFullScreenQuad(arg, QuadNode.RenderMode.Final, targetTexture, this.renderStep >= maxStep);
                if (this.firstRun) {
                    var final = new Bitmap(width, height);
                    var data = final.LockBits(new Rectangle(0, 0, width, height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    //GL.Instance.GetTexImage((uint)texture.Target, 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, data.Scan0);
                    gl.glReadPixels(0, 0, width, height, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, data.Scan0);
                    final.UnlockBits(data);
                    final.RotateFlip(RotateFlipType.Rotate180FlipX);
                    final.Save(string.Format("{0}.final.png", finalId));
                }
                this.firstRun = false;
            }
            else {
                this.DrawScene(arg, CubeNode.RenderMode.Init, null);
            }
        }

        private void Resize(int width, int height) {
            if (this.resources != null) { this.resources.Dispose(); }
            this.resources = new PeelingResource(width, height);
        }

        private void DrawScene(RenderEventArgs arg, CubeNode.RenderMode renderMode, Texture texture) {
            foreach (var item in this.Children) {
                var node = item as CubeNode;
                node.Mode = renderMode;
                if (texture != null) {
                    node.DepthTexture = texture;
                }
                node.RenderBeforeChildren(arg);
            }
        }

        private void DrawFullScreenQuad(RenderEventArgs arg, QuadNode.RenderMode renderMode, Texture tempTexture, bool useBackground) {
            if (tempTexture == null) { throw new Exception(); }

            this.fullscreenQuad.TempTexture = tempTexture;
            this.fullscreenQuad.Mode = renderMode;
            this.fullscreenQuad.UseBackground = useBackground;

            this.fullscreenQuad.RenderBeforeChildren(arg);
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }

        #endregion
    }
}
