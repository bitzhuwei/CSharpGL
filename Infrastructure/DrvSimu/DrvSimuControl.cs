using CSharpGL;

namespace DrvSimu
{
    public partial class DrvSimuControl : GLCanvas
    {
        public Scene Scene { get; private set; }
        private SatelliteManipulater cameraManipulater;

        public DrvSimuControl()
        {
            if (!this.designMode)
            {
                this.Load += ScientificCanvas_Load;
            }
        }
    }
}