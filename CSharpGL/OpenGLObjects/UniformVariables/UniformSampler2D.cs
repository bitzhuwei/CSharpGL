using GLM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{

    public class UniformSampler2D : UniformVariable
    {

        private samplerValue value;

        public samplerValue Value
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

        public UniformSampler2D(string varName) : base(varName) { }

        public override void SetUniform(ShaderProgram program)
        {
            GL.GetDelegateFor<GL.glActiveTexture>()((uint)value.Index);
            GL.Enable(GL.GL_TEXTURE_2D);
            GL.BindTexture(GL.GL_TEXTURE_2D, value.Name);
            //program.SetUniform(VarName, (int)((uint)value.Index - GL.GL_TEXTURE0));
            program.SetUniform(VarName, (int)(value.Index));
        }

        public override void ResetUniform(ShaderProgram program)
        {
            GL.BindTexture(GL.GL_TEXTURE_2D, 0);
        }

        internal override bool SetValue(ValueType value)
        {
            if (value.GetType() != typeof(samplerValue))
            {
                throw new ArgumentException(string.Format("[{0}] not match [{1}]'s value.",
                    value.GetType().Name, this.GetType().Name));
            }

            var v = (samplerValue)value;
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

    [TypeConverter(typeof(SamplerValueTypeConverter))]
    public struct samplerValue
    {
        private uint name;

        public uint Name
        {
            get { return name; }
            set { name = value; }
        }
        private uint index;

        public uint Index
        {
            get { return index; }
            set { index = value; }
        }

        public samplerValue(uint name, uint index)
        {
            this.name = name;
            this.index = index;
        }

        static readonly char[] separator = new char[] { '[', ']', };

        public static samplerValue Parse(string value)
        {
            string[] parts = value.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            uint name = uint.Parse(parts[1]);
            uint index = uint.Parse(parts[3]);

            return new samplerValue(name, index);
        }

        public override string ToString()
        {
            return string.Format("name:[{0}] index:[{1}]", name, index);
        }

        public static bool operator ==(samplerValue left, samplerValue right)
        {
            object leftObj = left, rightObj = right;
            if (leftObj == null)
            {
                if (rightObj == null) { return true; }
                else { return false; }
            }
            else
            {
                if (rightObj == null) { return false; }
            }

            return left.Equals(right);
        }

        public static bool operator !=(samplerValue left, samplerValue right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            var p = (samplerValue)obj;

            //return this.HashCode == p.HashCode;
            return (this.index == p.index && this.name == p.name);
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

    }
}
