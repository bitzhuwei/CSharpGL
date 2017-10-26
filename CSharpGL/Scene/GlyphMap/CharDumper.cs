using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Yield each character in the specified string as a string.
    /// </summary>
    class CharDumper : IEnumerable<string>
    {
        private string text;

        public CharDumper(string text)
        {
            this.text = text;
        }
        public IEnumerator<string> GetEnumerator()
        {
            foreach (var item in this.text)
            {
                yield return item.ToString();
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

}
