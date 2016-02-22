using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpShadingLanguage
{
    /// <summary>
    /// 此CSSL是否要被dump到GLSL文件。
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class Dump2FileAttribute : Attribute
    {
        /// <summary>
        /// 此CSSL是否要被dump到GLSL文件。
        /// </summary>
        public bool Dump2File { get; private set; }

        /// <summary>
        /// 此CSSL是否要被dump到GLSL文件。
        /// </summary>
        /// <param name="dump2File"></param>
        public Dump2FileAttribute(bool dump2File = true)
        {
            this.Dump2File = dump2File;
        }


        public override string ToString()
        {
            return string.Format("Dump to file: {0}", this.Dump2File);
        }
    }
}
