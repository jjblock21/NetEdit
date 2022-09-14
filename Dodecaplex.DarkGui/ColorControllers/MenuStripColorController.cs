using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Dodecaplex.DarkGui.ColorControllers
{
    /// <summary>
    /// Automatically updates the menu strip if the color scheme hets updated.
    /// </summary>
    public class MenuStripColorController : ColorController
    {
        private MenuStrip _menuStrip;

        public MenuStripColorController(MenuStrip menuStrip) : base()
        {
            _menuStrip = menuStrip;
        }

        protected override void ApplyColorScheme()
        {
            if (ColorScheme.active == null) return;
            //Create renderer with custom color table.
            ToolStripRenderer renderer = new ToolStripProfessionalRenderer(this);
            _lastScheme = ColorScheme.active;
            if (ColorScheme.active.menu_useCustomRenderer)
            {
                _menuStrip.RenderMode = ToolStripRenderMode.Professional;
                _menuStrip.Renderer = renderer;
            }
            else
            {
                _menuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
            }
            _menuStrip.BackColor = _lastScheme.menu_backColor;
            UpdateItemsRecursive(_menuStrip.Items, false);
        }

        //Update non renderer defined colors of ToolStripItems and their children recursively.
        private void UpdateItemsRecursive(ToolStripItemCollection items, bool isDropdownItem)
        {
            foreach (ToolStripMenuItem i in items.OfType<ToolStripMenuItem>())
            {
                // Go deeper if there is another dropdown.
                if (i.HasDropDown)
                {
                    i.DropDown.BackColor = _lastScheme.menu_dropdown_backColor;
                    //Update dropdown items later.
                    if (i.HasDropDownItems) UpdateItemsRecursive(i.DropDownItems, true);
                }
                // Use different back color if menu item is no in dropdown
                if (isDropdownItem) i.BackColor = _lastScheme.menu_button_backColor;
                else i.BackColor = _lastScheme.menu_backColor;
                i.ForeColor = _lastScheme.menu_textColor;
            }
        }

        #region Overrides
        //Color table overrides.
        public override Color MenuBorder
        {
            get { return _lastScheme.menu_dropdown_borderColor; }
        }
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
        #endregion
    }
}