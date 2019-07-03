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
    public class SaveListCommand<DataModelType, DataViewModelType, DataDetailViewModelType>
        : ListCommand<DataModelType, DataViewModelType, DataDetailViewModelType>, ICommand
        where DataViewModelType : IItemDataViewModel
        where DataDetailViewModelType : IItemDataViewModel
    {
        public SaveListCommand(ListViewModel<DataModelType, DataViewModelType, DataDetailViewModelType> listVM)
            :base(listVM) {}

        public bool CanExecute(object parameter)
        {
            return _listVM.CanSaveList();
        }

        public void Execute(object parameter)
        {
            _listVM.SaveList();
        }
    }
}
