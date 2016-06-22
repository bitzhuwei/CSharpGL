using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace System
{
    /// <summary>
    /// 对于没有key的情况，统一返回一个固定值.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class FullDictionary<TKey, TValue> : IDictionary<TKey, TValue>,
        ICollection<KeyValuePair<TKey, TValue>>, 
        IDictionary, ICollection, 
        //IReadOnlyDictionary<TKey, TValue>,
        //IReadOnlyCollection<KeyValuePair<TKey, TValue>>,
        IEnumerable<KeyValuePair<TKey, TValue>>, 
        IEnumerable, ISerializable, IDeserializationCallback
 
    {
        Dictionary<TKey, TValue> dict = new Dictionary<TKey, TValue>();

        /// <summary>
        /// 对于没有key的情况，统一返回那个固定值.
        /// </summary>
        readonly TValue defaultValue;

        /// <summary>
        /// 对于没有key的情况，统一返回一个固定值.
        /// </summary>
        /// <param name="defaultValue"></param>
        public FullDictionary(TValue defaultValue)
        {
            this.defaultValue = defaultValue;
        }


        public void Add(TKey key, TValue value)
        {
            dict.Add(key, value);
        }

        public bool ContainsKey(TKey key)
        {
            return dict.ContainsKey(key);
        }

        public ICollection<TKey> Keys
        {
            get { return dict.Keys; }
        }

        public bool Remove(TKey key)
        {
            return dict.Remove(key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (!dict.TryGetValue(key, out value))
            {
                value = defaultValue;
            }

            return true;
        }

        public ICollection<TValue> Values
        {
            get { return dict.Values; }
        }

        public TValue this[TKey key]
        {
            get
            {
                TValue result;
                this.TryGetValue(key, out result);
                return result;
            }
            set
            {
                dict[key] = value;
            }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            ((ICollection<KeyValuePair<TKey, TValue>>)dict).Add(item);
        }

        public void Clear()
        {
            dict.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return dict.Contains(item);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<TKey, TValue>>)dict).CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return dict.Count; }
        }

        public bool IsReadOnly
        {
            get { return ((ICollection<KeyValuePair<TKey, TValue>>)dict).IsReadOnly; }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return ((ICollection<KeyValuePair<TKey, TValue>>)dict).Remove(item);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return ((ICollection<KeyValuePair<TKey, TValue>>)dict).GetEnumerator();
        }

        Collections.IEnumerator Collections.IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<TKey, TValue>>)dict).GetEnumerator();
        }

        public void Add(object key, object value)
        {
            ((IDictionary)dict).Add(key, value);
        }

        public bool Contains(object key)
        {
            return ((IDictionary)dict).Contains(key);
        }

        IDictionaryEnumerator IDictionary.GetEnumerator()
        {
            return ((IDictionary)dict).GetEnumerator();
        }

        public bool IsFixedSize
        {
            get { return ((IDictionary)dict).IsFixedSize; }
        }

        ICollection IDictionary.Keys
        {
            get { return ((IDictionary)dict).Keys; }
        }

        public void Remove(object key)
        {
            ((IDictionary)dict).Remove(key);
        }

        ICollection IDictionary.Values
        {
            get { return ((IDictionary)dict).Values; }
        }

        public object this[object key]
        {
            get
            {
                return this[key];
            }
            set
            {
                this[key] = value;
            }
        }

        public void CopyTo(Array array, int index)
        {
            ((IDictionary)dict).CopyTo(array, index);
        }

        public bool IsSynchronized
        {
            get { return ((IDictionary)dict).IsSynchronized; }
        }

        public object SyncRoot
        {
            get { return ((IDictionary)dict).SyncRoot; }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            dict.GetObjectData(info, context);
        }

        public void OnDeserialization(object sender)
        {
            dict.OnDeserialization(sender);
        }
    }
}
