using InteractiveViewSystem.BaseModels.ItemModelAdapters;
using InteractiveViewSystem.BaseViewModels;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents.SepareteCreators;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using InteractiveViewSystem.GeneralizedViewModels.ProcessesAndEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryExample.ProcessAndEventsCreaters.SepareteCreators.DeliveryCreators
{
    public class ViewModelDeliveryEventCreator :
        EventViewModelCreator
    {
        public override IDetailItemViewModel<IEventModel, IDetailEventViewModel> CreateDetailViewModel(IItemModelAdapter<IEventModel> model)
        {
            return new DetailItemViewModel<IEventModel, IDetailEventViewModel>(model,
                new DeliveryEventDataDetailViewModelCreator(), new DeliveryEventModelAdapterCreator());
        }
    }
}
