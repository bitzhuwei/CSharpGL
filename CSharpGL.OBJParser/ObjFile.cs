using GLM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.OBJParser
{
    public class ObjFile
    {
        private List<ObjModel> models = new List<ObjModel>();

        public List<ObjModel> Models
        {
            get { return models; }
            set { models = value; }
        }

        public static ObjFile Load(string filename)
        {
            ObjFile file = new ObjFile();

            using (var sr = new StreamReader(filename))
            {
                var model = new ObjModel();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] parts = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    if (parts[0] == ("v"))
                    {
                        if (model.TriangleList.Count > 0)
                        {
                            file.models.Add(model);
                            model = new ObjModel();
                        }

                        vec3 position = new vec3(float.Parse(parts[1]), float.Parse(parts[2]), float.Parse(parts[3]));
                        model.PositionList.Add(position);
                    }
                    else if (parts[0] == ("vt"))
                    {
                        vec2 uv = new vec2(float.Parse(parts[1]), float.Parse(parts[2]));
                        model.UVList.Add(uv);
                    }
                    else if (parts[0] == ("vn"))
                    {
                        vec3 normal = new vec3(float.Parse(parts[1]), float.Parse(parts[2]), float.Parse(parts[3]));
                        model.NormalList.Add(normal);
                    }
                    else if (parts[0] == ("f"))
                    {
                        Triangle triangle = ParseFace(parts);
                        model.TriangleList.Add(triangle);
                    }
                }

                file.models.Add(model);
            }

            return file;
        }

        private static Triangle ParseFace(string[] parts)
        {
            Triangle result = new Triangle();
            if (parts[1].Contains("//"))
            {
                for (int i = 1; i < 4; i++)
                {
                    string[] indexes = parts[i].Split('/');
                    int position = int.Parse(indexes[0]); int normal = int.Parse(indexes[1]);
                    result[i - 1] = new VertexInfo() { position = position, normal = normal };
                }
            }
            else if (parts[1].Contains("/"))
            {
                int components = parts[1].Split('/').Length;
                if (components == 2)
                {
                    for (int i = 1; i < 4; i++)
                    {
                        string[] indexes = parts[i].Split('/');
                        int position = int.Parse(indexes[0]); int uv = int.Parse(indexes[1]);
                        result[i - 1] = new VertexInfo() { position = position, uv = uv };
                    }
                }
                else if (components == 3)
                {
                    for (int i = 1; i < 4; i++)
                    {
                        string[] indexes = parts[i].Split('/');
                        int position = int.Parse(indexes[0]); int uv = int.Parse(indexes[1]); int normal = int.Parse(indexes[2]);
                        result[i - 1] = new VertexInfo() { position = position, uv = uv, normal = normal, };
                    }
                }
            }
            else
            {
                for (int i = 1; i < 4; i++)
                {
                    int position = int.Parse(parts[i]);
                    result[i - 1] = new VertexInfo() { position = position, };
                }
            }

            return result;
        }

        static readonly char[] separator = new char[] { ' ' };
        static readonly char[] separator1 = new char[] { '/' };
        //static readonly char[] separator2 = new char[] { '//' };
    }

    public struct VertexInfo
    {
        public int position;
        public int normal;
        public int uv;
    }
    public struct Triangle
    {
        public VertexInfo vertex0;
        public VertexInfo vertex1;
        public VertexInfo vertex2;

        public VertexInfo this[int index]
        {
            set
            {
                if (index == 0)
                {
                    this.vertex0 = value;
                }
                else if (index == 1)
                {
                    this.vertex1 = value;
                }
                else if (index == 2)
                {
                    this.vertex2 = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
    }
}
