using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharpGL;

namespace CSharpGL3.Demo
{
    public partial class FormMain
    {


        private void FormMain_Load(object sender, EventArgs e)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(System.IO.File.ReadAllText(@"Demo.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(System.IO.File.ReadAllText(@"Demo.frag"), ShaderType.FragmentShader);
            var program = new GLProgramNode(shaderCodes);

            var positions = new vec3[6]; var diff = new vec3(1, -1, 1) * 0.5f;
            positions[0] = new vec3(-1, -1, 0) * 0.5f;
            positions[1] = new vec3(-1, 1, 0) * 0.5f;
            positions[2] = new vec3(1, 1, 0) * 0.5f;
            positions[3] = (new vec3(-1, -1, 0) + diff) * 0.5f;
            positions[4] = (new vec3(-1, 1, 0) + diff) * 0.5f;
            positions[5] = (new vec3(1, 1, 0) + diff) * 0.5f;
            var positionNode = new GLPositionsNode(positions);
            //var positionNode = GLVertexNode.Create(positions, VBOConfig.Vec3, "in_Position", BufferUsage.StaticDraw);

            var colors = new vec3[6];
            colors[0] = Color.Red.ToVec3();
            colors[1] = Color.Green.ToVec3();
            colors[2] = Color.Blue.ToVec3();
            colors[3] = Color.Orange.ToVec3();
            colors[4] = Color.LightGreen.ToVec3();
            colors[5] = Color.DarkBlue.ToVec3();
            var colorNode = new GLColorsNode(colors);
            //var colorNode = GLVertexNode.Create(colors, VBOConfig.Vec3, "in_Color", BufferUsage.StaticDraw);

            var indexNode = new GLZeroIndexNode(CSharpGL.DrawMode.Triangles, 0, positions.Length);

            var shapeNode = new GLPositionColorNode();

            root = new GLSeparatorNode();
            root.Children.Add(program);
            root.Children.Add(positionNode);
            root.Children.Add(colorNode);
            root.Children.Add(indexNode);
            root.Children.Add(shapeNode);

            this.renderAction = new RenderAction();
            this.renderAction.AppliedNode = this.root;
        }

    }
}
