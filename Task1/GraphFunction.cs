using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Kulazhin.Task1
{
    class GraphFunction
    {
        private delegate double GetFunc();

        private double m_argument;

        private TextBox M_argument
        {
            set
            {
                if (!double.TryParse(value.Text, out m_argument))
                    throw new FormatException("Incorrect input data!");
            }
        }

        public GraphFunction(TextBox argument)
        {
            M_argument = argument;
        }

        public double GetFunction()
        {
            GetFunc getFunc;

            if (m_argument < -4)
                getFunc = () => -2;
            else if (m_argument >= -4 && m_argument < 0)
                getFunc = () => 0.25 * m_argument;
            else if (m_argument >= 0 && m_argument < 2)
                getFunc = () => m_argument * m_argument;
            else
                getFunc = () => -0.5 * m_argument + 5;

            return getFunc();
        }
    }
}
