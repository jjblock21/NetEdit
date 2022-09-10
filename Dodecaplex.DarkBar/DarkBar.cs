using System.Runtime.InteropServices;

namespace Dodecaplex.DarkBar
{
    public static class DarkBar
    {
        public static void ChangeTitleBar(bool darkMode, IntPtr hwnd)
        {
            InteropHelper.DwmSetWindowAttribute(hwnd, 20, ref darkMode, Marshal.SizeOf(darkMode));
        }

        public static void RepaintTitleBar(IntPtr hwnd)
        {
            //TODO: Small hack, maybe do better
            InteropHelper.SendMessage(hwnd, 0x0086, (IntPtr)0, (IntPtr)0);
            InteropHelper.SendMessage(hwnd, 0x0086, (IntPtr)1, (IntPtr)0);
        }
    }
}