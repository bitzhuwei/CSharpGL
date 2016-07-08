
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// uniform mat2 variable;
    /// </summary>
    public class UniformMat2 : UniformSingleVariable
    {

        private mat2 value;
        /// <summary>
        /// 
        /// </summary>
        public mat2 Value
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
        /// <summary>
        /// uniform mat2 variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformMat2(string varName) : base(varName) { }
        /// <summary>
        /// uniform mat2 variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformMat2(string varName, mat2 value) : base(varName) { this.Value = value; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        public override void SetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniformMatrix2(VarName, this.value.to_array());
        }

        internal override bool SetValue(ValueType value)
        {
#if DEBUG
            if (value.GetType() != typeof(mat2))
            {
                throw new ArgumentException(string.Format("[{0}] not match [{1}]'s value.",
                    value.GetType().Name, this.GetType().Name));
            }
#endif

            var v = (mat2)value;
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
