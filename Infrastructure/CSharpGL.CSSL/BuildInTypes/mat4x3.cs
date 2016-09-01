namespace CSharpGL.CSSL
{
    /// <summary>
    /// 专用于CSSL。不可用于数学计算。
    /// <para>Specially designed for CSSL. Not for glm.</para>
    /// </summary>
    public class mat4x3
    {
        public override string ToString()
        {
            return string.Format("CSSL's mat4x3 type.");
        }

        private mat4x3()
        {
        }
    }
}