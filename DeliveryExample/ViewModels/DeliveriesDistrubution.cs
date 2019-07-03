using DeliveryExample.Commands;
using DeliveryExample.Models.ProcessAndEvents;
using DeliveryExample.ProcessAndEventsCreaters;
using DeliveryExample.ProcessAndEventsCreaters.SepareteCreators.DeliveryCreators;
using DeliveryExample.ProcessAndEventsCreaters.SepareteCreators.DeliveryMenCreators;
using InteractiveViewSystem.BaseViewModels;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents.SepareteCreators;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using InteractiveViewSystem.GeneralizedViewModels.ProcessesAndEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DeliveryExample.ViewModels
{
    public class DeliveriesDistrubution
    {
        public ListViewModel<IEventModel, IEventViewModel, IDetailEventViewModel> DeliveryMens { get; set; }

        public ListViewModel<IEventModel, IEventViewModel, IDetailEventViewModel> Deliveries { get; set; }

        public ICommand TakeDeliveryCommand { get; private set; }

        public DeliveriesDistrubution()
        {
            var deliveryMensCreator = new ViewModelDeliveryMenEventCreator();

            var deliveryMensModel = new DeliveryMenListModel();
            DeliveryMens = new ListViewModel<IEventModel, IEventViewModel, IDetailEventViewModel>(deliveryMensModel, deliveryMensCreator, new DeliveryMenEventModelAdapterCreator());

            var deliveriesCreator = new ViewModelDeliveryEventCreator();
            var deliveriesModel = new Deliveries();
            Deliveries = new ListViewModel<IEventModel, IEventViewModel, IDetailEventViewModel>(deliveriesModel, deliveriesCreator, new DeliveryEventModelAdapterCreator());

            TakeDeliveryCommand = new TakeDeliveryCommand(DeliveryMens, Deliveries);
        }


    }
}
