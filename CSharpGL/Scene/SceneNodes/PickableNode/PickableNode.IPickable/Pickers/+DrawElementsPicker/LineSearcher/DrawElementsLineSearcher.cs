namespace CSharpGL
{
    internal abstract class DrawElementsLineSearcher
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="primitiveInfo"></param>
        /// <param name="picker"></param>
        /// <returns></returns>
        internal abstract uint[] Search(PickingEventArgs arg,
            RecognizedPrimitiveInfo primitiveInfo,
            DrawElementsPicker picker);
    }
}