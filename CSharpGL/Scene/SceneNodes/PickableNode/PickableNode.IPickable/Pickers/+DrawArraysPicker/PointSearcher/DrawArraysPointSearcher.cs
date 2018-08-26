namespace CSharpGL
{
    internal abstract class DrawArraysPointSearcher
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="singleNodeVertexId">identify location inside this node.</param>
        /// <param name="stageVertexId">identify location when rendering multiple nodes.</param>
        /// <param name="picker"></param>
        /// <returns></returns>
        internal abstract uint Search(PickingEventArgs arg,
            uint singleNodeVertexId, uint stageVertexId, DrawArraysPicker picker);
    }
}