using System;

namespace CSharpGL.Demos
{
    /// <summary>
    /// A demo renderer can be selected and added into a scene in this demo project.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    internal sealed class DemoRendererAttribute : Attribute
    {
    }
}