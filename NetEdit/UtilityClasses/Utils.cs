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

        #region Extensions

        //TODO: Make coments for this
        public static string Filter(this string str, params char[] filterChars)
        {
            StringBuilder b = new StringBuilder();
            int i = 0;
            foreach (char c in str)
            {
                if (filterChars.Contains(c))
                    continue;
                b.Append(c);
                i++;
            }
            return b.ToString();
        }

        public static string Filter(this string str, char filterChar)
        {
            StringBuilder b = new StringBuilder();
            int i = 0;
            foreach (char c in str)
            {
                if (c == filterChar) continue;
                b.Append(c);
                i++;
            }
            return b.ToString();
        }

        #endregion
    }
}
