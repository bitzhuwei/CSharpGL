namespace CSharpGL.OBJFileViewer
{
    using CSharpGL;
    using CSharpGL.OBJFile;
    using System.Drawing;
    using System.IO;

    /// <summary>
    /// 一个<see cref="OBJModelRenderer"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// </summary>
    public class OBJModelRenderer : Renderer
    {
        private Bitmap bitmap;
        private Texture texture;
        /// <summary>
        ///
        /// </summary>
        /// <param name="singleModel"></param>
        /// <returns></returns>
        public static OBJModelRenderer Create(OBJModel singleModel, Bitmap bitmap)
        {
            var model = new OBJModelAdpater(singleModel);
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\ObjFile.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\ObjFile.frag"), ShaderType.FragmentShader);
            var map = new AttributeNameMap();
            map.Add("in_Position", OBJModelAdpater.strin_Position);
            map.Add("in_uv", OBJModelAdpater.strin_uv);
            //map.Add("in_Normal", OBJModelAdpater.strin_Normal);
            var renderer = new OBJModelRenderer(model, shaderCodes, map);
            renderer.bitmap = bitmap;

            return renderer;
        }

        private OBJModelRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeNameMap attributeNameMap, params GLSwitch[] switches)
            : base(model, shaderCodes, attributeNameMap, switches)
        {
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            var texture = new Texture(TextureTarget.Texture2D, this.bitmap,
                new SamplerParameters(
                    TextureWrapping.Repeat, TextureWrapping.Repeat, TextureWrapping.Repeat,
                    TextureFilter.Linear, TextureFilter.Linear));
            texture.Initialize();
            this.SetUniform("tex", texture);

            this.texture = texture;
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            this.SetUniform("projectionMatrix", projection);
            this.SetUniform("viewMatrix", view);
            this.SetUniform("modelMatrix", model);

            base.DoRender(arg);
        }
    }
}