namespace CSharpGL
{
    public partial class Renderer
    {
        //private Stack<UniformVariable> uniformVariableStack = new Stack<UniformVariable>();

        //private Stack<UniformArrayVariable> uniformArrayVariableStack = new Stack<UniformArrayVariable>();
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        protected override void DoRender(RenderEventArgs arg)
        {
            ShaderProgram program = this.Program;

            // 绑定shader
            program.Bind();
            program.PushUniforms();

            GLState[] stateList = this.stateList.ToArray();
            StatesOn(stateList);

            this.vertexArrayObject.Render(arg, program);

            StatesOff(stateList);

            // 解绑shader
            program.Unbind();
        }

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void StatesOn(GLState[] stateList)
        {
            int count = stateList.Length;
            for (int i = 0; i < count; i++)
            {
                stateList[i].On();
            }
        }

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void StatesOff(GLState[] stateList)
        {
            int count = stateList.Length;
            for (int i = count - 1; i >= 0; i--)
            {
                stateList[i].Off();
            }
        }

    }
}