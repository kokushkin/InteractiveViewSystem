using InteractiveViewSystem.BaseModels.ItemModelAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystem.BaseModels
{
    public interface IListModel<DataModelType>
    {
        event EventHandler<ListModelEventArgs<DataModelType>> Updated;

        void AddItems(IEnumerable<IItemModelAdapter<DataModelType>> addItems);

        void DeleteItems(IEnumerable<IItemModelAdapter<DataModelType>> remItems);

        IEnumerable<IItemModelAdapter<DataModelType>> GetItems();

        void Update();
    }
}
