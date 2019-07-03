using InteractiveViewSystem.BaseModels;
using InteractiveViewSystem.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InteractiveViewSystem.BaseCommands.ItemCommands
{
    public class UpdateItemCommand<DataModelType, DataDetailViewModelType> : ICommand
        where DataDetailViewModelType : IItemDataViewModel
    {
        DetailItemViewModel<DataModelType, DataDetailViewModelType> _itemVM;

        public UpdateItemCommand(DetailItemViewModel<DataModelType, DataDetailViewModelType> itemVM)
        {
            Debug.Assert(itemVM != null);
            _itemVM = itemVM;
            _itemVM.StateCanChanged += _itemVM_StateCanChanged;
        }

        void _itemVM_StateCanChanged(object sender, EventArgs e)
        {
            CanExecuteChanged(this, new EventArgs());
        }

        public event EventHandler CanExecuteChanged =  delegate { };

        public bool CanExecute(object parameter)
        {
            return _itemVM.CanUpdate();
        }

        public void Execute(object parameter)
        {
            _itemVM.Update();
        }
    }
}
