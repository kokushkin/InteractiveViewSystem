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
    public class StationEventDataDetailViewModelCreator
        : EventDataDetailViewModelCreator
    {
        public override IDetailEventViewModel CreateDataDetailViewModel(IEventModel dataModel)
        {
            return new DetailEventViewModel(dataModel);
        }
    }
}
