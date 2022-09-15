using NetEdit.UtilityClasses;
using System.Reflection;

namespace NetEdit
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.ThreadException += ThreadException;
            Application.Run(new MainWindow());
        }

        private static void ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            //TODO: Do exception catching here.
            Utils.ErrorMsg(e.Exception.Message + "\n" + e.Exception.InnerException ?? "");
        }

        #region Properties
        private static string? executingFolder;

        /// <summary>
        /// Returns the folder the executing Assembly file is located in.
        /// </summary>
        public static string ExecutingFolder
        {
            get
            {
                if (executingFolder == null)
                {
                    //Only retrieve value once if needed.
                    string assemblyLocation = Assembly.GetExecutingAssembly().Location;
                    string? dir = Path.GetDirectoryName(assemblyLocation);
                    if (dir == null) throw new Exception("Executing Directory could not be found.");
                    executingFolder = dir;
                }
                return executingFolder;
            }
        }
        #endregion
    }
}