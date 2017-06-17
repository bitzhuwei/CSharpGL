using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Supports picking in legacy OpenGL.
    /// </summary>
    public interface ILegacyPickable
    {
        /// <summary>
        /// 
        /// </summary>
        bool LegacyPickingEnabled { get; set; }

        /// <summary>
        /// Render this model in legacy OpenGL.
        /// </summary>
        /// <param name="arg"></param>
        void RenderForLegacyPicking(LegacyPickEventArgs arg);
    }

    /// <summary>
    /// 
    /// </summary>
    public class LegacyPickEventArgs
    {
        public readonly mat4 pickMatrix;
        public readonly Scene scene;
        public readonly int x;
        public readonly int y;
        public readonly Dictionary<uint, RendererBase> hitMap;

        public LegacyPickEventArgs(mat4 pickMatrix, Scene scene, int x, int y)
        {
            this.pickMatrix = pickMatrix;
            this.scene = scene;
            this.x = x;
            this.y = y;
            this.hitMap = new Dictionary<uint, RendererBase>();
        }
    }

}
