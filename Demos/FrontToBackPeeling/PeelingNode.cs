using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace FrontToBackPeeling
{
    partial class PeelingNode : SceneNodeBase, IRenderable
    {
        private int width;
        private int height;
        private GroupNode cubeNodeGroup;
        private QuadNode fullscreenQuad;
        private DepthMaskSwitch depthMask = new DepthMaskSwitch(false);
        private const int NUM_PASSES = 6;
        private bool bUseOQ = false;

        public bool ShowDepthPeeling { get; set; }

        private static readonly GLDelegates.void_uint glBlendEquation;
        private static readonly GLDelegates.void_uint_uint_uint_uint glBlendFuncSeparate;

        public PeelingNode(Scene scene)
        {
            this.ShowDepthPeeling = true;

            this.query = new Query();

            {
                var colors = new vec4[] { new vec4(1, 0, 0, 0.5f), new vec4(0, 1, 0, 0.5f), new vec4(0, 0, 1, 0.5f) };

                var groupNode = new GroupNode();
                for (int k = -1; k < 2; k++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        int index = 0;
                        for (int i = -1; i < 2; i++)
                        {
                            vec3 worldPosition = new vec3(i * 2, j * 2, k * 2);
                            var cubeNode = CubeNode.Create();
                            cubeNode.WorldPosition = worldPosition;
                            cubeNode.Color = colors[index++];

                            groupNode.Children.Add(cubeNode);
                        }
                    }
                }
                this.Children.Add(groupNode);

                this.cubeNodeGroup = groupNode;
            }
            {
                var quad = QuadNode.Create(scene);
                this.fullscreenQuad = quad;
            }
        }

        static PeelingNode()
        {
            glBlendEquation = GL.Instance.GetDelegateFor("glBlendEquation", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
            glBlendFuncSeparate = GL.Instance.GetDelegateFor("glBlendFuncSeparate", GLDelegates.typeof_void_uint_uint_uint_uint) as GLDelegates.void_uint_uint_uint_uint;
        }

        private BlendSwitch blend = new BlendSwitch(BlendEquationMode.Add, BlendSrcFactor.SrcAlpha, BlendDestFactor.OneMinusSrcAlpha, BlendSrcFactor.One, BlendDestFactor.One);

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

            if (this.ShowDepthPeeling)
            {
                {
                    //glBlendEquation(GL.GL_FUNC_ADD);
                    //glBlendFuncSeparate(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA, GL.GL_ONE, GL.GL_ONE);
                }
                // init.
                {
                    this.resources.blenderFBO.Bind();
                    GL.Instance.ClearColor(0, 0, 0, 1);
                    GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
                    this.DrawScene(arg, CubeNode.RenderMode.Init, null);
                    this.resources.blenderFBO.Unbind();
                }

                int numLayers = (NUM_PASSES - 1) * 2;
                // for each pass
                for (int layer = 1; bUseOQ || layer < numLayers; layer++)
                {
                    int currId = layer % 2;
                    int prevId = 1 - currId;
                    // peel.
                    {
                        this.resources.FBOs[currId].Bind();
                        GL.Instance.ClearColor(0, 0, 0, 1);
                        GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
                        this.depthMask.On();
                        //GL.Instance.Enable(GL.GL_BLEND);
                        this.blend.On();
                        if (bUseOQ)
                        {
                            this.query.BeginQuery(QueryTarget.SamplesPassed);
                        }
                        this.DrawScene(arg, CubeNode.RenderMode.Peel, this.resources.depthTextures[prevId]);
                        if (bUseOQ)
                        {
                            this.query.EndQuery(QueryTarget.SamplesPassed);
                        }
                        //GL.Instance.Disable(GL.GL_BLEND);
                        this.blend.Off();
                        this.depthMask.Off();
                        this.resources.FBOs[currId].Unbind();
                    }
                    // blend.
                    {
                        this.resources.blenderFBO.Bind();
                        this.DrawFullScreenQuad(arg, QuadNode.RenderMode.Blend, this.resources.colorTextures[currId]);
                        this.resources.blenderFBO.Unbind();
                    }

                    if (bUseOQ)
                    {
                        var sampleCount = this.query.SampleCount();
                        if (sampleCount == 0) { break; }
                    }
                }
                // final.
                this.DrawFullScreenQuad(arg, QuadNode.RenderMode.Final, this.resources.blenderColorTexture);
            }
            else
            {
                //GL.Instance.Enable(GL.GL_DEPTH_TEST);
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
            foreach (var item in this.cubeNodeGroup.Children)
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

        private void DrawFullScreenQuad(RenderEventArgs arg, QuadNode.RenderMode renderMode, Texture tempTexture)
        {
            this.fullscreenQuad.Mode = renderMode;
            if (tempTexture != null)
            {
                this.fullscreenQuad.TempTexture = tempTexture;
            }
            this.fullscreenQuad.RenderBeforeChildren(arg);
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }
}
