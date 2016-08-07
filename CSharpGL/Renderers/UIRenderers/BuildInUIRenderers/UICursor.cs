using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// opengl UI for Cursor
    /// </summary>
    public class UICursor : UIRenderer
    {

        /// <summary>
        /// opengl UI for Cursor
        /// </summary>
        /// <param name="anchor"></param>
        /// <param name="margin"></param>
        /// <param name="size"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public UICursor(
            System.Windows.Forms.AnchorStyles anchor, System.Windows.Forms.Padding margin,
            System.Drawing.Size size, int zNear, int zFar, string cursorBitmap = "")
            : base(anchor, margin, size, zNear, zFar)
        {
            SquareRenderer renderer = SquareRenderer.Create(cursorBitmap);

            this.Renderer = renderer;
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            this.Renderer.Initialize();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        protected override void DoRender(RenderEventArg arg)
        {
            mat4 projection = this.GetOrthoProjection();
            mat4 view = glm.lookAt(new vec3(0, 0, 1), new vec3(0, 0, 0), new vec3(0, 1, 0));
            mat4 model = glm.scale(mat4.identity(), new vec3(this.Size.Width, this.Size.Height, 1));
            var renderer = this.Renderer as Renderer;
            renderer.SetUniform("mvp", projection * view * model);

            base.DoRender(arg);
        }
    }
}
