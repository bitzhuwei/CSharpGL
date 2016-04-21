using GLM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// shader中的一个uniform变量。
    /// </summary>
    public abstract class UniformVariable
    {

        /// <summary>
        /// 变量名。
        /// </summary>
        public string VarName { get; private set; }

        /// <summary>
        /// 已更新（需要在render时提交到GPU）
        /// </summary>
        [Browsable(false)]
        public bool Updated { get; set; }

        /// <summary>
        /// shader中的一个uniform变量。
        /// </summary>
        /// <param name="varName"></param>
        public UniformVariable(string varName)
        {
            this.VarName = varName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        internal abstract bool SetValue(ValueType value);

        internal abstract ValueType GetValue();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        public abstract void SetUniform(ShaderProgram program);

        public virtual void ResetUniform(ShaderProgram program) { }

        public override string ToString()
        {
            return string.Format("{0}: {1}", this.VarName, this.GetValue());
        }

    }

}
