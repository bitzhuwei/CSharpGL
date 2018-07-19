using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;
using System.Runtime.InteropServices;

namespace fuluDd00_LayeredEngrave
{
    partial class PeelingNode : SceneNodeBase, IRenderable, IVolumeData
    {
        private PeelingResource resources;
        private Query query;
        private bool bUseOQ = true;
        private const int NUM_PASSES = 16;
        private DepthTestSwitch depthTest = new DepthTestSwitch(enableCapacity: false);

        public PeelingNode(vec3 size, params SceneNodeBase[] children)
        {
            this.ModelSize = size;

            this.query = new Query();
            this.Children.AddRange(children);
            this.InitializePeelingResource(vWidth, vHeight);
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

        const int vWidth = 256;
        const int vHeight = 256;
        const int vDepth = 256;
        private byte[] volumeData;// = new byte[vWidth * vHeight * vDepth];

        public byte[] VolumeData
        {
            get { return volumeData; }
        }

        private Texture texVolumeData;

        public Texture TexVolumeData
        {
            get { return this.texVolumeData; }
        }

        public int Width { get { return vWidth; } }
        public int Height { get { return vHeight; } }
        public int Depth { get { return vDepth; } }

        public unsafe void RenderBeforeChildren(RenderEventArgs arg)
        {
            if (!this.firstRun) { return; }
            // This helps to prove GetPixel(..)'s Y axis is from up to down.
            //{
            //    var bmp = new Bitmap("test.bmp");
            //    Color c = bmp.GetPixel(0, 0);
            //    c = bmp.GetPixel(bmp.Width - 1, 0);
            //    c = bmp.GetPixel(bmp.Width - 1, bmp.Height - 1);
            //    c = bmp.GetPixel(0, bmp.Height - 1);
            //}
            var volumeData = new byte[vWidth * vHeight * vDepth]; ;

            EngraveX(arg, volumeData, vWidth, vHeight, vDepth);
            EngraveY(arg, volumeData, vWidth, vHeight, vDepth);
            EngraveZ(arg, volumeData, vWidth, vHeight, vDepth);

            this.volumeData = volumeData;

            this.firstRun = false;
        }

        unsafe private void EngraveX(RenderEventArgs arg, byte[] volumeData, int width, int height, int depth)
        {
            var viewport = new int[4]; GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);
            {
                var position = new vec3(0, 0, 0);
                var center = new vec3(-1, 0, 0);
                //var center = new vec3(-3, -4, -5);
                var up = new vec3(0, 1, 0);
                var camera = new Camera(position, center, up, CameraType.Ortho, vWidth, vHeight);
                {
                    vec3 size = this.ModelSize;
                    IOrthoViewCamera c = camera;
                    c.Left = -size.z / 2; c.Right = size.z / 2;
                    c.Bottom = -size.y / 2; c.Top = size.y / 2;
                    c.Near = -size.x / 2; c.Far = size.x / 2;
                    //c.Left = -size.x; c.Right = size.x;
                    //c.Bottom = -size.y; c.Top = size.y;
                    //c.Near = -size.z; c.Far = size.z;
                }
                arg = new RenderEventArgs(arg.Param, camera);
            }


            // remember clear color.
            var clearColor = new float[4];
            GL.Instance.GetFloatv((uint)GetTarget.ColorClearValue, clearColor);

            GL.Instance.Viewport(0, 0, vWidth, vHeight);

            List<Bitmap> bitmapList = LayeredEngraving(arg);

            // restore clear color.
            GL.Instance.ClearColor(clearColor[0], clearColor[1], clearColor[2], clearColor[3]);
            GL.Instance.Viewport(viewport[0], viewport[1], viewport[2], viewport[3]);


            Color background = Color.SkyBlue;
            foreach (var bitmap in bitmapList)
            {
                for (int d = 0; d < vWidth; d++)
                {
                    for (int h = 0; h < vHeight; h++)
                    {
                        Color color = bitmap.GetPixel(d, vHeight - h - 1);
                        int w = vDepth - (int)((double)vDepth * (double)color.A / 256.0) - 1;
                        int index = w * vHeight * vDepth + h * vDepth + d;
                        if (color.A != 0 &&
                            (color.R != background.R || color.G != background.G || color.B != background.B))
                        {
                            volumeData[index] += (byte)(color.R * 0.299 + color.G * 0.587 + color.B * 0.114);
                        }
                    }
                }
                bitmap.Dispose();
            }
        }

        unsafe private void EngraveY(RenderEventArgs arg, byte[] volumeData, int width, int height, int depth)
        {
            var viewport = new int[4]; GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);
            {
                var position = new vec3(0, 0, 0);
                var center = new vec3(0, -1, 0);
                //var center = new vec3(-3, -4, -5);
                var up = new vec3(0, 0, -1);
                var camera = new Camera(position, center, up, CameraType.Ortho, vWidth, vHeight);
                {
                    vec3 size = this.ModelSize;
                    IOrthoViewCamera c = camera;
                    c.Left = -size.z / 2; c.Right = size.z / 2;
                    c.Bottom = -size.x / 2; c.Top = size.x / 2;
                    c.Near = -size.y / 2; c.Far = size.y / 2;
                    //c.Left = -size.x; c.Right = size.x;
                    //c.Bottom = -size.y; c.Top = size.y;
                    //c.Near = -size.z; c.Far = size.z;
                }
                arg = new RenderEventArgs(arg.Param, camera);
            }


