using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// A collection of <see cref="EZMBone"/>s.
    /// </summary>
    public class EZMSkeleton
    {
        // <Skeleton name="skeleton" count="60">
        /// <summary>
        /// A collection of <see cref="EZMBone"/>s.
        /// </summary>
        /// <param name="xSkeletion"></param>
        /// <returns></returns>
        public static EZMSkeleton Parse(System.Xml.Linq.XElement xElement)
        {
            EZMSkeleton result = null;
            if (xElement.Name == "Skeleton")
            {
                result = new EZMSkeleton();
                {
                    var attr = xElement.Attribute("name");
                    if (attr != null) { result.Name = attr.Value; }
                }
                {
                    var xBones = xElement.Elements("Bone");
                    var bones = new EZMBone[xBones.Count()];
                    var dict = new Dictionary<string, EZMBone>();
                    {
                        int index = 0;
                        foreach (var xBone in xBones)
                        {
                            var bone = EZMBone.Parse(xBone);
                            dict.Add(bone.Name, bone);
                            bones[index++] = bone;
                        }
                    }
                    result.nameBoneDict = dict;
                    List<EZMBone> rootBones = new List<EZMBone>();
                    foreach (var item in bones)
                    {
                        string parentName = item.ParentName;
                        EZMBone parent;
                        if ((parentName != null) && dict.TryGetValue(parentName, out parent))
                        {
                            item.Parent = parent;
                            parent.children.Add(item);
                        }
                        else
                        {
                            rootBones.Add(item);
                        }
                    }
                    var finalBones = new EZMBone[xBones.Count()];
                    {
                        int index = 0;
                        foreach (var item in rootBones)
                        {
                            // make sure bones are in 'parent - child' order.
                            Traverse(item, finalBones, ref index);
                        }
                    }
                    for (int i = 0; i < finalBones.Length; i++)
                    {
                        EZMBone bone = finalBones[i];
                        EZMBone parent = bone.Parent;
                        if (parent == null)
                        {
                            bone.AbsBoneMat = bone.State.ToMat4();
                        }
                        else
                        {
                            bone.AbsBoneMat = parent.AbsBoneMat * bone.State.ToMat4();
                        }
                    }
                    result.Bones = finalBones;
                }
            }

            return result;
        }

        private static void Traverse(EZMBone bone, EZMBone[] array, ref int index)
        {
            array[index++] = bone;
            foreach (var item in bone.children)
            {
                Traverse(item, array, ref index);
            }
        }

        public string Name { get; private set; }

        public EZMBone[] Bones { get; private set; }

        internal Dictionary<string, EZMBone> nameBoneDict = new Dictionary<string, EZMBone>();

        public override string ToString()
        {
            return string.Format("{0} {1} bones", this.Name, this.Bones.Length);
        }
    }
}
