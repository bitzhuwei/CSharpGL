using System.Collections.Generic;

namespace CSharpGL
{
    public partial class SceneObject
    {
        #region IEnumerable<SceneObject>

        /// <summary>
        /// enumerates self and all children objects recursively.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<SceneObject> GetEnumerator()
        {
            var enumerable = ITreeNodeHelper.DFSEnumerateRecursively(this);
            foreach (var item in enumerable)
            {
                yield return item;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion IEnumerable<SceneObject>
    }
}