using InteractiveViewSystem.BaseCreators.SepareteCreators;
using InteractiveViewSystem.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystem.BaseCreators
{
    public interface IBaseCreator<DataModelType, DataViewModelType, DataDetailViewModelType> :
        IItemModelAdapterCreator<DataModelType>,
        IDataViewModelCreator<DataModelType, DataViewModelType>,
        IDataDetailViewModelCreator<DataModelType, DataDetailViewModelType>,
        IViewModelCreator<DataModelType, DataViewModelType, DataDetailViewModelType>
        where DataViewModelType : IItemDataViewModel
        where DataDetailViewModelType : IItemDataViewModel{}
}
