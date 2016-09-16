using System;

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
        /// <param name="partCount">24 as default.</param>
        public UIAxis(
            System.Windows.Forms.AnchorStyles anchor, System.Windows.Forms.Padding margin,
            System.Drawing.Size size, int partCount = 24)
            : base(anchor, margin, size, -Math.Max(size.Width, size.Height), Math.Max(size.Width, size.Height))
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(ManifestResourceLoader.LoadTextFile(@"Resources\Simple.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(@"Resources\Simple.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("in_Position", Axis.strPosition);
            map.Add("in_Color", Axis.strColor);
            var renderer = new Renderer(new Axis(partCount, 0.5f), shaderCodes, map);

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
            float length = Math.Max(this.Size.Width, this.Size.Height);
            mat4 model = glm.scale(mat4.identity(),
                new vec3(length, length, length));
            var renderer = this.Renderer as Renderer;
            renderer.SetUniform("projectionMatrix", projection);
            renderer.SetUniform("viewMatrix", view);
            renderer.SetUniform("modelMatrix", model);

            base.DoRender(arg);
        }
    }
}