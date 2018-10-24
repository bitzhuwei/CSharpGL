using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public struct EZMBoneState
    {
        public EZMBoneState(vec3 position, Quaternion orientation, vec3 scale)
            : this()
        {
            this.position = position;
            this.orientation = orientation;
            this.scale = scale;

            mat4 S = glm.scale(mat4.identity(), scale);
            //mat4 S = mat4.identity();
            mat4 R = orientation.ToMat4();
            //mat4 R = mat4.identity();
            mat4 T = glm.translate(mat4.identity(), position);
            //mat4 T = mat4.identity();
            this.matrix = T * R * S;
        }

        public readonly vec3 position;
        public readonly Quaternion orientation;
        public readonly vec3 scale;

        /// <summary>
        /// cache matrix from Position, Orientation and Scale.
        /// </summary>
        public readonly mat4 matrix;

        //public void UpdateCache()
        //{
        //    mat4 S = glm.scale(mat4.identity(), this.Scale);
        //    mat4 R = this.Orientation.ToMat4();
        //    mat4 T = glm.translate(mat4.identity(), this.Position);
        //    this.matrix = T * R * S;
        //    this.inverseMatrix = glm.inverse(this.matrix);
        //}

        //public mat4 ToMat4()
        //{
        //    mat4 S = glm.scale(mat4.identity(), this.Scale);
        //    mat4 R = this.Orientation.ToMat4();
        //    mat4 T = glm.translate(mat4.identity(), this.Position);

        //    mat4 result = T * R * S;

        //    return result;
        //}

        public override string ToString()
        {
            return string.Format("Orientation:{0} Pos:{1} Scale:{2}.", this.orientation, this.position, this.scale);
        }

    }
}
