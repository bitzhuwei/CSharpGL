using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// opengl UI for Axis
    /// </summary>
    public class UIAxis : UIRenderer
    {

        /// <summary>
        /// opengl UI for Axis
        /// </summary>
        /// <param name="anchor"></param>
        /// <param name="margin"></param>
        /// <param name="size"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public UIAxis(
            System.Windows.Forms.AnchorStyles anchor, System.Windows.Forms.Padding margin,
            System.Drawing.Size size, int zNear, int zFar, int partCount = 24)
            : base(anchor, margin, size, zNear, zFar)
        {
            AxisRenderer renderer = AxisRenderer.Create(partCount);

            this.Renderer = renderer;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        protected override void DoRender(RenderEventArgs arg)
        {
            ICamera camera = arg.Camera;
            mat4 projection = this.GetOrthoProjection();
            vec3 position = (camera.Position - camera.Target).normalize();
            mat4 view = glm.lookAt(position, new vec3(0, 0, 0), camera.UpVector);
            float length = Math.Max(this.Size.Width, this.Size.Height) / 2;
            mat4 model = glm.scale(mat4.identity(),
                new vec3(length, length, length));
            Renderer renderer = this.Renderer as Renderer;
            renderer.SetUniform("projectionMatrix", projection);
            renderer.SetUniform("viewMatrix", view);
            renderer.SetUniform("modelMatrix", model);

            base.DoRender(arg);
        }
    }
}
