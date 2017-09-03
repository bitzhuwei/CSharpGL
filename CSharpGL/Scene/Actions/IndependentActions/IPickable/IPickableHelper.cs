namespace CSharpGL
{
    /// <summary>
    /// This helps to get last vertex's id of picked primitive.
    /// </summary>
    public static class IPickableHelper
    {
        /// <summary>
        /// Returns last vertex's id of picked geometry if the geometry represented by <paramref name="stageVertexId"/> belongs to this <paramref name="element"/> instance.
        /// <para>Returns false if <paramref name="stageVertexId"/> the primitive is in some other element.</para>
        /// </summary>
        /// <param name="element"></param>
        /// <param name="stageVertexId"></param>
        /// <param name="lastVertexId"></param>
        /// <returns></returns>
        public static bool GetLastVertexIdOfPickedGeometry(this IPickable element,
            uint stageVertexId, out uint lastVertexId)
        {
            lastVertexId = uint.MaxValue;
            bool result = false;

            if (element != null)
            {
                if (stageVertexId < element.PickingBaseId) // ID is in some previous element.
                { return false; }

                uint vertexCount = element.GetVertexCount();
                uint id = stageVertexId - element.PickingBaseId;
                if (id < vertexCount)
                {
                    lastVertexId = id;
                    result = true;
                }
                else // ID is in some subsequent element.
                {
                    result = false;
                }
            }

            return result;
        }
    }
}