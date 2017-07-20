using System;
using System.ComponentModel;

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
        public UniformSampler(string varName)
            : base(varName)
        {
        }

        /// <summary>
        /// uniform samplerXD variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformSampler(string varName, samplerValue value)
            : base(varName, value)
        {
        }

        private static GLDelegates.void_uint glActiveTexture;

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        protected override void DoSetUniform(ShaderProgram program)
        {
            if (glActiveTexture == null)
            { glActiveTexture = GL.Instance.GetDelegateFor("glActiveTexture", GLDelegates.typeof_void_uint) as GLDelegates.void_uint; }
            glActiveTexture(value.TextureUnitIndex + GL.GL_TEXTURE0);
            //OpenGL.BindTexture(GL.GL_TEXTURE_2D, value.TextureId);
            GL.Instance.BindTexture(value.target, value.TextureId);
            this.Location = program.glUniform(VarName, (int)value.TextureUnitIndex);
        }

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="program"></param>
        //public override void ResetUniform(ShaderProgram program)
        //{
        //    if (activeTexture == null)
        //    { activeTexture = OpenGL.GetDelegateFor<OpenGL.glActiveTexture>(); }
        //    activeTexture(value.activeTextureIndex + GL.GL_TEXTURE0);
        //    GL.Instance.BindTexture(value.target, 0);
        //    //base.ResetUniform(program);
        //    //if (glActiveTexture == null)
        //    //{ glActiveTexture = OpenGL.GetDelegateFor<OpenGL.glActiveTexture>(); }
        //    //glActiveTexture(value.ActiveTextureIndex);
        //    ////OpenGL.BindTexture(GL.GL_TEXTURE_2D, 0);
        //    //OpenGL.BindTexture(value.target, 0);
        //}

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
        public TextureTarget Target
        {
            get { return (TextureTarget)target; }
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

        private uint textureUnitIndex;

        /// <summary>
        /// 0 means GL.GL_TEXTURE0, 1 means GL.GL_TEXTURE1, ...
        /// </summary>
        public uint TextureUnitIndex
        {
            get { return textureUnitIndex; }
            set { textureUnitIndex = value; }
        }

        /// <summary>
        /// value for setting/resetting uniform samplerXD variable.
        /// </summary>
        /// <param name="texture"></param>
        public samplerValue(Texture texture)
        {
            this.target = (uint)texture.Target;
            this.textureId = texture.Id;
            this.textureUnitIndex = texture.TextureUnitIndex;
        }

        /// <summary>
        /// value for setting/resetting uniform samplerXD variable.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="textureId"></param>
        /// <param name="textureUnitIndex"></param>
        public samplerValue(TextureTarget target, uint textureId, uint textureUnitIndex)
        {
            this.target = (uint)target;
            this.textureId = textureId;
            this.textureUnitIndex = textureUnitIndex;
        }

        private static readonly char[] separator = new char[] { '[', ']', };

        internal static samplerValue Parse(string value)
        {
            string[] parts = value.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            TextureTarget target = (TextureTarget)Enum.Parse(typeof(TextureTarget), parts[1]);
            uint textureId = uint.Parse(parts[3]);
            uint textureUnitIndex = uint.Parse(parts[5]);

            return new samplerValue(target, textureId, textureUnitIndex);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Target:[{0}], Id:[{1}], TextureUnitIndex:[{2}]", target, textureId, textureUnitIndex);
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
            return string.Format("{0}#{1}#{2}", target, textureId, textureUnitIndex).GetHashCode();
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
                && this.textureUnitIndex == other.textureUnitIndex
                );
        }

        void ILoadFromString.Load(string value)
        {
            string[] parts = value.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            TextureTarget target = (TextureTarget)Enum.Parse(typeof(TextureTarget), parts[1]);
            this.target = (uint)target;
            this.textureId = uint.Parse(parts[3]);
            this.textureUnitIndex = uint.Parse(parts[5]);
        }
    }
}