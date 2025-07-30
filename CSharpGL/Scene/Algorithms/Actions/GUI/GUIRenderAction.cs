﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// Render <see cref="GLControl"/> objects.
    /// </summary>
    public class GUIRenderAction : ActionBase {
        private GLControl rootControl;

        /// <summary>
        /// Render <see cref="GLControl"/> objects.
        /// </summary>
        /// <param name="rootControl"></param>
        public GUIRenderAction(GLControl rootControl) {
            this.rootControl = rootControl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public unsafe override void Act(ActionParams param) {
            var gl = GL.current; if (gl != null) {
                int width = param.Viewport.width, height = param.Viewport.height;
                //    var scissor = new int[4];
                //    var viewport = new int[4];
                //    GL.Instance.GetIntegerv((GLenum)GetTarget.ScissorBox, scissor);
                //    GL.Instance.GetIntegerv((GLenum)GetTarget.Viewport, viewport);

                var arg = new GUIRenderEventArgs(param);
                RenderGUI(this.rootControl, arg);

                // Reset viewport.
                gl.glScissor(0, 0, width, height);
                gl.glViewport(0, 0, width, height);
            }
        }

        private static void RenderGUI(GLControl control, GUIRenderEventArgs arg) {
            if (control != null) {
                var renderable = control as IGUIRenderable;
                ThreeFlags flags = (renderable != null) ? renderable.EnableGUIRendering : ThreeFlags.None;
                bool before = (renderable != null) && ((flags & ThreeFlags.BeforeChildren) == ThreeFlags.BeforeChildren);
                bool children = (renderable == null) || ((flags & ThreeFlags.Children) == ThreeFlags.Children);
                bool after = (renderable != null) && ((flags & ThreeFlags.AfterChildren) == ThreeFlags.AfterChildren);

                if (before) {
                    if (renderable != null) renderable.RenderGUIBeforeChildren(arg);
                }

                if (children) {
                    foreach (var item in control.Children) {
                        RenderGUI(item, arg);
                    }
                }

                if (after) {
                    if (renderable != null) renderable.RenderGUIAfterChildren(arg);
                }
            }
        }
    }
}