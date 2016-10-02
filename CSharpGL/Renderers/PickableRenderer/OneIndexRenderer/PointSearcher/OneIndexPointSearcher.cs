namespace CSharpGL
{
    internal abstract class OneIndexPointSearcher
    {
        internal abstract uint Search(RenderEventArgs arg,
            int x, int y,
            RecognizedPrimitiveInfo lastIndexId,
            OneIndexRenderer modernRenderer);
    }
}