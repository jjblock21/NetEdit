using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodecaplex.DarkGui.ColorControllers
{
    public abstract class ColorController : ProfessionalColorTable
    {
        protected ColorScheme _lastScheme;

        public ColorController()
        {
            ColorScheme.ActiveChanged += ApplyColorScheme;
            //As long as UpdateItemsRecursive is only called _lastScheme has been updated.
            _lastScheme = new ColorScheme();
        }

        /// <summary>
        /// Gets called if the ColorScheme gets updated.
        /// </summary>
        protected abstract void ApplyColorScheme();
    }
}
