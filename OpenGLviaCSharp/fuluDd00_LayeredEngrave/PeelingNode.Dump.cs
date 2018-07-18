//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using CSharpGL;
//using System.Drawing;

//namespace fuluDd00_LayeredEngrave
//{
//    partial class PeelingNode : SceneNodeBase, IRenderable
//    {
//        private int width;
//        private int height;
//        private PeelingResource resources;
//        private Query query;
//        private bool bUseOQ = false;
//        private QuadNode fullscreenQuad;
//        private const int NUM_PASSES = 5;
//        private DepthTestSwitch depthTest = new DepthTestSwitch(enableCapacity: false);
//        private BlendSwitch blend = new BlendSwitch(BlendEquationMode.Add, BlendSrcFactor.DstAlpha, BlendDestFactor.One, BlendSrcFactor.Zero, BlendDestFactor.OneMinusSrcAlpha);

//        private bool dumpImages = true;
//        /// <summary>
//        /// Dump images once.
//        /// </summary>
//        public bool DumpImages
//        {
//            get { return dumpImages; }
//            set { dumpImages = value; }
//        }

//        private bool showDepthPeeling = true;
//        /// <summary>
//        /// 
//        /// </summary>
//        public bool ShowDepthPeeling { get { return this.showDepthPeeling; } set { this.showDepthPeeling = value; } }

//        private static readonly GLDelegates.void_uint glBlendEquation;
//        private static readonly GLDelegates.void_uint_uint_uint_uint glBlendFuncSeparate;

//        static PeelingNode()
//        {
//            glBlendEquation = GL.Instance.GetDelegateFor("glBlendEquation", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
//            glBlendFuncSeparate = GL.Instance.GetDelegateFor("glBlendFuncSeparate", GLDelegates.typeof_void_uint_uint_uint_uint) as GLDelegates.void_uint_uint_uint_uint;
//        }

//        public PeelingNode(Scene scene)
//        {
//            this.query = new Query();

//            {
//                const float alpha = 0.3f;
//                var colors = new vec4[] { new vec4(1, 0, 0, alpha), new vec4(0, 1, 0, alpha), new vec4(0, 0, 1, alpha) };

//                for (int k = -1; k < 2; k++)
//                {
//                    for (int j = -1; j < 2; j++)
//                    {
//                        int index = 0;
//                        for (int i = -1; i < 2; i++)
//                        {
//                            vec3 worldPosition = new vec3(i * 2, j * 2, k * 2);
//                            var cubeNode = CubeNode.Create();
//                            cubeNode.WorldPosition = worldPosition;
//                            cubeNode.Color = colors[index++];

//                            this.Children.Add(cubeNode);
//                        }
//                    }
//                }
//            }
//            {
//                var quad = QuadNode.Create(scene);
//                this.fullscreenQuad = quad;
//            }
//        }


//        #region IRenderable 成员

//        public ThreeFlags EnableRendering { get { return ThreeFlags.BeforeChildren; } set { } }

//        public void RenderBeforeChildren(RenderEventArgs arg)
//        {
//            var viewport = new int[4]; GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);

//            if (this.width != viewport[2] || this.height != viewport[3])
//            {
//                Resize(viewport[2], viewport[3]);

//                this.width = viewport[2];
//                this.height = viewport[3];
//            }

//            var leftList = new List<Bitmap>();
//            var rightList = new List<Bitmap>();

//            var dumpImages = this.DumpImages;
//            if (this.ShowDepthPeeling)
//            {
//                // init.
//                {
//                    this.resources.blenderFBO.Bind();
//                    GL.Instance.ClearColor(0, 0, 0, 1);
//                    GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
//                    this.DrawScene(arg, CubeNode.RenderMode.Init, null);
//                    this.resources.blenderFBO.Unbind();
//                    if (dumpImages)
//                    {
//                        var image = this.resources.blenderColorTexture.GetImage(this.width, this.height);
//                        image.Save(string.Format("0.init-blenderTexture.png"));
//                        leftList.Add(image);
//                        leftList.Add(image);
//                    }
//                }

