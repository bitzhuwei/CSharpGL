using CSharpGL.Maths;
using CSharpGL.Objects.Cameras;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace CSharpGL.Objects.UI.SimpleUI
{
    /// <summary>
    /// Draw a rectangle on OpenGL control like a <see cref="Windows.Forms.Control"/> drawn on a <see cref="windows.Forms.Form"/>.
    /// Set its properties(Anchor, Margin, Size, etc) to adjust its behaviour.
    /// </summary>
    public class LegacySimpleUIRect : SceneElementBase, IUILayout//, IRenderable, IHasObjectSpace
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

        protected override void DoRender(RenderModes renderMode)
        {
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
        }

        public IUILayoutParam Param { get; set; }
    }
}
