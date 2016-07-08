
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// uniform vec3 variable;
    /// </summary>
    public class UniformVec3 : UniformSingleVariable
    {

        private vec3 value;

        /// <summary>
        /// 
        /// </summary>
        public vec3 Value
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
        /// uniform vec3 variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformVec3(string varName) : base(varName) { }

        /// <summary>
        /// uniform vec3 variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformVec3(string varName, vec3 value) : base(varName) { this.Value = value; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        public override void SetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniform(VarName, value.x, value.y, value.z);
        }

        internal override bool SetValue(ValueType value)
        {
#if DEBUG
            if (value.GetType() != typeof(vec3))
            {
                throw new ArgumentException(string.Format("[{0}] not match [{1}]'s value.",
                    value.GetType().Name, this.GetType().Name));
            }
#endif

            var v = (vec3)value;
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
