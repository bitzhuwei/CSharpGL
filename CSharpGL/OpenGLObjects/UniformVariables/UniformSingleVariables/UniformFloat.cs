
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// uniform float variable;
    /// </summary>
    public class UniformFloat : UniformSingleVariable
    {

        private float value;
        /// <summary>
        /// 
        /// </summary>
        public float Value
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
        /// uniform float variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformFloat(string varName) : base(varName) { }

        /// <summary>
        /// uniform float variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformFloat(string varName, float value) : base(varName) { this.Value = value; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        public override void SetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniform(VarName, value);
        }

        internal override bool SetValue(ValueType value)
        {
#if DEBUG
            if (value.GetType() != typeof(float))
            {
                throw new ArgumentException(string.Format("[{0}] not match [{1}]'s value.",
                    value.GetType().Name, this.GetType().Name));
            }
#endif

            var v = (float)value;
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