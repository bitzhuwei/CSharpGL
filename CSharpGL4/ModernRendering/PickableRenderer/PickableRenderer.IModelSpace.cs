using System.ComponentModel;
namespace CSharpGL
{
    public partial class PickableRenderer
    {
        #region IModelSpace 成员

        /// <summary>
        /// 
        /// </summary>
        public vec3 WorldPosition { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float RotationAngle { get; set; }

        private vec3 _rotationAxis = new vec3(0, 1, 0);
        /// <summary>
        /// 
        /// </summary>
        public vec3 RotationAxis { get { return this._rotationAxis; } set { this._rotationAxis = value; } }

        private vec3 _scale = new vec3(1, 1, 1);
        /// <summary>
        /// 
        /// </summary>
        public vec3 Scale { get { return this._scale; } set { this._scale = value; } }

        private vec3 _modelSize = new vec3(1, 1, 1);
        /// <summary>
        /// 
        /// </summary>
        public vec3 ModelSize { get { return this._modelSize; } set { this._modelSize = value; } }

        #endregion
    }
}