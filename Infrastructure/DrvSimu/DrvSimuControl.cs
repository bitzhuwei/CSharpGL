using CSharpGL;

namespace DrvSimu
{
    public partial class DrvSimuCanvas : GLCanvas
    {
        public Scene Scene { get; private set; }
        private SatelliteManipulater cameraManipulater;

        public DrvSimuCanvas()
        {
            if (!this.designMode)
            {
                this.Load += ScientificCanvas_Load;
            }
        }
    }
}