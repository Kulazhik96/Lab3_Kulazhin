using System;
using System.Windows.Controls;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Kulazhin.Task2
{
    internal class TaylorSeries
    {
        private double xStart;
        private double xEnd;
        private double dX;
        private double m_precision;
        private int decimalDigits;

        private double CheckParse(TextBox value)
        {
            if (!double.TryParse(value.Text, out double temp))
                throw new FormatException("Incorrect input data!");

            return temp;
        }

        private TextBox XStart
        {
            set => xStart = CheckParse(value);
        }

        private TextBox XEnd
        {
            set => xEnd = CheckParse(value);
        }

        private TextBox DX
        {
            set => dX = CheckParse(value);
        }

        private TextBox M_precision
        {
            set
            {
                m_precision = CheckParse(value);
                decimalDigits = RoundingPrecision(m_precision);
            }
        }

        public TaylorSeries(TextBox start, TextBox end, TextBox step, TextBox precision)
        {
            XStart = start;
            XEnd = end;
            DX = step;
            M_precision = precision;

            if (dX > 0 && xStart > xEnd)
                throw new ArgumentException("Start value must be lower than end!");
            if (dX < 0 && xStart < xEnd)
                throw new ArgumentException("Start value must be greater than end!");
            if (dX == 0)
                throw new ArgumentException("Step must not be equal to zero!");
            if (m_precision <= 0)
                throw new ArgumentException("Precision must be greater than zero!");
        }

        public List<double> GetFunctionValue()
        {
            List<double> function = new();

            // Get every function value from xStart to xEnd.
            for (double argument = xStart; IsArgumentEqualToEnd(xStart, xEnd, argument); argument += dX)
            {
                // Check for more than 1 turnover (>360)
                if (argument > 360)
                {
                    argument -= 360;
                    xEnd -= 360;
                }

                double term = 1.0, seriesSum = 1.0;
                int power = 1;
                double termsSumed = 1;
                double radianArgument = argument * Math.PI / 180;

                // Get Tayloe's series sum for every argument.
                while (Math.Abs(term) >= m_precision)
                {
                    term = Math.Pow(-1, power) * Math.Pow(radianArgument, 2 * power) / Factorial(2 * power);
                    seriesSum += term;
                    power++; termsSumed++;
                }

                double functionValue = Math.Round(seriesSum, decimalDigits);
                if (functionValue == 0)
                {
                    functionValue = Math.Abs(functionValue);
                }

                function.Add(argument);
                function.Add(functionValue);
                function.Add(termsSumed);
            }

            return function;
        }

        private static double Factorial(int value)
        {
            if (value == 0)
                return 1;

            double result = 1;
            for (int i = 1; i <= value; i++)
            {
                result *= i;
            }

            return result;
        }

        private static int RoundingPrecision(double prcsn)
        {
            int decimalDigits = 0;
            while (prcsn != 1)
            {
                prcsn *= 10;
                decimalDigits++;
            }

            return decimalDigits;
        }

        private static bool IsArgumentEqualToEnd(double start, double end, double argument)
        {
            if (start > end)
            {
                if (argument >= end)
                    return true;
                else return false;
            }
            else
            {
                if (argument <= end)
                    return true;
                else return false;
            }
        }
    }
}
