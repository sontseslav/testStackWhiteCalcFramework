using Calc.Autimation.Framework.Internals;
using System;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;

namespace Calc.Autimation.Framework
{
    /**
     * Calculator application factory
     * Based on Singleton pattern
     */
    public class CalcFactory : IDisposable
    {
        //instance variable for Singleton
        private static CalcFactory _instance;
        //calc app path
        private const string CalcExePath = @"C:\Windows\system32\calc.exe";
        //TestStack.White.Application
        private Application _calcApp;

        //Singleton property
        public static CalcFactory Instance
        {
            get { return _instance ?? (_instance = new CalcFactory()); }
        }

        //App init
        public void Launch()
        {
            if (_calcApp != null) return;
            _calcApp = Application.Launch(CalcExePath);
        }

        /**
         * Gets window object
         * <typeparam name="T">Type of window</typeparam>
         * <returns>returns instance of an object</returns>
         */
        public T GetWindow<T>()
        {
            Window whiteWin = _calcApp.GetWindow(typeof(T).GetWindowInfo().Title);
            var window = (T)Activator.CreateInstance(typeof(T), new object [] {whiteWin});
            return window;
        }

        //Closes calc
        public void Dispose()
        {
            _calcApp.Close();
            _calcApp.Dispose();
            _calcApp = null;
            _instance = null;
        }
    }
}
