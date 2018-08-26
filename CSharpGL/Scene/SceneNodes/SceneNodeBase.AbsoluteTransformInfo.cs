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
            var position = new vec4(this.worldSpacePosition, 1.0f);
            var worldSpacePosition = this.cascadeModelMatrix * position;
            return new vec3(worldSpacePosition);
        }

        /// <summary>
        /// Gets this node's abolute position in specified view space.
        /// </summary>
        /// <param name="viewMat">specifies the view space transform.</param>
        /// <returns></returns>
        public vec3 GetAbsoluteViewPosition(mat4 viewMat)
        {
            var position = new vec4(this.worldSpacePosition, 1.0f);
            var viewPosition = viewMat * this.cascadeModelMatrix * position;
            return new vec3(viewPosition);
        }
    }
}
