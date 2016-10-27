namespace DrvSimu
{
    public partial class ScientificCanvas
    {
        protected override void Dispose(bool disposing)
        {
            this.cameraManipulater.Unbind();

            base.Dispose(disposing);
        }
    }
}