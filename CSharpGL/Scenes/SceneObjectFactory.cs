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
            IBufferable bufferable = GetModel(buildIn);
            var obj = new SceneObject();
            obj.Name = bufferable.GetType().Name;
            obj.Renderer = new SceneObjectRenderer(obj, bufferable, shaderCodes, map);

            return obj;
        }

        private static IBufferable GetModel(BuildInSceneObject buildIn)
        {
            IBufferable bufferable = null;

            switch (buildIn)
            {
                case BuildInSceneObject.Cube:
                    bufferable = new Cube();
                    break;
                case BuildInSceneObject.Sphere:
                    bufferable = new Sphere();
                    break;
                default:
                    throw new NotImplementedException();
            }

            return bufferable;
        }

    }

    public enum BuildInSceneObject
    {
        Cube,
        Sphere,
    }
}
