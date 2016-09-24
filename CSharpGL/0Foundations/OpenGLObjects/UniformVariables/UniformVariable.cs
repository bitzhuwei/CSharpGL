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

        private bool updated = true;

        /// <summary>
        /// 标识此uniform变量是否已更新（若为true，则需要在render前一刻提交到GPU）
        /// <para>Set uniform's value to GPU if true; otherwise nothing to do.</para>
        /// </summary>
        public bool Updated { get { return updated; } set { updated = value; } }

        /// <summary>
        /// An uniform variable in shader.
        /// </summary>
        /// <param name="varName">variable name.</param>
        public UniformVariable(string varName)
        {
            this.VarName = varName;
        }

        /// <summary>
        /// Set uniform's value to GPU.(And maybe alsoe reset <see cref="Updated"/> property.)
        /// </summary>
        /// <param name="program"></param>
        public void SetUniform(ShaderProgram program)
        {
            if (this.Updated)
            {
                this.DoSetUniform(program);
            }
        }

        /// <summary>
        /// Set uniform's value to GPU.(And maybe alsoe reset <see cref="Updated"/> property.)
        /// </summary>
        /// <param name="program"></param>
        protected abstract void DoSetUniform(ShaderProgram program);
    }
}