namespace NetEdit.Utilities
{
    public static class MsgBox
    {
        /// <summary>
        /// Shows an Error Message box.
        /// </summary>
        /// <param name="message">The error message</param>
        public static void Error(string message)
        {
            MessageBox.Show(message, "Uncaught Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}