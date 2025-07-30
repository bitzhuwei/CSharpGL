using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    public partial class CodeBase {
        public static bool XOR(bool left, bool right) {
            if (left) {
                if (right) { return false; }
                else { return true; }
            }
            else {
                if (right) { return true; }
                else { return false; }
            }
        }
    }
}
