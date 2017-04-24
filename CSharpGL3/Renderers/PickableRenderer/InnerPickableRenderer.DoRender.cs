namespace CSharpGL
{
    partial class InnerPickableRenderer
    {
        protected override void DoRender(RenderEventArgs arg)
        {
            if (arg.PickingGeometryType == PickingGeometryType.None)
            {
                base.DoRender(arg);
            }
            else
            {
                this.Render4Picking(arg);
            }
        }
    }
}