﻿using System;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// Helper class for array.
    /// </summary>
    public static class ArrayHelper {
        /// <summary>
        /// Print elements in format 'element, element, element, ...'
        /// </summary>
        /// <param name="array"></param>
        /// <param name="seperator"></param>
        /// <returns></returns>
        public static string PrintArray(this System.Collections.IEnumerable array, string seperator = " ") {
            if (array == null) { return string.Empty; }

            var builder = new StringBuilder();
            foreach (object item in array) {
                builder.Append(item);
                builder.Append(seperator);
            }

            return builder.ToString();
        }

        /// <summary>
        /// Print elements in format 'x,y,z; x,y,z; ...'
        /// </summary>
        /// <param name="array"></param>
        /// <param name="components">2, 3, or 4.</param>
        /// <param name="componentSeparator"></param>
        /// <param name="vectorSeparator"></param>
        /// <returns></returns>
        public static string PrintVectors(this float[] array, int components = 3, string componentSeparator = ",", string vectorSeparator = "\r\n") {
            if (components < 1) { throw new ArgumentOutOfRangeException("components"); }

            if (array == null) { return string.Empty; }

            var builder = new StringBuilder();
            int counter = 0;
            foreach (float item in array) {
                builder.Append(item.ToShortString());
                counter++;
                if (counter % components == 0) {
                    builder.Append(vectorSeparator);
                    counter = 0;
                }
                else {
                    builder.Append(componentSeparator);
                }
            }

            return builder.ToString();
        }
    }
}