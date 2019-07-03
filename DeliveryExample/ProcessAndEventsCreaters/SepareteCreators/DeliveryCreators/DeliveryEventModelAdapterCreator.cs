using DeliveryExample.Models.NativeModels;
using DeliveryExample.Models.ProcessAndEvents;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents.SepareteCreators;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryExample.ProcessAndEventsCreaters.SepareteCreators.DeliveryCreators
{
    class DeliveryEventModelAdapterCreator :
        EventModelAdapterCreator
    {
        public override IEventModel CreateNewDataModel()
        {
            Delivery nwDelivery = new Delivery();
            //nwStation.Save();
            DeliveryEvent nwDeliveryEvent = new DeliveryEvent(nwDelivery);
            return nwDeliveryEvent;
        }
    }
}
