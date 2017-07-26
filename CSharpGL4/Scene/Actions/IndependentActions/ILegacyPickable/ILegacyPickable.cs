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
        void RenderBeforeChildrenForLegacyPicking(LegacyPickingEventArgs arg);

        ///// <summary>
        ///// Render this model after rendering its children in legacy OpenGL.
        ///// </summary>
        ///// <param name="arg"></param>
        //void RenderAfterChildrenForLegacyPicking(LegacyPickEventArgs arg);
    }

    /// <summary>
    /// 
    /// </summary>
    public class LegacyPickingEventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly mat4 pickMatrix;
        /// <summary>
        /// 
        /// </summary>
        public readonly Scene scene;
        /// <summary>
        /// 
        /// </summary>
        public readonly int x;
        /// <summary>
        /// 
        /// </summary>
        public readonly int y;
        /// <summary>
        /// 
        /// </summary>
        public readonly Dictionary<uint, SceneNodeBase> hitMap;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pickMatrix"></param>
        /// <param name="scene"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public LegacyPickingEventArgs(mat4 pickMatrix, Scene scene, int x, int y)
        {
            this.pickMatrix = pickMatrix;
            this.scene = scene;
            this.x = x;
            this.y = y;
            this.hitMap = new Dictionary<uint, SceneNodeBase>();

            this.ModelMatrixStack = new Stack<mat4>();
            this.ModelMatrixStack.Push(mat4.identity());
        }


        /// <summary>
        /// 
        /// </summary>
        internal Stack<mat4> ModelMatrixStack { get; private set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class HitTarget
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly SceneNodeBase node;

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
        public HitTarget(SceneNodeBase sceneElement, uint zNear, uint zFar)
        {
            this.node = sceneElement;
            this.zNear = zNear;
            this.zFar = zFar;
        }

    }

}
