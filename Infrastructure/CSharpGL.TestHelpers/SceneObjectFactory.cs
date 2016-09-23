using System;
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
            IBufferable model = GetModel(buildIn);
            AttributeNameMap map = GetMap(buildIn);
            vec3 lengths = GetLengths(buildIn);
            var renderer = new BuildInRenderer(lengths, model, shaderCodes, map);
            //renderer.Initialize();

            SceneObject obj = renderer.WrapToSceneObject();

            return obj;
        }

        private const int groundXLength = 2000;
        private const int groundZLength = 2000;

        private static vec3 GetLengths(BuildInSceneObject buildIn)
        {
            var lengths = new vec3(1, 1, 1) * 2;

            switch (buildIn)
            {
                case BuildInSceneObject.Cube:
                    break;

                case BuildInSceneObject.Sphere:
                    break;

                case BuildInSceneObject.Ground:
                    lengths = new vec3(groundXLength, 1, groundZLength);
                    break;

                case BuildInSceneObject.Axis:
                    break;

                default:
                    throw new NotImplementedException();
            }

            return lengths;
        }

        private static AttributeNameMap GetMap(BuildInSceneObject buildIn)
        {
            var map = new AttributeNameMap();

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
            IBufferable model = null;

            switch (buildIn)
            {
                case BuildInSceneObject.Cube:
                    model = new Cube();
                    break;

                case BuildInSceneObject.Sphere:
                    model = new Sphere();
                    break;

                case BuildInSceneObject.Ground:
                    model = new Ground(1, groundXLength / 2, groundZLength / 2);
                    break;

                case BuildInSceneObject.Axis:
                    model = new Axis();
                    break;

                default:
                    throw new NotImplementedException();
            }

            return model;
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