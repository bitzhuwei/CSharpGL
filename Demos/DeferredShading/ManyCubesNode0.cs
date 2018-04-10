using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace DeferredShading
{
    /// <summary>
    /// render many cubes in regular way.
    /// </summary>
    partial class ManyCubesNode0 : ModernNode, IRenderable
    {
        /// <summary>
        /// render many cubes in regular way.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ManyCubesNode0 Create(ManyCubesModel model)
        {
            var map = new PropertyMap();
            map.Add("vPosition", ManyCubesModel.strPosition);
            map.Add("vColor", ManyCubesModel.strColor);
            var vs = new VertexShader(regularVert);
            var fs = new FragmentShader(regularFrag);
            var array = new ShaderArray(vs, fs);
            var firstPassBuilder = new RenderMethodBuilder(array, map);
            var node = new ManyCubesNode0(model, firstPassBuilder);
            node.Initialize();

            return node;
        }

        private ManyCubesNode0(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders) { }

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children | ThreeFlags.AfterChildren;
        /// <summary>
        /// Render before/after children? Render children? 
        /// RenderAction cares about this property. Other actions, maybe, maybe not, your choice.
        /// </summary>
        public ThreeFlags EnableRendering
        {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            if (!this.IsInitialized) { this.Initialize(); }

            var camera = arg.Camera;
            mat4 p = camera.GetProjectionMatrix();
            mat4 v = camera.GetViewMatrix();
            mat4 m = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[0];
            var program = method.Program;
            program.SetUniform("MVP", p * v * m);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
