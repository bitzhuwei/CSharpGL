namespace CSharpGL
{
    internal abstract class DrawArraysLineSearcher
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="flatColorVertexId"></param>
        /// <param name="stageVertexId"></param>
        /// <param name="picker"></param>
        /// <returns></returns>
        internal abstract uint[] Search(PickingEventArgs arg,
            uint flatColorVertexId, uint stageVertexId, DrawArraysPicker picker);
    }
}