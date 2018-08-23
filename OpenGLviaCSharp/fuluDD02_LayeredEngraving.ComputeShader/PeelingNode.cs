using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;
using System.Runtime.InteropServices;
using System.IO;

namespace fuluDD02_LayeredEngraving.ComputeShader
{
    partial class PeelingNode : SceneNodeBase, IRenderable, IVolumeData
    {
        private PeelingResource resources;
        private Query query;
        private bool bUseOQ = true;
        private const int maxPassCount = 16;
        private DepthTestSwitch depthTest = new DepthTestSwitch(enableCapacity: false);
        private ShaderProgram engraveXComp;
        private ShaderProgram engraveYComp;
        private ShaderProgram engraveZComp;
        private VertexBuffer outBuffer;

        public PeelingNode(vec3 size, params SceneNodeBase[] children)
        {
            this.ModelSize = size;

            this.query = new Query();
            this.Children.AddRange(children);
            {
                var cs = new CSharpGL.ComputeShader(Shaders.engraveXComp);
                var provider = new ShaderArray(cs);
                this.engraveXComp = provider.GetShaderProgram();
            }
            {
                var cs = new CSharpGL.ComputeShader(Shaders.engraveYComp);
                var provider = new ShaderArray(cs);
                this.engraveYComp = provider.GetShaderProgram();
            }
            {
                var cs = new CSharpGL.ComputeShader(Shaders.engraveZComp);
                var provider = new ShaderArray(cs);
                this.engraveZComp = provider.GetShaderProgram();
            }
            {
                var data = new uint[Width * Height * Depth];
                this.outBuffer = data.GenVertexBuffer(VBOConfig.UInt, BufferUsage.DynamicCopy);
            }
            {
                this.InitializePeelingResource(vWidth, vHeight);
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
            string filename = "engraving.comp.raw";
            //if (!File.Exists(filename))
            {
                //var data = new Voxel[vWidth * vHeight * vDepth];
                VertexBuffer data = this.outBuffer; // which is a uint[vWidth * vHeight * vDepth];

                EngraveX(arg, data, vWidth, vHeight, vDepth);
                EngraveY(arg, data, vWidth, vHeight, vDepth);
                EngraveZ(arg, data, vWidth, vHeight, vDepth);

                using (var fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
                using (var bw = new BinaryWriter(fs))
                {
                    var array = (uint*)data.MapBuffer(MapBufferAccess.ReadOnly);
                    for (int i = 0; i < data.Length; i++)
                    {
                        vec4 value = glm.unpackUnorm4x8(array[i]);
                        Voxel v = new Voxel((byte)(value.x * byte.MaxValue), (byte)(value.y * byte.MaxValue), (byte)(value.z * byte.MaxValue));
                        bw.Write(v.r); bw.Write(v.g); bw.Write(v.b);
                    }
                    data.UnmapBuffer();
                }
            }
            this.volumeData = GetVolumeData(filename);

            this.firstRun = false;
        }

        private byte[] GetVolumeData(string filename)
        {
            byte[] data;
            //int index = 0;
            //int readCount = 0;
            using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            using (var br = new BinaryReader(fs))
            {
                int unReadCount = (int)fs.Length;
                data = new byte[unReadCount];
                br.Read(data, 0, unReadCount);
            }

            return data;
        }

        unsafe private void EngraveX(RenderEventArgs arg, VertexBuffer volumeData, int width, int height, int depth)
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

            List<Bitmap> bitmapList = LayeredEngraving(arg, "X");

            // restore clear color.
            GL.Instance.ClearColor(clearColor[0], clearColor[1], clearColor[2], clearColor[3]);
            GL.Instance.Viewport(viewport[0], viewport[1], viewport[2], viewport[3]);


            Color background = Color.SkyBlue;
            foreach (var bitmap in bitmapList)
            {
                Texture texture = GetTexture(bitmap);
                ComputeShaderEngrave(this.engraveXComp, texture, volumeData, vWidth, vHeight);
                bitmap.Dispose();
                texture.Dispose();
            }
        }

        unsafe private void EngraveY(RenderEventArgs arg, VertexBuffer volumeData, int width, int height, int depth)
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

            List<Bitmap> bitmapList = LayeredEngraving(arg, "Y");

            // restore clear color.
            GL.Instance.ClearColor(clearColor[0], clearColor[1], clearColor[2], clearColor[3]);
            GL.Instance.Viewport(viewport[0], viewport[1], viewport[2], viewport[3]);


            Color background = Color.SkyBlue;
            foreach (var bitmap in bitmapList)
            {
                Texture texture = GetTexture(bitmap);
                ComputeShaderEngrave(this.engraveYComp, texture, volumeData, vWidth, vHeight);
                bitmap.Dispose();
                texture.Dispose();
            }
        }
        unsafe private void EngraveZ(RenderEventArgs arg, VertexBuffer volumeData, int width, int height, int depth)
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

