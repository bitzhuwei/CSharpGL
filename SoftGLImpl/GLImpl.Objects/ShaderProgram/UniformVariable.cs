using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SoftGLImpl {
    class UniformVariable {
        public int location = -1;
        public readonly FieldInfo fieldInfo;

        public UniformVariable(FieldInfo field) {
            this.fieldInfo = field;
        }

        public override string ToString() {
            return string.Format("f:{0}, loc:{1}", this.fieldInfo, this.location);
        }
    }
}
