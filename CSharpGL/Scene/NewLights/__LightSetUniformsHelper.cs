using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public static class __LightSetUniformsHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="light"></param>
        /// <param name="program"></param>
        public static void SetUniforms(this LightBase light, ShaderProgram program)
        {
            if (light is PointLight)
            {
                SetUniforms(light as PointLight, program);
            }
            else if (light is DirectionalLight)
            {
                SetUniforms(light as DirectionalLight, program);
            }
            else if (light is SpotLight)
            {
                SetUniforms(light as SpotLight, program);
            }
            else
            {
                throw new System.Exception(string.Format("Not expected light type:[{0}].", light.GetType()));
            }
        }

        private static void SetUniforms(this PointLight light, ShaderProgram program)
        {
            program.SetUniform("light.position", light.Position);
            program.SetUniform("light.diffuse", light.Diffuse);
            program.SetUniform("light.specular", light.Specular);
            program.SetUniform("light.constant", light.Attenuation.Constant);
            program.SetUniform("light.linear", light.Attenuation.Linear);
            program.SetUniform("light.quadratic", light.Attenuation.Exp);
            program.SetUniform("light.direction", new vec3());// for point light, meaningless.
            program.SetUniform("light.cutOff", 0.0f);// for point light, meanlingless.

            // 0: point light; 1: directional light; 2: spot light.
            const int lightUpRoutine = 0;
            program.SetUniform("lightUpRoutine", lightUpRoutine);

        }

        private static void SetUniforms(this DirectionalLight light, ShaderProgram program)
        {
            program.SetUniform("light.position", light.Position);// for directional light, meaningless.
            program.SetUniform("light.diffuse", light.Diffuse);
            program.SetUniform("light.specular", light.Specular);
            program.SetUniform("light.constant", light.Attenuation.Constant);
            program.SetUniform("light.linear", light.Attenuation.Linear);
            program.SetUniform("light.quadratic", light.Attenuation.Exp);
            program.SetUniform("light.direction", light.Direction);
            program.SetUniform("light.cutOff", 0.0f);// for directional light, meanlingless.

            // 0: point light; 1: directional light; 2: spot light.
            const int lightUpRoutine = 1;
            program.SetUniform("lightUpRoutine", lightUpRoutine);

        }

        private static void SetUniforms(this SpotLight light, ShaderProgram program)
        {
            program.SetUniform("light.position", light.Position);
            program.SetUniform("light.diffuse", light.Diffuse);
            program.SetUniform("light.specular", light.Specular);
            program.SetUniform("light.constant", light.Attenuation.Constant);
            program.SetUniform("light.linear", light.Attenuation.Linear);
            program.SetUniform("light.quadratic", light.Attenuation.Exp);
            program.SetUniform("light.direction", light.Direction);
            program.SetUniform("light.cutOff", light.CutOff);

            // 0: point light; 1: directional light; 2: spot light.
            const int lightUpRoutine = 2;
            program.SetUniform("lightUpRoutine", lightUpRoutine);

        }
    }
}
