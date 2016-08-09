using System;

namespace CSharpGL
{
    /// <summary>
    /// Transform model's position from model space to world space,
    /// including translation, scale and rotation.
    /// </summary>
    public partial class TransformScript : ScriptComponent
    {
        /// <summary>
        /// translate this object.
        /// </summary>
        public vec3 Position { get; set; }
        /// <summary>
        /// rotate this object.
        /// </summary>
        public vec3 Rotation { get; set; }
        /// <summary>
        /// scale this object.
        /// </summary>
        public vec3 Scale { get; set; }

        /// <summary>
        /// Transform model's position from model space to world space,
        /// including translation, scale and rotation.
        /// </summary>
        /// <param name="bindingObject"></param>
        public TransformScript(SceneObject bindingObject = null)
            : base(bindingObject)
        {
            this.Scale = new vec3(1, 1, 1);
        }

        static readonly vec3 xAxis = new vec3(1, 0, 0);
        static readonly vec3 yAxis = new vec3(0, 1, 0);
        static readonly vec3 zAxis = new vec3(0, 0, 1);

        mat4 selfMatrix = mat4.identity();

        /// <summary>
        /// Get model matrix that transform model's position from model space to world space,
        /// Make sure the scene object list is traversed in pre-order.
        /// </summary>
        /// <returns></returns>
        public mat4 GetModelMatrix()
        {
            SceneObject obj = this.BindingObject;
            if (obj != null)
            {
                mat4 matrix = mat4.identity();
                matrix = glm.translate(matrix, this.Position);
                matrix = glm.scale(matrix, this.Scale);
                matrix = glm.rotate(matrix, (float)(this.Rotation.x * Math.PI / 180.0), xAxis);
                matrix = glm.rotate(matrix, (float)(this.Rotation.y * Math.PI / 180.0), yAxis);
                matrix = glm.rotate(matrix, (float)(this.Rotation.z * Math.PI / 180.0), zAxis);

                // matrix equals to (translate * scale * rotation) as below:
                //mat4 translate = glm.translate(mat4.identity(), this.Position);
                //mat4 scale = glm.scale(mat4.identity(), this.Scale);
                //mat4 rotation = glm.rotate(mat4.identity(), (float)(this.Rotation.x * Math.PI / 180.0), xAxis);
                //rotation = glm.rotate(rotation, (float)(this.Rotation.y * Math.PI / 180.0), yAxis);
                //rotation = glm.rotate(rotation, (float)(this.Rotation.z * Math.PI / 180.0), zAxis);

                this.selfMatrix = matrix;
            }

            return this.selfMatrix;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void DoInitialize()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elapsedTime"></param>
        protected override void DoUpdate(double elapsedTime)
        {
            //throw new NotImplementedException();
        }
    }
}
