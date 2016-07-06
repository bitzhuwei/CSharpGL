
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{

    public class UniformSampler : UniformSingleVariable
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

        public UniformSampler(string varName) : base(varName) { }

        public UniformSampler(string varName, samplerValue value) : base(varName) { this.Value = value; }

        static OpenGL.glActiveTexture glActiveTexture = null;

        public override void SetUniform(ShaderProgram program)
        {
            if (glActiveTexture == null)
            { glActiveTexture = OpenGL.GetDelegateFor<OpenGL.glActiveTexture>(); }
            glActiveTexture(value.ActiveTextureIndex);
            //OpenGL.BindTexture(OpenGL.GL_TEXTURE_2D, value.TextureId);
            OpenGL.BindTexture(value.target, value.TextureId);
            this.Location = program.SetUniform(VarName, value.activeTextureIndex);
        }

        public override void ResetUniform(ShaderProgram program)
        {
            //base.ResetUniform(program);
            //if (glActiveTexture == null)
            //{ glActiveTexture = OpenGL.GetDelegateFor<OpenGL.glActiveTexture>(); }
            //glActiveTexture(value.ActiveTextureIndex);
            ////OpenGL.BindTexture(OpenGL.GL_TEXTURE_2D, 0);
            //OpenGL.BindTexture(value.target, 0);
        }

        internal override bool SetValue(ValueType value)
        {
#if DEBUG
            if (value.GetType() != typeof(samplerValue))
            {
                throw new ArgumentException(string.Format("[{0}] not match [{1}]'s value.",
                    value.GetType().Name, this.GetType().Name));
            }
#endif

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
        internal uint target;

        public BindTextureTarget Target
        {
            get { return (BindTextureTarget)target; }
            set { target = (uint)value; }
        }

        private uint textureId;

        public uint TextureId
        {
            get { return textureId; }
            set { textureId = value; }
        }

        internal uint activeTextureIndex;

        public uint ActiveTextureIndex
        {
            get { return (activeTextureIndex + OpenGL.GL_TEXTURE0); }
            set { activeTextureIndex = (value - OpenGL.GL_TEXTURE0); }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <param name="textureId"></param>
        /// <param name="activeTextureIndex">OpenGL.GL_TEXTURE0 etc</param>
        public samplerValue(BindTextureTarget target, uint textureId, uint activeTextureIndex)
        {
            this.target = (uint)target;
            this.textureId = textureId;
            this.activeTextureIndex = (activeTextureIndex - OpenGL.GL_TEXTURE0);
        }

        static readonly char[] separator = new char[] { '[', ']', };

        internal static samplerValue Parse(string value)
        {
            string[] parts = value.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            BindTextureTarget target = (BindTextureTarget)Enum.Parse(typeof(BindTextureTarget), parts[1]);
            uint textureId = uint.Parse(parts[3]);
            uint activeTextureIndex = uint.Parse(parts[5]);

            return new samplerValue(target, textureId, activeTextureIndex);
        }

        public override string ToString()
        {
            return string.Format("texture target: [{0}] texture id:[{1}] active texture index:[{2}]", target, textureId, activeTextureIndex);
        }

        public static bool operator ==(samplerValue left, samplerValue right)
        {
            //object leftObj = left, rightObj = right;
            //if (leftObj == null)
            //{
            //    if (rightObj == null) { return true; }
            //    else { return false; }
            //}
            //else
            //{
            //    if (rightObj == null) { return false; }
            //}

            return left.Equals(right);
        }

        public static bool operator !=(samplerValue left, samplerValue right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            var p = (samplerValue)obj;

            return (
                this.target == p.target
                && this.activeTextureIndex == p.activeTextureIndex
                && this.textureId == p.textureId);
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

    }

    public enum BindTextureTarget : uint
    {
        Texture1D = OpenGL.GL_TEXTURE_1D,
        Texture2D = OpenGL.GL_TEXTURE_2D,
        Texture3D = OpenGL.GL_TEXTURE_3D,
    }
}
