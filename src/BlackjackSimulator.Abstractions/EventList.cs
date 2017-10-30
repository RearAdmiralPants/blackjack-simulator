namespace BlackjackSimulator.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class EventList<T> : Collection<T>
    {
        public event EventHandler ItemAdding;
        public event EventHandler ItemAdded;

        public new void Add(T item)
        {
            if (this.ItemAdding != null)
            {
                this.ItemAdding(item, EventArgs.Empty);
            }

            base.Add(item);

            if (this.ItemAdded != null)
            {
                this.ItemAdded(item, EventArgs.Empty);
            }
        }
    }
}
