using InteractiveViewSystem.BaseCreators.SepareteCreators;
using InteractiveViewSystem.BaseModels.ItemModelAdapters;
using InteractiveViewSystem.BaseViewModels;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using InteractiveViewSystem.GeneralizedViewModels.ProcessesAndEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents.SepareteCreators
{
    public class EventViewModelCreator :
        IViewModelCreator<IEventModel, IEventViewModel, IDetailEventViewModel>
    {
        public virtual IDetailItemViewModel<IEventModel, IDetailEventViewModel> CreateDetailViewModel(IItemModelAdapter<IEventModel> model)
        {
            return new DetailItemViewModel<IEventModel, IDetailEventViewModel>(model,
                new EventDataDetailViewModelCreator(), new EventModelAdapterCreator());
        }

        public IItemViewModel<IEventModel, IEventViewModel> CreateItemViewModel(IItemModelAdapter<IEventModel> itemModel)
        {
            var dataViewModelCreator = new EventDataViewModelCreator();
            return new ItemViewModel<IEventModel, IEventViewModel>(itemModel, dataViewModelCreator);
        }
    }
}
