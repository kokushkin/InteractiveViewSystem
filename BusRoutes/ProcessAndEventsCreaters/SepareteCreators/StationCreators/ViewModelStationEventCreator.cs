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

namespace BusRoutes.ProcessAndEventsCreaters.SepareteCreators.StationCreators
{
    public class ViewModelStationEventCreator :
        EventViewModelCreator
    {
        public override IDetailItemViewModel<IEventModel, IDetailEventViewModel> CreateDetailViewModel(IItemModelAdapter<IEventModel> model)
        {
            return new DetailItemViewModel<IEventModel, IDetailEventViewModel>(model,
                new StationEventDataDetailViewModelCreator(), new StationEventModelAdapterCreator());
        }
    }
}
