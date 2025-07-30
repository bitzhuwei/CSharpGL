namespace CSharpGL {
    public class DummyCamera {
        public vec3 position;
        public vec3 target;
        public vec3 up;
        public float near;
        public float far;

        /// <summary>
        /// 60.0f as default?
        /// </summary>
        public float fov;
        /// <summary>
        /// width / height
        /// </summary>
        public float aspectRatio;

        public mat4 GetProjectionView() {
            var projection = glm.perspective(
                (float)(this.fov * Math.PI / 180.0f),
                this.aspectRatio, this.near, this.far);
            var view = glm.lookAt(this.position, this.target, this.up);
            return projection * view;
        }
    }
}