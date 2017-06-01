using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GLField<T> where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        private T value;

        /// <summary>
        /// 
        /// </summary>
        public T Value
        {
            get { return this.value; }
            set
            {
                if (!this.value.Equals(value))
                {
                    this.value = value;
                    {
                        foreach (var item in this.destinations)
                        {
                            var changedEvent = item.SourceValueChanged;
                            if (changedEvent != null)
                            {
                                changedEvent(item, EventArgs.Empty);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler SourceValueChanged;

        /// <summary>
        /// /
        /// </summary>
        public GLField<T> Source { get; private set; }

        /// <summary>
        /// I need to update my value when specified <paramref name="source"/>'s value is changed.
        /// </summary>
        /// <param name="source"></param>
        public void ConnectFrom(GLField<T> source)
        {
            if (source != null)
            {
                this.Source = source;
                source.destinations.Add(this);
            }
            else
            {
                var current = this.Source;
                if (current != null)
                {
                    this.Source = null;
                    current.destinations.Remove(this);
                }
            }
        }

        private List<GLField<T>> destinations = new List<GLField<T>>();

        ///// <summary>
        ///// 
        ///// </summary>
        //public List<GLField<T>> Destinations
        //{
        //    get { return destinations; }
        //}

        /// <summary>
        /// I will notify specified <paramref name="destination"/> when my Value changes.
        /// </summary>
        /// <param name="destination"></param>
        public void ConnectTo(GLField<T> destination)
        {
            if (destination != null)
            {
                destination.Source = this;
                this.destinations.Add(destination);
            }
        }

        /// <summary>
        /// I will notify specified <paramref name="destinations"/> when my Value changes.
        /// </summary>
        /// <param name="destinations"></param>
        public void ConnectTo(IEnumerable<GLField<T>> destinations)
        {
            if (destinations != null)
            {
                foreach (var item in destinations)
                {
                    item.Source = this;
                    this.destinations.Add(item);
                }
            }
        }
    }
}
