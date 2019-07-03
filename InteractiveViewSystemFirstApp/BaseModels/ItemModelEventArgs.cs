using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystem.BaseModels
{
    public class ItemModelEventArgs<DataModelType> : EventArgs where DataModelType : IItemDataModel<DataModelType>
    {
        public IItemModel<DataModelType> Item { get; private set; }

        public ItemModelEventArgs(IItemModel<DataModelType> _item)
        {
            Item = _item;
        }
    }
}
