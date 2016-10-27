using CSharpGL;
using System.Drawing;

namespace DrvSimu
{
    public partial class DrvSimuControl
    {
        public void SetColor(Color color)
        {
            this.pointsRenderer.SetColor(color);
        }
    }
}