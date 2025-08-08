namespace Import3D {
    /// <summary>
    /// column-major matrix4x4
    /// </summary>
    public unsafe struct mat4 {
        /// <summary>
        /// column-major matrix4x4
        /// </summary>
        public fixed float values[16];

        public float this[int row, int column] {
            get { return this.values[row + column * 4]; }
            set { this.values[row + column * 4] = value; }
        }
    }
}
