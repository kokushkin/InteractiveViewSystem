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
    public class DeliveryMenListModel : IListModel<IEventModel>
    {
        List<DeliveryMen> deliveryMens = new List<DeliveryMen>();

        public event EventHandler<ListModelEventArgs<IEventModel>> Updated;

        public DeliveryMenListModel()
        {
            Update();
        }

        public void AddItems(IEnumerable<IItemModelAdapter<IEventModel>> addItems)
        {
            throw new NotImplementedException();
        }

        public void DeleteItems(IEnumerable<IItemModelAdapter<IEventModel>> remItems)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IItemModelAdapter<IEventModel>> GetItems()
        {
            return deliveryMens.Select(dlm => new DeliveryMenEvent(dlm))
                .Select(dlmev => new ItemModelAdapterForPassive<IEventModel>(dlmev))              
                .ToList();
        }

        public void Update()
        {
            deliveryMens = ServiceWrap.GetDeliveryMens();
            Updated?.Invoke(this, new ListModelEventArgs<IEventModel>(this));
        }


    }
}
