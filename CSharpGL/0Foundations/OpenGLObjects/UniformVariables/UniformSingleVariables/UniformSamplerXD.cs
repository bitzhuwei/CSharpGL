
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// uniform samplerXD variable;
    /// </summary>
    public class UniformSampler : UniformSingleVariable<samplerValue>
    {

        /// <summary>
        /// uniform samplerXD variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformSampler(string varName) : base(varName) { }
        /// <summary>
        /// uniform samplerXD variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformSampler(string varName, samplerValue value) : base(varName, value) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        public override void SetUniform(ShaderProgram program)
        {
            OpenGL.ActiveTexture(value.ActiveTextureIndex);
            //OpenGL.BindTexture(OpenGL.GL_TEXTURE_2D, value.TextureId);
            OpenGL.BindTexture(value.target, value.TextureId);
            this.Location = program.SetUniform(VarName, value.activeTextureIndex);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        public override void ResetUniform(ShaderProgram program)
        {
            OpenGL.ActiveTexture(value.ActiveTextureIndex);
            OpenGL.BindTexture(value.target, 0);
            //base.ResetUniform(program);
            //if (glActiveTexture == null)
            //{ glActiveTexture = OpenGL.GetDelegateFor<OpenGL.glActiveTexture>(); }
            //glActiveTexture(value.ActiveTextureIndex);
            ////OpenGL.BindTexture(OpenGL.GL_TEXTURE_2D, 0);
            //OpenGL.BindTexture(value.target, 0);
        }
    }

    /// <summary>
    /// value for setting/resetting uniform samplerXD variable.
    /// </summary>
    [TypeConverter(typeof(StructTypeConverter<samplerValue>))]
    public struct samplerValue : IEquatable<samplerValue>, ILoadFromString
    {
        internal uint target;
        /// <summary>
        /// 
        /// </summary>
        public BindTextureTarget Target
        {
            get { return (BindTextureTarget)target; }
            set { target = (uint)value; }
        }

        private uint textureId;
        /// <summary>
        /// 
        /// </summary>
        public uint TextureId
        {
            get { return textureId; }
            set { textureId = value; }
        }

        internal uint activeTextureIndex;
        /// <summary>
        /// OpenGL.GL_TEXTURE0, OpenGL.GL_TEXTURE1, OpenGL.GL_TEXTURE2, ...
        /// </summary>
        public uint ActiveTextureIndex
        {
            get { return (activeTextureIndex + OpenGL.GL_TEXTURE0); }
            set { activeTextureIndex = (value - OpenGL.GL_TEXTURE0); }
        }

        /// <summary>
        /// value for setting/resetting uniform samplerXD variable.
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("texture target: [{0}] texture id:[{1}] active texture index:[{2}]", target, textureId, activeTextureIndex);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(samplerValue left, samplerValue right)
        {
            return !left.Equals(right);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj is samplerValue) && (this.Equals((samplerValue)obj));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return string.Format("{0}#{1}#{2}", target, textureId, activeTextureIndex).GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(samplerValue other)
        {
            return (
                this.target == other.target
                && this.textureId == other.textureId
                && this.activeTextureIndex == other.activeTextureIndex
                );
        }

        void ILoadFromString.Load(string value)
        {
            string[] parts = value.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            BindTextureTarget target = (BindTextureTarget)Enum.Parse(typeof(BindTextureTarget), parts[1]);
            uint textureId = uint.Parse(parts[3]);
            uint activeTextureIndex = uint.Parse(parts[5]);
            this.target = (uint)target;
            this.textureId = textureId;
            this.activeTextureIndex = (activeTextureIndex - OpenGL.GL_TEXTURE0);
        }
    }
}
