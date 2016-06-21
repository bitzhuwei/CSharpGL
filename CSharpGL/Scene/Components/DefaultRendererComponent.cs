using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class DefaultRendererComponent : RendererComponent
    {

        const string strprojection = "projection";
        const string strview = "view";
        const string strmodel = "model";
        //uint projectionLocation;
        //uint viewLocation;
        //uint modelLocation;

        [Description("renderer.")]
        public Renderer Renderer { get; private set; }

        public DefaultRendererComponent(BuildInSceneObject buildIn, SceneObject bindingObject = null)
            : base(bindingObject)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(ManifestResourceLoader.LoadTextFile(@"Resources\BuildInSceneObject.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(@"Resources\BuildInSceneObject.frag"), ShaderType.FragmentShader);
            IBufferable bufferable = GetModel(buildIn);
            PropertyNameMap map = GetMap(buildIn);
            var renderer = new Renderer(bufferable, shaderCodes, map);
            renderer.Initialize();
            this.Renderer = renderer;
        }

        public override void Render(RenderEventArgs arg)
        {
            Renderer renderer = this.Renderer;
            if (renderer != null)
            {
                mat4 projection, view, model;
                if (this.TryGetMatrix(arg, out projection, out view, out model))
                {
                    renderer.SetUniform(strprojection, projection);
                    renderer.SetUniform(strview, view);
                    renderer.SetUniform(strmodel, model);
                    renderer.Render(arg);
                }
            }
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
                    bufferable = new Ground(1, 10, 10);
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
}
