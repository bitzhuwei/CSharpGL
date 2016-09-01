namespace CSharpGL
{
    partial class InnerPickableRenderer
    {
        protected override void DoRender(RenderEventArgs arg)
        {
            if (arg.RenderMode == RenderModes.ColorCodedPicking)
            {
                ColorCodedRender(arg);
            }
            else if (arg.RenderMode == RenderModes.Render)
            {
                base.DoRender(arg);
            }
        }
    }
}