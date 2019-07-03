using InteractiveViewSystem.BaseModels;
using InteractiveViewSystem.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InteractiveViewSystem.BaseCommands.ListCommands
{
    public class EditListCommand<DataModelType, DataViewModelType, DataDetailViewModelType>
        : ListCommand<DataModelType, DataViewModelType, DataDetailViewModelType>, ICommand
        where DataViewModelType : IItemDataViewModel
        where DataDetailViewModelType : IItemDataViewModel
    {

        public EditListCommand(ListViewModel<DataModelType, DataViewModelType, DataDetailViewModelType> listVM)
            : base(listVM) { }

        public bool CanExecute(object parameter)
        {
            return _listVM.CanEditList();
        }

        public void Execute(object parameter)
        {
            _listVM.EditList();
        }
    }
}
