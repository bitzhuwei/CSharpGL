﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// 
    /// </summary>
    public class LightEquipment : ITextureSource {
        private readonly IFramebufferProvider framebufferProvider = new DepthFramebufferProvider();
        private readonly PolygonOffsetFillSwitch polygonFillOffset = new PolygonOffsetFillSwitch(false);
        private int width;
        private int height;

        /// <summary>
        /// bind framebuffer, setup viewport, polygon-offset and so on.
        /// </summary>
        public unsafe void Begin(Viewport viewport) {
            var gl = GL.current; if (gl != null) {
                this.width = viewport.width; this.height = viewport.height;
                var framebuffer = this.framebufferProvider.GetFramebuffer(this.width, this.height);

                framebuffer.Bind();
                gl.glViewport(0, 0, this.width, this.height);
                this.polygonFillOffset.On();
                {
                    gl.glClearColor(1.0f, 1.0f, 1.0f, 1.0f);// white color means farest position.
                    gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);
                    //{
                    //    var args = new RenderEventArgs(this.Camera);
                    //    foreach (var item in this.Children)
                    //    {
                    //        RenderAction.Render(item, args, true, true);
                    //    }
                    //}
                }
            }
        }

        /// <summary>
        /// unbind framebuffer, reset viewport, polygon-offset and so on.
        /// </summary>
        public unsafe void End() {
            var gl = GL.current; if (gl != null) {
                int width = this.width, height = this.height;
                var framebuffer = this.framebufferProvider.GetFramebuffer(width, height);

                this.polygonFillOffset.Off();
                gl.glViewport(0, 0, width, height);// recover viewport.
                framebuffer.Unbind();
            }
        }

        #region ITextureSource 成员

        /// <summary>
        /// The texture that records shadow caused by some light.
        /// </summary>
        public Texture BindingTexture {
            get { return this.framebufferProvider.BindingTexture; }
        }

        #endregion
    }
}
