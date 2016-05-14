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
            this.Updated = true;
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

        /// <summary>
        /// 默认重置Updated = false;
        /// <para>以避免重复设置。</para>
        /// <para>某些类型的uniform可能需要重复调用SetUniform()（例如纹理类型的uniform sampler2D）</para>
        /// </summary>
        /// <param name="program"></param>
        public virtual void ResetUniform(ShaderProgram program) { this.Updated = false; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", this.VarName, this.GetValue());
        }

    }

}
