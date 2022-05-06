using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Kulazhin.Defaults
{
    public enum MessageTask1
    {
        ArgumentMessage,
        FunctionMessage
    };

    public enum MessageTask2
    {
        StartArgumentMessage,
        EndArgumentMessage,
        ArgumentStepMessage,
        PrecisionMessage
    }

    internal static class DefaultMessages
    {
        // Default messages for Task#1
        public static string DefaultMessage(MessageTask1 message)
        {
            switch ((int)message)
            {
                case 0: return "Set argument (X)";
                case 1: return "Function value (Y)";
                default: return string.Empty;
            }
        }

        // Default messages for Task#2
        public static string DefaultMessage(MessageTask2 message)
        {
            switch ((int)message)
            {
                case 0: return "Set start argument (degrees)";
                case 1: return "Set end argument (degrees)";
                case 2: return "Set argument step (degrees)";
                case 3: return "Set precision (e.g. 0,001)";
                default: return string.Empty;
            }
        }
    }
}
