using System;
using System.Collections.Generic;
using System.IO;

namespace CSharpGL
{
    /// <summary>
    /// Description of SceneObject.
    /// </summary>
    public partial class SceneObjectFactory
    {
        public static SceneObject GetBuildInSceneObject(BuildInSceneObject buildIn)
        {
            SceneObject obj = null;
            switch (buildIn)
            {
                case BuildInSceneObject.Cube:
                    {
                        var shaderCodes = new ShaderCode[2];
                        shaderCodes[0] = new ShaderCode(File.ReadAllText(@"Resources\SceneObject.vert"), ShaderType.VertexShader);
                        shaderCodes[1] = new ShaderCode(File.ReadAllText(@"Resources\SceneObject.vert"), ShaderType.FragmentShader);
                        var map = new PropertyNameMap();
                        map.Add("in_Position", Cube.strPosition);
                        map.Add("in_Color", Cube.strColor);
                        obj = new SceneObject();
                        obj.Renderer = new SceneObjectRenderer(obj, new Cube(), shaderCodes, map);
                    }
                    break;
                case BuildInSceneObject.Sphere:
                    {
                        var shaderCodes = new ShaderCode[2];
                        shaderCodes[0] = new ShaderCode(File.ReadAllText(@"Resources\BuildInSceneObject.vert"), ShaderType.VertexShader);
                        shaderCodes[1] = new ShaderCode(File.ReadAllText(@"Resources\BuildInSceneObject.frag"), ShaderType.FragmentShader);
                        var map = new PropertyNameMap();
                        map.Add("in_Position", Sphere.strPosition);
                        map.Add("in_Color", Sphere.strColor);
                        obj = new SceneObject();
                        obj.Renderer = new SceneObjectRenderer(obj, new Cube(), shaderCodes, map);
                    }
                    break;
                default:
                    throw new NotImplementedException();
            }

            return obj;
        }

    }

    public enum BuildInSceneObject
    {
        Cube,
        Sphere,
    }
}
