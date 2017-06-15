using CSharpGL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPLY
{
    class PLYModel : IBufferable
    {
        public const string strPosition = "position";
        public const string strColor = "color";

        private VertexBuffer positionBuffer;
        private VertexBuffer colorBuffer;
        private OneIndexBuffer indexBuffer;

        private static readonly char[] separator = new char[] { ' ' };

        public PLYModel(string filename)
        {
            var positions = new List<vec3>();
            var colors = new List<vec3>();
            var indexes = new List<uint>();

            using (var reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 11)// position + color
                    {
                        var x = float.Parse(parts[0]);
                        var y = float.Parse(parts[1]);
                        var z = float.Parse(parts[2]);
                        var r = int.Parse(parts[7]);
                        var g = int.Parse(parts[8]);
                        var b = int.Parse(parts[9]);
                        positions.Add(new vec3(x, y, z));
                        colors.Add(new vec3(r / 255.0f, g / 255.0f, b / 255.0f));
                    }
                    else if (parts.Length == 5)// index
                    {
                        var a = uint.Parse(parts[1]);
                        var b = uint.Parse(parts[2]);
                        var c = uint.Parse(parts[3]);
                        indexes.Add(a);
                        indexes.Add(b);
                        indexes.Add(c);
                    }
                }
            }
            {
                var array = positions.ToArray();
                array.Move2Center();
                this.positionBuffer = array.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
            }
            {
                var array = colors.ToArray();
                this.colorBuffer = array.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
            }
            {
                var array = indexes.ToArray();
                this.indexBuffer = array.GenIndexBuffer(DrawMode.Triangles, BufferUsage.StaticDraw);
            }
        }

        #region IBufferable 成员

        public VertexBuffer GetVertexAttributeBuffer(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                return this.positionBuffer;
            }
            else if (bufferName == strColor)
            {
                return this.colorBuffer;
            }

            throw new NotImplementedException();
        }

        public IndexBuffer GetIndexBuffer()
        {
            return this.indexBuffer;
        }

        #endregion
    }
}
