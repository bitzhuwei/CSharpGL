using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    [Serializable]
    public class ShaderCompilationException : Exception
    {
        private readonly string compilerOutput;

        public ShaderCompilationException(string compilerOutput)
        {
            this.compilerOutput = compilerOutput;
        }
        public ShaderCompilationException(string message, string compilerOutput)
            : base(message)
        {
            this.compilerOutput = compilerOutput;
        }
        public ShaderCompilationException(string message, Exception inner, string compilerOutput)
            : base(message, inner)
        {
            this.compilerOutput = compilerOutput;
        }
        protected ShaderCompilationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        { }

        public string CompilerOutput { get { return compilerOutput; } }

        public override string ToString()
        {
            //return base.ToString();
            return string.Format("{0}{1}{2}", base.ToString(), Environment.NewLine, compilerOutput);
        }
    }
}
