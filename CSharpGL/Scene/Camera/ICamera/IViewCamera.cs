using System.ComponentModel;

namespace CSharpGL
{
    /// <summary>
    /// Use this for view matrix.
    /// <para>Typical usage: projection * view * model in GLSL.</para>
    /// </summary>
    public interface IViewCamera
    {
        /// <summary>
        /// Gets or sets the position of the camera in world space.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        [Description("Gets or sets the position of the camera in world space."), Category("Camera")]
        vec3 Position { get; set; }

        /// <summary>
        /// Gets or sets the target of the camera in world space.
        /// </summary>
        /// <value>
        /// The target.
        /// </value>
        [Description("Gets or sets the target of the camera in world space."), Category("Camera")]
        vec3 Target { get; set; }

        /// <summary>
        /// Gets or sets up vector.
        /// </summary>
        /// <value>
        /// Up vector.
        /// </value>
        [Description("The up direction, relative to camera. (Controls tilt)."), Category("Camera")]
        vec3 UpVector { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        mat4 GetViewMatrix();
    }
}