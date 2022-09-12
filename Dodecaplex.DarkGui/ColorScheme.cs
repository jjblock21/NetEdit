namespace Dodecaplex.DarkGui
{
    public class ColorScheme
    {
        public static ColorScheme? active { get; private set; }
        public static event Action? ActiveChanged;

        public static void Use(ColorScheme colorScheme)
        {
            active = colorScheme;
            ActiveChanged?.Invoke();
        }

        //Window colors.
        public Color textColor;
        public Color backColor;


        //Button related control colors
        public Color ctrl_backColor;
        public Color ctrl_borderColor;

        public Color ctrl_clicked_backColor;
        public Color ctrl_clicked_borderColor;

        public Color ctrl_disabled_backColor;
        public Color ctrl_disabled_borderColor;

        public Color ctrl_hover_backColor;
        public Color ctrl_hover_borderColor;
        public Color ctrl_hover_textColor;


        //Menu strip colors.
        //The dropdown colors apply to all tool strips.
        public Color menu_dropdown_borderColor;
        public Color menu_dropdown_backColor;

        public Color menu_backColor;
        public Color menu_textColor;

        public Color menu_button_backColor;
        public Color menu_hover_backColor;
        public Color menu_hover_borderColor;
        public Color menu_disabled_textColor;
        public Color menu_disabled_backColor;

        //These are also used in all toolstrips.
        //TODO: Somewhate globalize these.
        public Color menu_seperator;
        public Color menu_imageMargin;


        //Tool strip colors
        public Color tools_backColor;
        public Color tools_textColor;
        public Color tools_borderColor;

        public Color tools_hover_backColor;
        public Color tools_hover_borderColor;

        public Color tools_clicked_borderColor;
        public Color tools_clicked_backColor;


        #region ControlProperties
        //Use custom renderer for tool strips.
        public bool menu_useCustomRenderer;
        #endregion


    }
}
