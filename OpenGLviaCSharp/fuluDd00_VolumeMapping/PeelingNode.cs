using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;

namespace fuluDd00_VolumeMapping
{
    partial class PeelingNode : SceneNodeBase, IRenderable, IVolumeData
    {
        private int width;
        private int height;
        private PeelingResource resources;
        private Query query;
        private bool bUseOQ = true;
        private const int NUM_PASSES = 16;
        private DepthTestSwitch depthTest = new DepthTestSwitch(enableCapacity: false);

        public PeelingNode(params SceneNodeBase[] children)
        {
            this.query = new Query();
            this.Children.AddRange(children);
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

        private bool firstRun = true;

        public bool FirstRun
        {
            get { return firstRun; }
            set { firstRun = value; }
        }

        const int vWidth = 64;
        const int vHeight = 64;
        const int vDepth = 64;
        private byte[] volumeData = new byte[vWidth * vHeight * vDepth];

        public byte[] VolumeData
        {
            get { return volumeData; }
        }

        public int Width { get { return vWidth; } }
        public int Height { get { return vHeight; } }
        public int Depth { get { return vDepth; } }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            if (!this.firstRun) { return; }

            var viewport = new int[4]; GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);

            if (this.width != viewport[2] || this.height != viewport[3])
            {
                Resize(viewport[2], viewport[3]);

                this.width = viewport[2];
                this.height = viewport[3];
            }

            int currentStep = 0, totalStep = this.RenderStep;
            this.resources.blenderFBO.Bind();
            GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            this.resources.blenderFBO.Unbind();
            Texture targetTexture = this.resources.blenderColorTexture;

            var bitmapList = new List<Bitmap>();
            // remember clear color.
            var clearColor = new float[4];
            GL.Instance.GetFloatv((uint)GetTarget.ColorClearValue, clearColor);

            // init.
            if (currentStep <= totalStep)
            {
                currentStep++;
                this.resources.blenderFBO.Bind();
                GL.Instance.ClearColor(0, 0, 0, 0);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
                this.DrawScene(arg, CubeNode.RenderMode.Init, null);
                this.resources.blenderFBO.Unbind();
                targetTexture = this.resources.blenderColorTexture;

                if (firstRun)
                {
                    var bitmap = targetTexture.GetImage(this.width, this.height);
                    bitmap.Save("0.init.png");
                    var image = (Bitmap)bitmap.GetThumbnailImage(vWidth, vHeight, null, IntPtr.Zero);
                    bitmapList.Add(image);
                    bitmap.Dispose();
                }
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
                    this.resources.FBOs[currId].Bind();
                    GL.Instance.ClearColor(0, 0, 0, 0);
                    GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
                    if (bUseOQ) { this.query.BeginQuery(QueryTarget.SamplesPassed); }
                    this.DrawScene(arg, CubeNode.RenderMode.Peel, this.resources.depthTextures[prevId]);
                    if (bUseOQ) { this.query.EndQuery(QueryTarget.SamplesPassed); }
                    this.resources.FBOs[currId].Unbind();
                    targetTexture = this.resources.colorTextures[currId];

                    if (bUseOQ)
                    {
                        int sampleCount = this.query.SampleCount();
                        sampled = (sampleCount > 0);
                    }

                    if (firstRun && sampled)
                    {
                        var bitmap = targetTexture.GetImage(this.width, this.height);
                        bitmap.Save(string.Format("{0}.peel.png", layer * 2 - 1));
                        var image = (Bitmap)bitmap.GetThumbnailImage(vWidth, vHeight, null, IntPtr.Zero);
                        bitmapList.Add(image);
                        bitmap.Dispose();
                    }
                }

                //    // blend.
                //    if (currentStep <= totalStep)
                //    {
                //        currentStep++;
                //        this.resources.blenderFBO.Bind();
                //        this.depthTest.On();
                //        //this.DrawFullScreenQuad(arg, QuadNode.RenderMode.Blend, this.resources.colorTextures[currId], false);
                //        this.depthTest.Off();
                //        this.resources.blenderFBO.Unbind();
                //        targetTexture = this.resources.blenderColorTexture;
                //        if (firstRun && sampled)
                //        {
                //            targetTexture.GetImage(this.width, this.height).Save(string.Format(
                //                "{0}.blend.png", layer * 2));
                //        }
                //    }

                //    if (!sampled) { break; }
            }

            byte minA = byte.MaxValue;
            byte maxA = byte.MinValue;
            var volumeData = this.volumeData;
            foreach (var bitmap in bitmapList)
            {
                for (int w = 0; w < vWidth; w++)
                {
                    for (int h = 0; h < vHeight; h++)
                    {
                        Color color = bitmap.GetPixel(w, h);
                        if (color.A < minA) { minA = color.A; }
                        if (maxA < color.A) { maxA = color.A; }
                        int d = (int)((double)vDepth * (double)color.A / 256.0);
                        int index = w * vHeight * vDepth + h * vDepth + d;
                        if (color.A != 0)
                        {
                            volumeData[index] += Math.Max(color.R, Math.Max(color.G, color.B));
                        }
                    }
                }
                bitmap.Dispose();
            }
            // restore clear color.
            //GL.Instance.ClearColor(clearColor[0], clearColor[1], clearColor[2], clearColor[3]);
            // final.
            //this.DrawFullScreenQuad(arg, QuadNode.RenderMode.Final, targetTexture, this.renderStep >= maxStep);
            //if (this.firstRun)
            //{
            //    var final = new Bitmap(width, height);
            //    var data = final.LockBits(new Rectangle(0, 0, width, height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            //    //GL.Instance.GetTexImage((uint)texture.Target, 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, data.Scan0);
            //    GL.Instance.ReadPixels(0, 0, width, height, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, data.Scan0);
            //    final.UnlockBits(data);
            //    final.RotateFlip(RotateFlipType.Rotate180FlipX);
            //    final.Save(string.Format("{0}.final.png", finalId));
            //}
            this.firstRun = false;
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

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }
}
