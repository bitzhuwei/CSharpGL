using System;

namespace CSharpGL
{
    /// <summary>
    /// Description of TransformComponent.
    /// </summary>
    public partial class TransformComponent : Component
    {
        public vec3 Position { get; set; }
        public vec3 Rotation { get; set; }
        public vec3 Scale { get; set; }

        public TransformComponent(SceneObject bindingObject = null)
            : base(bindingObject)
        {
            this.Scale = new vec3(1, 1, 1);
        }

        static readonly vec3 xAxis = new vec3(1, 0, 0);
        static readonly vec3 yAxis = new vec3(0, 1, 0);
        static readonly vec3 zAxis = new vec3(0, 0, 1);
        /// <summary>
        /// Get model matrix.
        /// </summary>
        /// <returns></returns>
        public mat4 GetMatrix()
        {
            mat4 matrix;

            matrix = glm.rotate((float)(this.Rotation.x * Math.PI / 180.0), xAxis);
            matrix = glm.rotate((float)(this.Rotation.y * Math.PI / 180.0), yAxis);
            matrix = glm.rotate((float)(this.Rotation.z * Math.PI / 180.0), zAxis);
            matrix = glm.scale(matrix, this.Scale);
            matrix = glm.translate(matrix, this.Position);

            return matrix;
        }
    }
}
