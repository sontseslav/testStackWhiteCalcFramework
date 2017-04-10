using Calc.Autimation.Framework;
using Calc.Autimation.Framework.Mappings;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calc.Autimation.Tests
{
    [TestClass]
    public class BaseFunctionalTests
    {
        private int _firstDigit;
        private int _secondDigit;
        private MainWindow _mainWindow;

        [TestInitialize]
        public void setUp()
        {
            CalcFactory.Instance.Launch();
            _mainWindow = CalcFactory.Instance.GetWindow<MainWindow>();
            _mainWindow.MenuBar.MenuItem("View", "Scientific").Click();
            var rand = new Random();
            _firstDigit = rand.Next(1, 1000);
            _secondDigit = rand.Next(1, 1000);
        }

        [TestCleanup]
        public void tearDown(){
            CalcFactory.Instance.Dispose();
        }

        [TestMethod]
        public void PlusCountsCorrect()
        {
            _mainWindow.SetDigitByButtonClick(_firstDigit);
            _mainWindow.Add.Click();
            _mainWindow.SetDigitByButtonClick(_secondDigit);
            _mainWindow.EqualsButton.Click();
            Assert.AreEqual(_firstDigit + _secondDigit, _mainWindow.Result);
        }

        [TestMethod]
        public void SubstractCountsCorrect()
        {
            _mainWindow.SetDigitByButtonClick(_firstDigit);
            _mainWindow.Subtract.Click();
            _mainWindow.SetDigitByButtonClick(_secondDigit);
            _mainWindow.EqualsButton.Click();
            Assert.AreEqual(_firstDigit - _secondDigit, _mainWindow.Result);
        }

        [TestMethod]
        public void AngleSineCountsCorrect()
        {
            _mainWindow.SetDigitByButtonClick(_firstDigit);
            _mainWindow.Sine.Click();
            Assert.AreEqual(Math.Sin(_firstDigit * Math.PI / 180), _mainWindow.Result);
        }

        [TestMethod]
        public void AngleCosineCountsCorrect()
        {
            _mainWindow.SetDigitByButtonClick(_firstDigit);
            _mainWindow.Cosine.Click();
            Assert.AreEqual(Math.Cos(_firstDigit * Math.PI / 180), _mainWindow.Result);
        }

        [TestMethod]
        public void SqyareRootCountsCorrect()
        {
            _mainWindow.SetDigitByButtonClick(_firstDigit);
            _mainWindow.YRoot.Click();
            _mainWindow.SetDigitByButtonClick(2);
            _mainWindow.EqualsButton.Click();
            Assert.AreEqual(Math.Sqrt(_firstDigit), _mainWindow.Result);
        }
    }
}
