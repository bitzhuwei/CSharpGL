namespace CSharpGL
{
    internal abstract class OneIndexPointSearcher
    {
        internal abstract uint Search(RenderEventArgs arg,
            int x, int y,
            RecognizedPrimitiveIndex lastIndexId,
            OneIndexRenderer modernRenderer);
    }
}