//                int numLayers = (NUM_PASSES - 1) * 2;
//                // for each pass
//                for (int layer = 1; bUseOQ || layer < numLayers; layer++)
//                {
//                    int currId = layer % 2;
//                    int prevId = 1 - currId;
//                    // peel.
//                    {
//                        this.resources.FBOs[currId].Bind();
//                        GL.Instance.ClearColor(0, 0, 0, 0);
//                        GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
//                        if (dumpImages)
//                        {
//                            var image = this.resources.colorTextures[currId].GetImage(this.width, this.height);
//                            rightList.Add(image);
//                        }
//                        if (bUseOQ) { this.query.BeginQuery(QueryTarget.SamplesPassed); }
//                        this.DrawScene(arg, CubeNode.RenderMode.Peel, this.resources.depthTextures[prevId]);
//                        if (bUseOQ) { this.query.EndQuery(QueryTarget.SamplesPassed); }
//                        this.resources.FBOs[currId].Unbind();
//                        if (dumpImages)
//                        {
//                            var image = this.resources.colorTextures[currId].GetImage(this.width, this.height);
//                            image.Save(string.Format("1.layers[{0}].0.peel-textures[{1}].png", layer, currId));
//                            rightList.Add(image);
//                        }
//                    }
//                    // blend.
//                    {
//                        this.resources.blenderFBO.Bind();
//                        this.depthTest.On();
//                        this.blend.On();
//                        this.DrawFullScreenQuad(arg, QuadNode.RenderMode.Blend, this.resources.colorTextures[currId]);
//                        this.blend.Off();
//                        this.depthTest.Off();
//                        this.resources.blenderFBO.Unbind();
//                        if (dumpImages)
//                        {
//                            var image = this.resources.blenderColorTexture.GetImage(this.width, this.height);
//                            image.Save(string.Format("1.layers[{0}].1.blend-blenderTexture.png", layer));
//                            leftList.Add(image);
//                            leftList.Add(image);
//                        }
//                    }

//                    if (bUseOQ)
//                    {
//                        var sampleCount = this.query.SampleCount();
//                        if (sampleCount == 0) { break; }
//                    }
//                }
//                // final.
//                this.DrawFullScreenQuad(arg, QuadNode.RenderMode.Final, this.resources.blenderColorTexture);
//                if (dumpImages)
//                {
//                    var image = this.resources.blenderColorTexture.GetImage(this.width, this.height);
//                    image.Save(string.Format("2.final-blenderTexture.png"));
//                }
//                if (dumpImages)
//                {
//                    var left = new Bitmap(width, height);
//                    var data = left.LockBits(new Rectangle(0, 0, width, height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
//                    //GL.Instance.GetTexImage((uint)texture.Target, 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, data.Scan0);
//                    GL.Instance.ReadPixels(0, 0, width, height, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, data.Scan0);
//                    left.UnlockBits(data);
//                    left.RotateFlip(RotateFlipType.Rotate180FlipX);
//                    leftList.Add(left);
//                }
//                if (dumpImages)
//                {
//                    var first = rightList[0];
//                    rightList.Add(first);
//                    this.resources.FBOs[0].Bind();
//                    vec4 clearColor = Color.SkyBlue.ToVec4();
//                    GL.Instance.ClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
//                    GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
//                    {
//                        var image = this.resources.colorTextures[0].GetImage(this.width, this.height);
//                        rightList.Add(image);
//                    }
//                    this.resources.FBOs[0].Unbind();
//                    rightList.Add(first);
//                }
//            }
//            else
//            {
//                this.DrawScene(arg, CubeNode.RenderMode.Init, null);
//            }

//            if (dumpImages)
//            {
//                for (int i = 0; i < leftList.Count; i++)
//                {
//                    var image = leftList[i];
//                    image.Save(string.Format("left{0}.png", i));
//                }
//                for (int i = 0; i < rightList.Count; i++)
//                {
//                    var image = rightList[i];
//                    image.Save(string.Format("right{0}.png", i));
//                }

//                if (leftList.Count != rightList.Count) { throw new Exception(); }
//                for (int i = 0; i < leftList.Count; i++)
//                {
//                    var bmp = Merge(leftList[i], rightList[i]);
//                    bmp.Save(string.Format("left+right{0}.png", i));
//                }
//            }

//            this.DumpImages = false;
//        }

//        static Bitmap Merge(Bitmap leftBmp, Bitmap rightBmp)
//        {
//            int width = leftBmp.Width + rightBmp.Width;
//            int height = leftBmp.Height >= rightBmp.Height ? leftBmp.Height : rightBmp.Height;
//            var result = new Bitmap(width, height);
//            using (var g = Graphics.FromImage(result))
//            {
//                g.DrawImage(leftBmp, new Point());
//                g.DrawImage(rightBmp, new Point(leftBmp.Width, 0));
//            }

//            return result;
//        }
//        private void Resize(int width, int height)
//        {
//            if (this.resources != null) { this.resources.Dispose(); }
//            this.resources = new PeelingResource(width, height);
//        }

//        private void DrawScene(RenderEventArgs arg, CubeNode.RenderMode renderMode, Texture texture)
//        {
//            foreach (var item in this.Children)
//            {
//                var node = item as CubeNode;
//                node.Mode = renderMode;
//                if (texture != null)
//                {
//                    node.DepthTexture = texture;
//                }
//                node.RenderBeforeChildren(arg);
//            }
//        }

//        private void DrawFullScreenQuad(RenderEventArgs arg, QuadNode.RenderMode renderMode, Texture tempTexture)
//        {
//            this.fullscreenQuad.Mode = renderMode;
//            if (tempTexture != null)
//            {
//                this.fullscreenQuad.TempTexture = tempTexture;
//            }
//            this.fullscreenQuad.RenderBeforeChildren(arg);
//        }

//        public void RenderAfterChildren(RenderEventArgs arg)
//        {
//        }

//        #endregion
//    }
//}
