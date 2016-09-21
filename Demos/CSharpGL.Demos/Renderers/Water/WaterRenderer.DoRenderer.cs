using System;
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

            this.backgroundRenderer.passedTime = passedTime;
            this.backgroundRenderer.Render(arg);

            this.waterTextureRenderer.passedTime = passedTime;
            this.waterTextureRenderer.Render(arg);

            base.DoRender(arg);

            passedTime += deltaTime;
            //angle += 2.0f * (float)Math.PI / 120.0f * deltaTime;
        }

        static float passedTime = 0.0f;
        static float deltaTime = 1f;//todo: experimental value.

        //static float angle = 0.0f;

    }

}