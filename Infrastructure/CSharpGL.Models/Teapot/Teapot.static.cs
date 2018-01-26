namespace CSharpGL
{
    public partial class Teapot
    {
        static Teapot()
        {
            var colors = new vec3[normalData.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = normalData[i].Abs();
            }
            colorData = colors;

        }

        internal static readonly vec3[] colorData;

    }
}
