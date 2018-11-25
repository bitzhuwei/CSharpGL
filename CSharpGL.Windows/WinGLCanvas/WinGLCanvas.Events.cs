﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace CSharpGL
{
    public partial class WinGLCanvas
    {
        private static readonly vec4 clearColor = Color.SkyBlue.ToVec4();
        private Bitmap bitmap;

        /// <summary>
        ///
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            GLRenderContext renderContext = this.renderContext;
            if (renderContext == null)
            {
                base.OnPaint(e);
                return;
            }

            stopWatch.Reset();
            stopWatch.Start();

            //	Make sure it's our instance of openSharpGL that's active.
            renderContext.MakeCurrent();

            if (this.designMode)
            {
                try
                {
                    GL.Instance.ClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                    GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                    //this.assist.Render(this.RenderTrigger == RenderTrigger.TimerBased, this.Height, this.FPS, this);
                }
                catch (Exception)
                {
                }
            }
            else
            {
                //	If there is a draw handler, then call it.
                DoOpenGLDraw(e);
            }

            //	Blit our offscreen bitmap.
            Graphics graphics = e.Graphics;
            //{
            //    // way #1.
            //    renderContext.Blit(graphics);
            //}
            {
                // way #2.
                int width = this.Width, height = this.Height;
                if (width > 0 && height > 0)
                {
                    Bitmap bitmap = this.bitmap;
                    if (bitmap == null || bitmap.Width != width || bitmap.Height != height)
                    {
                        if (bitmap != null) { bitmap.Dispose(); }
                        bitmap = new Bitmap(width, height);
                        this.bitmap = bitmap;
                    }

                    var bmpData = bitmap.LockBits(new Rectangle(0, 0, width, height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    GL.Instance.ReadPixels(0, 0, width, height, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, bmpData.Scan0);
                    bitmap.UnlockBits(bmpData);
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
                    graphics.DrawImage(bitmap, 0, 0);
                }
            }

            stopWatch.Stop();

            {
                ErrorCode error = (ErrorCode)GL.Instance.GetError();
                if (error != ErrorCode.NoError)
                {
                    string str = string.Format("{0}: OpenGL error: {1}", this.GetType().FullName, error);
                    Debug.WriteLine(str);
                    Log.Write(str);
                }
            }

            this.FPS = 1000.0 / stopWatch.Elapsed.TotalMilliseconds;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
        }

        private void redrawTimer_Tick(object sender, EventArgs e)
        {
            //this.renderingRequired = true;
            this.Invalidate();
        }

        /// <summary>
        /// Make render context in this Canvas the current one in the thread.
        /// </summary>
        public void MakeCurrent()
        {
            GLRenderContext renderContext = this.renderContext;
            if (renderContext != null)
            {
                renderContext.MakeCurrent();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            int width = this.Width, height = this.Height;
            if (width > 0 && height > 0)
            {
                GLRenderContext renderContext = this.renderContext;
                if (renderContext != null)
                {
                    renderContext.MakeCurrent();

                    renderContext.SetDimensions(width, height);

                    GL.Instance.Viewport(0, 0, width, height);

                    if (this.designMode)
                    {
                        //this.assist.Resize(width, height);
                    }
                    else
                    {
                        //Bitmap bitmap = this.bitmap;
                        //this.bitmap = new Bitmap(width, height);
                        //if (bitmap != null) { bitmap.Dispose(); }
                    }

                    this.Invalidate();
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="e"></param>
        protected override void OnHandleDestroyed(EventArgs e)
        {
            DestroyRenderContext();
            {
                Bitmap bitmap = this.bitmap;
                if (bitmap != null) { bitmap.Dispose(); }
                this.bitmap = null;
            }

            base.OnHandleDestroyed(e);
        }

        private void DestroyRenderContext()
        {
            GLRenderContext renderContext = this.renderContext;
            if (renderContext != null)
            {
                this.renderContext = null;
                renderContext.Dispose();
            }
        }

        /// <summary>
        /// Call this function in derived classes to do the OpenGL Draw event.
        /// </summary>
        private void DoOpenGLDraw(PaintEventArgs e)
        {
            GLEventHandler<PaintEventArgs> handler = this.OpenGLDraw;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// Occurs when OpenGL drawing should be performed.
        /// </summary>
        [Description("Called whenever OpenGL drawing should occur."), Category("CSharpGL")]
        public event GLEventHandler<PaintEventArgs> OpenGLDraw;

    }
}