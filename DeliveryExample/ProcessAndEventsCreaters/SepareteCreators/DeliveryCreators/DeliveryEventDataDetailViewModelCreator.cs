using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents.SepareteCreators;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using InteractiveViewSystem.GeneralizedViewModels.ProcessesAndEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryExample.ProcessAndEventsCreaters.SepareteCreators
{
    public class DeliveryEventDataDetailViewModelCreator
        : EventDataDetailViewModelCreator
    {
        public override IDetailEventViewModel CreateDataDetailViewModel(IEventModel dataModel)
        {
            return new DetailEventViewModel(dataModel);
        }
    }
}
