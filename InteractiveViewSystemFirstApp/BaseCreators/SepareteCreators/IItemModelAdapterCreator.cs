using InteractiveViewSystem.BaseModels.ItemModelAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystem.BaseCreators.SepareteCreators
{
    public interface IItemModelAdapterCreator<DataModelType>
    {
        DataModelType CreateNewDataModel();

        IItemModelAdapter<DataModelType> CreateDeepCopyOfItemModel(IItemModelAdapter<DataModelType> model);

        IItemModelAdapter<DataModelType> CreateItemModel(DataModelType dataModel);
    }
}
