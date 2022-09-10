using Dodecaplex.DarkGui;
using Newtonsoft.Json;

namespace NetEdit.Colors
{
    public class Themes
    {
        private string _path;
        private string _fileExtension;
        public Dictionary<string, ColorScheme> items;

        public Themes(string searchFolder)
        {
            _path = searchFolder;
            _fileExtension = "editorTheme";
            items = new Dictionary<string, ColorScheme>();
        }

        public Themes(string searchFolder, string fileExtension)
        {
            _path = searchFolder;

            //Remove . and * from the file Extension if present.
            _fileExtension = fileExtension.Filter('.', '*');

            items = new Dictionary<string, ColorScheme>();
        }

        /// <summary>
        /// Scans the theme folder for themes and saves them as ColorScheme instances in the items dictionary.
        /// </summary>
        public void ScanFolder()
        {
            if (Directory.Exists(_path))
            {
                //Get all files in the repository.
                foreach (string file in Directory.GetFiles(_path))
                {
                    //Split file name into name and extension.
                    string[] name = Path.GetFileName(file).Split('.');
                    Console.WriteLine(name[0] + "  " + name[name.Length - 1]);
                    //Get last entry and check file extension.
                    if (name[name.Length - 1] == _fileExtension)
                    {
                        string json = File.ReadAllText(file);
                        try
                        {
                            //Deserialze json and add it to dictionary with name.
                            ColorScheme? colorScheme = JsonConvert.DeserializeObject<ColorScheme>(json);
                            if (colorScheme == null) continue;
                            items.Add(name[0], colorScheme);
                        }
                        catch { continue; /*TODO: Log Error.*/ }
                    }
                }
            }
        }
    }
}