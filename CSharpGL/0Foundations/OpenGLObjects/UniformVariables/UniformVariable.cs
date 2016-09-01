namespace CSharpGL
{
    /// <summary>
    /// An uniform variable in shader.
    /// </summary>
    public abstract class UniformVariable
    {
        /// <summary>
        /// variable name.
        /// </summary>
        public string VarName { get; private set; }

        /// <summary>
        /// location retrieved from shader.
        /// </summary>
        public int Location { get; internal set; }

        /// <summary>
        /// 标识此uniform变量是否已更新（若为true，则需要在render前一刻提交到GPU）
        /// <para>Set uniform's value to GPU if true; otherwise nothing to do.</para>
        /// </summary>
        public bool Updated { get; set; }

        /// <summary>
        /// An uniform variable in shader.
        /// </summary>
        /// <param name="varName">variable name.</param>
        public UniformVariable(string varName)
        {
            this.VarName = varName;
            this.Updated = true;
        }

        /// <summary>
        /// Set uniform's value to GPU.
        /// </summary>
        /// <param name="program"></param>
        public abstract void SetUniform(ShaderProgram program);

        /// <summary>
        /// 默认重置Updated = false;
        /// <para>以避免重复设置。</para>
        /// <para>某些类型的uniform可能需要重复调用SetUniform()（例如纹理类型的uniform sampler2D）</para>
        /// <para>Simply set <code>this.Updated = false;</code> by default to avoid repeatly setting uniform variable.</para>
        /// <para>But some types of uniform variables may need to be set repeatly(uniform sampler2D etc.) and that's when you should override this method.</para>
        /// </summary>
        /// <param name="program"></param>
        public virtual void ResetUniform(ShaderProgram program)
        {
            this.Updated = false;
        }
    }
}