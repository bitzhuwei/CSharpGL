using System;

namespace CSharpGL.CSSL
{
    /// <summary>
    /// 此CSSL是否要被dump到GLSL文件。
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class GLSLVersionAttribute : Attribute
    {
        /// <summary>
        /// 此CSSL是否要被dump到GLSL文件。
        /// </summary>
        public GLSLVersion Version { get; private set; }

        /// <summary>
        /// 此CSSL是否要被dump到GLSL文件。
        /// </summary>
        /// <param name="dump2File"></param>
        public GLSLVersionAttribute(GLSLVersion version)
        {
            this.Version = version;
        }

        public override string ToString()
        {
            return string.Format("GLSL version: {0}", this.Version);
        }
    }

    public enum GLSLVersion
    {
        v150,
    }
}