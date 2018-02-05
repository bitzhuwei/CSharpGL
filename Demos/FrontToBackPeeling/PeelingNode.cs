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

        public PeelingNode()
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
                var quad = QuadNode.Create();
                this.fullscreenQuad = quad;
            }
        }

        static PeelingNode()
        {
            glBlendEquation = GL.Instance.GetDelegateFor("glBlendEquation", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
            glBlendFuncSeparate = GL.Instance.GetDelegateFor("glBlendFuncSeparate", GLDelegates.typeof_void_uint_uint_uint_uint) as GLDelegates.void_uint_uint_uint_uint;
        }
        #region IRenderable 成员

        public ThreeFlags EnableRendering { get { return ThreeFlags.BeforeChildren; } set { } }

        public bool ShowDepthPeeling { get; set; }

        private DepthTestState depthTestState = new DepthTestState(true);

        private const int NUM_PASSES = 6;
        private bool bUseOQ = false;
        private static readonly GLDelegates.void_uint glBlendEquation;
        private static readonly GLDelegates.void_uint_uint_uint_uint glBlendFuncSeparate;

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
                this.resources.colorBlenderFramebuffer.Bind();
                //GL.Instance.DrawBuffer(GL.GL_COLOR_ATTACHMENT0);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
                //this.depthTestState.On();
                this.DrawScene(arg, CubeNode.RenderMode.Cube, null);
                this.resources.colorBlenderFramebuffer.Unbind();

                int numLayers = (NUM_PASSES - 1) * 2;
                // for each pass
                for (int layer = 0; bUseOQ || layer < numLayers; layer++)
                {
                    int currId = layer % 2;
                    int prevId = 1 - currId;
                    this.resources.framebuffers[currId].Bind();
                    //GL.Instance.DrawBuffer(GL.GL_COLOR_ATTACHMENT0);
                    //GL.Instance.ClearColor(0, 0, 0, 0);
                    //GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
                    GL.Instance.Clear(GL.GL_DEPTH_BUFFER_BIT);
                    //this.depthTestState.Off();
                    //GL.Instance.Disable(GL.GL_BLEND);
                    GL.Instance.Enable(GL.GL_BLEND);
                    glBlendEquation(GL.GL_FUNC_ADD);
                    glBlendFuncSeparate(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA, GL.GL_ONE, GL.GL_ONE);
                    if (bUseOQ)
                    {
                        this.query.BeginQuery(QueryTarget.SamplesPassed);
                    }
                    this.DrawScene(arg, CubeNode.RenderMode.FrontPeel, this.resources.depthAttachments[prevId]);
                    if (bUseOQ)
                    {
                        this.query.EndQuery(QueryTarget.SamplesPassed);
                    }
                    this.resources.framebuffers[currId].Unbind();

                    this.resources.colorBlenderFramebuffer.Bind();
                    GL.Instance.DrawBuffer(GL.GL_COLOR_ATTACHMENT0);
                    //this.depthTestState.Off();
                    this.DrawFullScreenQuad(arg, QuadNode.RenderMode.Blend, this.resources.colorAttachments[currId]);
                    GL.Instance.Disable(GL.GL_BLEND);
                    this.resources.colorBlenderFramebuffer.Unbind();

                    if (bUseOQ)
                    {
                        var sampleCount = this.query.SampleCount();
                        if (sampleCount == 0) { break; }
                    }
                }

                //GL.Instance.DrawBuffer(GL.GL_BACK_RIGHT);
                //GL.Instance.Disable(GL.GL_DEPTH_TEST);
                //GL.Instance.Disable(GL.GL_BLEND);
                this.DrawFullScreenQuad(arg, QuadNode.RenderMode.Final, this.resources.colorBlenderColorAttachment);
            }
            else
            {
                //GL.Instance.Enable(GL.GL_DEPTH_TEST);
                this.DrawScene(arg, CubeNode.RenderMode.Cube, null);
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
