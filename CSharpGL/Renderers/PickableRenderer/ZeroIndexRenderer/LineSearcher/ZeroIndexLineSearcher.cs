namespace CSharpGL
{
    internal abstract class ZeroIndexLineSearcher
    {
        internal abstract uint[] Search(RenderEventArgs arg,
            int x, int y,
            uint lastVertexId, ZeroIndexRenderer modernRenderer);
    }
}