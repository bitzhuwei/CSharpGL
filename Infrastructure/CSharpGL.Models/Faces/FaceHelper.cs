using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public static class FaceHelper
    {
        /// <summary>
        /// Generate adjacent faces for GL_TRIANLES model.
        /// </summary>
        /// <param name="faces"></param>
        /// <returns></returns>
        public static AdjacentFace[] CalculateAdjacentFaces(this Face[] faces)
        {
            Dictionary<Edge, SharedFaces> dict = GenerateDict(faces);

            AdjacentFace[] result = GenerateAdjacentFaces(faces, dict);

            return result;
        }

        private static void PirntAdjacentFaces(AdjacentFace[] result)
        {
            using (var sw = new System.IO.StreamWriter("adjacentFaces.txt"))
            {
                foreach (var item in result)
                {
                    sw.WriteLine(string.Format("new AdjacentFace({0}, {1}, {2}, {3}, {4}, {5}),", item.vertexId1, item.adjacentId1, item.vertexId2, item.adjacentId2, item.vertexId3, item.adjacentId3));
                }
            }
        }

        private static AdjacentFace[] GenerateAdjacentFaces(Face[] faces, Dictionary<Edge, SharedFaces> dict)
        {
            var result = new AdjacentFace[faces.Length];
            for (int i = 0; i < result.Length; i++)
            {
                var face = faces[i];
                var edges = new Edge[] { new Edge(face.vertexId1, face.vertexId2), new Edge(face.vertexId2, face.vertexId3), new Edge(face.vertexId3, face.vertexId1) };
                var adjacentVertexes = new List<ushort>();
                foreach (var edge in edges)
                {
                    SharedFaces sharedFaces;
                    if (dict.TryGetValue(edge, out sharedFaces))
                    {
                        int otherFaceIndex = sharedFaces.face1 == i ? sharedFaces.face2 : sharedFaces.face1;
                        if (otherFaceIndex == faces.Length)
                        { adjacentVertexes.Add(edge.vertexId1); }
                        else
                        {
                            Face otherFace = faces[otherFaceIndex];
                            if (otherFace.vertexId1 != edge.vertexId1
                                && otherFace.vertexId1 != edge.vertexId2)
                            { adjacentVertexes.Add(otherFace.vertexId1); }
                            else if (otherFace.vertexId2 != edge.vertexId1
                                && otherFace.vertexId2 != edge.vertexId2)
                            { adjacentVertexes.Add(otherFace.vertexId2); }
                            else if (otherFace.vertexId3 != edge.vertexId1
                                && otherFace.vertexId3 != edge.vertexId2)
                            { adjacentVertexes.Add(otherFace.vertexId3); }
                            else
                            { throw new Exception(string.Format("all 3 vertexes are on the edge?!")); }
                        }
                    }
                    else
                    {
                        throw new Exception(string.Format("Not found edge[{0}]!", edge));
                    }
                }

                if (adjacentVertexes.Count != 3) { throw new Exception("This should never happen!"); }

                var adjacentFace = new AdjacentFace(face.vertexId1, adjacentVertexes[0],
                    face.vertexId2, adjacentVertexes[1],
                    face.vertexId3, adjacentVertexes[2]);
                result[i] = adjacentFace;
            }

            return result;
        }

        private static Dictionary<Edge, SharedFaces> GenerateDict(Face[] faces)
        {
            var result = new Dictionary<Edge, SharedFaces>();

            for (int i = 0; i < faces.Length; i++)
            {
                var face = faces[i];
                var edges = new Edge[] { new Edge(face.vertexId1, face.vertexId2), new Edge(face.vertexId2, face.vertexId3), new Edge(face.vertexId3, face.vertexId1) };
                foreach (var edge in edges)
                {
                    SharedFaces sharedFaces;
                    if (result.TryGetValue(edge, out sharedFaces))
                    {
                        if (sharedFaces.face2 < faces.Length)
                        { throw new Exception(string.Format("More than 2 faces share an edge! [{0}]", i)); }

                        sharedFaces.face2 = i;
                    }
                    else
                    {
                        sharedFaces = new SharedFaces(i, faces.Length);// faces.Length is temp face index.
                        result.Add(edge, sharedFaces);
                    }
                }
            }

            return result;
        }
    }
}
