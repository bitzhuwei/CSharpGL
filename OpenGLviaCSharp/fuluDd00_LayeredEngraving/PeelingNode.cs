using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;

namespace fuluDd00_LayeredEngraving
{
    partial class PeelingNode : SceneNodeBase, IRenderable
    {
        private PeelingResource resources4Display;
        private PeelingResource resources4VolumeData;
        private Query query;
        private bool bUseOQ = true;
        private QuadNode fullscreenQuad;
        private const int NUM_PASSES = 16;
        private DepthTestSwitch depthTest = new DepthTestSwitch(enableCapacity: false);
        private BlendSwitch blend = new BlendSwitch(BlendEquationMode.Add, BlendSrcFactor.DstAlpha, BlendDestFactor.One, BlendSrcFactor.Zero, BlendDestFactor.OneMinusSrcAlpha);
        private ivec3 volumeSize;

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

        public PeelingNode(vec3 size, ivec3 volumeSize, params SceneNodeBase[] children)
        {
            this.ModelSize = size;
            this.volumeSize = volumeSize;

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

        private bool firstRun4Display = true;

        public bool FirstRun4Display
        {
            get { return firstRun4Display; }
            set { firstRun4Display = value; }
        }

        private bool firstRun4VolumeData = true;

        public bool FirstRun4VolumeData
        {
            get { return firstRun4VolumeData; }
            set { firstRun4VolumeData = value; }
        }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            Render4Display(arg);

            if (this.firstRun4VolumeData)
            {
                Render4VolumeData(arg);
                this.firstRun4VolumeData = false;
            }
        }

        private void Render4VolumeData(RenderEventArgs arg)
        {
            var viewport = new int[4]; GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);
            ivec3 volumeSize = this.volumeSize;
            int width = volumeSize.x, height = volumeSize.y, depth = volumeSize.z;
            PeelingResource resouce = this.resources4VolumeData;

            {
                var position = new vec3(0, 0, 0);
                var center = new vec3(0, 0, -1);
                var up = new vec3(0, 1, 0);
                ICamera camera = new Camera(position, center, up, CameraType.Ortho, width, height);
                vec3 size = this.ModelSize;
                IOrthoViewCamera c = camera;
                c.Left = -size.x / 2.0; c.Right = size.x / 2.0;
                c.Bottom = -size.y / 2.0; c.Top = size.y / 2.0;
                c.Near = -size.z / 2.0; c.Far = size.z / 2.0;
                arg = new RenderEventArgs(arg.Param, camera);
            }

            if (resouce == null
                || resouce.width != width
                || resouce.height != height)
            {
                Resize4VolumeData(width, height);
                resouce = this.resources4VolumeData;
            }

            int currentStep = 0, totalStep = this.RenderStep;
            resouce.blenderFBO.Bind();
            GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            resouce.blenderFBO.Unbind();
            Texture targetTexture = resouce.blenderColorTexture;

            // remember clear color.
            var clearColor = new float[4];
            GL.Instance.GetFloatv((uint)GetTarget.ColorClearValue, clearColor);

            GL.Instance.Viewport(0, 0, width, height);

            // init.
            if (currentStep <= totalStep)
            {
                currentStep++;
                resouce.blenderFBO.Bind();
                GL.Instance.ClearColor(0, 0, 0, 1);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
                this.DrawScene(arg, CubeNode.RenderMode.Init, null);
                resouce.blenderFBO.Unbind();
                targetTexture = resouce.blenderColorTexture;

                if (firstRun4VolumeData) { targetTexture.GetImage(width, height).Save("v0.init.png"); }
            }

            int numLayers = (NUM_PASSES - 1) * 2;
            int finalId = 2;
            // for each pass
            for (int layer = 1; (bUseOQ || layer < numLayers) && (currentStep <= totalStep); layer++)
            {
                finalId = layer * 2 + 1;
                int currId = layer % 2;
                int prevId = 1 - currId;
                bool sampled = true;
                // peel.
                if (currentStep <= totalStep)
                {
                    currentStep++;
                    resouce.FBOs[currId].Bind();
                    GL.Instance.ClearColor(0, 0, 0, 0);
                    GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
                    if (bUseOQ) { this.query.BeginQuery(QueryTarget.SamplesPassed); }
                    this.DrawScene(arg, CubeNode.RenderMode.Peel, resouce.depthTextures[prevId]);
                    if (bUseOQ) { this.query.EndQuery(QueryTarget.SamplesPassed); }
                    resouce.FBOs[currId].Unbind();
                    targetTexture = resouce.colorTextures[currId];

                    if (bUseOQ)
                    {
                        int sampleCount = this.query.SampleCount();
                        sampled = (sampleCount > 0);
                    }

                    if (firstRun4VolumeData && sampled)
                    {
                        targetTexture.GetImage(width, height).Save(string.Format(
                            "v{0}.peel.png", layer * 2 - 1));
                    }
                }


                // blend.
                if (currentStep <= totalStep)
                {
                    currentStep++;
                    resouce.blenderFBO.Bind();
                    this.depthTest.On();
                    this.blend.On();
                    this.DrawFullScreenQuad(arg, QuadNode.RenderMode.Blend, resouce.colorTextures[currId], false);
                    this.blend.Off();
                    this.depthTest.Off();
                    resouce.blenderFBO.Unbind();
                    targetTexture = resouce.blenderColorTexture;
                    if (firstRun4VolumeData && sampled)
                    {
                        targetTexture.GetImage(width, height).Save(string.Format(
                            "v{0}.blend.png", layer * 2));
                    }
                }

                if (!sampled) { break; }
            }

