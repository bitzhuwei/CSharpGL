namespace CSharpGL.CSSL
{
    /// <summary>
    /// 专用于CSSL。不可用于数学计算。
    /// <para>Specially designed for CSSL. Not for glm.</para>
    /// </summary>
    public class mat3x2
    {
        public override string ToString()
        {
            return string.Format("CSSL's mat3x2 type.");
        }

        private mat3x2()
        {
        }
    }
}