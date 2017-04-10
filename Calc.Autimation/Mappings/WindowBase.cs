using System.Collections.Generic;
using System.Linq;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace Calc.Autimation.Framework.Mappings
{
    //Base class for window objects
    public abstract class WindowBase
    {
        /**
         * <summary>
         * <see cref="TestStack.White.Window"/>
         * </summary>
         */
        private Window _window;

        ///<summary>
        ///Collection of items in the window
        ///</summary>
        private List<IUIItem> _uiItems;

        ///<summary>
        ///Flag to determine if ui items are initialized
        ///</summary>
        private bool _initialized;

        ///<summary>
        ///Init instance of WindowBase class
        ///</summary>
        ///<param name="window"Window</param>
        protected WindowBase(Window window)
        {
            _window = window;
        }

        ///<summary>
        ///<see cref="TestStack.White.Window">
        ///</summary>
        protected Window Window { get { return _window; } }

        /// <summary>
        /// Gets UI element by name
        /// </summary>
        /// <typeparam name="T">Type of ui element</typeparam>
        /// <param name="name">name of ui element</param>
        /// <returns>instnace of ui element</returns>
        protected T GetByName<T>(string name) where T : IUIItem
        {
            Initialize();
            return (T)_uiItems.SingleOrDefault(item => item.AutomationElement.Current.Name == name);
        }

        ///<summary>
        ///Gets UI elements by id
        ///</summary>
        ///<typeparam name="T">type of an UI element</typeparam>
        ///<param name="id">ID of an element</param>
        ///<returns>instance of UI element</returns>
        protected T GetById<T>(string id) where T : IUIItem
        {
            Initialize();
            return (T)_uiItems.SingleOrDefault(item => item.AutomationElement.Current.AutomationId == id);
        }

        ///<summary>
        ///Gets IU elements by name and id
        ///</summary>
        ///<typeparam name="T">type of IU element</typeparam>
        ///<param name="name">name of UI element</param>
        ///<param name="id">id of UI element</param>
        ///<returns>instance of UI element</returns>
        protected T GetByNameAndId<T>(string name, string id) where T : IUIItem
        {
            Initialize();
            return (T)_uiItems.SingleOrDefault(item => item.AutomationElement.Current.AutomationId == id &&
                item.AutomationElement.Current.Name == name);
        }

        /// <summary>
        /// Initialies collection of ui elements
        /// </summary>
        private void Initialize()
        {
            if (_initialized)
                return;

            _uiItems = _window.GetMultiple(SearchCriteria.All).ToList();
            _initialized = true;
        }
    }
}
