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

        //Main tool strip colors.
        public Color menu_dropdown_borderColor;
        public Color menu_dropdown_backColor;
        public Color menu_backColor;
        public Color menu_textColor;
        public Color menu_button_backColor;
        public Color menu_hover_backColor;
        public Color menu_hover_borderColor;
        public Color menu_disabled_textColor;
        public Color menu_disabled_backColor;
        public Color menu_seperator;
        public Color menu_imageMargin;

        #region ControlProperties
        //Use custom renderer for the tool strip.
        public bool menu_useCustomRenderer;
        #endregion


    }
}
