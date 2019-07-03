using InteractiveViewSystem.BaseModels.ItemModelAdapters;
using InteractiveViewSystem.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystem.BaseCreators.SepareteCreators
{
    public interface IViewModelCreator<DataModelType, DataViewModelType, DataDetailViewModelType>
        where DataViewModelType : IItemDataViewModel
        where DataDetailViewModelType : IItemDataViewModel
    {
        IDetailItemViewModel<DataModelType, DataDetailViewModelType> CreateDetailViewModel(IItemModelAdapter<DataModelType> model);

        IItemViewModel<DataModelType, DataViewModelType> CreateItemViewModel(IItemModelAdapter<DataModelType> model);
    }
}
