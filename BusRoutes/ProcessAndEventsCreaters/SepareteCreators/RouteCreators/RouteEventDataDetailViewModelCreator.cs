using BusRoutes.ProcessAndEventsCreaters.SepareteCreators.StationCreators;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents.SepareteCreators;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using InteractiveViewSystem.GeneralizedViewModels.ProcessesAndEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusRoutes.ProcessAndEventsCreaters.SepareteCreators.RouteCreators
{
    public class RouteEventDataDetailViewModelCreator
        : EventDataDetailViewModelCreator
    {
        public override IDetailEventViewModel CreateDataDetailViewModel(IEventModel dataModel)
        {
            var stationCreator = new ViewModelStationEventCreator();

            return new DetailEventViewModel(dataModel, stationCreator, new StationEventModelAdapterCreator());
        }
    }
}
