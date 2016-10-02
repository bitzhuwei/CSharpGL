namespace CSharpGL
{
    internal abstract class OneIndexLineSearcher
    {
        internal abstract uint[] Search(RenderEventArgs arg,
            int x, int y,
            RecognizedPrimitiveInfo lastIndexId,
            OneIndexRenderer modernRenderer);
    }
}