using AutoMapper;
using DeliveryExample.Models.NativeModels;
using DeliveryExample.ServiceContracts;
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
    public class Deliveries : IListModel<IEventModel>
    {
        public event EventHandler<ListModelEventArgs<IEventModel>> Updated;

        List<Delivery> deliveries;

        public Deliveries()
        {
            Update();
        }

        public void AddItems(IEnumerable<IItemModelAdapter<IEventModel>> addItems)
        {
            throw new NotImplementedException("Don't need");
        }

        public void DeleteItems(IEnumerable<IItemModelAdapter<IEventModel>> remItems)
        {
            throw new NotImplementedException("Don't need");
        }

        public IEnumerable<IItemModelAdapter<IEventModel>> GetItems()
        {
           return deliveries
                .Select(dl => new DeliveryEvent(dl))
                .Select(dev => new ItemModelAdapterForPassive<IEventModel>(dev)).ToList();
        }

        public void Update()
        {
            deliveries = ServiceWrap.GetAvailableDeliveries();
            Updated?.Invoke(this, new ListModelEventArgs<IEventModel>(this));
        }
    }
}
