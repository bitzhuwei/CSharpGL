using GLM;
using CSharpGL.Objects.Cameras;
using CSharpGL.UIs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace CSharpGL.Objects.Demos.UIs
{
    /// <summary>
    /// Draw a rectangle on OpenGL control like a <see cref="Windows.Forms.Control"/> drawn on a <see cref="windows.Forms.Form"/>.
    /// Set its properties(Anchor, Margin, Size, etc) to adjust its behaviour.
    /// </summary>
    public class LegacySimpleUIRect : RendererBase, IUILayout//, IRenderable, IHasObjectSpace
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="anchor">the edges of the viewport to which a SimpleUIRect is bound and determines how it is resized with its parent.
        /// <para>something like AnchorStyles.Left | AnchorStyles.Bottom.</para></param>
        /// <param name="margin">the space between viewport and SimpleRect.</param>
        /// <param name="size">Stores width when <see cref="OpenGLUIRect.Anchor"/>.Left & <see cref="OpenGLUIRect.Anchor"/>.Right is <see cref="OpenGLUIRect.Anchor"/>.None.
        /// <para> and height when <see cref="OpenGLUIRect.Anchor"/>.Top & <see cref="OpenGLUIRect.Anchor"/>.Bottom is <see cref="OpenGLUIRect.Anchor"/>.None.</para></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        /// <param name="rectColor">default color is red.</param>
        //public LegacySimpleUIRect(AnchorStyles anchor, Padding margin, System.Drawing.Size size, int zNear = -1000, int zFar = 1000, GLColor rectColor = null)
        public LegacySimpleUIRect(IUILayoutParam param, GLColor rectColor = null)
        {
            this.Param = param;

            if (rectColor == null)
            { this.RectColor = new GLColor(1, 0, 0, 1); }
            else
            { this.RectColor = rectColor; }
        }

        public GLColor RectColor { get; set; }

        protected override void DoInitialize()
        {
        }

        void legacyUIRect_AfterRendering(object sender, Objects.RenderEventArgs e)
        {
            LegacySimpleUIRect element = sender as LegacySimpleUIRect;

            GL.MatrixMode(GL.GL_PROJECTION);
            GL.PopMatrix();

            GL.MatrixMode(GL.GL_MODELVIEW);
            GL.PopMatrix();
        }

        void legacyUIRect_BeforeRendering(object sender, Objects.RenderEventArgs e)
        {
            LegacySimpleUIRect element = sender as LegacySimpleUIRect;

            IUILayoutArgs args = element.GetArgs();

            GL.MatrixMode(GL.GL_PROJECTION);
            GL.PushMatrix();
            GL.LoadIdentity();
            GL.Ortho((float)args.left, (float)args.right, (float)args.bottom, (float)args.top, element.Param.zNear, element.Param.zFar);
            //GL.Ortho(args.left / 2, args.right / 2, args.bottom / 2, args.top / 2, element.Param.zNear, element.Param.zFar);

            IViewCamera camera = e.Camera;

            if (camera == null)
            {
                GL.gluLookAt(0, 0, 1, 0, 0, 0, 0, 1, 0);
                //throw new Exception("Camera not set!");
            }
            else
            {
                vec3 position = camera.Position - camera.Target;
                position.Normalize();
                GL.gluLookAt(position.x, position.y, position.z,
                    0, 0, 0,
                    camera.UpVector.x, camera.UpVector.y, camera.UpVector.z);
            }

            GL.MatrixMode(GL.GL_MODELVIEW);
            GL.PushMatrix();
            GL.Scale(args.UIWidth / 2, args.UIHeight / 2, args.UIWidth);

        }

        protected override void DoRender(RenderEventArgs e)
        {
            legacyUIRect_BeforeRendering(this, e);
            //PushObjectSpace();

            GL.Begin(PrimitiveModes.LineLoop);
            GL.Color(RectColor);
            //GL.Vertex(-args.UIWidth / 2, -args.UIHeight / 2, 0);
            //GL.Vertex(args.UIWidth / 2, -args.UIHeight / 2, 0);
            //GL.Vertex(args.UIWidth / 2, args.UIHeight / 2, 0);
            //GL.Vertex(-args.UIWidth / 2, args.UIHeight / 2, 0);
            GL.Vertex(-1, -1, 0);
            GL.Vertex(1, -1, 0);
            GL.Vertex(1, 1, 0);
            GL.Vertex(-1, 1, 0);
            GL.End();

            //PopObjectSpace();
            legacyUIRect_AfterRendering(this, e);
        }

        public IUILayoutParam Param { get; set; }

        protected override void DisposeUnmanagedResources()
        {
        }
    }
}
