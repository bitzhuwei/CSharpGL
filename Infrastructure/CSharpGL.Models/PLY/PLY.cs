using System;
using System.Collections.Generic;
using System.IO;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class PLY : IBufferable
    {
        /// <summary>
        /// 
        /// </summary>
        public vec3 ModelSize { get; private set; }

        public const string strPosition = "position";

        public const string strColor = "color";

        private VertexBuffer positionBuffer;

        //private VertexBuffer colorBuffer;

        private OneIndexBuffer indexBuffer;

        private static readonly char[] separator = new char[]
		{
			' '
		};

        public PLY()
        {
            var positions = new List<vec3>();
            var indexes = new List<uint>();
            using (var reader = new System.IO.StreamReader("dragon.ply"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 3)
                    {
                        float x = float.Parse(parts[0]);
                        float y = float.Parse(parts[1]);
                        float z = float.Parse(parts[2]);
                        positions.Add(new vec3(x, y, z));
                    }
                    else if (parts.Length == 4)
                    {
                        uint index0 = uint.Parse(parts[1]);
                        uint index1 = uint.Parse(parts[2]);
                        uint index2 = uint.Parse(parts[3]);
                        indexes.Add(index0);
                        indexes.Add(index1);
                        indexes.Add(index2);
                    }
                }
            }
            {
                vec3[] array = positions.ToArray();
                IBoundingBox boundingBox = array.Move2Center();
                this.ModelSize = boundingBox.MaxPosition - boundingBox.MinPosition;
                this.positionBuffer = array.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
            }
            {
                uint[] array = indexes.ToArray();
                this.indexBuffer = array.GenIndexBuffer(DrawMode.Triangles, BufferUsage.StaticDraw);
            }
        }

        public VertexBuffer GetVertexAttributeBuffer(string bufferName, string varNameInShader)
        {
            VertexBuffer result = null;

            if (bufferName == "position")
            {
                result = this.positionBuffer;
            }
            //else
            //{
            //    if (!(bufferName == "color"))
            //    {
            //        throw new System.NotImplementedException();
            //    }
            //    result = this.colorBuffer;
            //}

            return result;
        }

        public IndexBuffer GetIndexBuffer()
        {
            return this.indexBuffer;
        }
    }
}
