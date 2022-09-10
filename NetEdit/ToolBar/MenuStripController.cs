namespace NetEdit.ToolBar
{
    public class MenuStripController
    {
        //TODO: Rethink this.
        /// <summary>
        /// Recursively loop through all the items and assign their click events to a single event.
        /// </summary>
        /// <param name="items">Collection of items to with child items to update.</param>
        private void AssignEventsRecursive(ToolStripItemCollection items)
        {
            foreach (ToolStripMenuItem i in items.OfType<ToolStripMenuItem>())
            {
                //Loop through drop down items first.
                if (i.HasDropDownItems) AssignEventsRecursive(i.DropDownItems);
                // Assign events for item.
                i.Click += (object? sender, EventArgs args) =>
                {
                    ItemClicked?.Invoke(i.AccessibleName, in i);
                };
            }
        }

        public MenuStripController(MenuStrip menuStrip)
        {
            AssignEventsRecursive(menuStrip.Items);
        }

        public event ToolStripItemEvent? ItemClicked;
    }

    public delegate void ToolStripItemEvent(string name, in ToolStripMenuItem item);
}