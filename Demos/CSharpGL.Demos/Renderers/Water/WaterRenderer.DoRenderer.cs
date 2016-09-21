namespace CSharpGL.Demos
{
    internal partial class WaterRenderer
    {
        protected override void DoRender(RenderEventArgs arg)
        {
            UpdateWaves();

            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            //mat4 model = this.GetModelMatrix();
            this.SetUniform("u_projectionMatrix", projection);
            this.SetUniform("u_viewMatrix", view);
            this.SetUniform("u_inverseViewNormalMatrix", new mat3(new vec3(view[0]), new vec3(view[1]), new vec3(view[2])));

            base.DoRender(arg);
        }
        static float passedTime = 0.0f;

        static float angle = 0.0f;

        const int NUMBERWAVES = 4;
        static float overallSteepness = 0.2f;
        static WaveParameters[] waveParameters = new WaveParameters[NUMBERWAVES];
        static WaveDirections[] waveDirections = new WaveDirections[NUMBERWAVES];

        private void UpdateWaves()
        {
            // Waves can be faded in and out.

            // Wave One
            waveParameters[0].speed = 1.0f;
            waveParameters[0].amplitude = 0.01f;
            waveParameters[0].wavelength = 4.0f;
            waveParameters[0].steepness = overallSteepness / (waveParameters[0].wavelength * waveParameters[0].amplitude * (float)NUMBERWAVES);
            waveDirections[0].x = +1.0f;
            waveDirections[0].z = +1.0f;

            // Wave Two
            waveParameters[1].speed = 0.5f;
            waveParameters[1].amplitude = 0.02f;
            waveParameters[1].wavelength = 3.0f;
            waveParameters[1].steepness = overallSteepness / (waveParameters[1].wavelength * waveParameters[1].amplitude * (float)NUMBERWAVES);
            waveDirections[1].x = +1.0f;
            waveDirections[1].z = +0.0f;

            // Wave Three
            waveParameters[2].speed = 0.1f;
            waveParameters[2].amplitude = 0.015f;
            waveParameters[2].wavelength = 2.0f;
            waveParameters[2].steepness = overallSteepness / (waveParameters[1].wavelength * waveParameters[1].amplitude * (float)NUMBERWAVES);
            waveDirections[2].x = -0.1f;
            waveDirections[2].z = -0.2f;

            // Wave Four
            waveParameters[3].speed = 1.1f;
            waveParameters[3].amplitude = 0.008f;
            waveParameters[3].wavelength = 1.0f;
            waveParameters[3].steepness = overallSteepness / (waveParameters[1].wavelength * waveParameters[1].amplitude * (float)NUMBERWAVES);
            waveDirections[3].x = -0.2f;
            waveDirections[3].z = -0.1f;
        }
    }

    struct WaveParameters
    {
        public float speed;
        public float amplitude;
        public float wavelength;
        public float steepness;
    }
    struct WaveDirections
    {
        public float x;
        public float z;
    }
}