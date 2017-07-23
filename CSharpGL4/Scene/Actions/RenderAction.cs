using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Render <see cref="IRenderable"/> objects.
    /// </summary>
    public class RenderAction : ActionBase
    {

        /// <summary>
        /// 
        /// </summary>
        public ICamera Camera { get; set; }

        /// <summary>
        /// Render <see cref="IRenderable"/> objects.
        /// </summary>
        /// <param name="clear"></param>
        /// <param name="clearColor"></param>
        /// <param name="rootElement"></param>
        /// <param name="camera"></param>
        /// <param name="firstPass"></param>
        public static void Render(bool clear, vec4 clearColor, SceneNodeBase rootElement, ICamera camera, bool firstPass)
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
            RenderAction.Render(rootElement, arg, firstPass, true);

            if (clear)
            {
                GL.Instance.ClearColor(value[0], value[1], value[2], value[3]);
            }
        }

        /// <summary>
        /// Render <see cref="IRenderable"/> objects.
        /// </summary>
        /// <param name="rootElement"></param>
        /// <param name="camera"></param>
        public RenderAction(SceneNodeBase rootElement, ICamera camera)
            : base(rootElement)
        {
            this.Camera = camera;

            this.Clear = true;
            this.ClearColor = Color.SkyBlue.ToVec4();
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Clear { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public vec4 ClearColor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstPass">Update all objects' model matrix if <paramref name="firstPass"/> is true.</param>
        public override void Render(bool firstPass)
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
            RenderAction.Render(this.RootElement, arg, firstPass, true);

            if (clear)
            {
                GL.Instance.ClearColor(value[0], value[1], value[2], value[3]);
            }
        }

        public static void Render(SceneNodeBase sceneElement, RenderEventArgs arg, bool firstPass, bool renderThis)
        {
            if (sceneElement != null)
            {
                if (firstPass)
                {
                    mat4 parentCascadeModelMatrix = arg.ModelMatrixStack.Peek();
                    sceneElement.cascadeModelMatrix = sceneElement.GetModelMatrix(parentCascadeModelMatrix);
                }

                var renderable = sceneElement as IRenderable;
                ThreeFlags flags = (renderable != null) ? renderable.EnableRendering : ThreeFlags.None;
                bool before = (renderable != null) && ((flags & ThreeFlags.BeforeChildren) == ThreeFlags.BeforeChildren);
                bool children = (renderable == null) || ((flags & ThreeFlags.Children) == ThreeFlags.Children);
                bool after = (renderable != null) && ((flags & ThreeFlags.AfterChildren) == ThreeFlags.AfterChildren);

                if (renderThis && before)
                {
                    renderable.RenderBeforeChildren(arg);
                }

                if (firstPass || (children && renderThis))
                {
                    if (firstPass) { arg.ModelMatrixStack.Push(sceneElement.cascadeModelMatrix); }
                    foreach (var item in sceneElement.Children)
                    {
                        RenderAction.Render(item, arg, firstPass, children);
                    }
                    if (firstPass) { arg.ModelMatrixStack.Pop(); }
                }

                if (renderThis && after)
                {
                    renderable.RenderAfterChildren(arg);
                }
            }
        }

    }
}