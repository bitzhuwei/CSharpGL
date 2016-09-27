using System;
using System.Collections.Generic;
using System.IO;

namespace CSharpGL.OBJFile
{
    public class OBJRawFile
    {
        private List<OBJModel> models = new List<OBJModel>();

        public List<OBJModel> Models
        {
            get { return models; }
            //set { models = value; }
        }

        public static OBJRawFile Load(string filename)
        {
            OBJRawFile file = new OBJRawFile();

            LoadModels(filename, file);
            GenNormals(file);
            OrganizeModels(file);

            return file;
        }

        private static void OrganizeModels(OBJRawFile file)
        {
            List<OBJModel> models = new List<OBJModel>();
            foreach (var model in file.models)
            {
                var newModel = OrganizeModels(model);
                models.Add(newModel);
            }

            file.models.Clear();
            file.models.AddRange(models);
        }

        private static OBJModel OrganizeModels(OBJModel model)
        {
            OBJModel result = new OBJModel();
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
                if (face.vertex0.normal > 0)
                    result.normalList[face.vertex0.position - 1] = model.normalList[face.vertex0.normal - 1];
                if (face.vertex1.normal > 0)
                    result.normalList[face.vertex1.position - 1] = model.normalList[face.vertex1.normal - 1];
                if (face.vertex2.normal > 0)
                    result.normalList[face.vertex2.position - 1] = model.normalList[face.vertex2.normal - 1];

                if (hasUV)
                {
                    if (face.vertex0.uv > 0)
                        result.uvList[face.vertex0.position - 1] = model.uvList[face.vertex0.uv - 1];
                    if (face.vertex1.uv > 0)
                        result.uvList[face.vertex1.position - 1] = model.uvList[face.vertex1.uv - 1];
                    if (face.vertex2.uv > 0)
                        result.uvList[face.vertex2.position - 1] = model.uvList[face.vertex2.uv - 1];
                }

                result.faceList.Add(new Tuple<int, int, int>(face.vertex0.position, face.vertex1.position, face.vertex2.position));
                //result.faceList[i] = new Tuple<int, int, int>(face.vertex0.position, face.vertex1.position, face.vertex2.position);
            }

            //model.innerFaceList.Clear();

            return result;
        }

        private static void GenNormals(OBJRawFile file)
        {
            foreach (var model in file.models)
            {
                GenNormals(model);
            }
        }

        private static void GenNormals(OBJModel model)
        {
            if (model.normalList.Count > 0) { return; }

            var faceNormals = new vec3[model.innerFaceList.Count];
            model.normalList.AddRange(new vec3[model.positionList.Count]);

            for (int i = 0; i < model.innerFaceList.Count; i++)
            {
                var face = model.innerFaceList[i];
                vec3 vertex0 = model.positionList[face.vertex0.position - 1];
                vec3 vertex1 = model.positionList[face.vertex1.position - 1];
                vec3 vertex2 = model.positionList[face.vertex2.position - 1];
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
                    var face = model.innerFaceList[j];
                    if (face.vertex0.position - 1 == i || face.vertex1.position - 1 == i || face.vertex2.position - 1 == i)
                    {
                        sum = sum + faceNormals[i];
                        shared++;
                    }
                }
                if (shared > 0)
                {
                    sum = (sum / shared).normalize();
                }
                model.normalList[i] = sum;
            }
        }

        private static void LoadModels(string filename, OBJRawFile file)
        {
            using (var sr = new StreamReader(filename))
            {
                var model = new OBJModel();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] parts = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    if (parts[0] == ("v"))
                    {
                        if (model.innerFaceList.Count > 0)
                        {
                            file.models.Add(model);
                            model = new OBJModel();
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
                    int position = int.Parse(indexes[0]);
                    int normal = int.Parse(indexes[2]);
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

        private static readonly char[] separator = new char[] { ' ' };
        private static readonly char[] separator1 = new char[] { '/' };
    }

    internal class VertexInfo
    {
        public int position;
        public int normal;
        public int uv;
    }

    internal class Triangle
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