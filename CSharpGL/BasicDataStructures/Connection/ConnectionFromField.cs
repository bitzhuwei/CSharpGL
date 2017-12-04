//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace CSharpGL
//{
//    /// <summary>
//    /// When Someone chhanged, I will know.
//    /// </summary>
//    public class ConnectionField
//    {
//        private long lastUpdateTick = DateTime.Now.Ticks;
//        /// <summary>
//        /// 
//        /// </summary>
//        public long LastUpdateTick
//        {
//            get { return lastUpdateTick; }
//        }

//        private List<ConnectionField> from = new List<ConnectionField>();
//        private List<long> ticks = new List<long>();
//        /// <summary>
//        /// If <paramref name="field"/> changed, I will know.
//        /// </summary>
//        /// <param name="field"></param>
//        public void ConnectFrom(ConnectionField field)
//        {
//            this.from.Add(field);
//            this.ticks.Add(field.lastUpdateTick);
//        }

//        private object _value;
//        /// <summary>
//        /// 
//        /// </summary>
//        public object Value
//        {
//            get { return _value; }
//            set
//            {
//                if (!value.Equals(_value))
//                {
//                    _value = value;
//                    lastUpdateTick = DateTime.Now.Ticks;
//                }
//            }
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <returns></returns>
//        public bool FromUpdated()
//        {
//            var result = false;
//            ConnectionField field = this;
//            while (field != null)
//            {
//                for (int i = 0; i < field.from.Count; i++)
//                {
//                    if (field.from[i].lastUpdateTick != field.ticks[i])
//                    {
//                        result = true;
//                        break;
//                    }
//                }
//            }


//            foreach (var item in field.from)
//            {
//                if (item.FromUpdated())
//                {
//                    result = true;
//                    break;
//                }
//            }
//            return result;
//        }
//    }

//    public class ConnectionClass<T> where T : class
//    {

//    }
//}
