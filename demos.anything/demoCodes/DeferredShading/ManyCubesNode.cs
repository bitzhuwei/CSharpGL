using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CSharpGL;

namespace DeferredShading {
    /// <summary>
    /// render many cubes in deferred shading way.
    /// </summary>
    partial class ManyCubesNode : ModernNode, IRenderable {
        /// <summary>
        /// render many cubes in deferred shading way.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ManyCubesNode Create(ManyCubesModel model) {
            var map = new AttributeMap();
            map.Add("inPosition", ManyCubesModel.strPosition);
            map.Add("inColor", ManyCubesModel.strColor);
            var program = GLProgram.Create(firstPassVert, firstPassFrag); Debug.Assert(program != null);
            var firstPassBuilder = new RenderMethodBuilder(program, map);
            var node = new ManyCubesNode(model, firstPassBuilder);
            node.Initialize();

            return node;
        }

        private ManyCubesNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders) { }

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children | ThreeFlags.AfterChildren;
        /// <summary>
        /// Render before/after children? Render children? 
        /// RenderAction cares about this property. Other actions, maybe, maybe not, your choice.
        /// </summary>
        public ThreeFlags EnableRendering {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        public void RenderBeforeChildren(RenderEventArgs arg) {
            if (!this.IsInitialized) { this.Initialize(); }

            var camera = arg.Camera;
            mat4 p = camera.GetProjectionMatrix();
            mat4 v = camera.GetViewMatrix();
            mat4 m = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[0];
            var program = method.Program;
            program.SetUniform("mvpMat", p * v * m);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }
    }
}
