namespace DrvSimu
{
    public partial class DrvSimuCanvas
    {
        protected override void Dispose(bool disposing)
        {
            this.cameraManipulater.Unbind();

            base.Dispose(disposing);
        }
    }
}