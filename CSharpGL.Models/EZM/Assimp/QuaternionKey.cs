using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    public unsafe class QuaternionKey {
        public readonly double time;
        public readonly Quaternion value;

        public QuaternionKey(double time, Quaternion value) {
            this.time = time;
            this.value = value;
        }
    }
}
