namespace CSharpGL
{
    internal abstract class DrawArraysLineSearcher
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="lastVertexId"></param>
        /// <param name="picker"></param>
        /// <returns></returns>
        internal abstract uint[] Search(PickingEventArgs arg,
            uint lastVertexId, DrawArraysPicker picker);
    }
}