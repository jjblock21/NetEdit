namespace Dodecaplex.DarkGui.ColorControllers
{
    /// <summary>
    /// Automatically updates the tool strips if the color scheme hets updated.
    /// </summary>
    public class ToolStripColorController : ColorController
    {
        private ToolStrip[] _toolStrips;

        public ToolStripColorController(params ToolStrip[] menuStrip) : base()
        {
            _toolStrips = menuStrip;
        }

        protected override void ApplyColorScheme()
        {
            if (ColorScheme.active == null) return;
            //Create renderer with custom color table.
            ToolStripRenderer renderer = new ToolStripProfessionalRenderer(this);
            _lastScheme = ColorScheme.active;
            foreach (ToolStrip toolStrip in _toolStrips)
            {
                if (ColorScheme.active.menu_useCustomRenderer)
                {
                    toolStrip.RenderMode = ToolStripRenderMode.Professional;
                    toolStrip.Renderer = renderer;
                }
                else
                {
                    toolStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                }
                toolStrip.BackColor = _lastScheme.tools_backColor;
                UpdateItemsRecursive(toolStrip.Items);
            }
        }

        //Update non renderer defined colors of ToolStripItems and their children recursively.
        private void UpdateItemsRecursive(ToolStripItemCollection items)
        {
            foreach (ToolStripMenuItem i in items.OfType<ToolStripMenuItem>())
            {
                // Go deeper if there is another dropdown.
                if (i.HasDropDown)
                {
                    i.DropDown.BackColor = _lastScheme.menu_dropdown_backColor;
                    //Update dropdown items later.
                    if (i.HasDropDownItems) UpdateItemsRecursive(i.DropDownItems);
                }
                i.BackColor = _lastScheme.tools_backColor;
                i.ForeColor = _lastScheme.tools_textColor;
            }
        }

        #region Overrides
        //Color table overrides.
        public override Color ToolStripDropDownBackground
        {
            get { return _lastScheme.menu_dropdown_backColor; }
        }
        public override Color SeparatorDark
        {
            get { return _lastScheme.menu_seperator; }
        }
        public override Color ImageMarginGradientBegin
        {
            get { return _lastScheme.menu_imageMargin; }
        }
        public override Color ImageMarginGradientMiddle
        {
            get { return _lastScheme.menu_imageMargin; }
        }
        public override Color ImageMarginGradientEnd
        {
            get { return _lastScheme.menu_imageMargin; }
        }
        public override Color ToolStripBorder
        {
            get { return _lastScheme.tools_borderColor; }
        }
        //TODO: Figure out how to change button colors.
        #endregion
    }
}