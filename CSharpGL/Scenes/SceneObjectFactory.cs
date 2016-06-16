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
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(ManifestResourceLoader.LoadTextFile(@"Resources\BuildInSceneObject.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(@"Resources\BuildInSceneObject.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("in_Position", Cube.strPosition);
            map.Add("in_Color", Cube.strColor);
            var obj = new SceneObject();
            obj.Name = "Sphere";
            switch (buildIn)
            {
                case BuildInSceneObject.Cube:
                    obj.Renderer = new SceneObjectRenderer(obj, new Cube(), shaderCodes, map);
                    break;
                case BuildInSceneObject.Sphere:
                    obj.Renderer = new SceneObjectRenderer(obj, new Sphere(), shaderCodes, map);
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
