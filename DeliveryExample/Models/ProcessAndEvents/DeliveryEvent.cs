using DeliveryExample.Models.NativeModels;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryExample.Models.ProcessAndEvents
{
    public class DeliveryEvent : IEventModel
    {
        Delivery _delvery;

        public long Id
        {
            get
            {
                return _delvery.Id;
            }
            set
            {

            }
        }

        public string Name
        {
            get
            {
                return _delvery.Title;
            }
            set
            {

            }
        }

        public DateTime Time
        {
            get
            {
                return _delvery.ExpirationTime;
            }
            set
            {

            }
        }

        public string Description
        {
            get
            {
                return _delvery.Status.ToString();
            }
            set
            {

            }
        }

        public IProcessModel SubProcess
        {
            get
            {
                return null;
            }
            set
            {

            }
        }

        public DeliveryEvent(Delivery delvery)
        {
            _delvery = delvery;
        }

        public void Save(IEventModel saveDataModel)
        {

        }

        public void Update()
        {

        }

        public override int GetHashCode()
        {
            return _delvery.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            DeliveryEvent deliveryEvent = obj as DeliveryEvent;
            if (deliveryEvent == null)
                return false;
            return _delvery.Equals(deliveryEvent._delvery);
        }

        public void AddToDeliveryMen(DeliveryMen deliveryMen)
        {
            deliveryMen.Deliveries.Add(_delvery);
        }
    }
}
