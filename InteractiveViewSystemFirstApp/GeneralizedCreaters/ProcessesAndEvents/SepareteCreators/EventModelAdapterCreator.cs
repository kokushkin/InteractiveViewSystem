using InteractiveViewSystem.BaseCreators.SepareteCreators;
using InteractiveViewSystem.BaseModels;
using InteractiveViewSystem.BaseModels.ItemModelAdapters;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents.SepareteCreators
{
    public class EventModelAdapterCreator : IItemModelAdapterCreator<IEventModel>
    {
        public virtual IEventModel CreateNewDataModel()
        {
            return new EventModel(0, String.Empty, DateTime.Now, "new");
        }

        public virtual IItemModelAdapter<IEventModel> CreateDeepCopyOfItemModel(IItemModelAdapter<IEventModel> model)
        {
            var oldDataModel = model.DataModel;
            var newDataModel = new EventModel(oldDataModel.Id, oldDataModel.Name,
                oldDataModel.Time, oldDataModel.Description);
            var newModel = new ItemModelAdapterForPassive<IEventModel>(newDataModel);
            return newModel;
        }

        public virtual IItemModelAdapter<IEventModel> CreateItemModel(IEventModel dataModel)
        {
            return new ItemModelAdapterForPassive<IEventModel>(dataModel);
        }
    }
}
