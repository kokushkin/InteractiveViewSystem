using InteractiveViewSystem.BaseModels;
using InteractiveViewSystem.BaseModels.ItemModelAdapters;
using InteractiveViewSystem.GeneralizedViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InteractiveViewSystem.BaseViewModels
{
    public interface IDetailItemViewModel<DataModelType, DataDetailViewModelType>
        where DataDetailViewModelType : IItemDataViewModel
    {

        DataDetailViewModelType DataViewModel { get; }

        /// <summary>
        /// показывает редактируется ли элемент
        /// </summary>
        bool IsEditing { get; }

        bool IsSaved { get; }

        ICommand UpdateCommand { get; }

        ICommand EditCommand { get; }

        ICommand SaveCommand { get; }

        event EventHandler StateCanChanged;

        void Save();

        bool CanSave();

        void Update();

        bool CanUpdate();

        void Edit();

        bool CanEdit();

        IItemModelAdapter<DataModelType> GetItemModel();

    }
}
