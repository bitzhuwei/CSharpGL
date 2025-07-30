using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FirstSightOfAssimpNet {
    public static class Matrix4x4Helper {
        public static mat4 ToMat4(this Assimp.Matrix4x4 matrix) {
            return new mat4(
                new vec4(matrix.A1, matrix.B1, matrix.C1, matrix.D1),
                new vec4(matrix.A2, matrix.B2, matrix.C2, matrix.D2),
                new vec4(matrix.A3, matrix.B3, matrix.C3, matrix.D3),
                new vec4(matrix.A4, matrix.B4, matrix.C4, matrix.D4)
                );
        }

        public static Assimp.Matrix4x4 ToMatrix(this mat4 mat) {
            vec4 col0 = mat[0];
            vec4 col1 = mat[1];
            vec4 col2 = mat[2];
            vec4 col3 = mat[3];
            return new Assimp.Matrix4x4(
                col0.x, col1.x, col2.x, col3.x,
                col0.y, col1.y, col2.y, col3.y,
                col0.z, col1.z, col2.z, col3.z,
                col0.w, col1.w, col2.w, col3.w);
        }
    }
}
