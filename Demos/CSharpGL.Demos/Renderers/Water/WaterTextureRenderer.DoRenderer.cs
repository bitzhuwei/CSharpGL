namespace CSharpGL.Demos
{
    internal partial class WaterTextureRenderer
    {

        protected override void DoRender(RenderEventArgs arg)
        {
            UpdateWaves();

            //this.viewportSwitch.On();
            this.framebuffer.Bind();
            OpenGL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            this.SetUniform("u_passedTime", this.passedTime);
            this.SetUniform("u_waveParameters", ToFloat(waveParameters));
            this.SetUniform("u_waveDirections", ToFloat(waveDirections));

            base.DoRender(arg);

            this.framebuffer.Unbind();
            //this.viewportSwitch.Off();
        }

        const int NUMBERWAVES = 4;
        static float overallSteepness = 0.2f;
        public static WaveParameters[] waveParameters = new WaveParameters[NUMBERWAVES];
        public static WaveDirections[] waveDirections = new WaveDirections[NUMBERWAVES];

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

        public static float[] ToFloat(WaveParameters[] items)
        {
            var result = new float[items.Length * 4];
            for (int i = 0; i < items.Length; i++)
            {
                result[i * 4 + 0] = items[i].speed;
                result[i * 4 + 1] = items[i].amplitude;
                result[i * 4 + 2] = items[i].wavelength;
                result[i * 4 + 3] = items[i].steepness;
            }
            return result;
        }
        public static float[] ToFloat(WaveDirections[] items)
        {
            var result = new float[items.Length * 2];
            for (int i = 0; i < items.Length; i++)
            {
                result[i * 2 + 0] = items[i].x;
                result[i * 2 + 1] = items[i].z;
            }
            return result;
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