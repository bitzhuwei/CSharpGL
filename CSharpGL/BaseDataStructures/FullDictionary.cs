using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;

namespace CSharpGL
{
    /// <summary>
    /// 对于没有key的情况，统一返回一个固定值.
    /// <para>Returns a special value for keys not in the dictionary.</para>
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
        private Dictionary<TKey, TValue> dict = new Dictionary<TKey, TValue>();

        /// <summary>
        /// 对于没有key的情况，统一返回那个固定值.
        /// </summary>
        private readonly TValue defaultValue;

        /// <summary>
        /// 对于没有key的情况，统一返回一个固定值.
        /// <para>Returns a special value for keys not in the dictionary.</para>
        /// </summary>
        /// <param name="defaultValue"></param>
        public FullDictionary(TValue defaultValue)
        {
            Debug.Assert(defaultValue != null);

            this.defaultValue = defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(TKey key, TValue value)
        {
            dict.Add(key, value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey(TKey key)
        {
            return dict.ContainsKey(key);
        }

        /// <summary>
        ///
        /// </summary>
        public ICollection<TKey> Keys
        {
            get { return dict.Keys; }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(TKey key)
        {
            return dict.Remove(key);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            if (!dict.TryGetValue(key, out value))
            {
                value = defaultValue;
            }

            return true;
        }

        /// <summary>
        ///
        /// </summary>
        public ICollection<TValue> Values
        {
            get { return dict.Values; }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="item"></param>
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            ((ICollection<KeyValuePair<TKey, TValue>>)dict).Add(item);
        }

        /// <summary>
        ///
        /// </summary>
        public void Clear()
        {
            dict.Clear();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return dict.Contains(item);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<TKey, TValue>>)dict).CopyTo(array, arrayIndex);
        }

        /// <summary>
        ///
        /// </summary>
        public int Count
        {
            get { return dict.Count; }
        }

        /// <summary>
        ///
        /// </summary>
        public bool IsReadOnly
        {
            get { return ((ICollection<KeyValuePair<TKey, TValue>>)dict).IsReadOnly; }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return ((ICollection<KeyValuePair<TKey, TValue>>)dict).Remove(item);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return ((ICollection<KeyValuePair<TKey, TValue>>)dict).GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<TKey, TValue>>)dict).GetEnumerator();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(object key, object value)
        {
            ((IDictionary)dict).Add(key, value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(object key)
        {
            return ((IDictionary)dict).Contains(key);
        }

        IDictionaryEnumerator IDictionary.GetEnumerator()
        {
            return ((IDictionary)dict).GetEnumerator();
        }

        /// <summary>
        ///
        /// </summary>
        public bool IsFixedSize
        {
            get { return ((IDictionary)dict).IsFixedSize; }
        }

        ICollection IDictionary.Keys
        {
            get { return ((IDictionary)dict).Keys; }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="key"></param>
        public void Remove(object key)
        {
            ((IDictionary)dict).Remove(key);
        }

        ICollection IDictionary.Values
        {
            get { return ((IDictionary)dict).Values; }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        public void CopyTo(Array array, int index)
        {
            ((IDictionary)dict).CopyTo(array, index);
        }

        /// <summary>
        ///
        /// </summary>
        public bool IsSynchronized
        {
            get { return ((IDictionary)dict).IsSynchronized; }
        }

        /// <summary>
        ///
        /// </summary>
        public object SyncRoot
        {
            get { return ((IDictionary)dict).SyncRoot; }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            dict.GetObjectData(info, context);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        public void OnDeserialization(object sender)
        {
            dict.OnDeserialization(sender);
        }
    }
}