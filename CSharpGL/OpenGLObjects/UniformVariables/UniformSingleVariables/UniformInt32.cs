
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// uniform int variable;
    /// </summary>
    public class UniformInt32 : UniformSingleVariable
    {

        private int value;
        /// <summary>
        /// 
        /// </summary>
        public int Value
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
        public UniformInt32(string varName) : base(varName) { }

        /// <summary>
        /// uniform float variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformInt32(string varName, int value) : base(varName) { this.Value = value; }
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
            if (value.GetType() != typeof(int))
            {
                throw new ArgumentException(string.Format("[{0}] not match [{1}]'s value.",
                    value.GetType().Name, this.GetType().Name));
            }
#endif

            var v = (int)value;
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