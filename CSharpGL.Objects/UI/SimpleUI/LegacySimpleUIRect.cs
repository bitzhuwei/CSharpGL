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
        public LegacySimpleUIRect(IUILayoutParam param,
            //AnchorStyles anchor, Padding margin, System.Drawing.Size size, int zNear = -1000, int zFar = 1000, 
            GLColor rectColor = null)
        {
            this.Param = param;

            if (rectColor == null)
            { this.RectColor = new GLColor(1, 0, 0, 1); }
            else
            { this.RectColor = new GLColor(1, 0, 0, 1); }

            this.RenderBound = true;
        }

        #region IRenderable 成员

        protected void CalculateViewport(IUILayoutArgs args)
        {
            int[] viewport = new int[4];
            GL.GetInteger(GetTarget.Viewport, viewport);
            args.viewportWidth = viewport[2];
            args.viewportHeight = viewport[3];
        }

        protected void CalculateCoords(int viewWidth, int viewHeight, IUILayoutArgs args)
        {
            if ((this.Param.Anchor & leftRightAnchor) == leftRightAnchor)
            {
                args.UIWidth = viewWidth - this.Param.Margin.Left - this.Param.Margin.Right;
                if (args.UIWidth < 0) { args.UIWidth = 0; }
            }
            else
            {
                args.UIWidth = this.Param.Size.Width;
            }

            if ((this.Param.Anchor & topBottomAnchor) == topBottomAnchor)
            {
                args.UIHeight = viewHeight - this.Param.Margin.Top - this.Param.Margin.Bottom;
                if (args.UIHeight < 0) { args.UIHeight = 0; }
            }
            else
            {
                args.UIHeight = this.Param.Size.Height;
            }

            if ((this.Param.Anchor & leftRightAnchor) == AnchorStyles.None)
            {
                args.left = -(args.UIWidth / 2
                    + (viewWidth - args.UIWidth) * ((double)this.Param.Margin.Left / (double)(this.Param.Margin.Left + this.Param.Margin.Right)));
            }
            else if ((this.Param.Anchor & leftRightAnchor) == AnchorStyles.Left)
            {
                args.left = -(args.UIWidth / 2 + this.Param.Margin.Left);
            }
            else if ((this.Param.Anchor & leftRightAnchor) == AnchorStyles.Right)
            {
                args.left = -(viewWidth - args.UIWidth / 2 - this.Param.Margin.Right);
            }
            else // if ((Anchor & leftRightAnchor) == leftRightAnchor)
            {
                args.left = -(args.UIWidth / 2 + this.Param.Margin.Left);
            }

            if ((this.Param.Anchor & topBottomAnchor) == AnchorStyles.None)
            {
                args.bottom = -viewHeight / 2;
                args.bottom = -(args.UIHeight / 2
                    + (viewHeight - args.UIHeight) * ((double)this.Param.Margin.Bottom / (double)(this.Param.Margin.Bottom + this.Param.Margin.Top)));
            }
            else if ((this.Param.Anchor & topBottomAnchor) == AnchorStyles.Bottom)
            {
                args.bottom = -(args.UIHeight / 2 + this.Param.Margin.Bottom);
            }
            else if ((this.Param.Anchor & topBottomAnchor) == AnchorStyles.Top)
            {
                args.bottom = -(viewHeight - args.UIHeight / 2 - this.Param.Margin.Top);
            }
            else // if ((Anchor & topBottomAnchor) == topBottomAnchor)
            {
                args.bottom = -(args.UIHeight / 2 + this.Param.Margin.Bottom);
            }
        }


        #endregion

        /// <summary>
        /// render UI model at axis's center(0, 0, 0) in <paramref name="UIWidth"/> and <paramref name="UIHeight"/>.
        /// <para>The <see cref="LegacySimpleUIRect.RenderMode()"/> only draws a rectangle to show the UI's scope.</para>
        /// </summary>
        /// <param name="UIWidth"></param>
        /// <param name="UIHeight"></param>
        /// <param name="gl"></param>
        /// <param name="renderMode"></param>
        protected virtual void RenderModel(IUILayoutArgs args, RenderModes renderMode)
        {
            if (this.RenderBound)
            {
                GL.Begin(PrimitiveModes.LineLoop);
                GL.Color(RectColor);
                GL.Vertex(-args.UIWidth / 2, -args.UIHeight / 2, 0);
                GL.Vertex(args.UIWidth / 2, -args.UIHeight / 2, 0);
                GL.Vertex(args.UIWidth / 2, args.UIHeight / 2, 0);
                GL.Vertex(-args.UIWidth / 2, args.UIHeight / 2, 0);
                GL.End();
            }
        }

        /// <summary>
        /// leftRightAnchor = (AnchorStyles.Left | AnchorStyles.Right); 
        /// </summary>
        protected const AnchorStyles leftRightAnchor = (AnchorStyles.Left | AnchorStyles.Right);

        /// <summary>
        /// topBottomAnchor = (AnchorStyles.Top | AnchorStyles.Bottom);
        /// </summary>
        protected const AnchorStyles topBottomAnchor = (AnchorStyles.Top | AnchorStyles.Bottom);

        //protected int viewWidth;
        //protected int viewHeight;
        //protected int UIWidth;
        //protected int UIHeight;
        //protected int left;
        //protected int bottom;
        protected IUILayoutArgs args = new IUILayoutArgs();

        /// <summary>
        /// if Camera is null, this UI rectangle area will be drawn with an invoking
        /// <para>gl.LookAt(0, 0, 1, 0, 0, 0, 0, 1, 0);</para>
        /// <para>otherwise, it uses gl.LookAt(Camera's (Position - Target), Target, UpVector);</para>
        /// </summary>
        public virtual IScientificCamera Camera { get; set; }

        public GLColor RectColor { get; set; }

        public bool RenderBound { get; set; }

        #region IHasObjectSpace 成员

        /// <summary>
        /// Prepare projection matrix.
        /// </summary>
        /// <param name="gl"></param>
        public virtual void PushObjectSpace()
        {
            this.args = new IUILayoutArgs();
            //int viewWidth;
            //int viewHeight;
            CalculateViewport(args);

            //int UIWidth, UIHeight, left, bottom;
            CalculateCoords(args.viewportWidth, args.viewportHeight, args);

            GL.MatrixMode(GL.GL_PROJECTION);
            GL.PushMatrix();
            GL.LoadIdentity();
            GL.Ortho(args.left, args.right, args.bottom, args.top, this.Param.zNear, this.Param.zFar);

            IViewCamera camera = this.Camera;
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
        }

        public virtual void PopObjectSpace()
        {
            GL.MatrixMode(GL.GL_PROJECTION);
            GL.PopMatrix();

            GL.MatrixMode(GL.GL_MODELVIEW);
            GL.PopMatrix();
        }

        #endregion


        protected override void DoInitialize()
        {
        }

        protected override void DoRender(RenderModes renderMode)
        {
            PushObjectSpace();

            RenderModel(args, renderMode);

            PopObjectSpace();
        }

        public IUILayoutParam Param { get; set; }
    }
}
