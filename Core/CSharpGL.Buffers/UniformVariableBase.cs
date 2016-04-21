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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        internal abstract void SetValue(ValueType value);

        public abstract ValueType GetValue();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        public abstract void SetUniform(ShaderProgram program);

        public override string ToString()
        {
            return string.Format("{0}: {1}", this.VarName, this.GetValue());
        }

        public override bool Equals(object obj)
        {
            UniformVariableBase uniformVar = obj as UniformVariableBase;
            if (uniformVar == null) { return false; }
            return this.VarName == uniformVar.VarName;
        }

        public override int GetHashCode()
        {
            return this.VarName.GetHashCode();
        }
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

        internal override void SetValue(ValueType value)
        {
            if (value.GetType() != typeof(float))
            {
                throw new ArgumentException(string.Format("[{0}] not match [{1}]'s value.",
                    value.GetType().Name, this.GetType().Name));
            }

            this.Value = (float)value;
        }

        public override ValueType GetValue()
        {
            return Value;
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

        internal override void SetValue(ValueType value)
        {
            if (value.GetType() != typeof(vec2))
            {
                throw new ArgumentException(string.Format("[{0}] not match [{1}]'s value.",
                    value.GetType().Name, this.GetType().Name));
            }

            this.Value = (vec2)value;
        }

        public override ValueType GetValue()
        {
            return Value;
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

        internal override void SetValue(ValueType value)
        {
            if (value.GetType() != typeof(vec3))
            {
                throw new ArgumentException(string.Format("[{0}] not match [{1}]'s value.",
                    value.GetType().Name, this.GetType().Name));
            }

            this.Value = (vec3)value;
        }

        public override ValueType GetValue()
        {
            return Value;
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

        internal override void SetValue(ValueType value)
        {
            if (value.GetType() != typeof(vec4))
            {
                throw new ArgumentException(string.Format("[{0}] not match [{1}]'s value.",
                    value.GetType().Name, this.GetType().Name));
            }

            this.Value = (vec4)value;
        }

        public override ValueType GetValue()
        {
            return Value;
        }
    }

    public class UniformMat2 : UniformVariableBase
    {

        /// <summary>
        /// 用字段减少复制，提升效率。
        /// </summary>
        public mat2 Value;

        public UniformMat2(string varName) : base(varName) { }

        public override void SetUniform(ShaderProgram program)
        {
            program.SetUniformMatrix2(VarName, this.Value.to_array());
        }

        internal override void SetValue(ValueType value)
        {
            if (value.GetType() != typeof(mat2))
            {
                throw new ArgumentException(string.Format("[{0}] not match [{1}]'s value.",
                    value.GetType().Name, this.GetType().Name));
            }

            this.Value = (mat2)value;
        }

        public override ValueType GetValue()
        {
            return Value;
        }
    }

    public class UniformMat3 : UniformVariableBase
    {

        /// <summary>
        /// 用字段减少复制，提升效率。
        /// </summary>
        public mat3 Value;

        public UniformMat3(string varName) : base(varName) { }

        public override void SetUniform(ShaderProgram program)
        {
            program.SetUniformMatrix3(VarName, this.Value.to_array());
        }

        internal override void SetValue(ValueType value)
        {
            if (value.GetType() != typeof(mat3))
            {
                throw new ArgumentException(string.Format("[{0}] not match [{1}]'s value.",
                    value.GetType().Name, this.GetType().Name));
            }

            this.Value = (mat3)value;
        }

        public override ValueType GetValue()
        {
            return Value;
        }
    }

    public class UniformMat4 : UniformVariableBase
    {

        /// <summary>
        /// 用字段减少复制，提升效率。
        /// </summary>
        public mat4 Value;

        public UniformMat4(string varName) : base(varName) { }

        public override void SetUniform(ShaderProgram program)
        {
            program.SetUniformMatrix4(VarName, this.Value.to_array());
        }

        internal override void SetValue(ValueType value)
        {
            if (value.GetType() != typeof(mat4))
            {
                throw new ArgumentException(string.Format("[{0}] not match [{1}]'s value.",
                    value.GetType().Name, this.GetType().Name));
            }

            this.Value = (mat4)value;
        }

        public override ValueType GetValue()
        {
            return Value;
        }
    }
}
