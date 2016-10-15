namespace CSharpGL
{
    public partial class PickableRenderer
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        protected override void DoRender(RenderEventArgs arg)
        {
            if (arg.PickingGeometryType == PickingGeometryType.None)
            {
                base.DoRender(arg);
            }
            else
            {
                this.innerPickableRenderer.Render(arg);
            }
        }
    }
}