using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    class LinearInterpolationInfoGroup : IEquatable<LinearInterpolationInfoGroup> {
        public readonly LinearInterpolationInfo[] array;

        public LinearInterpolationInfoGroup(int length) {
            this.array = new LinearInterpolationInfo[length];
        }

        public override string ToString() {
            var builder = new StringBuilder();
            foreach (var item in this.array) {
                builder.AppendLine(item.ToString());
            }

            return builder.ToString();
        }

        #region IEquatable<LinearInterpolationInfoGroup> 成员

        public bool Equals(LinearInterpolationInfoGroup? other) {
            if (other is null) { return false; }

            if (this.array.Length != other.array.Length) { return false; }
            for (int i = 0; i < this.array.Length; i++) {
                if (this.array[i] != other.array[i]) {
                    return false;
                }
            }

            return true;
        }

        #endregion

        public override bool Equals(Object? other) {
            if (other == null) { return false; }

            if (other is LinearInterpolationInfoGroup obj) {
                return Equals(obj);
            }
            else { return false; }
        }

        public override int GetHashCode() {
            return this.ToString().GetHashCode();
        }

        public static bool operator ==(LinearInterpolationInfoGroup left, LinearInterpolationInfoGroup right) {
            if (((object)left) == null || ((object)right) == null)
                return Object.Equals(left, right);

            return left.Equals(right);
        }

        public static bool operator !=(LinearInterpolationInfoGroup left, LinearInterpolationInfoGroup right) {
            if (((object)left) == null || ((object)right) == null)
                return !Object.Equals(left, right);

            return !(left.Equals(right));
        }
    }

    class LinearInterpolationInfo : IEquatable<LinearInterpolationInfo> {
        public uint gl_VertexID;
        public vec3 fragCoord;

        public LinearInterpolationInfo(uint gl_VertexID, vec3 fragCoord) {
            this.gl_VertexID = gl_VertexID;
            this.fragCoord = fragCoord;
        }

        public override string ToString() {
            return string.Format("gl_VertexID:{0}, fragCoord:{1}", this.gl_VertexID, this.fragCoord);
        }

        #region IEquatable<LinearInterpolationInfo> 成员

        public bool Equals(LinearInterpolationInfo? other) {
            if (other is null) { return false; }

            if (this.gl_VertexID != other.gl_VertexID) { return false; }
            if (this.fragCoord != other.fragCoord) { return false; }

            return true;
        }

        #endregion

        public override bool Equals(Object? other) {
            if (other == null) { return false; }

            if (other is LinearInterpolationInfo obj) {
                return Equals(obj);
            }
            else { return false; }
        }

        public override int GetHashCode() {
            return this.ToString().GetHashCode();
        }

        public static bool operator ==(LinearInterpolationInfo left, LinearInterpolationInfo right) {
            if (((object)left) == null || ((object)right) == null)
                return Object.Equals(left, right);

            return left.Equals(right);
        }

        public static bool operator !=(LinearInterpolationInfo left, LinearInterpolationInfo right) {
            if (((object)left) == null || ((object)right) == null)
                return !Object.Equals(left, right);

            return !(left.Equals(right));
        }
    }
}
