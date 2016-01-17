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
            //set { models = value; }
        }

        public static ObjFile Load(string filename)
        {
            ObjFile file = new ObjFile();

            LoadModels(filename, file);
            GenNormals(file);
            OrganizeModels(file);

            return file;
        }

        private static void OrganizeModels(ObjFile file)
        {
            List<ObjModel> models = new List<ObjModel>();
            foreach (var model in file.models)
            {
                var newModel = OrganizeModels(model);
                models.Add(newModel);
            }

            file.models.Clear();
            file.models.AddRange(models);
        }

        private static ObjModel OrganizeModels(ObjModel model)
        {
            ObjModel result = new ObjModel();
            result.positionList = model.positionList;

            result.normalList.AddRange(model.normalList);

            bool hasUV = model.uvList.Count > 0;
            if (hasUV)
            {
                result.uvList.AddRange(model.uvList);
            }

            for (int i = 0; i < model.innerFaceList.Count; i++)
            {
                var face = model.innerFaceList[i];
                var tuple = new Tuple<int, int, int>(face.vertex0.position, face.vertex1.position, face.vertex2.position);
                result.faceList.Add(tuple);
                result.normalList[face.vertex0.position] = model.normalList[face.vertex0.normal];
                result.normalList[face.vertex1.position] = model.normalList[face.vertex1.normal];
                result.normalList[face.vertex2.position] = model.normalList[face.vertex2.normal];

                if (hasUV)
                {
                    result.uvList[face.vertex0.position] = model.uvList[face.vertex0.normal];
                    result.uvList[face.vertex1.position] = model.uvList[face.vertex1.normal];
                    result.uvList[face.vertex2.position] = model.uvList[face.vertex2.normal];
                }
            }

            return result;
        }

        private static void GenNormals(ObjFile file)
        {
            foreach (var model in file.models)
            {
                GenNormals(model);
            }
        }

        private static void GenNormals(ObjModel model)
        {
            if (model.normalList.Count > 0) { return; }

            var faceNormals = new vec3[model.innerFaceList.Count];
            for (int i = 0; i < model.innerFaceList.Count; i++)
            {
                var face = model.innerFaceList[i];
                vec3 vertex0 = model.positionList[face.vertex0.position];
                vec3 vertex1 = model.positionList[face.vertex1.position];
                vec3 vertex2 = model.positionList[face.vertex2.position];
                vec3 v1 = vertex0 - vertex2;
                vec3 v2 = vertex2 - vertex1;
                faceNormals[i] = v1.cross(v2);
            }

            for (int i = 0; i < model.positionList.Count; i++)
            {
                vec3 sum = new vec3();
                int shared = 0;
                for (int j = 0; j < model.innerFaceList.Count; j++)
                {
                    var face = model.innerFaceList[i];
                    if (face.vertex0.position == i || face.vertex1.position == i || face.vertex2.position == i)
                    {
                        sum = sum + faceNormals[i];
                        shared++;
                    }
                }
                sum = sum / shared;
                sum.Normalize();
                model.normalList[i] = sum;
            }

            for (int i = 0; i < model.innerFaceList.Count; i++)
            {
                model.innerFaceList[i].vertex0.normal = model.innerFaceList[i].vertex0.position;
                model.innerFaceList[i].vertex1.normal = model.innerFaceList[i].vertex1.position;
                model.innerFaceList[i].vertex2.normal = model.innerFaceList[i].vertex2.position;
            }
        }

        private static void LoadModels(string filename, ObjFile file)
        {
            using (var sr = new StreamReader(filename))
            {
                var model = new ObjModel();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] parts = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    if (parts[0] == ("v"))
                    {
                        if (model.innerFaceList.Count > 0)
                        {
                            file.models.Add(model);
                            model = new ObjModel();
                        }

                        vec3 position = new vec3(float.Parse(parts[1]), float.Parse(parts[2]), float.Parse(parts[3]));
                        model.positionList.Add(position);
                    }
                    else if (parts[0] == ("vt"))
                    {
                        vec2 uv = new vec2(float.Parse(parts[1]), float.Parse(parts[2]));
                        model.uvList.Add(uv);
                    }
                    else if (parts[0] == ("vn"))
                    {
                        vec3 normal = new vec3(float.Parse(parts[1]), float.Parse(parts[2]), float.Parse(parts[3]));
                        model.normalList.Add(normal);
                    }
                    else if (parts[0] == ("f"))
                    {
                        Triangle triangle = ParseFace(parts);
                        model.innerFaceList.Add(triangle);
                    }
                }

                file.models.Add(model);
            }
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
                    result[i - 1] = new VertexInfo() { position = position, normal = normal, uv = -1 };
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
                        result[i - 1] = new VertexInfo() { position = position, normal = -1, uv = uv };
                    }
                }
                else if (components == 3)
                {
                    for (int i = 1; i < 4; i++)
                    {
                        string[] indexes = parts[i].Split('/');
                        int position = int.Parse(indexes[0]); int uv = int.Parse(indexes[1]); int normal = int.Parse(indexes[2]);
                        result[i - 1] = new VertexInfo() { position = position, normal = normal, uv = uv, };
                    }
                }
            }
            else
            {
                for (int i = 1; i < 4; i++)
                {
                    int position = int.Parse(parts[i]);
                    result[i - 1] = new VertexInfo() { position = position, normal = -1, uv = -1, };
                }
            }

            return result;
        }

        static readonly char[] separator = new char[] { ' ' };
        static readonly char[] separator1 = new char[] { '/' };
        //static readonly char[] separator2 = new char[] { '//' };
    }

    public class VertexInfo
    {
        public int position;
        public int normal;
        public int uv;
    }
    public class Triangle
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
