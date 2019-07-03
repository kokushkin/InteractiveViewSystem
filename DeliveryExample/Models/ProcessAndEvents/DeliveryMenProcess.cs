using DeliveryExample.Models.NativeModels;
using InteractiveViewSystem.BaseModels;
using InteractiveViewSystem.BaseModels.ItemModelAdapters;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryExample.Models.ProcessAndEvents
{
    public class DeliveryMenProcess : IProcessModel
    {
        DeliveryMen _deliveryMen;

        public long Id
        {
            get
            {
                return _deliveryMen.Id;
            }
            set { }
        }

        public string Name
        {
            get
            {
                return _deliveryMen.Name;
            }
            set { }
        }

        public DateTime TimeStart
        {
            get
            {
                return DateTime.MinValue;
            }
            set { }
        }

        public DateTime TimeEnd
        {
            get
            {
                return DateTime.MaxValue;
            }
            set { }
        }

        public string Description
        {
            get
            {
                return $"{_deliveryMen.Location}. Total {_deliveryMen.Deliveries.Count} deliveries";
            }
            set { }
        }

        public List<IEventModel> Events
        {
            get
            {
                return _deliveryMen.Deliveries.Select(dlv => new DeliveryEvent(dlv)).ToList<IEventModel>();
            }
            set
            {
                _deliveryMen.Deliveries.Clear();
                foreach(var deliv in value.OfType<DeliveryEvent>())
                {
                    deliv.AddToDeliveryMen(_deliveryMen);
                }
                _deliveryMen.Save();
            }
        }

        public DeliveryMenProcess(DeliveryMen deliveryMen)
        {
            _deliveryMen = deliveryMen;
        }

        public void Save(IProcessModel saveDataModel)
        {
            Name = saveDataModel.Name;
            TimeStart = saveDataModel.TimeStart;
            TimeEnd = saveDataModel.TimeEnd;
            Description = saveDataModel.Description;
        }

        public void Update()
        {
            _deliveryMen.Update();
            Updated?.Invoke(this, new ListModelEventArgs<IEventModel>(this));
        }

        public event EventHandler<ListModelEventArgs<IEventModel>> Updated;

        public void AddItems(IEnumerable<IItemModelAdapter<IEventModel>> addItems)
        {
            var addedDeliveryEvents = addItems.Select(itm => itm.DataModel).OfType<DeliveryEvent>().ToList();
            var currentDeliveryEvents = Events.OfType<DeliveryEvent>().ToList();

            Events = currentDeliveryEvents.Union(addedDeliveryEvents).ToList<IEventModel>();
        }

        public void DeleteItems(IEnumerable<IItemModelAdapter<IEventModel>> remItems)
        {
            //не реализованный функционал
            //var removedDeliveryEvents = remItems.Select(itm => itm.DataModel).OfType<DeliveryEvent>().ToList();
            //var currentDeliveryEvents = Events.OfType<DeliveryEvent>().ToList();

            //Events = currentDeliveryEvents.Except(removedDeliveryEvents).ToList<IEventModel>();
        }

        public IEnumerable<IItemModelAdapter<IEventModel>> GetItems()
        {
            return Events.Select(ev => new ItemModelAdapterForPassive<IEventModel>(ev)).ToArray();
        }
    }
}
