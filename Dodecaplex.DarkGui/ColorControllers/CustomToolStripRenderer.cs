namespace Dodecaplex.DarkGui.ColorControllers
{
    public class CustomToolStripRenderer : ToolStripProfessionalRenderer
    {
        private Color _arrowColor;

        public CustomToolStripRenderer(ProfessionalColorTable colorTable, Color arrowColor) : base(colorTable)
        {
            _arrowColor = arrowColor;
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            // Couldn't figure out how to change this color from the renderer.
            e.ArrowColor = _arrowColor;
            base.OnRenderArrow(e);
        }
    }
}