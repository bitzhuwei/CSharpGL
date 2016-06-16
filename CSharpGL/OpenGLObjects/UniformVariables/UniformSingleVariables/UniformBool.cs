
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 由于未知的原因，shader对bool没反应，所以内部用float的1.0f和0.0f代替bool的true和false。
    /// </summary>
    public class UniformBool : UniformSingleVariable
    {

        private bool value;

        public bool Value
        {
            get { return this.value; }
            set
            {
                if (this.value != value)
                {
                    this.value = value;
                    this.Updated = true;
                }
            }
        }

        public UniformBool(string varName) : base(varName) { }

        public override void SetUniform(ShaderProgram program)
        {
            program.SetUniform(VarName, value ? 1.0f : 0.0f);
        }

        internal override bool SetValue(ValueType value)
        {
#if DEBUG
            if (value.GetType() != typeof(bool))
            {
                throw new ArgumentException(string.Format("[{0}] not match [{1}]'s value.",
                    value.GetType().Name, this.GetType().Name));
            }
#endif

            var v = (bool)value;
            if (v != this.value)
            {
                this.value = v;
                this.Updated = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        internal override ValueType GetValue()
        {
            return value;
        }

    }

}