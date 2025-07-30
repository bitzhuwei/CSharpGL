
using System.Collections.Concurrent;
using System.Diagnostics;

namespace System.Collections.Generic {
    public class ObjectPool {
        private readonly ConcurrentBag<object> _pool = new();
        private readonly Type codeType;
        public ObjectPool(Type codeType) {
            this.codeType = codeType;
        }

        private object? CreateNewObject() {
            //if (_currentSize >= _maxPoolSize)
            //    throw new InvalidOperationException("Object pool exhausted");

            var obj = Activator.CreateInstance(this.codeType);
            //Debug.Assert(obj != null);
            //this._pool.Add(obj);
            //Interlocked.Increment(ref _currentSize);
            return obj;
        }

        public object? Rent() {
            if (_pool.TryTake(out var obj)) { return obj; }

            return CreateNewObject();
        }

        public void Return(object obj) {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            //if (_pool.Count < _maxPoolSize && _resetAction != null) {
            //    _resetAction(obj);  // 重置对象状态
            //    _pool.Add(obj);
            //}
            //else {
            //    // 超过最大容量或无需重置时直接丢弃
            //    Interlocked.Decrement(ref _currentSize);
            //    obj = null;
            //}
            this._pool.Add(obj);
        }

        //public void Dispose() {
        //    foreach (var obj in _pool) {
        //        if (_resetAction != null) _resetAction(obj);
        //        GC.SuppressFinalize(obj);
        //    }
        //    _pool.Clear();
        //}
    }
    public class ObjectPool<T> where T : class, new() {
        public static readonly ObjectPool<T> instance = new();

        private readonly ConcurrentBag<T> _pool = new();
        //private readonly Func<T> _objectFactory;
        //private readonly Action<T> _resetAction;
        //private readonly int _maxPoolSize;
        //private int _currentSize;

        //public int ActiveCount => _currentSize - _pool.Count;
        //public int IdleCount => _pool.Count;

        //public ObjectPool(Func<T> objectFactory, Action<T> resetAction, int initialSize = 0, int maxPoolSize = 100) {
        //    _objectFactory = objectFactory ?? throw new ArgumentNullException(nameof(objectFactory));
        //    _resetAction = resetAction;
        //    _maxPoolSize = maxPoolSize;

        //    for (int i = 0; i < initialSize; i++) {
        //        _pool.Add(CreateNewObject());
        //    }
        //    _currentSize = initialSize;
        //}
        private ObjectPool() { }

        private T CreateNewObject() {
            //if (_currentSize >= _maxPoolSize)
            //    throw new InvalidOperationException("Object pool exhausted");

            var obj = new T();
            //this._pool.Add(obj);
            //Interlocked.Increment(ref _currentSize);
            return obj;
        }

        public T Rent() {
            if (_pool.TryTake(out var obj))
                return obj;

            return CreateNewObject();
        }

        public void Return(T obj) {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            //if (_pool.Count < _maxPoolSize && _resetAction != null) {
            //    _resetAction(obj);  // 重置对象状态
            //    _pool.Add(obj);
            //}
            //else {
            //    // 超过最大容量或无需重置时直接丢弃
            //    Interlocked.Decrement(ref _currentSize);
            //    obj = null;
            //}
            this._pool.Add(obj);
        }

        //public void Dispose() {
        //    foreach (var obj in _pool) {
        //        if (_resetAction != null) _resetAction(obj);
        //        GC.SuppressFinalize(obj);
        //    }
        //    _pool.Clear();
        //}
    }
}
