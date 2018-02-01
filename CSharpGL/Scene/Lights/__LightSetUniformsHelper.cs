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
        // lightUpRoutine:
        // 0: PointLight;  1: DirectionalLight; 
        // 2: SpotLight;
        // 3: XSpotLight;  4: NXSpotLight;
        // 5: YSpotLight;  6: NYSpotLight;
        // 7: ZSpotLight;  8: NZSpotLight;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="light"></param>
        /// <param name="program"></param>
        public static void SetBlinnPhongUniforms(this LightBase light, ShaderProgram program)
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
            else if (light is TSpotLight)
            {
                SetUniforms(light as TSpotLight, program);
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
            //program.SetUniform("light.direction", );
            //program.SetUniform("light.cutOff", );

            int lightUpRoutine = 0;
            program.SetUniform("lightUpRoutine", lightUpRoutine);
        }

        private static void SetUniforms(this DirectionalLight light, ShaderProgram program)
        {
            //program.SetUniform("light.position", light.Position);// for directional light, meaningless.
            program.SetUniform("light.diffuse", light.Diffuse);
            program.SetUniform("light.specular", light.Specular);
            //program.SetUniform("light.constant", light.Attenuation.Constant);
            //program.SetUniform("light.linear", light.Attenuation.Linear);
            //program.SetUniform("light.quadratic", light.Attenuation.Exp);
            program.SetUniform("light.direction", light.Direction);
            //program.SetUniform("light.cutOff", 0.0f);// for directional light, meanlingless.

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
            program.SetUniform("light.direction", light.Position - light.Target);
            program.SetUniform("light.cutOff", light.CutOff);

            const int lightUpRoutine = 2;
            program.SetUniform("lightUpRoutine", lightUpRoutine);
        }

        private static void SetUniforms(this TSpotLight light, ShaderProgram program)
        {
            program.SetUniform("light.position", light.Position);
            program.SetUniform("light.diffuse", light.Diffuse);
            program.SetUniform("light.specular", light.Specular);
            program.SetUniform("light.constant", light.Attenuation.Constant);
            program.SetUniform("light.linear", light.Attenuation.Linear);
            program.SetUniform("light.quadratic", light.Attenuation.Exp);
            program.SetUniform("light.direction", light.Direction.ToVec3());
            //program.SetUniform("light.cutOff", light.CutOff);

            int lightUpRoutine = (int)light.Direction;
            program.SetUniform("lightUpRoutine", lightUpRoutine);
        }

    }
}
