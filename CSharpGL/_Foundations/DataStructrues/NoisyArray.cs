using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Invoke ItemUpdated event when item is updated.
    /// </summary>
    public class NoisyArray<T> where T : struct, IEquatable<T>
    {
        T[] array;
        /// <summary>
        /// Array.
        /// </summary>
        public T[] Array
        {
            get { return array; }
        }

        /// <summary>
        /// Invoked when a new value is set for an item.
        /// </summary>
        public event EventHandler<NoisyArrayEventArgs<T>> ItemUpdated;

        /// <summary>
        /// Invoke ItemUpdated event when item is updated.
        /// </summary>
        /// <param name="length"></param>
        public NoisyArray(int length)
        {
            if (length < 0) { throw new ArgumentException(); }

            this.array = new T[length];
            this.Length = length;
        }

        /// <summary>
        /// Invoke ItemUpdated event when item is updated.
        /// </summary>
        /// <param name="array"></param>
        public NoisyArray(T[] array)
        {
            if (array == null) { throw new ArgumentNullException(); }

            this.array = array;
            this.Length = array.Length;
        }

        /// <summary>
        /// Gets or sets item's value.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get { return this.array[index]; }
            set
            {
                //if (!object.Equals(value, this.array[index]))
                if (!value.Equals(this.array[index]))
                {
                    this.array[index] = value;
                    EventHandler<NoisyArrayEventArgs<T>> itemUpdated = this.ItemUpdated;
                    if (itemUpdated != null)
                    {
                        itemUpdated(this, new NoisyArrayEventArgs<T>(value, index));
                    }
                }
            }
        }

        /// <summary>
        /// This array's length.
        /// </summary>
        public int Length { get; private set; }
    }

    /// <summary>
    /// <see cref="NoisyArray&lt;T&gt;"/>'s event args.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NoisyArrayEventArgs<T> : EventArgs
    {
        /// <summary>
        /// <see cref="NoisyArray&lt;T&gt;"/>'s event args.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="index"></param>
        public NoisyArrayEventArgs(T value, int index)
        {
            this.Value = value;
            this.Index = index;
        }

        /// <summary>
        /// 
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int Index { get; private set; }
    }
}
