using System;
using bitzhuwei.Compiler;
using SoftGLImpl;

namespace bitzhuwei.PreDirectiveFormat {
    internal interface IFullFormat {
        /// <summary>
        /// update <paramref name="ppContext"/>'s state.
        /// </summary>
        /// <param name="ppContext"></param>
        void Update(SoftGLImpl.PpContext ppContext);
    }

}
