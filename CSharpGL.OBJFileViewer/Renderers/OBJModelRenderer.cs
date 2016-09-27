namespace CSharpGL.OBJFileViewer
{
    using CSharpGL;
    using CSharpGL.OBJFile;
    using System.IO;

    /// <summary>
    /// 一个<see cref="OBJModelRenderer"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// </summary>
    public class OBJModelRenderer : Renderer
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="singleModel"></param>
        /// <returns></returns>
        public static OBJModelRenderer Create(OBJModel singleModel)
        {
            var model = new OBJModelAdpater(singleModel);
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\ObjFile.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\ObjFile.frag"), ShaderType.FragmentShader);
            var map = new AttributeNameMap();
            map.Add("in_Position", OBJModelAdpater.strin_Position);
            map.Add("in_Color", OBJModelAdpater.strin_Color);
            //map.Add("in_Normal", OBJModelAdpater.strin_Normal);
            var renderer = new OBJModelRenderer(model, shaderCodes, map);

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