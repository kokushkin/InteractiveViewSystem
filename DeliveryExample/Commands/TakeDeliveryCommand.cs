using InteractiveViewSystem.BaseViewModels;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using InteractiveViewSystem.GeneralizedViewModels.ProcessesAndEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DeliveryExample.Commands
{
    public class TakeDeliveryCommand : ICommand
    {
        ListViewModel<IEventModel, IEventViewModel, IDetailEventViewModel> _deliveryMens;
        ListViewModel<IEventModel, IEventViewModel, IDetailEventViewModel> _deliveries;

        public event EventHandler CanExecuteChanged;

        public TakeDeliveryCommand(ListViewModel<IEventModel, IEventViewModel, IDetailEventViewModel> deliveryMens,
            ListViewModel<IEventModel, IEventViewModel, IDetailEventViewModel> deliveries)
        {
            _deliveryMens = deliveryMens;
            _deliveries = deliveries;
            _deliveryMens.StateCanChanged += _deliveryMens_StateCanChanged;
            _deliveries.StateCanChanged += _deliveries_StateCanChanged;
        }

        private void _deliveries_StateCanChanged(object sender, EventArgs e)
        {
            CanExecuteChanged(this, new EventArgs());
        }

        private void _deliveryMens_StateCanChanged(object sender, EventArgs e)
        {
            CanExecuteChanged(this, new EventArgs());
        }

        public bool CanExecute(object parameter)
        {
            return _deliveryMens.CurrentVM != null && _deliveries.CurrentVM != null;
        }

        public void Execute(object parameter)
        {
            try
            {
                var idDeliveryMen = Convert.ToInt32(_deliveryMens.CurrentVM.DataViewModel.Id);
                var idDelivery = Convert.ToInt32(_deliveries.CurrentVM.DataViewModel.Id);
                var result = ServiceWrap.TakeDelivery(idDeliveryMen, idDelivery);
                CanExecuteChanged(this, new EventArgs());
            }
            catch(Exception ex)
            {
                throw new NotImplementedException();
            }

        }
    }
}
