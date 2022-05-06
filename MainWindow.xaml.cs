using System;
using Lab3_Kulazhin.Defaults;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab3_Kulazhin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Task #1
        private void SetArgument_GotFocus(object sender, RoutedEventArgs e)
        {
            SetArgument.Text = string.Empty;
            SetArgument.LostFocus += (sender, e) => { if (SetArgument.Text == string.Empty) SetArgument.Text = DefaultMessages.DefaultMessage(MessageTask1.ArgumentMessage); };
        }

        private void CalcFunction_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Task1.GraphFunction functionResult = new(SetArgument);
                GetFunction.Text = functionResult.GetFunction().ToString();
            }

            catch (FormatException exc)
            {
                MessageBox.Show(exc.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearTask_1Area_Click(object sender, RoutedEventArgs e)
        {
            SetArgument.Text = DefaultMessages.DefaultMessage(MessageTask1.ArgumentMessage);
            GetFunction.Text = DefaultMessages.DefaultMessage(MessageTask1.FunctionMessage);
        }

        // Task #2
        private void SetStartArgument_GotFocus(object sender, RoutedEventArgs e)
        {
            SetStartArgument.Text = string.Empty;
            SetStartArgument.LostFocus += (sender, e) => { if (SetStartArgument.Text == string.Empty) SetStartArgument.Text = DefaultMessages.DefaultMessage(MessageTask2.StartArgumentMessage); };
        }

        private void SetEndArgument_GotFocus(object sender, RoutedEventArgs e)
        {
            SetEndArgument.Text = string.Empty;
            SetEndArgument.LostFocus += (sender, e) => { if (SetEndArgument.Text == string.Empty) SetEndArgument.Text = DefaultMessages.DefaultMessage(MessageTask2.EndArgumentMessage); };
        }

        private void SetArgumentStep_GotFocus(object sender, RoutedEventArgs e)
        {
            SetArgumentStep.Text = string.Empty;
            SetArgumentStep.LostFocus += (sender, e) => { if (SetArgumentStep.Text == string.Empty) SetArgumentStep.Text = DefaultMessages.DefaultMessage(MessageTask2.ArgumentStepMessage); };
        }

        private void SetPrecision_GotFocus(object sender, RoutedEventArgs e)
        {
            SetPrecision.Text = string.Empty;
            SetPrecision.LostFocus += (sender, e) => { if (SetPrecision.Text == string.Empty) SetPrecision.Text = DefaultMessages.DefaultMessage(MessageTask2.PrecisionMessage); };
        }

        private void CalculateFunction_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Task2.TaylorSeries functionCalculation = new(SetStartArgument, SetEndArgument, SetArgumentStep, SetPrecision);
                List<double> functionValues = functionCalculation.GetFunctionValue();

                Task2.ResultTable.FunctionValues resultTable = new(functionValues);
                resultTable.Show();
            }

            catch (FormatException exc)
            {
                MessageBox.Show(exc.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            catch (ArgumentException exc)
            {
                MessageBox.Show(exc.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearTask_2Area_Click(object sender, RoutedEventArgs e)
        {
            SetStartArgument.Text = DefaultMessages.DefaultMessage(MessageTask2.StartArgumentMessage);
            SetEndArgument.Text = DefaultMessages.DefaultMessage(MessageTask2.EndArgumentMessage);
            SetArgumentStep.Text = DefaultMessages.DefaultMessage(MessageTask2.ArgumentStepMessage);
            SetPrecision.Text = DefaultMessages.DefaultMessage(MessageTask2.PrecisionMessage);
        }
    }
}
