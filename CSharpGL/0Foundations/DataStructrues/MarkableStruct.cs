using System;

namespace CSharpGL
{
    /// <summary>
    /// Keeps a struct value and records the time when is it's udpated.
    /// </summary>
    public class MarkableStruct<T> where T : struct,IEquatable<T>
    {
        private T value;

        public T Value
        {
            get { return value; }
            set
            {
                if (!value.Equals(this.value))
                {
                    this.value = value;
                    this.UpdateTicks = DateTime.Now.Ticks;
                }
            }
        }

        /// <summary>
        /// The last time when the value is updated.
        /// </summary>
        public long UpdateTicks { get; private set; }

        /// <summary>
        /// Records time when is a property is updated and uploaded.
        /// </summary>
        /// <param name="value">value.</param>
        public MarkableStruct(T value)
        {
            this.Value = value;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[{0}]({1})", this.value, this.UpdateTicks);
        }
    }
}