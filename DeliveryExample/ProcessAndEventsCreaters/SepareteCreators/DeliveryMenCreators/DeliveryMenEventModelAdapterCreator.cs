using DeliveryExample.Models.NativeModels;
using DeliveryExample.Models.ProcessAndEvents;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents.SepareteCreators;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryExample.ProcessAndEventsCreaters.SepareteCreators.DeliveryMenCreators
{
    public class DeliveryMenEventModelAdapterCreator :
        EventModelAdapterCreator
    {
        public override IEventModel CreateNewDataModel()
        {
            DeliveryMen nwDeliveryMen = new DeliveryMen();
            DeliveryMenEvent nwDeliveryMenEvent = new DeliveryMenEvent(nwDeliveryMen);
            return nwDeliveryMenEvent;
        }
    }
}