            List<Bitmap> bitmapList = LayeredEngraving(arg, "Z");

            // restore clear color.
            GL.Instance.ClearColor(clearColor[0], clearColor[1], clearColor[2], clearColor[3]);
            GL.Instance.Viewport(viewport[0], viewport[1], viewport[2], viewport[3]);


            Color background = Color.SkyBlue;
            foreach (var bitmap in bitmapList)
            {
                Texture texture = GetTexture(bitmap);
                ComputeShaderEngrave(this.engraveZComp, texture, volumeData, vWidth, vHeight);
                bitmap.Dispose();
                texture.Dispose();
            }
        }

        unsafe private List<Bitmap> LayeredEngraving(RenderEventArgs arg, string prefix)
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
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
                    bitmap.Save(string.Format("{0}.0.init.png", prefix));
                    //var image = (Bitmap)bitmap.GetThumbnailImage(vWidth, vHeight, null, IntPtr.Zero);
                    bitmapList.Add(bitmap);
                    //bitmap.Dispose();
                }
            }

            int numLayers = (maxPassCount - 1) * 2;
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
                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
                        bitmap.Save(string.Format("{0}{1}.peel.png", prefix, layer * 2 - 1));
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


        internal static GLDelegates.void_uint_uint_uint glBindBufferBase;

        private void ComputeShaderEngrave(ShaderProgram engraveComp, Texture texInput, VertexBuffer outBuffer, int width, int height)
        {
            if (glBindBufferBase == null) { glBindBufferBase = GL.Instance.GetDelegateFor("glBindBufferBase", GLDelegates.typeof_void_uint_uint_uint) as GLDelegates.void_uint_uint_uint; }

            // engrave volume data with compute shader.
            uint inputUnit = 0, outputUnit = 1;
            // Activate the compute program and bind the output texture image
            engraveComp.Bind();
            //glBindImageTexture(outputUnit, outBuffer.BufferId, 0, false, 0, GL.GL_READ_WRITE, GL.GL_RED);
            glBindBufferBase(GL.GL_SHADER_STORAGE_BUFFER, outputUnit, outBuffer.BufferId);
            glBindImageTexture(inputUnit, texInput.Id, 0, false, 0, GL.GL_READ_WRITE, GL.GL_RGBA32F);
            // Dispatch
            glDispatchCompute(1, (uint)height, 1);
            //glDispatchCompute((uint)width, (uint)height, 1);
            glMemoryBarrier(GL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT);
            glBindImageTexture(inputUnit, 0, 0, false, 0, GL.GL_READ_WRITE, GL.GL_RGBA32F);
            //glBindImageTexture(outputUnit, 0, 0, false, 0, GL.GL_READ_WRITE, GL.GL_RED);
            engraveComp.Unbind();
        }
        //private void ComputeShaderEngrave(Texture texInput, Texture texOutput, int width, int height)
        //{
        //    // engrave volume data with compute shader.
        //    uint inputUnit = 0, outputUnit = 1;
        //    ShaderProgram computeProgram = this.engraveComp;
        //    // Activate the compute program and bind the output texture image
        //    computeProgram.Bind();
        //    glBindImageTexture(inputUnit, texInput.Id, 0, false, 0, GL.GL_READ_WRITE, GL.GL_RGBA32F);
        //    glBindImageTexture(outputUnit, texOutput.Id, 0, true, 0, GL.GL_READ_WRITE, GL.GL_RED);
        //    // Dispatch
        //    glDispatchCompute(1, (uint)height, 1);
        //    //glDispatchCompute((uint)width, (uint)height, 1);
        //    glMemoryBarrier(GL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT);
        //    glBindImageTexture(inputUnit, 0, 0, false, 0, GL.GL_READ_WRITE, GL.GL_RGBA32F);
        //    glBindImageTexture(outputUnit, 0, 0, true, 0, GL.GL_READ_WRITE, GL.GL_RED);
        //    computeProgram.Unbind();
        //}

        private Texture GetTexture(Bitmap bitmap)
        {
            //bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);

            var texture = new Texture(new TexImageBitmap(bitmap, GL.GL_RGBA32F));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));

            texture.Initialize();

            return texture;
        }

    }
}
