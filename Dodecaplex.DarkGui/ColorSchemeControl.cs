namespace Dodecaplex.DarkGui
{
    public abstract class ColorSchemeControl : Control
    {
        public ColorSchemeControl()
        {
            ColorScheme.ActiveChanged += () => Init(ColorScheme.active);
        }

        protected abstract void Init(in ColorScheme? colorScheme);
    }
}