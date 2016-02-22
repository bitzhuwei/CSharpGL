using CSharpGL.CSSL2GLSL;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpShadingLanguage.Convertor
{
    public partial class FormMain : Form
    {
        string[] selectedCSharpShaderFiles;

        public FormMain()
        {
            InitializeComponent();
        }

        private void btnBrowseCSharpShaderFiles_Click(object sender, EventArgs e)
        {
            if (openCSharpShaderFilesDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.selectedCSharpShaderFiles = openCSharpShaderFilesDlg.FileNames;
                StringBuilder builder = new StringBuilder();
                foreach (var item in openCSharpShaderFilesDlg.FileNames)
                {
                    builder.Append("\"");
                    builder.Append(item);
                    builder.Append("\" ");
                }

                this.txtCSharpShaderFiles.Text = builder.ToString();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtCSharpShaderFiles.Text) || this.selectedCSharpShaderFiles == null)
            {
                string message = string.Format("{0}", "Please select a C#Shader file first!");
                MessageBox.Show(message);
                return;
            }

            WorkingSwitch(true);

            WorkerData data = new WorkerData(this.selectedCSharpShaderFiles);
            this.bgWorker.RunWorkerAsync(data);
        }

        void WorkingSwitch(bool working)
        {
            bool starting = working;
            bool ended = !working;

            this.btnStart.Enabled = ended;
            this.btnBrowseCSharpShaderFiles.Enabled = ended;

            this.pgbProgress.Visible = starting;
            this.pgbSingleFileProgress.Visible = starting;

            this.lblSingleFileProgress.Visible = starting;
            this.lblTotal.Visible = starting;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            WorkingSwitch(false);
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            WorkerData data = e.Argument as WorkerData;
            int fileCount = data.csharpShaderFiles.Length;
            int fileIndex = 1;
            const int magicNumber = 100;

            WorkerResult result = new WorkerResult(null, data);
            e.Result = result;

            StringBuilder builder = new StringBuilder();

            foreach (var fullname in this.selectedCSharpShaderFiles)
            {
                builder.Append(fileIndex); builder.Append("/"); builder.Append(fileCount);
                builder.Append(": "); builder.AppendLine(fullname);

                FileInfo fileInfo = new FileInfo(fullname);
                string filename = fileInfo.Name;

                try
                {
                    CSharpCodeProvider objCSharpCodePrivoder = new CSharpCodeProvider();

                    CompilerParameters objCompilerParameters = new CompilerParameters();
                    objCompilerParameters.ReferencedAssemblies.Add("CSharpShadingLanguage.dll");
                    objCompilerParameters.GenerateExecutable = false;
                    objCompilerParameters.GenerateInMemory = true;
                    objCompilerParameters.IncludeDebugInformation = true;
                    CompilerResults cr = objCSharpCodePrivoder.CompileAssemblyFromFile(
                        objCompilerParameters, fullname);

                    if (cr.Errors.HasErrors)
                    {
                        builder.AppendLine(string.Format("编译错误：{0}", fullname));
                        foreach (CompilerError err in cr.Errors)
                        {
                            Console.WriteLine(err.ErrorText);
                            builder.AppendLine(err.ErrorText);
                        }
                    }
                    else
                    {
                        List<SemanticShader> semanticShaderList = new List<SemanticShader>();
                        Assembly assembly = cr.CompiledAssembly;
                        Type[] types = assembly.GetTypes();
                        foreach (var type in types)
                        {
                            if (type.IsSubclassOf(typeof(CSShaderCode)))
                            {
                                CSShaderCode shaderCode = Activator.CreateInstance(type) as CSShaderCode;
                                SemanticShader semanticShader = shaderCode.GetSemanticShader(fullname);
                                semanticShaderList.Add(semanticShader);
                            }
                        }

                        //var semanticShaderList =
                        //    from type in cr.CompiledAssembly.GetTypes()
                        //    where type.IsSubclassOf(typeof(ShaderCode))
                        //    select (Activator.CreateInstance(type) as ShaderCode).Dump(fullname);

                        foreach (var item in semanticShaderList)
                        {
                            item.Dump2File();
                        }

                    }
                }
                catch (Exception ex)
                {
                    string message = string.Format("{0}", ex);
                    builder.AppendLine(message);
                    result.builder = builder;
                }

                if (result.builder != builder) { builder.AppendLine("sucessfully done!"); }
                builder.AppendLine();

                SingleFileProgress thisFileDone = new SingleFileProgress()
                {
                    filename = filename,
                    progress = magicNumber,
                    message = string.Format("All is done for {0}", fileInfo.Name),
                };
                bgWorker.ReportProgress(fileIndex++ * magicNumber / fileCount, thisFileDone);
            }
        }

        //private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    WorkerData data = e.Argument as WorkerData;
        //    int fileCount = data.csharpShaderFiles.Length;
        //    int fileIndex = 1;
        //    const int magicNumber = 100;

        //    WorkerResult result = new WorkerResult(null, data);
        //    e.Result = result;

        //    StringBuilder builder = new StringBuilder();

        //    foreach (var fullname in this.selectedCSharpShaderFiles)
        //    {
        //        builder.Append(fileIndex); builder.Append("/"); builder.Append(fileCount);
        //        builder.Append(": "); builder.AppendLine(fullname);

        //        FileInfo fileInfo = new FileInfo(fullname);
        //        string filename = fileInfo.Name;

        //        try
        //        {
        //            CSharpCodeProvider objCSharpCodePrivoder = new CSharpCodeProvider();

        //            CompilerParameters objCompilerParameters = new CompilerParameters();
        //            objCompilerParameters.ReferencedAssemblies.Add("System.dll");
        //            objCompilerParameters.ReferencedAssemblies.Add("CSharpShadingLanguage.dll");
        //            objCompilerParameters.GenerateExecutable = false;
        //            objCompilerParameters.GenerateInMemory = true;
        //            //objCompilerParameters.IncludeDebugInformation = true;
        //            //objCompilerParameters.OutputAssembly = "tmptmptmp.dll";
        //            CompilerResults cr = objCSharpCodePrivoder.CompileAssemblyFromFile(
        //                objCompilerParameters, fullname);

        //            if (cr.Errors.HasErrors)
        //            {
        //                builder.AppendLine(string.Format("编译错误：{0}", fullname));
        //                foreach (CompilerError err in cr.Errors)
        //                {
        //                    Console.WriteLine(err.ErrorText);
        //                    builder.AppendLine(err.ErrorText);
        //                }
        //            }
        //            else
        //            {
        //                List<ShaderTemplate> shaderTemplateList = new List<ShaderTemplate>();
        //                Assembly assembly = cr.CompiledAssembly;
        //                Type[] types = assembly.GetTypes();
        //                foreach (var type in types)
        //                {
        //                    if (type.IsSubclassOf(typeof(VertexShaderCode))
        //                        || type.IsSubclassOf(typeof(FragmentShaderCode)))
        //                    {
        //                        ShaderTemplate template = new ShaderTemplate(type, fullname);
        //                        shaderTemplateList.Add(template);
        //                    }
        //                }
        //                foreach (var item in shaderTemplateList)
        //                {
        //                    item.Dump2File();
        //                }
        //            }
        //            //if (data.generateGlyphList)
        //            //{
        //            //    FontTexturePNGPrinter printer = new FontTexturePNGPrinter(ttfTexture);
        //            //    foreach (var progress in printer.Print(fontFullname, data.maxTexturWidth))
        //            //    {
        //            //        bgWorker.ReportProgress(fileIndex * magicNumber / fileCount, progress);
        //            //    }
        //            //}
        //        }
        //        catch (Exception ex)
        //        {
        //            string message = string.Format("{0}", ex);
        //            builder.AppendLine(message);
        //            result.builder = builder;
        //        }

        //        if (result.builder != builder) { builder.AppendLine("sucessfully done!"); }
        //        builder.AppendLine();

        //        SingleFileProgress thisFileDone = new SingleFileProgress()
        //        {
        //            filename = filename,
        //            progress = magicNumber,
        //            message = string.Format("All is done for {0}", fileInfo.Name),
        //        };
        //        bgWorker.ReportProgress(fileIndex++ * magicNumber / fileCount, thisFileDone);
        //    }
        //}

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            SingleFileProgress progress = e.UserState as SingleFileProgress;
            {
                var value = e.ProgressPercentage;
                if (value < pgbProgress.Minimum) value = pgbProgress.Minimum;
                if (value > pgbProgress.Maximum) value = pgbProgress.Maximum;
                pgbProgress.Value = value;
                this.lblTotal.Text = string.Format("Working on: {0}", progress.filename);
            }
            {
                var value = progress.progress;
                if (value < pgbSingleFileProgress.Minimum) value = pgbSingleFileProgress.Minimum;
                if (value > pgbSingleFileProgress.Maximum) value = pgbSingleFileProgress.Maximum;
                pgbSingleFileProgress.Value = value;

                this.lblSingleFileProgress.Text = progress.message;
            }
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            WorkerResult result = e.Result as WorkerResult;
            FileInfo file = new FileInfo(result.data.csharpShaderFiles[0]);

            string directory = file.DirectoryName;
            if (result.builder != null)
            {
                try
                {
                    string log = file.FullName + ".log";
                    File.WriteAllText(log, result.builder.ToString());
                    Process.Start("explorer", log);
                }
                catch (Exception ex)
                {
                    string message = string.Format("{0}", ex);
                    MessageBox.Show(message);
                }
            }

            if (e.Error != null)
            {
                MessageBox.Show(e.Error.ToString(), "发生异常");
                if (MessageBox.Show("是否打开保存结果的文件夹？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    Process.Start("explorer", directory);
                }
            }
            else if (e.Cancelled)
            {
                if (MessageBox.Show("您取消了操作，是否打开保存结果的文件夹？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    Process.Start("explorer", directory);
                }
            }
            else
            {
                if (MessageBox.Show("操作已完成，是否打开保存结果的文件夹？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    Process.Start("explorer", directory);
                }

            }

            pgbProgress.Value = pgbProgress.Minimum;
            pgbSingleFileProgress.Value = pgbSingleFileProgress.Minimum;

            WorkingSwitch(false);
        }

    }
}
