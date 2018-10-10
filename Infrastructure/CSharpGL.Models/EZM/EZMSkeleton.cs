using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.EZM
{
    class EZMSkeleton
    {
        // <Skeleton name="skeleton" count="60">
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xSkeletion"></param>
        /// <returns></returns>
        internal static EZMSkeleton Parse(System.Xml.Linq.XElement xElement)
        {
            EZMSkeleton result = null;
            if (xElement.Name == "Skeleton")
            {
                result = new EZMSkeleton();
                result.Name = xElement.Attribute("name").Value;
                {
                    var xBones = xElement.Elements("Bone");
                    var bones = new EZMBone[xBones.Count()];
                    int index = 0;
                    foreach (var xBone in xBones)
                    {
                        bones[index++] = EZMBone.Parse(xBone);
                    }
                    result.Bones = bones;
                }
            }

            return result;
        }

        public string Name { get; private set; }

        public EZMBone[] Bones { get; private set; }
    }
}
