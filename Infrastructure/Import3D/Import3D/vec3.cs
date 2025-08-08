namespace Import3D {
    public struct vec3 {
        public float x;
        public float y;
        public float z;

        public vec3(float value) {
            this.x = value;
            this.y = value;
            this.z = value;
        }
        public vec3(float x, float y, float z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString() {
            return $"{x}, {y}, {z}";
        }
    }
}
