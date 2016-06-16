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
            IBufferable bufferable = GetModel(buildIn);
            PropertyNameMap map = GetMap(buildIn);
            var obj = new SceneObject();
            obj.Name = bufferable.GetType().Name;
            obj.Renderer = new SceneObjectRenderer(bufferable, shaderCodes, map);

            return obj;
        }

        private static PropertyNameMap GetMap(BuildInSceneObject buildIn)
        {
            var map = new PropertyNameMap();

            switch (buildIn)
            {
                case BuildInSceneObject.Cube:
                    map.Add("in_Position", Cube.strPosition);
                    map.Add("in_Color", Cube.strColor);
                    break;
                case BuildInSceneObject.Sphere:
                    map.Add("in_Position", Sphere.strPosition);
                    map.Add("in_Color", Sphere.strColor);
                    break;
                case BuildInSceneObject.Ground:
                    map.Add("in_Position", Ground.strPosition);
                    map.Add("in_Color", Ground.strColor);
                    break;
                case BuildInSceneObject.Axis:
                    map.Add("in_Position", Axis.strPosition);
                    map.Add("in_Color", Axis.strColor);
                     break;
                default:
                    throw new NotImplementedException();
            }

            return map;
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
                case BuildInSceneObject.Ground:
                    bufferable = new Ground(10, 2, 2);
                    break;
                case BuildInSceneObject.Axis:
                    bufferable = new Axis();
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
        Ground,
        Axis,
    }
}
