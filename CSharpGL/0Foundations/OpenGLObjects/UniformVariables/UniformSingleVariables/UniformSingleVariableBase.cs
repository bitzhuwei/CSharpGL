namespace CSharpGL
{
    /// <summary>
    /// shader中的一个uniform变量。
    /// </summary>
    public abstract class UniformSingleVariableBase : UniformVariable
    {
        /// <summary>
        /// shader中的一个uniform变量。
        /// </summary>
        /// <param name="varName"></param>
        public UniformSingleVariableBase(string varName) : base(varName) { }
    }
}