            // remember clear color.
            var clearColor = new float[4];
            GL.Instance.GetFloatv((uint)GetTarget.ColorClearValue, clearColor);

            GL.Instance.Viewport(0, 0, vWidth, vHeight);

            List<Bitmap> bitmapList = LayeredEngraving(arg);

            // restore clear color.
            GL.Instance.ClearColor(clearColor[0], clearColor[1], clearColor[2], clearColor[3]);
            GL.Instance.Viewport(viewport[0], viewport[1], viewport[2], viewport[3]);


            Color background = Color.SkyBlue;
            foreach (var bitmap in bitmapList)
            {
                for (int w = 0; w < vWidth; w++)
                {
                    for (int d = 0; d < vHeight; d++)
                    {
                        Color color = bitmap.GetPixel(w, vDepth - d - 1);
                        int h = vHeight - (int)((double)vDepth * (double)color.A / 256.0) - 1;
                        int index = w * vHeight * vDepth + h * vDepth + d;
                        if (color.A != 0 &&
                            (color.R != background.R || color.G != background.G || color.B != background.B))
                        {
                            volumeData[index] += (byte)(color.R * 0.299 + color.G * 0.587 + color.B * 0.114);
                        }
                    }
                }
                bitmap.Dispose();
            }
        }
        unsafe private void EngraveZ(RenderEventArgs arg, byte[] volumeData, int width, int height, int depth)
        {
            var viewport = new int[4]; GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);
            {
                var position = new vec3(0, 0, 0);
                var center = new vec3(0, 0, -1);
                //var center = new vec3(-3, -4, -5);
                var up = new vec3(0, 1, 0);
                var camera = new Camera(position, center, up, CameraType.Ortho, vWidth, vHeight);
                {
                    vec3 size = this.ModelSize;
                    IOrthoViewCamera c = camera;
                    c.Left = -size.x / 2; c.Right = size.x / 2;
                    c.Bottom = -size.y / 2; c.Top = size.y / 2;
                    c.Near = -size.z / 2; c.Far = size.z / 2;
                    //c.Left = -size.x; c.Right = size.x;
                    //c.Bottom = -size.y; c.Top = size.y;
                    //c.Near = -size.z; c.Far = size.z;
                }
                arg = new RenderEventArgs(arg.Param, camera);
            }


            // remember clear color.
            var clearColor = new float[4];
            GL.Instance.GetFloatv((uint)GetTarget.ColorClearValue, clearColor);

            GL.Instance.Viewport(0, 0, vWidth, vHeight);

            List<Bitmap> bitmapList = LayeredEngraving(arg);

            // restore clear color.
            GL.Instance.ClearColor(clearColor[0], clearColor[1], clearColor[2], clearColor[3]);
            GL.Instance.Viewport(viewport[0], viewport[1], viewport[2], viewport[3]);


            Color background = Color.SkyBlue;
            foreach (var bitmap in bitmapList)
            {
                for (int w = 0; w < vWidth; w++)
                {
                    for (int h = 0; h < vHeight; h++)
                    {
                        Color color = bitmap.GetPixel(w, vHeight - h - 1);
                        int d = (int)((double)vDepth * (double)color.A / 256.0);
                        int index = w * vHeight * vDepth + h * vDepth + d;
                        if (color.A != 0 &&
                            (color.R != background.R || color.G != background.G || color.B != background.B))
                        {
                            volumeData[index] += (byte)(color.R * 0.299 + color.G * 0.587 + color.B * 0.114);
                        }
                    }
                }
                bitmap.Dispose();
            }
        }

        unsafe private List<Bitmap> LayeredEngraving(RenderEventArgs arg)
        {
            var bitmapList = new List<Bitmap>();

            int currentStep = 0, totalStep = this.RenderStep;
            Texture targetTexture;
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
                    var bitmap = targetTexture.GetImage(vWidth, vHeight);
                    bitmap.Save("0.init.png");
                    //var image = (Bitmap)bitmap.GetThumbnailImage(vWidth, vHeight, null, IntPtr.Zero);
                    bitmapList.Add(bitmap);
                    //bitmap.Dispose();
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
                        var bitmap = targetTexture.GetImage(vWidth, vHeight);
                        bitmap.Save(string.Format("{0}.peel.png", layer * 2 - 1));
                        //var image = (Bitmap)bitmap.GetThumbnailImage(vWidth, vHeight, null, IntPtr.Zero);
                        bitmapList.Add(bitmap);
                        //bitmap.Dispose();
                    }
                }
            }

            return bitmapList;
        }

        private void InitializePeelingResource(int width, int height)
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
