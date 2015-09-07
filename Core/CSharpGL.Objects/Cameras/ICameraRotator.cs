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
        ICamera Camera { get; set; }

        void MouseUp(int x, int y);

        void MouseMove(int x, int y);

        void SetBounds(int width, int height);

        void MouseDown(int x, int y);

        void Reset();

    }
}
