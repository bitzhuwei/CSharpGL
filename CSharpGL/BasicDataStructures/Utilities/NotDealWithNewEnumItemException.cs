using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class NotDealWithNewEnumItemException : Exception
    {
        private Type enumType;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumType"></param>
        public NotDealWithNewEnumItemException(Type enumType)
        {
            this.enumType = enumType;
        }

        /// <summary>
        /// 
        /// </summary>
        public override string Message
        {
            get
            {
                return string.Format("Not deal with new item of Enum type [{0}]!", enumType);
            }
        }
    }
}
