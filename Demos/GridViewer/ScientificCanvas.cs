using CSharpGL;

namespace GridViewer
{
    public partial class ScientificCanvas : GLCanvas
    {
        public Scene Scene { get; private set; }
        private SatelliteManipulater cameraManipulater;

        public ScientificCanvas()
        {
            if (!this.designMode)
            {
                this.Load += ScientificCanvas_Load;
            }
        }
    }
}