using System.Collections.Generic;

namespace FirstSightOfAssimpNet {
    /// <summary>
    /// (<see cref="Assimp.Bone"/> + final transform)s + (name -> index)s
    /// </summary>
    public class AllBoneInfos {
        public readonly BoneInfo[] boneInfos;
        public readonly Dictionary<string, uint> name2index;

        public AllBoneInfos(BoneInfo[] boneInfos, Dictionary<string, uint> name2index) {
            this.boneInfos = boneInfos;
            this.name2index = name2index;
        }

        public override string ToString() {
            return string.Format("{0} bones, {1} dict items", boneInfos.Length, name2index.Count);
        }
    }
}
