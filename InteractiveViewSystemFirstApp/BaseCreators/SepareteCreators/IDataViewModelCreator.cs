using InteractiveViewSystem.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystem.BaseCreators.SepareteCreators
{
    public interface IDataViewModelCreator<DataModelType, DataViewModelType>
        where DataViewModelType : IItemDataViewModel
    {
        DataViewModelType CreateDataViewModel(DataModelType dataModel);
    }
}
