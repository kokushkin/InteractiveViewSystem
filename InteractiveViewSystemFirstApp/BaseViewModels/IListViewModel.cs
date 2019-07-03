using InteractiveViewSystem.BaseModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InteractiveViewSystem.BaseViewModels
{
    public interface IListViewModel<DataModelType,DataViewModelType,DataDetailViewModelType>
        where DataViewModelType : IItemDataViewModel
        where DataDetailViewModelType : IItemDataViewModel
    {
        IItemViewModel<DataModelType, DataViewModelType> SelectedItem { get; set; }

        IDetailItemViewModel<DataModelType, DataDetailViewModelType> CurrentVM { get; }

        ObservableCollection<IItemViewModel<DataModelType, DataViewModelType>> ItemsVM { get; }

        bool IsEditing { get; }

        bool IsSaved { get; }

        ICommand AddItemCommand { get; }

        ICommand DeleteItemCommand { get; }

        ICommand EditListCommand { get; }

        ICommand SaveListCommand { get; }

        ICommand SelectItemCommand { get; }

        ICommand UpdateListCommand { get; }

        event EventHandler StateCanChanged;

        void SelectItem(IItemViewModel<DataModelType, DataViewModelType> itemVM);

        bool CanSelectItem();

        void UpdateList();          

        bool CanUpdateList();

        void AddItem();

        bool CanAddItem();

        void DeleteItem(IItemViewModel<DataModelType, DataViewModelType> itemVM);

        bool CanDeleteItem();

        void EditList();

        bool CanEditList();

        void SaveList();

        bool CanSaveList();
    }
}
