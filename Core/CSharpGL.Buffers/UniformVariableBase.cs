using CSharpGL.Objects.Shaders;
using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Buffers
{
    /// <summary>
    /// shader中的一个uniform变量。
    /// </summary>
    public abstract class UniformVariableBase
    {

        /// <summary>
        /// 变量名。
        /// </summary>
        public string VarName { get; private set; }


        /// <summary>
        /// shader中的一个uniform变量。
        /// </summary>
        /// <param name="varName"></param>
        public UniformVariableBase(string varName)
        {
            this.VarName = varName;
        }

        public abstract void SetUniform(ShaderProgram program);
    }

    public class UniformFloat : UniformVariableBase
    {

        /// <summary>
        /// 用字段减少复制，提升效率。
        /// </summary>
        public float Value;

        public UniformFloat(string varName) : base(varName) { }

        public override void SetUniform(ShaderProgram program)
        {
            program.SetUniform(VarName, Value);
        }
    }

    public class UniformVec2 : UniformVariableBase
    {

        /// <summary>
        /// 用字段减少复制，提升效率。
        /// </summary>
        public vec2 Value;

        public UniformVec2(string varName) : base(varName) { }

        public override void SetUniform(ShaderProgram program)
        {
            vec2 value = this.Value;
            program.SetUniform(VarName, value.x, value.y);
        }
    }

    public class UniformVec3 : UniformVariableBase
    {

        /// <summary>
        /// 用字段减少复制，提升效率。
        /// </summary>
        public vec3 Value;

        public UniformVec3(string varName) : base(varName) { }

        public override void SetUniform(ShaderProgram program)
        {
            vec3 value = this.Value;
            program.SetUniform(VarName, value.x, value.y, value.z);
        }
    }

    public class UniformVec4 : UniformVariableBase
    {

        /// <summary>
        /// 用字段减少复制，提升效率。
        /// </summary>
        public vec4 Value;

        public UniformVec4(string varName) : base(varName) { }

        public override void SetUniform(ShaderProgram program)
        {
            vec4 value = this.Value;
            program.SetUniform(VarName, value.x, value.y, value.z, value.w);
        }
    }

    public class Uniformmat2 : UniformVariableBase
    {

        /// <summary>
        /// 用字段减少复制，提升效率。
        /// </summary>
        public mat2 Value;

        public Uniformmat2(string varName) : base(varName) { }

        public override void SetUniform(ShaderProgram program)
        {
            program.SetUniformMatrix2(VarName, this.Value.to_array());
        }
    }

    public class Uniformmat3 : UniformVariableBase
    {

        /// <summary>
        /// 用字段减少复制，提升效率。
        /// </summary>
        public mat3 Value;

        public Uniformmat3(string varName) : base(varName) { }

        public override void SetUniform(ShaderProgram program)
        {
            program.SetUniformMatrix3(VarName, this.Value.to_array());
        }
    }

    public class Uniformmat4 : UniformVariableBase
    {

        /// <summary>
        /// 用字段减少复制，提升效率。
        /// </summary>
        public mat4 Value;

        public Uniformmat4(string varName) : base(varName) { }

        public override void SetUniform(ShaderProgram program)
        {
            program.SetUniformMatrix4(VarName, this.Value.to_array());
        }
    }
}
