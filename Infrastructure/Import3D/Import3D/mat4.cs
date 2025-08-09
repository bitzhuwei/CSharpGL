using System.Text;

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

        public mat4() {
            // identity matrix
            for (int i = 0; i < 4; i++) {
                values[i * 5] = 1.0f;
            }
        }

        public override string ToString() {
            var builder = new StringBuilder();
            for (int row = 0; row < 4; row++) {
                for (int column = 0; column < 4; column++) {
                    var value = this[row, column];
                    builder.Append(value);
                    builder.Append(", ");
                }
                builder.AppendLine();
            }
            return builder.ToString();
        }
    }
}
