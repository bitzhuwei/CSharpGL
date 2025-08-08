namespace Import3D {
    public struct vec4 {
        public float x;
        public float y;
        public float z;
        public float w;

        public vec4(float value) {
            this.x = value;
            this.y = value;
            this.z = value;
            this.w = value;
        }
        public vec4(float x, float y, float z, float w) {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public override string ToString() {
            return $"{x}, {y}, {z}, {w}";
        }
    }
}
