
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
            GL.GetDelegateFor<GL.glActiveTexture>()(value.ActiveTextureIndex);
            GL.Enable(GL.GL_TEXTURE_2D);
            GL.BindTexture(GL.GL_TEXTURE_2D, value.TextureId);
            program.SetUniform(VarName, (int)((uint)value.ActiveTextureIndex - GL.GL_TEXTURE0));
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
        private uint textureId;

        public uint TextureId
        {
            get { return textureId; }
            set { textureId = value; }
        }
        private uint activeTextureIndex;

        public uint ActiveTextureIndex
        {
            get { return activeTextureIndex; }
            set { activeTextureIndex = value; }
        }

        public samplerValue(uint textureId, uint activeTextureIndex)
        {
            this.textureId = textureId;
            this.activeTextureIndex = activeTextureIndex;
        }

        static readonly char[] separator = new char[] { '[', ']', };

        public static samplerValue Parse(string value)
        {
            string[] parts = value.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            uint textureId = uint.Parse(parts[1]);
            uint activeTextureIndex = uint.Parse(parts[3]);

            return new samplerValue(textureId, activeTextureIndex);
        }

        public override string ToString()
        {
            return string.Format("texture id:[{0}] active texture index:[{1}]", textureId, activeTextureIndex);
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
            return (this.activeTextureIndex == p.activeTextureIndex && this.textureId == p.textureId);
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

    }
}
