
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// uniform mat4 variable;
    /// </summary>
    public class UniformMat4 : UniformSingleVariable
    {

        private mat4 value;
        /// <summary>
        /// 
        /// </summary>
        public mat4 Value
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
        /// uniform mat4 variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformMat4(string varName) : base(varName) { }

        /// <summary>
        /// uniform mat4 variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformMat4(string varName, mat4 value) : base(varName) { this.Value = value; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        public override void SetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniformMatrix4(VarName, this.value.to_array());
        }

        internal override bool SetValue(ValueType value)
        {
#if DEBUG
            if (value.GetType() != typeof(mat4))
            {
                throw new ArgumentException(string.Format("[{0}] not match [{1}]'s value.",
                    value.GetType().Name, this.GetType().Name));
            }
#endif

            var v = (mat4)value;
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
