namespace DrvSimu
{
    public partial class DrvSimuControl
    {
        protected override void Dispose(bool disposing)
        {
            this.cameraManipulater.Unbind();

            base.Dispose(disposing);
        }
    }
}