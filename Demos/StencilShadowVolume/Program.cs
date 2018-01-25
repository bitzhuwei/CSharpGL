using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StencilShadowVolume
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            {
                IModelProvider provider = new AdjacentCubeProvider();
                var info = new ModelInfo(provider, AdjacentCubeModel.strPosition, AdjacentCubeModel.strColor, provider.Size);
                //Application.Run(new FormAdjacentTriangles(info));
                Application.Run(new Form0SilhouetteDetection(info));
                Application.Run(new Form1ExtrudeVolume(info));
                Application.Run(new Form2ShadowVolume(info));
            }
            //{
            //    IModelProvider provider = new AdjacentTeapotProvider();
            //    var info = new ModelInfo(provider, AdjacentTeapot.strPosition, AdjacentTeapot.strColor, provider.Size);
            //    //Application.Run(new FormAdjacentTriangles(info));
            //    Application.Run(new Form0SilhouetteDetection(info));
            //    Application.Run(new Form1ExtrudeVolume(info));
            //    Application.Run(new Form2ShadowVolume(info));
            //}
        }
    }

    public interface IModelProvider
    {
        IBufferSource Model { get; }

        vec3 Size { get; }
    }

    public class AdjacentTeapotProvider : IModelProvider
    {

        #region IModelProvider 成员

        public IBufferSource Model
        {
            get { return new AdjacentTeapot(); }
        }

        public vec3 Size
        {
            get { return (new AdjacentTeapot()).GetModelSize(); }
        }

        #endregion
    }
    public class AdjacentCubeProvider : IModelProvider
    {

        #region IModelProvider 成员

        public IBufferSource Model
        {
            get { return new AdjacentCubeModel(); }
        }

        public vec3 Size
        {
            get { return (new AdjacentCubeModel()).GetSize(); }
        }

        #endregion
    }
    public class ModelInfo
    {
        public readonly IModelProvider modelProvider;
        public readonly string position;
        public readonly string color;
        public readonly vec3 size;

        public ModelInfo(IModelProvider modelProvider, string position, string color, vec3 size)
        {
            this.modelProvider = modelProvider;
            this.position = position;
            this.color = color;
            this.size = size;
        }
    }
}
