using CSharpGL;

namespace DrvSimu
{
    public partial class DrvSimuControl
    {
        public void AddPoint(vec3 point)
        {
            this.pointsRenderer.SetPoint(point);
            this.crossRenderer.SetPoint(point);
            this.Invalidate();
        }
    }
}