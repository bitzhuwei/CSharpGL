using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpShaderLanguage
{
    /// <summary>
    /// 此处不需要实现。
    /// </summary>
    [global::System.Serializable]
    class NotNeedToImplementException : Exception
    {
        /// <summary>
        /// 此处不需要实现。
        /// </summary>
        public NotNeedToImplementException() { }

        /// <summary>
        /// 此处不需要实现。
        /// </summary>
        /// <param name="message"></param>
        public NotNeedToImplementException(string message) : base(message) { }

        /// <summary>
        /// 此处不需要实现。
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public NotNeedToImplementException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// 此处不需要实现。
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected NotNeedToImplementException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
