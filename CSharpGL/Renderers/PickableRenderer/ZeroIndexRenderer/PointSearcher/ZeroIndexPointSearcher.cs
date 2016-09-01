namespace CSharpGL
{
    internal abstract class ZeroIndexPointSearcher
    {
        internal abstract uint Search(RenderEventArgs arg,
            int x, int y,
            uint lastVertexId, ZeroIndexRenderer modernRenderer);
    }
}