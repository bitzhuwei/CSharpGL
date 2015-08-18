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
    public partial class FormTransformFeedback : Form
    {
        uint[] TimerQueryName = new uint[1];
        uint[] Query = new uint[1];

        private FormWhiteBoard frmWhiteBoard;

        public FormTransformFeedback()
        {
            InitializeComponent();
        }

        private void FormTransformFeedback_Load(object sender, EventArgs e)
        {
            frmWhiteBoard = new FormWhiteBoard();
            frmWhiteBoard.Show();

            GL.Enable(GL.GL_DEBUG_OUTPUT);
            GL.Enable(GL.GL_DEBUG_OUTPUT_SYNCHRONOUS_ARB);
            GL.DebugMessageControl(
                Enumerations.DebugMessageControlSource.DONT_CARE,
                Enumerations.DebugMessageControlType.DONT_CARE, 
                Enumerations.DebugMessageControlSeverity.DONT_CARE, 0, null, true);
            GL.DebugMessageCallback(this.CallbackProc, this.Handle);

            GL.GenQueries(1, TimerQueryName);

            // begin
            GL.GenQueries(1, Query);

            InitProgram();

        }

        private void InitProgram()
        {

            throw new NotImplementedException();
        }
        void CallbackProc(
            CSharpGL.Enumerations.DebugSource source,
            CSharpGL.Enumerations.DebugType type,
            uint id,
            CSharpGL.Enumerations.DebugSeverity severity,
            int length,
            StringBuilder message,
            IntPtr userParam)
        {
            FormTransformFeedback thisForm = FormTransformFeedback.FromHandle(userParam) as FormTransformFeedback;
            
            DateTime now = DateTime.Now;

            StringBuilder builder = new StringBuilder();
            {
                builder.AppendLine(string.Format("{0:yyyy-MM-dd HH:mm:ss.ffff}:", now));
                builder.Append("source: ");
                builder.Append(source); builder.Append(", ");
                builder.Append("type: ");
                builder.Append(type); builder.Append(", ");
                builder.Append("id: ");
                builder.Append(id); builder.Append(", ");
                builder.Append("severity: ");
                builder.Append(severity); builder.Append(", ");
                builder.Append("length: ");
                builder.Append(length); builder.Append(", ");
                builder.Append("message: ");
                if (message != null)
                {
                    builder.Append(message.ToString()); builder.Append(", ");
                }
                else
                {
                    builder.Append("<null>"); builder.Append(", ");
                }
                builder.Append("userParam: ");
                builder.Append(userParam);
                builder.AppendLine();
            }

            string text = builder.ToString();

            if (!this.frmWhiteBoard.IsDisposed)
            {
                this.frmWhiteBoard.AppendText(text);
            }
        }
    }
}
