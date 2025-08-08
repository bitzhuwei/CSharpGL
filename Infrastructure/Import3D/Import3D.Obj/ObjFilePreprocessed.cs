
namespace Import3D.Obj {
    public class ObjFilePreprocessed {
        public readonly List<string> lines;
        public readonly int vCount;
        public readonly int vtCount;
        public readonly int vnCount;
        public readonly int fCount;

        public ObjFilePreprocessed(List<string> lines, int vCount, int vtCount, int vnCount, int fCount) {
            this.lines = lines;
            this.vCount = vCount;
            this.vtCount = vtCount;
            this.vnCount = vnCount;
            this.fCount = fCount;
        }
    }
}