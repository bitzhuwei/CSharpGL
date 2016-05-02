using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    internal partial class TeapotModel
    {
        internal sealed class TeapotLoader
        {
            static TeapotModel model;
            static readonly object synObj = new object();

            internal static TeapotModel GetModel()
            {
                if (model == null)
                {
                    lock (synObj)
                    {
                        if (model == null)
                        {
                            model = Load();
                        }
                    }
                }

                return model;
            }

            internal static TeapotModel Load()
            {
                Assembly executingAssembly;
                string location;
                ManifestResourceLoader.GetLocation(@"ModernRendering\IBufferables\TeapotModel.obj", 1, out executingAssembly, out location);

                using (Stream stream = executingAssembly.GetManifestResourceStream(location))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        TeapotModel model = LoadModels(reader);
                        GenNormals(model);

                        return model;
                    }
                }
            }

            private static void GenNormals(TeapotModel model)
            {
                var faceNormals = new vec3[model.faces.Count];
                model.normals.AddRange(new vec3[model.positions.Count]);

                for (int i = 0; i < model.faces.Count; i++)
                {
                    var face = model.faces[i];
                    vec3 vertex0 = model.positions[face.Item1 - 1];
                    vec3 vertex1 = model.positions[face.Item2 - 1];
                    vec3 vertex2 = model.positions[face.Item3 - 1];
                    vec3 v1 = vertex0 - vertex2;
                    vec3 v2 = vertex2 - vertex1;
                    faceNormals[i] = v2.cross(v1).normalize();
                }

                for (int i = 0; i < model.positions.Count; i++)
                {
                    vec3 sum = new vec3();
                    int shared = 0;
                    for (int j = 0; j < model.faces.Count; j++)
                    {
                        var face = model.faces[j];
                        if (face.Item1 - 1 == i || face.Item2 - 1 == i || face.Item3 - 1 == i)
                        {
                            sum = sum + faceNormals[j];
                            shared++;
                        }
                    }
                    if (shared > 0)
                    {
                        sum = (sum / shared).normalize();
                    }
                    model.normals[i] = sum;
                }

            }

            private static TeapotModel LoadModels(StreamReader stream)
            {
                var model = new TeapotModel();
                List<String> headers = new List<string>();

                while (!stream.EndOfStream)
                {
                    string line = stream.ReadLine();
                    string[] parts = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    if (parts[0] == ("v"))
                    {
                        vec3 position = new vec3(float.Parse(parts[1]), float.Parse(parts[2]), float.Parse(parts[3]));
                        model.positions.Add(position);
                    }
                    else if (parts[0] == ("vn"))
                    {
                        vec3 normal = new vec3(float.Parse(parts[1]), float.Parse(parts[2]), float.Parse(parts[3]));
                        model.normals.Add(normal);
                    }
                    else if (parts[0] == ("f"))
                    {
                        //ushort index = ushort.Parse(parts[1]);
                        var face = new Tuple<ushort, ushort, ushort>(ushort.Parse(parts[1]), ushort.Parse(parts[2]), ushort.Parse(parts[3]));
                        model.faces.Add(face);
                    }
                    else
                    {
                        if (!headers.Contains(parts[0]))
                        {
                            headers.Add(parts[0]);
                        }
                    }
                }

                return model;
            }

            static readonly char[] separator = new char[] { ' ' };
        }
    }

}
