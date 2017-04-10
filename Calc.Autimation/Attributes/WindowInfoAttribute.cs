using System;

namespace Calc.Autimation.Framework.Attributes
{
    /// <summary>
    /// Provides additional info about window object
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    class WindowInfoAttribute : Attribute
    {
        private string _title;
        public WindowInfoAttribute() { }
        public WindowInfoAttribute(string title)
        {
            _title = title;
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
    }
}