            // restore clear color.
            GL.Instance.ClearColor(clearColor[0], clearColor[1], clearColor[2], clearColor[3]);
            GL.Instance.Viewport(viewport[0], viewport[1], viewport[2], viewport[3]);
        }

        private void Render4Display(RenderEventArgs arg)
        {
            var viewport = new int[4]; GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);
            int width = viewport[2], height = viewport[3];
            PeelingResource resouce = this.resources4Display;

            if (resouce == null
               || resouce.width != width
               || resouce.height != height)
            {
                Resize4Display(viewport[2], viewport[3]);
                resouce = this.resources4Display;
            }

            int currentStep = 0, totalStep = this.RenderStep;
            resouce.blenderFBO.Bind();
            GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            resouce.blenderFBO.Unbind();
            Texture targetTexture = resouce.blenderColorTexture;

            if (this.ShowDepthPeeling)
            {
                // remember clear color.
                var clearColor = new float[4];
                GL.Instance.GetFloatv((uint)GetTarget.ColorClearValue, clearColor);

                // init.
                if (currentStep <= totalStep)
                {
                    currentStep++;
                    resouce.blenderFBO.Bind();
                    GL.Instance.ClearColor(0, 0, 0, 1);
                    GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
                    this.DrawScene(arg, CubeNode.RenderMode.Init, null);
                    resouce.blenderFBO.Unbind();
                    targetTexture = resouce.blenderColorTexture;

                    if (firstRun4Display) { targetTexture.GetImage(width, height).Save("0.init.png"); }
                }

                int numLayers = (NUM_PASSES - 1) * 2;
                int finalId = 2;
                // for each pass
                for (int layer = 1; (bUseOQ || layer < numLayers) && (currentStep <= totalStep); layer++)
                {
                    finalId = layer * 2 + 1;
                    int currId = layer % 2;
                    int prevId = 1 - currId;
                    bool sampled = true;
                    // peel.
                    if (currentStep <= totalStep)
                    {
                        currentStep++;
                        resouce.FBOs[currId].Bind();
                        GL.Instance.ClearColor(0, 0, 0, 0);
                        GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
                        if (bUseOQ) { this.query.BeginQuery(QueryTarget.SamplesPassed); }
                        this.DrawScene(arg, CubeNode.RenderMode.Peel, resouce.depthTextures[prevId]);
                        if (bUseOQ) { this.query.EndQuery(QueryTarget.SamplesPassed); }
                        resouce.FBOs[currId].Unbind();
                        targetTexture = resouce.colorTextures[currId];

                        if (bUseOQ)
                        {
                            int sampleCount = this.query.SampleCount();
                            sampled = (sampleCount > 0);
                        }

                        if (firstRun4Display && sampled)
                        {
                            targetTexture.GetImage(width, height).Save(string.Format(
                                "{0}.peel.png", layer * 2 - 1));
                        }
                    }


                    // blend.
                    if (currentStep <= totalStep)
                    {
                        currentStep++;
                        resouce.blenderFBO.Bind();
                        this.depthTest.On();
                        this.blend.On();
                        this.DrawFullScreenQuad(arg, QuadNode.RenderMode.Blend, resouce.colorTextures[currId], false);
                        this.blend.Off();
                        this.depthTest.Off();
                        resouce.blenderFBO.Unbind();
                        targetTexture = resouce.blenderColorTexture;
                        if (firstRun4Display && sampled)
                        {
                            targetTexture.GetImage(width, height).Save(string.Format(
                                "{0}.blend.png", layer * 2));
                        }
                    }

                    if (!sampled) { break; }
                }

                // restore clear color.
                GL.Instance.ClearColor(clearColor[0], clearColor[1], clearColor[2], clearColor[3]);
                // final.
                this.DrawFullScreenQuad(arg, QuadNode.RenderMode.Final, targetTexture, this.renderStep >= maxStep);
                if (this.firstRun4Display)
                {
                    var final = new Bitmap(width, height);
                    var data = final.LockBits(new Rectangle(0, 0, width, height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    //GL.Instance.GetTexImage((uint)texture.Target, 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, data.Scan0);
                    GL.Instance.ReadPixels(0, 0, width, height, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, data.Scan0);
                    final.UnlockBits(data);
                    final.RotateFlip(RotateFlipType.Rotate180FlipX);
                    final.Save(string.Format("{0}.final.png", finalId));
                }
                this.firstRun4Display = false;
            }
            else
            {
                this.DrawScene(arg, CubeNode.RenderMode.Init, null);
            }
        }

        private void Resize4Display(int width, int height)
        {
            if (this.resources4Display != null) { this.resources4Display.Dispose(); }
            this.resources4Display = new PeelingResource(width, height);
        }

        private void Resize4VolumeData(int width, int height)
        {
            if (this.resources4VolumeData != null) { this.resources4VolumeData.Dispose(); }
            this.resources4VolumeData = new PeelingResource(width, height);
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
