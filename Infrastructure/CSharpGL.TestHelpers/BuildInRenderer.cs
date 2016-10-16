namespace CSharpGL
{
    public class BuildInRenderer : Renderer
    {
        public BuildInRenderer(vec3 lengths, IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, params GLSwitch[] switches)
            : base(model, shaderCodes, attributeMap, switches)
        {
            this.ModelSize = lengths;
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            this.SetUniform("projection", arg.Camera.GetProjectionMatrix());
            this.SetUniform("view", arg.Camera.GetViewMatrix());
            mat4 model;
            if (this.GeUpdatedModelMatrix(out model))
            {
                this.SetUniform("model", model);
            }

            base.DoRender(arg);
        }
    }
}