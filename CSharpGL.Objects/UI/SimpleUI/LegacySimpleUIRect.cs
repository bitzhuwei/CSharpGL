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
        }

        /// <summary>
        /// render UI model at axis's center(0, 0, 0) in <paramref name="UIWidth"/> and <paramref name="UIHeight"/>.
        /// <para>The <see cref="LegacySimpleUIRect.RenderMode()"/> only draws a rectangle to show the UI's scope.</para>
        /// </summary>
        /// <param name="UIWidth"></param>
        /// <param name="UIHeight"></param>
        /// <param name="gl"></param>
        /// <param name="renderMode"></param>
        protected virtual void RenderModel(RenderModes renderMode)
        {
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
        }

        //protected int viewWidth;
        //protected int viewHeight;
        //protected int UIWidth;
        //protected int UIHeight;
        //protected int left;
        //protected int bottom;
        //protected IUILayoutArgs args = new IUILayoutArgs();

        /// <summary>
        /// if Camera is null, this UI rectangle area will be drawn with an invoking
        /// <para>gl.LookAt(0, 0, 1, 0, 0, 0, 0, 1, 0);</para>
        /// <para>otherwise, it uses gl.LookAt(Camera's (Position - Target), Target, UpVector);</para>
        /// </summary>
        public virtual IScientificCamera Camera { get; set; }

        public GLColor RectColor { get; set; }

        #region IHasObjectSpace 成员

        /// <summary>
        /// Prepare projection matrix.
        /// </summary>
        /// <param name="gl"></param>
        public virtual void PushObjectSpace()
        {
            //this.args = new IUILayoutArgs();
            ////int viewWidth;
            ////int viewHeight;
            //CalculateViewport(args);

            ////int UIWidth, UIHeight, left, bottom;
            //CalculateCoords(args.viewportWidth, args.viewportHeight, args);
            var args = this.GetArgs();

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
            GL.Scale(args.UIWidth / 2, args.UIHeight / 2, 1);
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

            RenderModel(renderMode);

            PopObjectSpace();
        }

        public IUILayoutParam Param { get; set; }
    }
}
