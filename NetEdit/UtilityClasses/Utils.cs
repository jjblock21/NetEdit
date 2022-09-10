using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEdit.UtilityClasses
{
    public static class Utils
    {
        /// <summary>
        /// Shows an Error Message box.
        /// </summary>
        /// <param name="message">The error message</param>
        public static void ErrorMsg(string message)
        {
            MessageBox.Show(message, "Uncaught Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
