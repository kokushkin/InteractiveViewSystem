using InteractiveViewSystem.BaseModels;
using InteractiveViewSystem.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InteractiveViewSystem.BaseCommands.ListCommands
{
    public class SelectItemCommand<DataModelType, DataViewModelType, DataDetailViewModelType>
        : ListCommand<DataModelType, DataViewModelType, DataDetailViewModelType>, ICommand
        where DataViewModelType : IItemDataViewModel
        where DataDetailViewModelType : IItemDataViewModel
    {
        public SelectItemCommand(ListViewModel<DataModelType, DataViewModelType, DataDetailViewModelType> listVM)
            :base(listVM) {}

        public bool CanExecute(object parameter)
        {
            return _listVM.CanSelectItem();
        }

        public void Execute(object parameter)
        {
            Debug.Assert(parameter is ItemViewModel<DataModelType, DataViewModelType>);
            _listVM.SelectItem((ItemViewModel<DataModelType, DataViewModelType>)parameter);
        }
    }
}
