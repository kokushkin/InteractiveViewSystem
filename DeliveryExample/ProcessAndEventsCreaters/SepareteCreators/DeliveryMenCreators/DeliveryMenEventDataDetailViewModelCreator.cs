using DeliveryExample.ProcessAndEventsCreaters.SepareteCreators.DeliveryCreators;
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
    public class DeliveryMenEventDataDetailViewModelCreator
        : EventDataDetailViewModelCreator
    {
        public override IDetailEventViewModel CreateDataDetailViewModel(IEventModel dataModel)
        {
            var deliveryCreator = new ViewModelDeliveryEventCreator();
            var modelAdapterCreator = new DeliveryEventModelAdapterCreator();
            return new DetailEventViewModel(dataModel, deliveryCreator, modelAdapterCreator);
        }
    }
}
