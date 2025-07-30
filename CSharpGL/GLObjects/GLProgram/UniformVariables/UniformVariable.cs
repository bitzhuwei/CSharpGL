namespace CSharpGL {
    /// <summary>
    /// An uniform variable in shader.
    /// </summary>
    public abstract unsafe class UniformVariable {
        /// <summary>
        /// variable name.
        /// </summary>
        public readonly string varName;

        /// <summary>
        /// location retrieved from shader.
        /// </summary>
        public int location;

        /// <summary>
        /// 标识此uniform变量是否已更新（若为true，则需要在render前一刻提交到GPU）
        /// <para>If true, set uniform's value to GPU; otherwise nothing needed to do.</para>
        /// </summary>

        public bool updated = true;

        /// <summary>
        /// An uniform variable in shader.
        /// </summary>
        /// <param name="varName">variable name.</param>
        public UniformVariable(string varName) {
            this.varName = varName;
        }

        /// <summary>
        /// Set uniform's value to GPU.(And maybe alsoe reset <see cref="updated"/> property.)
        /// </summary>
        /// <param name="program"></param>
        public void SetUniform(GLProgram program) {
            if (this.updated) {
                this.DoSetUniform(program);
                // TODO: use uniform block to make 'updated' works.
                //this.updated = false;
            }
        }

        /// <summary>
        /// Set uniform's value to GPU.(And maybe alsoe reset <see cref="updated"/> property.)
        /// </summary>
        /// <param name="program"></param>
        protected abstract void DoSetUniform(GLProgram program);
    }
}