using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class EZMBoneState : ICloneable
    {
        public EZMBoneState(vec3 position, Quaternion orientation, vec3 scale)
        {
            this.Position = position;
            this.Orientation = orientation;
            this.Scale = scale;
        }

        public vec3 Position { get; private set; }

        public Quaternion Orientation { get; private set; }

        public vec3 Scale { get; private set; }

        public mat4 ToMat4()
        {
            mat4 S = glm.scale(mat4.identity(), this.Scale);
            mat4 R = this.Orientation.ToMat4();
            mat4 T = glm.translate(mat4.identity(), this.Position);

            mat4 result = T * R * S;

            return result;
        }

        public override string ToString()
        {
            return string.Format("Orientation:{0} Pos:{1} Scale:{2}.", this.Orientation, this.Position, this.Scale);
        }

        #region ICloneable 成员

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
    }
}
