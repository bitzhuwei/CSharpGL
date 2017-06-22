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
        ThreeFlags EnableLegacyPicking { get; set; }

        /// <summary>
        /// Render this model before rendering its children in legacy OpenGL.
        /// </summary>
        /// <param name="arg"></param>
        void RenderBeforeChildrenForLegacyPicking(LegacyPickEventArgs arg);

        ///// <summary>
        ///// Render this model after rendering its children in legacy OpenGL.
        ///// </summary>
        ///// <param name="arg"></param>
        //void RenderAfterChildrenForLegacyPicking(LegacyPickEventArgs arg);
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

    /// <summary>
    /// 
    /// </summary>
    public class HitTarget
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly RendererBase renderer;

        /// <summary>
        /// 
        /// </summary>
        public readonly uint zNear;

        /// <summary>
        /// 
        /// </summary>
        public readonly uint zFar;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneElement"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public HitTarget(RendererBase sceneElement, uint zNear, uint zFar)
        {
            this.renderer = sceneElement;
            this.zNear = zNear;
            this.zFar = zFar;
        }

    }

}
