﻿using System;
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
    public class RenderAction : DependentActionBase
    {
        public uint ClearMask { get; set; }

        /// <summary>
        /// Render <see cref="IRenderable"/> objects.
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="clearMask"></param>
        public RenderAction(Scene scene, uint clearMask = GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT)
            : base(scene)
        {
            this.ClearMask = clearMask;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Act()
        {
            //int[] value = null;
            //value = new int[4];
            //GL.Instance.GetIntegerv((uint)GetTarget.ColorClearValue, value);
            vec4 clearColor = this.Scene.ClearColor;
            GL.Instance.ClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
            GL.Instance.Clear(this.ClearMask);

            var arg = new RenderEventArgs(this.Scene, this.Scene.Camera);
            RenderAction.Render(this.Scene.RootElement, arg);

            //GL.Instance.ClearColor(value[0], value[1], value[2], value[3]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneElement"></param>
        /// <param name="arg"></param>
        public static void Render(SceneNodeBase sceneElement, RenderEventArgs arg)
        {
            if (sceneElement != null)
            {
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
                    foreach (var item in sceneElement.Children)
                    {
                        RenderAction.Render(item, arg);
                    }
                }

                if (after)
                {
                    renderable.RenderAfterChildren(arg);
                }
            }
        }

    }
}