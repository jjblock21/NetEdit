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
            _lastScheme = ColorScheme.active;
            foreach (ToolStrip toolStrip in _toolStrips)
            {
                if (ColorScheme.active.menu_useCustomRenderer)
                {
                    //Create renderer with custom color table.
                    ToolStripRenderer renderer = new CustomToolStripRenderer(this, _lastScheme.tools_textColor);
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
            foreach (ToolStripItem i in items.OfType<ToolStripItem>())
            {
                // Go deeper if there is another dropdown.
                i.BackColor = _lastScheme.tools_backColor;
                i.ForeColor = _lastScheme.tools_textColor;
            }
            foreach (ToolStripSplitButton i in items.OfType<ToolStripSplitButton>())
            {
                if (i.HasDropDown)
                {
                    i.DropDown.BackColor = _lastScheme.menu_dropdown_backColor;
                    if (i.HasDropDownItems)
                        UpdateItemsRecursive(i.DropDownItems);
                }
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

        public override Color ButtonSelectedBorder
        {
            get { return _lastScheme.tools_hover_borderColor; }
        }
        public override Color ButtonSelectedGradientBegin
        {
            get { return _lastScheme.tools_hover_backColor; }
        }
        public override Color ButtonSelectedGradientMiddle
        {
            get { return _lastScheme.tools_hover_backColor; }
        }
        //TODO: Add Gradients to ColorScheme
        public override Color ButtonSelectedGradientEnd
        {
            get { return _lastScheme.tools_hover_backColor; }
        }

        //Checked
        public override Color ButtonCheckedHighlightBorder
        {
            get { return _lastScheme.tools_hover_borderColor; }
        }
        public override Color ButtonCheckedHighlight
        {
            get { return _lastScheme.tools_hover_backColor; }
        }
        public override Color ButtonCheckedGradientBegin
        {
            get { return _lastScheme.tools_hover_backColor; }
        }
        public override Color ButtonCheckedGradientMiddle
        {
            get { return _lastScheme.tools_hover_backColor; }
        }
        public override Color ButtonCheckedGradientEnd
        {
            get { return _lastScheme.tools_hover_backColor; }
        }

        //Pressed
        public override Color ButtonPressedBorder
        {
            get { return _lastScheme.tools_clicked_borderColor; }
        }
        public override Color ButtonPressedGradientBegin
        {
            get { return _lastScheme.tools_clicked_backColor; }
        }
        public override Color ButtonPressedGradientMiddle
        {
            get { return _lastScheme.tools_clicked_backColor; }
        }
        public override Color ButtonPressedGradientEnd
        {
            get { return _lastScheme.tools_clicked_backColor; }
        }

        //TODO: make these as cross used
        //Menu dropdowns
        public override Color MenuItemBorder
        {
            get { return _lastScheme.menu_hover_borderColor; }
        }
        public override Color MenuItemSelected
        {
            get { return _lastScheme.menu_hover_borderColor; }
        }
        public override Color MenuItemSelectedGradientBegin
        {
            get { return _lastScheme.menu_hover_backColor; }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get { return _lastScheme.menu_hover_backColor; }
        }
        public override Color MenuItemPressedGradientBegin
        {
            get { return _lastScheme.menu_hover_backColor; }
        }
        public override Color MenuItemPressedGradientMiddle
        {
            get { return _lastScheme.menu_hover_backColor; }
        }
        public override Color MenuItemPressedGradientEnd
        {
            get { return _lastScheme.menu_hover_backColor; }
        }
        #endregion
    }
}