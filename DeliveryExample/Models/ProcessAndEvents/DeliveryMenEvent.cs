using DeliveryExample.Models.NativeModels;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryExample.Models.ProcessAndEvents
{
    public class DeliveryMenEvent : IEventModel
    {
        DeliveryMen _deliveryMen;

        public long Id
        {
            get
            {
                return _deliveryMen.Id;
            }
            set
            {
                
            }
        }

        public string Name
        {
            get
            {
                return _deliveryMen.Name;
            }
            set
            {

            }
        }

        public DateTime Time
        {
            get
            {
                return DateTime.Now;
            }
            set
            {

            }
        }

        public string Description
        {
            get
            {
                return _deliveryMen.Location;
            }
            set
            {

            }
        }

        IProcessModel deliveryMenProcess;
        public IProcessModel SubProcess
        {
            get
            {
                return deliveryMenProcess;
            }
            set
            {
                deliveryMenProcess = value;
            }
        }



        public DeliveryMenEvent(DeliveryMen deliveryMen)
        {
            _deliveryMen = deliveryMen;
            deliveryMenProcess = new DeliveryMenProcess(_deliveryMen);
        }

        public void Save(IEventModel saveDataModel)
        {

        }

        public void Update()
        {
            _deliveryMen.Update();
        }


    }
}
