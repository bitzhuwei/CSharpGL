using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// This helps to get last vertex's id of picked primitive.
    /// </summary>
    public static class IColorCodedPickingHelper
    {
        /// <summary>
        /// Returns last vertex's id of picked geometry if the geometry represented by <paramref name="stageVertexId"/> belongs to this <paramref name="element"/> instance.
        /// <para>Returns false if <paramref name="stageVertexId"/> the primitive is in some other element.</para>
        /// </summary>
        /// <param name="element"></param>
        /// <param name="stageVertexId"></param>
        /// <param name="lastVertexId"></param>
        /// <returns></returns>
        public static bool GetLastVertexIdOfPickedGeometry(this IColorCodedPicking element, uint stageVertexId, out uint lastVertexId)
        {
            lastVertexId = uint.MaxValue;
            bool result = false;

            if (element != null)
            {
                if (stageVertexId < element.PickingBaseID) // ID is in some previous element.
                { return false; }

                uint vertexCount = element.GetVertexCount();
                uint id = stageVertexId - element.PickingBaseID;
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

        /// <summary>
        /// Get geometry's index(start from 0) according to <paramref name="lastVertexId"/> and <paramref name="mode"/>.
        /// <para>Returns false if failed.</para>
        /// </summary>
        /// <param name="element"></param>
        /// <param name="mode"></param>
        /// <param name="lastVertexId">Refers to the last vertex that constructs the primitive.
        /// <para>Ranges from 0 to (<paramref name="element"/>'s vertices' count - 1).</para></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static bool GetGeometryIndex(this IColorCodedPicking element, PrimitiveMode mode, uint lastVertexId, out uint index)
        {
            index = uint.MaxValue;
            if (element == null) { return false; }

            uint vertexCount = element.GetVertexCount();

            if (lastVertexId < vertexCount)
            {
                switch (mode)
                {
                    case PrimitiveMode.Points:
                        // vertexID should range from 0 to vertexCount - 1.
                        index = lastVertexId;
                        break;
                    case PrimitiveMode.Lines:
                        // vertexID should range from 0 to vertexCount - 1.
                        index = lastVertexId / 2;
                        break;
                    case PrimitiveMode.LineLoop:
                        // vertexID should range from 0 to vertexCount.
                        if (lastVertexId == 0) // This is the last primitive.
                        { index = vertexCount - 1; }
                        else
                        { index = lastVertexId - 1; }
                        break;
                    case PrimitiveMode.LineStrip:
                        index = lastVertexId - 1;// If lastVertexId is 0, this returns -1.
                        break;
                    case PrimitiveMode.Triangles:
                        index = lastVertexId / 3;
                        break;
                    case PrimitiveMode.TriangleStrip:
                        index = lastVertexId - 2;// if lastVertexId is 0 or 1, this returns -2 or -1.
                        break;
                    case PrimitiveMode.TriangleFan:
                        index = lastVertexId - 2;// if lastVertexId is 0 or 1, this returns -2 or -1.
                        break;
                    case PrimitiveMode.Quads:
                        index = lastVertexId / 4;
                        break;
                    case PrimitiveMode.QuadStrip:
                        index = lastVertexId / 2 - 1;// If lastVertexId is 0 or 1, this returns -1.
                        break;
                    case PrimitiveMode.Polygon:
                        index = 0;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }

            return true;
        }

        /// <summary>
        /// Get geometry's count according to specified <paramref name="mode"/>.
        /// <para>Returns false if the <paramref name="element"/> is null.</para>
        /// </summary>
        /// <param name="element"></param>
        /// <param name="mode"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static bool GetGeometryCount(this IColorCodedPicking element, PrimitiveMode mode, out uint count)
        {
            bool result = false;
            count = uint.MaxValue;

            if (element != null)
            {
                uint vertexCount = element.GetVertexCount();

                switch (mode)
                {
                    case PrimitiveMode.Points:
                        count = vertexCount;
                        break;
                    case PrimitiveMode.Lines:
                        count = vertexCount / 2;
                        break;
                    case PrimitiveMode.LineLoop:
                        count = vertexCount;
                        break;
                    case PrimitiveMode.LineStrip:
                        count = vertexCount - 1;
                        break;
                    case PrimitiveMode.Triangles:
                        count = vertexCount / 3;
                        break;
                    case PrimitiveMode.TriangleStrip:
                        count = vertexCount - 2;
                        break;
                    case PrimitiveMode.TriangleFan:
                        count = vertexCount - 2;
                        break;
                    case PrimitiveMode.Quads:
                        count = vertexCount / 4;
                        break;
                    case PrimitiveMode.QuadStrip:
                        count = vertexCount / 2 - 1;
                        break;
                    case PrimitiveMode.Polygon:
                        count = 1;
                        break;
                    default:
                        throw new NotImplementedException();
                }

                result = true;
            }

            return result;
        }
    }
}
