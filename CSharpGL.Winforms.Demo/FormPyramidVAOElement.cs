using CSharpGL.Maths;
using CSharpGL.Objects.Shaders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.Winforms.Demo
{
    public partial class FormPyramidVAOElement : Form
    {
        PyramidVAOElement element;
        public mat4 projectionMatrix;
        public mat4 viewMatrix;
        public mat4 modelMatrix;
        private float rotation;

        public FormPyramidVAOElement()
        {
            InitializeComponent();

            element = new PyramidVAOElement();
            element.Initialize();

            element.BeforeRendering += element_BeforeRendering;
            element.AfterRendering += element_AfterRendering;
        }

        void element_AfterRendering(object sender, Objects.RenderEventArgs e)
        {
            element.shaderProgram.Unbind();
        }

        void element_BeforeRendering(object sender, Objects.RenderEventArgs e)
        {
            rotation += 3.0f;
            mat4 modelMatrix = glm.rotate(rotation, new vec3(0, 1, 0));

            const float distance = 0.2f;
            viewMatrix = glm.lookAt(new vec3(-distance, distance, -distance), new vec3(0, 0, 0), new vec3(0, -1, 0));

            int[] viewport = new int[4];
            GL.GetInteger(GetTarget.Viewport, viewport);
            projectionMatrix = glm.perspective(60.0f, (float)viewport[2] / (float)viewport[3], 0.01f, 100.0f);

            ShaderProgram shaderProgram = element.shaderProgram;
            shaderProgram.Bind();

            shaderProgram.SetUniformMatrix4(PyramidVAOElement.strprojectionMatrix, projectionMatrix.to_array());
            shaderProgram.SetUniformMatrix4(PyramidVAOElement.strviewMatrix, viewMatrix.to_array());
            shaderProgram.SetUniformMatrix4(PyramidVAOElement.strmodelMatrix, modelMatrix.to_array());
        }

        private void glCanvas1_OpenGLDraw(object sender, RenderEventArgs e)
        {
            GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            element.Render(Objects.RenderModes.Render);
        }
    }
}
