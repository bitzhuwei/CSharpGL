using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Windows
{
    /// <summary>
    /// Allows a version to be specified as metadata on a field.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class VersionAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VersionAttribute"/> class.
        /// </summary>
        /// <param name="major">The major version number.</param>
        /// <param name="minor">The minor version number.</param>
        public VersionAttribute(int major, int minor)
        {
            this.Major = major;
            this.Minor = minor;
        }

        /// <summary>
        /// Determines whether this version is at least as high as the version specified in the parameters.
        /// </summary>
        /// <param name="major">The major version.</param>
        /// <param name="minor">The minor version.</param>
        /// <returns>True if this version object is at least as high as the version specified by <paramref name="major"/> and <paramref name="minor"/>.</returns>
        public bool IsAtLeastVersion(int major, int minor)
        {
            //  If major versions match, we care about minor. Otherwise, we only care about major.
            if (this.Major > major) { return true; }
            if (this.Major < major) { return false; }

            return (this.Minor >= minor);
        }

        /// <summary>
        /// Gets the version attribute of an enumeration value <paramref name="enumeration"/>.
        /// </summary>
        /// <param name="enumeration">The enumeration.</param>
        /// <returns>The <see cref="VersionAttribute"/> defined on <paramref name="enumeration "/>, or null of none exists.</returns>
        public static VersionAttribute GetVersionAttribute(Enum enumeration)
        {
            //  Get the attribute from the enumeration value (if it exists).
            Type type = enumeration.GetType();
            string str = enumeration.ToString();
            MemberInfo[] members = type.GetMember(str);
            MemberInfo member = members.Single();
            object[] objs = member.GetCustomAttributes(typeof(VersionAttribute), false);
            IEnumerable<VersionAttribute> attributes = objs.OfType<VersionAttribute>();
            VersionAttribute firstOrDefault = attributes.FirstOrDefault();
            return firstOrDefault;
        }

        /// <summary>
        /// Gets the major version number.
        /// </summary>
        public int Major { get; protected set; }

        /// <summary>
        /// Gets the minor version number.
        /// </summary>
        public int Minor { get; protected set; }
    }
}
