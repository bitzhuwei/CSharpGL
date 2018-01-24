using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public partial class Teapot : IBufferSource
    {
        public vec3 GetModelSize()
        {
            return new vec3(3.214815f * 2, 1.575f * 2, 2.0f * 2);
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strColor = "color";
        private VertexBuffer colorBuffer;
        public const string strNormal = "normal";
        private VertexBuffer normalBuffer;

        private IDrawCommand drawCmd;

        #region IBufferable 成员

        public IEnumerable<VertexBuffer> GetVertexAttributeBuffer(string bufferName)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = Teapot.positionData.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else if (bufferName == strColor)
            {
                if (this.colorBuffer == null)
                {
                    this.colorBuffer = Teapot.colorData.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.colorBuffer;
            }
            else if (bufferName == strNormal)
            {
                if (this.normalBuffer == null)
                {
                    this.normalBuffer = Teapot.normalData.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.normalBuffer;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand()
        {
            if (this.drawCmd == null)
            {
                //var result = GenerateAdjacentFaces(Teapot.faceData);
                //PirntAdjacentFaces(result);
                //AdjacentFace[] faces = Teapot.adjacentFaceData;
                Face[] faces = Teapot.faceData;
                IndexBuffer buffer = faces.GenIndexBuffer(IndexBufferElementType.UShort, BufferUsage.StaticDraw);
                this.drawCmd = new DrawElementsCmd(buffer, DrawMode.Triangles);
            }

            yield return this.drawCmd;
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

        /// <summary>
        /// GenerateAdjacentFaces(Teapot.faceData); for GL_TRIANLES model 'teapot'.
        /// </summary>
        /// <param name="faces"></param>
        private AdjacentFace[] GenerateAdjacentFaces(Face[] faces)
        {
            Dictionary<Edge, SharedFaces> dict = GenerateDict(faces);

            AdjacentFace[] result = GenerateAdjacentFaces(faces, dict);

            return result;
        }

        private AdjacentFace[] GenerateAdjacentFaces(Face[] faces, Dictionary<Edge, SharedFaces> dict)
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

        private Dictionary<Edge, SharedFaces> GenerateDict(Face[] faces)
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

        #endregion
    }

    internal class SharedFaces
    {
        public int face1;
        public int face2;

        public SharedFaces(int f1, int f2)
        {
            this.face1 = f1;
            this.face2 = f2;
        }
    }

    internal class Edge
    {
        public readonly ushort vertexId1;
        public readonly ushort vertexId2;

        public Edge(ushort v1, ushort v2)
        {
            this.vertexId1 = v1;
            this.vertexId2 = v2;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", this.vertexId1, this.vertexId2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }

            var other = (Edge)obj;
            if (this.vertexId1 != other.vertexId1) { return false; }
            if (this.vertexId2 != other.vertexId2) { return false; }

            return true;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}
