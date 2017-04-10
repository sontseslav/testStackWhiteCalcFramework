using System;
using Calc.Autimation.Framework.Attributes;

namespace Calc.Autimation.Framework.Internals
{
    /// <summary>
    /// Extension methods
    /// </summary>
    internal static class Extensions
    {
        /// <summary>
        /// Gets <see cref="Calculator.Automation.Framework.Attributes.WindowInfoAttribute"/>
        /// </summary>
        /// <param name="type">type</param>
        /// <returns><see cref="Calculator.Automation.Framework.Attributes.WindowInfoAttribute"/></returns>
        internal static WindowInfoAttribute GetWindowInfo(this Type type)
        {
            var windowInfo = (WindowInfoAttribute)Attribute.GetCustomAttribute(type, typeof(WindowInfoAttribute));
            if (windowInfo == null)
            {
                throw new ArgumentException(string.Format("{0} type doesn't contain WindowInfoAttribute", type.ToString()));
            }
            return windowInfo;
        }
    }
}
