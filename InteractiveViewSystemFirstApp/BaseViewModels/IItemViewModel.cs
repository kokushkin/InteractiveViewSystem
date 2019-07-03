using InteractiveViewSystem.BaseModels;
using InteractiveViewSystem.BaseModels.ItemModelAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystem.BaseViewModels
{
    public interface IItemViewModel<DataModelType, DataViewModelType>
        where DataViewModelType : IItemDataViewModel
    {
        DataViewModelType DataViewModel { get; }

        IItemModelAdapter<DataModelType> GetItemModel();
    }
}
