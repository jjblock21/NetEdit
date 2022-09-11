using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Dodecaplex.DarkGui.ToolStripColors
{
    public class MenuStripColorController : ProfessionalColorTable
    {
        private List<ToolStrip> _menuStrip;
        private ColorScheme _lastScheme;

        public MenuStripColorController(params ToolStrip[] toolStrips)
        {
            _menuStrip = new List<ToolStrip>();
            _menuStrip.AddRange(toolStrips);
            ColorScheme.ActiveChanged += ApplyColorScheme;
            //As long as UpdateItemsRecursive is only called _lastScheme has been updated.
            _lastScheme = new ColorScheme();
        }

        private void ApplyColorScheme()
        {
            if (ColorScheme.active == null) return;
            //Create renderer with custom color table.
            ToolStripRenderer renderer = new ToolStripProfessionalRenderer(this);
            _lastScheme = ColorScheme.active;
            foreach (ToolStrip menuStrip in _menuStrip)
            {
                if (ColorScheme.active.menu_useCustomRenderer)
                {
                    menuStrip.RenderMode = ToolStripRenderMode.Professional;
                    menuStrip.Renderer = renderer;
                }
                else
                {
                    menuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                }
                menuStrip.BackColor = _lastScheme.menu_backColor;
                UpdateItemsRecursive(menuStrip.Items);
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
                i.BackColor = _lastScheme.menu_button_backColor;
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