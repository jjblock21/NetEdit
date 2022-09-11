using Dodecaplex.DarkBar;
using Dodecaplex.DarkGui;
using Dodecaplex.DarkGui.ColorControllers;
using NetEdit.Colors;
using NetEdit.ToolBar;
using Newtonsoft.Json;
using System.Reflection;

namespace NetEdit
{
    public partial class Editor : Form
    {
        private Themes themes;
        private MenuStripController? mainMenu;

        private MenuStripColorController? mainMenuColorController;
        private ToolStripColorController? toolStripColorController;

        public Editor()
        {
            themes = new Themes(Program.ExecutingFolder + @"\themes");
            themes.ScanFolder();

            //This was needed to update theme files.
            /*themes.items["dark"].ctrl_hover_textColor = Color.WhiteSmoke;

            themes.items["dark"].menu_backColor = Color.FromArgb(32, 32, 32);
            themes.items["dark"].menu_button_backColor = Color.FromArgb(32, 32, 32);
            themes.items["dark"].menu_disabled_backColor = Color.FromArgb(32, 32, 32);
            themes.items["dark"].menu_imageMargin = Color.FromArgb(32, 32, 32);
            themes.items["dark"].menu_dropdown_backColor = Color.FromArgb(32, 32, 32);
            themes.items["dark"].backColor = Color.FromArgb(32, 32, 32);

            themes.items["dark"].menu_disabled_textColor = Color.Gray;
            themes.items["dark"].menu_dropdown_borderColor = Color.FromArgb(100, 100, 100);
            themes.items["dark"].menu_hover_backColor = Color.FromArgb(40, 40, 40);
            themes.items["dark"].menu_hover_borderColor = Color.CornflowerBlue;
            themes.items["dark"].menu_textColor = Color.WhiteSmoke;
            themes.items["dark"].menu_seperator = Color.FromArgb(100, 100, 100);
            themes.items["dark"].menu_useCustomRenderer = true;

            //TODO: Add all colors.
            themes.items["dark"].tools_backColor = Color.FromArgb(32, 32, 32);
            themes.items["dark"].tools_borderColor = Color.FromArgb(32, 32, 32);
            themes.items["dark"].tools_textColor = Color.WhiteSmoke;

            themes.items["light"].textColor = SystemColors.ControlText;
            themes.items["light"].backColor = SystemColors.Window;
            themes.items["light"].menu_backColor = SystemColors.Control;
            themes.items["light"].menu_dropdown_backColor = SystemColors.Control;
            themes.items["light"].menu_button_backColor = SystemColors.Control;
            themes.items["light"].menu_textColor = SystemColors.ControlText;
            themes.items["light"].tools_backColor = SystemColors.Control;
            themes.items["light"].tools_borderColor = SystemColors.Control;
            themes.items["light"].tools_textColor = SystemColors.ControlText;

            Console.WriteLine(JsonConvert.SerializeObject(themes.items["dark"]));
            Console.WriteLine(JsonConvert.SerializeObject(themes.items["light"]));*/

            /*foreach (KeyValuePair<string, ColorScheme> s in themes.items)
                Console.WriteLine(s);*/ //Debug code

            InitializeComponent();
        }

        private void Editor_Load(object sender, EventArgs e)
        {
            // Cahnge the title bar color on start
            //TODO: Change theme on startup.
            DarkBar.ChangeTitleBar(true, Handle);

            // This is initialized here, or after initialize component.
            mainMenuColorController = new MenuStripColorController(menuStrip);
            mainMenu = new MenuStripController(menuStrip);

            toolStripColorController = new ToolStripColorController(mainToolStrip);
        }

        private void outlinedButton1_Click(object sender, EventArgs e)
        {
            //TODO: Load title bar color from theme file.
            //Change color of title bar and apply theme.
            DarkBar.ChangeTitleBar(true, Handle);
            DarkBar.RepaintTitleBar(Handle);
            ColorScheme.Use(themes.items["dark"]);
            BackColor = themes.items["dark"].backColor;
        }

        private void outlinedButton2_Click(object sender, EventArgs e)
        {
            //Change color of title bar and apply theme.
            DarkBar.ChangeTitleBar(false, Handle);
            DarkBar.RepaintTitleBar(Handle);
            ColorScheme.Use(themes.items["light"]);
            BackColor = themes.items["light"].backColor;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}