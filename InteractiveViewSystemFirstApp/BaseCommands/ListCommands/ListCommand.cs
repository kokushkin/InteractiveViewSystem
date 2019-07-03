using InteractiveViewSystem.BaseModels;
using InteractiveViewSystem.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystem.BaseCommands.ListCommands
{
    public class ListCommand<DataModelType, DataViewModelType, DataDetailViewModelType>
        where DataViewModelType : IItemDataViewModel
        where DataDetailViewModelType : IItemDataViewModel
    {
        protected ListViewModel<DataModelType, DataViewModelType, DataDetailViewModelType> _listVM;

        public ListCommand(ListViewModel<DataModelType, DataViewModelType, DataDetailViewModelType> listVM)
        {
            Debug.Assert(listVM != null);
            _listVM = listVM;
            _listVM.StateCanChanged += _listVM_StateCanChanged;
        }

        void _listVM_StateCanChanged(object sender, EventArgs e)
        {
            CanExecuteChanged(this, new EventArgs());
        }

        public event EventHandler CanExecuteChanged = delegate { };
    }
}
