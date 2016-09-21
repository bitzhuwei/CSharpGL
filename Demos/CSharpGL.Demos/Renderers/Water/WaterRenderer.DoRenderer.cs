namespace CSharpGL.Demos
{
    internal partial class WaterRenderer
    {
        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            mat4 inverseView = glm.inverse(view);
            //mat4 model = this.GetModelMatrix();
            this.SetUniform("u_projectionMatrix", projection);
            this.SetUniform("u_viewMatrix", view);
            this.SetUniform("u_inverseViewNormalMatrix", new mat3(new vec3(view[0]), new vec3(view[1]), new vec3(view[2])));
            this.SetUniform("u_passedTime", passedTime);
            this.SetUniform("u_waveParameters", WaterTextureRenderer.ToFloat(WaterTextureRenderer.waveParameters));
            this.SetUniform("u_waveDirections", WaterTextureRenderer.ToFloat(WaterTextureRenderer.waveDirections));

            this.cullfaceSwitch.On();

            this.backgroundRenderer.passedTime = passedTime;
            this.backgroundRenderer.Render(arg);

            this.waterTextureRenderer.passedTime = passedTime;
            this.waterTextureRenderer.Render(arg);

            base.DoRender(arg);

            this.cullfaceSwitch.Off();

            passedTime += deltaTime;
        }

        private static float passedTime = 0.0f;
        private static float deltaTime = 1f;//todo: experimental value.
    }
}