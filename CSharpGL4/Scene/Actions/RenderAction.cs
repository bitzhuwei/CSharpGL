using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class RenderAction
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clear"></param>
        /// <param name="clearColor"></param>
        /// <param name="rootElement"></param>
        /// <param name="camera"></param>
        public static void Render(bool clear, vec4 clearColor, RendererBase rootElement, ICamera camera)
        {
            int[] value = null;
            if (clear)
            {
                value = new int[4];
                GL.Instance.GetIntegerv((uint)GetTarget.ColorClearValue, value);
                GL.Instance.ClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);
            }

            var arg = new RenderEventArgs(camera);
            RenderAction.Render(rootElement, arg);

            if (clear)
            {
                GL.Instance.ClearColor(value[0], value[1], value[2], value[3]);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clear"></param>
        /// <param name="clearColor"></param>
        /// <param name="rootElement"></param>
        public RenderAction(bool clear, vec4 clearColor, RendererBase rootElement, ICamera camera)
        {
            this.Clear = clear;
            this.ClearColor = clearColor;
            this.RootElement = rootElement;
            this.Camera = camera;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Render()
        {
            int[] value = null;
            bool clear = this.Clear;
            if (clear)
            {
                value = new int[4];
                GL.Instance.GetIntegerv((uint)GetTarget.ColorClearValue, value);
                vec4 clearColor = this.ClearColor;
                GL.Instance.ClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);
            }

            var arg = new RenderEventArgs(this.Camera);
            RenderAction.Render(this.RootElement, arg);

            if (clear)
            {
                GL.Instance.ClearColor(value[0], value[1], value[2], value[3]);
            }
        }

        public static void Render(RendererBase sceneElement, RenderEventArgs arg)
        {
            if (sceneElement != null)
            {
                mat4 parentCascadeModelMatrix = arg.ModelMatrixStack.Peek();
                sceneElement.cascadeModelMatrix = sceneElement.GetModelMatrix(parentCascadeModelMatrix);

                var renderable = sceneElement as IRenderable;
                ThreeFlags flags = (renderable != null) ? renderable.EnableRendering : ThreeFlags.None;
                bool before = (renderable != null) && ((flags & ThreeFlags.BeforeChildren) == ThreeFlags.BeforeChildren);
                bool children = (renderable == null) || ((flags & ThreeFlags.Children) == ThreeFlags.Children);
                bool after = (renderable != null) && ((flags & ThreeFlags.AfterChildren) == ThreeFlags.AfterChildren);

                if (before)
                {
                    renderable.RenderBeforeChildren(arg);
                }

                if (children)
                {
                    arg.ModelMatrixStack.Push(sceneElement.cascadeModelMatrix);
                    foreach (var item in sceneElement.Children)
                    {
                        RenderAction.Render(item, arg);
                    }
                    arg.ModelMatrixStack.Pop();
                }

                if (after)
                {
                    renderable.RenderAfterChildren(arg);
                }

            }
        }

        public bool Clear { get; set; }

        public vec4 ClearColor { get; set; }

        public RendererBase RootElement { get; set; }

        public ICamera Camera { get; set; }
    }
}