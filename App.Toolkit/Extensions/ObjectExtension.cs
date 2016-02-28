using System.Collections.Generic;
using System.Linq;

namespace System
{
    /// <summary>
    /// Object extensions
    /// </summary>
    public static class ObjectExtension
    {
        /// <summary>
        /// Return the property list of an object.
        /// </summary>
        /// <param name="obj">The object to inspect.</param>
        /// <returns>Returns a dictionnary of the object properties name and value.</returns>
        public static Dictionary<string, object> GetPropertiesData(this object obj)
        {
            return obj.GetType()
                .GetProperties()
                .ToDictionary(p => p.Name, p => p.GetValue(obj));
        }
    }
}
