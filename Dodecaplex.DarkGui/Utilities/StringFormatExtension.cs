namespace Dodecaplex.DarkGui.Utilities
{
    public static class StringFormatExtension
    {
        /// <summary>
        /// Sets Alignment and LineAlignment to StringAlignment.Center.
        /// </summary>
        /// <returns>The new StringFormat instance.</returns>
        public static StringFormat Center(this StringFormat stringFormat)
        {
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;
            return stringFormat;
        }
    }
}