using Calc.Autimation.Framework.Attributes;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.WindowStripControls;

namespace Calc.Autimation.Framework.Mappings
{
    /// <summary>
    /// Main window
    /// </summary>
    [WindowInfo(Title = "Calculator")]
    public class MainWindow : WindowBase
    {
        /// <summary>
        /// Initializes MainWindow class
        /// </summary>
        /// <param name="window">Window</param>
        public MainWindow(Window window)
            : base(window)
        {

        }

        /// <summary>
        /// Gets divide button
        /// </summary>
        public Button Divide { get { return GetByNameAndId<Button>("Divide", "91"); } }

        /// <summary>
        /// Gets multiply button
        /// </summary>
        public Button Multiply { get { return GetByNameAndId<Button>("Multiply", "92"); } }

        /// <summary>
        /// Gets add button
        /// </summary>
        public Button Add { get { return GetByNameAndId<Button>("Add", "93"); } }

        /// <summary>
        /// Gets substract button
        /// </summary>
        public Button Subtract { get { return GetByNameAndId<Button>("Subtract", "94"); } }

        /// <summary>
        /// Gets menu bar
        /// </summary>
        public MenuBar MenuBar { get { return Window.MenuBar; } }

        /// <summary>
        /// Gets order of y root button
        /// </summary>
        public Button YRoot { get { return GetByNameAndId<Button>("Order of y root", "96"); } }

        /// <summary>
        /// Gets sine button
        /// </summary>
        public Button Sine { get { return GetByNameAndId<Button>("Sine", "102"); } }

        /// <summary>
        /// Gets cosine Button
        /// </summary>
        public Button Cosine { get { return GetByNameAndId<Button>("Cosine", "103"); } }

        /// <summary>
        /// Gets eauals button
        /// </summary>
        public Button EqualsButton { get { return GetByNameAndId<Button>("Equals", "121"); } }

        /// <summary>
        /// Gets result value
        /// </summary>
        public double Result { get { return double.Parse(GetById<Label>("150").Text); } }

        /// <summary>
        /// Gets digit button 
        /// </summary>
        /// <param name="digit">digit</param>
        /// <returns>instance of a button</returns>
        public Button GetDigitButton(char digit)
        {
            return GetByNameAndId<Button>(digit.ToString(), (130 + char.GetNumericValue(digit)).ToString());
        }

        /// <summary>
        /// Sets digit by clicking buttons
        /// </summary>
        /// <param name="digit"></param>
        public void SetDigitByButtonClick(double digit)
        {
            foreach (char d in digit.ToString())
            {
                GetDigitButton(d).Click();
            }
        }
    }
}
