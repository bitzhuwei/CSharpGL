using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    public abstract partial class SceneNodeBase
    {
        /// <summary>
        /// Gets this node's abolute position in world space.
        /// </summary>
        /// <returns></returns>
        public vec3 GetAbsoluteWorldPosition()
        {
            var position = new vec4(this.worldPosition, 1.0f);
            var worldPosition = this.cascadeModelMatrix * position;
            return new vec3(worldPosition);
        }

        /// <summary>
        /// Gets this node's abolute position in specified view space.
        /// </summary>
        /// <param name="viewMatrix">specifies the view space transform.</param>
        /// <returns></returns>
        public vec3 GetAbsoluteViewPosition(mat4 viewMatrix)
        {
            var position = new vec4(this.worldPosition, 1.0f);
            var viewPosition = viewMatrix * this.cascadeModelMatrix * position;
            return new vec3(viewPosition);
        }
    }
}
