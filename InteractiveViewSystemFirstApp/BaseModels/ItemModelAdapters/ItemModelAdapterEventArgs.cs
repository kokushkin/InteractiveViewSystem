using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystem.BaseModels.ItemModelAdapters
{
    public class ItemModelAdapterEventArgs<DataModelType> : EventArgs
    {
        public IItemModelAdapter<DataModelType> Item { get; private set; }

        public ItemModelAdapterEventArgs(IItemModelAdapter<DataModelType> _item)
        {
            Item = _item;
        }
    }
}
