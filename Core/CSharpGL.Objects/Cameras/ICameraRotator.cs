using GLM;
using System;
using System.Drawing;


namespace CSharpGL.Objects.Cameras
{
    /// <summary>
    /// Rotates a camera on a sphere, whose center is camera's Target.
    /// <para>Just like a satellite moves around a fixed star.</para>
    /// </summary>
    public interface ICameraRotator 
    {
        /// <summary>
        /// 
        /// </summary>
        ICamera Camera { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void MouseUp(int x, int y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void MouseMove(int x, int y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        void SetBounds(int width, int height);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void MouseDown(int x, int y);

        /// <summary>
        /// 
        /// </summary>
        void Reset();

    }
}
