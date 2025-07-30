using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    partial class GLTexture {
        //private Dictionary<uint, GLfloat[]> property2Valuefv = new();
        //private Dictionary<uint, GLfloat> property2Valuef = new();
        private Dictionary<uint, object> property2Value = new();

        public void SetProperty(uint pname, object param) {
            // TODO: if (if params​ should have a defined constant value (based on the value of pname​) and does not)
            //  { context.lastErrorCode = (uint)(ErrorCode.InvalidEnum); return; }

            var dict = this.property2Value;
            if (!dict.TryAdd(pname, param)) { dict[pname] = param; }
        }

        public object GetProperty(uint pname) {
            if (this.property2Value.TryGetValue(pname, out var value)) {
                return value;
            }
            else {
                return 0;
            }
        }

        private void InitParameters() {

        }
    }
}
