using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// </summary>
    public static class SceneObjectHelper
    {

        /// <summary>
        /// Gets a <see cref="SceneObject"/> that contains this renderer.
        /// </summary>
        /// <param name="renderer"></param>
        /// <returns></returns>
        public static SceneObject WrapToSceneObject(this RendererBase renderer)
        {
            var obj = new SceneObject();
            obj.Renderer = renderer;
            return obj;
        }
    }
}