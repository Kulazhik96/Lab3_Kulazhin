using System;
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
using System.Windows.Shapes;

namespace Lab3_Kulazhin.Task2.ResultTable
{
    /// <summary>
    /// Interaction logic for FunctionValues.xaml
    /// </summary>
    public partial class FunctionValues : Window
    {
        public FunctionValues(List<double> functionValues)
        {
            InitializeComponent();

            int rowNumber = 1;
            IEnumerator<double> enumerator = functionValues.GetEnumerator();
            double arg, func, term;

            // Create table for arguments, function values and summed terms for each one.
            while(enumerator.MoveNext())
            {
                arg = enumerator.Current;
                TextBox arguments = new();
                InitializeTextBox(ref arguments, arg);
                enumerator.MoveNext();
                SetRowAndColumn(arguments, 0, rowNumber);

                func = enumerator.Current;
                TextBox functionValue = new();
                InitializeTextBox(ref functionValue, func);
                enumerator.MoveNext();
                SetRowAndColumn(functionValue, 1, rowNumber);

                term = enumerator.Current;
                TextBox termsSummed = new();
                InitializeTextBox(ref termsSummed, term);
                SetRowAndColumn(termsSummed, 2, rowNumber++);

                ResultTable.RowDefinitions.Add(new RowDefinition());
                ResultTable.Children.Add(arguments);
                ResultTable.Children.Add(functionValue);
                ResultTable.Children.Add(termsSummed);
            }
        }

        private static void InitializeTextBox(ref TextBox box, double print)
        {
            box.IsReadOnly = true;
            box.Text = print.ToString();
            box.FontFamily = new FontFamily("ISOCPEUR");
            box.FontSize = 25;
            box.VerticalContentAlignment = VerticalAlignment.Center;
            box.HorizontalContentAlignment = HorizontalAlignment.Center;
        }

        private static void SetRowAndColumn(TextBox box, int column, int row)
        {
            Grid.SetColumn(box, column);
            Grid.SetRow(box, row);
        }
    }
}
