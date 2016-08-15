using CSharpGL;
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buildIn"></param>
        /// <returns></returns>
        public static SceneObject GetBuildInSceneObject(BuildInSceneObject buildIn)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\BuildInSceneObject.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\BuildInSceneObject.frag"), ShaderType.FragmentShader);
            IBufferable bufferable = GetModel(buildIn);
            PropertyNameMap map = GetMap(buildIn);
            var renderer = new BuildInRenderer(bufferable, shaderCodes, map);
            renderer.Initialize();

            var obj = new SceneObject();
            obj.Renderer = renderer;
            obj.Name = string.Format("{0}", buildIn);

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
                    bufferable = new Ground(1, 1000, 1000);
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

    /// <summary>
    /// 
    /// </summary>
    public enum BuildInSceneObject
    {
        /// <summary>
        /// 
        /// </summary>
        Cube,
        /// <summary>
        /// 
        /// </summary>
        Sphere,
        /// <summary>
        /// 
        /// </summary>
        Ground,
        /// <summary>
        /// 
        /// </summary>
        Axis,
    }
}
