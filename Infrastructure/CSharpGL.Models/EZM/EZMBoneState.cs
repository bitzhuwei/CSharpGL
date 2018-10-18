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
            this.Position = position;
            this.Orientation = orientation;
            this.Scale = scale;

            mat4 S = glm.scale(mat4.identity(), this.Scale);
            mat4 R = this.Orientation.ToMat4();
            mat4 T = glm.translate(mat4.identity(), this.Position);
            this.matrix = T * R * S;
            this.inverseMatrix = glm.inverse(this.matrix);
        }

        public vec3 Position { get; private set; }

        public Quaternion Orientation { get; private set; }

        public vec3 Scale { get; private set; }

        /// <summary>
        /// cache matrix from Position, Orientation and Scale.
        /// </summary>
        public mat4 matrix;
        /// <summary>
        /// cache inversed matrix.
        /// </summary>
        public mat4 inverseMatrix;

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
            return string.Format("Orientation:{0} Pos:{1} Scale:{2}.", this.Orientation, this.Position, this.Scale);
        }

    }
}
