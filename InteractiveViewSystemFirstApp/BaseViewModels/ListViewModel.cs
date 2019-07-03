using InteractiveViewSystem.BaseCommands.ListCommands;
using InteractiveViewSystem.BaseCreators;
using InteractiveViewSystem.BaseCreators.SepareteCreators;
using InteractiveViewSystem.BaseModels;
using InteractiveViewSystem.BaseModels.ItemModelAdapters;
using InteractiveViewSystem.GeneralizedViewModels;
using InteractiveViewSystem.GeneralizedViewModels.ProcessesAndEvents;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace InteractiveViewSystem.BaseViewModels
{
    public class ListViewModel<DataModelType, DataViewModelType, DataDetailViewModelType> : 
        Notifier, IListViewModel<DataModelType, DataViewModelType, DataDetailViewModelType>
        where DataViewModelType : IItemDataViewModel
        where DataDetailViewModelType : IItemDataViewModel
    {
        IItemViewModel<DataModelType, DataViewModelType> selectedItem;
        public IItemViewModel<DataModelType, DataViewModelType> SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                SelectItem(selectedItem);
                NotifyPropertyChanged("SelectedItem");
            }
        }

        IDetailItemViewModel<DataModelType, DataDetailViewModelType> currentVM;
        public IDetailItemViewModel<DataModelType, DataDetailViewModelType> CurrentVM
        {
            get
            {
                return currentVM;
            }

            private set
            {
                currentVM = value;
                NotifyPropertyChanged("CurrentVM");
            }
        }

        public ObservableCollection<IItemViewModel<DataModelType, DataViewModelType>> ItemsVM { get; private set; }

        public bool IsEditing { get; private set; }

        public bool IsSaved { get; private set; }

        public ICommand AddItemCommand { get; private set; }

        public ICommand DeleteItemCommand { get; private set; }

        public ICommand EditListCommand { get; private set; }

        public ICommand SaveListCommand { get; private set; }

        public ICommand SelectItemCommand { get; private set; }

        public ICommand UpdateListCommand { get; private set; }

        public event EventHandler StateCanChanged;

        IViewModelCreator<DataModelType, DataViewModelType, DataDetailViewModelType> _creator;

        IItemModelAdapterCreator<DataModelType> _itemModelCreator;

        IListModel<DataModelType> _model;

        Dictionary<IItemModelAdapter<DataModelType>, ChangeStatus> addedAndDelatedItems;

        bool _synchroniseWithCurrentModel;

        public bool LetUpdate { get; set; }

        public ListViewModel(IListModel<DataModelType> model,
        IViewModelCreator<DataModelType, DataViewModelType, DataDetailViewModelType> creator,
        IItemModelAdapterCreator<DataModelType> itemModelCreator)
        {
            if (creator == null)
                throw new ArgumentNullException("creator can't be null");
            _creator = creator;

            if (itemModelCreator == null)
                throw new ArgumentNullException("itemModelCreator can't be null");
            _itemModelCreator = itemModelCreator;

            if (model == null)
                throw new ArgumentNullException("model can't be null");

            _model = model;
            _model.Updated += OnUpdate;
            var itemViewModels = GetItemViewModels(_model.GetItems());
            UpdateList(itemViewModels);

            AddItemCommand = new AddItemCommand<DataModelType, DataViewModelType, DataDetailViewModelType>(this);
            DeleteItemCommand = new DeleteItemCommand<DataModelType, DataViewModelType, DataDetailViewModelType>(this);
            EditListCommand = new EditListCommand<DataModelType, DataViewModelType, DataDetailViewModelType>(this);
            SaveListCommand = new SaveListCommand<DataModelType, DataViewModelType, DataDetailViewModelType>(this);
            SelectItemCommand = new SelectItemCommand<DataModelType, DataViewModelType, DataDetailViewModelType>(this);
            UpdateListCommand = new UpdateListCommand<DataModelType, DataViewModelType, DataDetailViewModelType>(this);

            addedAndDelatedItems = new Dictionary<IItemModelAdapter<DataModelType>, ChangeStatus>();

            IsSaved = true;
        }

        void OnUpdate(object sender, ListModelEventArgs<DataModelType> e)
        {
            if (CanUpdateList())
            {
                var itemsFromModel = _model.GetItems().ToList();

                //добавляем те элементы, которые были добавленны в процессе редактирования
                var addedItems = addedAndDelatedItems.Where(itm => itm.Value == ChangeStatus.Add).Select(itm => itm.Key).ToList();
                itemsFromModel.AddRange(addedItems);

                //удаляем элементы, которые были удалены, чтобы они не отображались
                var deletedItems = addedAndDelatedItems.Where(itm => itm.Value == ChangeStatus.Delete).Select(itm => itm.Key).ToList();
                foreach (var delItem in deletedItems)
                    itemsFromModel.Remove(delItem);

                var newItemViewModels = GetItemViewModels(itemsFromModel);
                UpdateList(newItemViewModels);
            }   
        }

        List<IItemViewModel<DataModelType, DataViewModelType>> GetItemViewModels(IEnumerable<IItemModelAdapter<DataModelType>> itemModels)
        {
            List<IItemViewModel<DataModelType, DataViewModelType>> itemViewModels =
                new List<IItemViewModel<DataModelType, DataViewModelType>>();

            foreach(var itemModel in itemModels)
            {
                var itemViewModel = _creator.CreateItemViewModel(itemModel);
                itemViewModels.Add(itemViewModel);
            }

            return itemViewModels;
        }

        void UpdateList(List<IItemViewModel<DataModelType, DataViewModelType>> itemViewModels)
        {
            //сохраняем текущий элемент
            //это необходимо, т.к. при последующей очистки списка, элемент обнуляется, из-за привязки
            var savedSelectedItem = SelectedItem;

            //производим полное обновление
            if (ItemsVM == null)
            {
                ItemsVM = new ObservableCollection<IItemViewModel<DataModelType, DataViewModelType>>(itemViewModels);
            }
            else
            {
                ItemsVM.Clear();
                foreach (var viewModel in itemViewModels)
                {
                    ItemsVM.Add(viewModel);
                }
            }

            //делаем необходимые действия если был выбранный элемент
            if (savedSelectedItem != null)
            {
                //ищем его в списке
                var selectedItemFromUpdate = itemViewModels.FirstOrDefault(itm => itm.DataViewModel.Equals(savedSelectedItem.DataViewModel));
                //текущего элемента нет в обновлении
                if (selectedItemFromUpdate == null)
                {
                    CurrentVM = null;
                    SelectedItem = null;
                }
                //в противном случае, НЕ надо чтобы выбранный элемент был обновленным
                //он сам мебя должен обновлять
                //(такое ограничение, из-за того, что он сам может содержать свой список, который должен поддерживать текущий элемент)
                //устанавливаем только VM(не детальный)
                else
                {
                    selectedItem = selectedItemFromUpdate;
                    NotifyPropertyChanged("SelectedItem");

                    //var saveCurVM = CurrentVM;
                    //SelectedItem = selectedItemFromUpdate;
                    //CurrentVM = saveCurVM;
                }
            }
        }

        public virtual void SelectItem(IItemViewModel<DataModelType, DataViewModelType> itemVM)
        {
            if (CanSelectItem())
            {
                //возникает когда удаляются все элементы из ObservCollection, 
                //и устанавливается текущий элемент 0;
                if (itemVM == null)
                    return;
                var itemModel = itemVM.GetItemModel();

                SelectItemByModel(itemModel);
            }
        }

        void SelectItemByModel(IItemModelAdapter<DataModelType> itemModel)
        {
            CurrentVM = _creator.CreateDetailViewModel(itemModel);

            Debug.Assert(StateCanChanged != null);
            StateCanChanged(this, new EventArgs());
        }

        public bool CanSelectItem()
        {
            return true;
        }

        public void UpdateList()
        {
            if (CanUpdateList())
            {
                _model.Update();
                Debug.Assert(StateCanChanged != null);
                StateCanChanged(this, new EventArgs());
            }           
        }

        public bool CanUpdateList()
        {
            return !IsEditing || LetUpdate;
        }

        public void AddItem()
        {
            if (CanAddItem())
            {
                //создаем IDetailItemViewModel
                var dataItemModel = _itemModelCreator.CreateNewDataModel();
                var itemModel = _itemModelCreator.CreateItemModel(dataItemModel);

                var detailItemViewModel = _creator.CreateDetailViewModel(itemModel);
                CurrentVM = detailItemViewModel;

                //IItemViewModel
                var itemViewModel = _creator.CreateItemViewModel(itemModel);
                ItemsVM.Add(itemViewModel);

                addedAndDelatedItems[itemModel] = ChangeStatus.Add;

                CurrentVM.Edit();

                Debug.Assert(StateCanChanged != null);
                StateCanChanged(this, new EventArgs());
            }
        }

        public bool CanAddItem()
        {
            return IsEditing;
        }

        public void DeleteItem(IItemViewModel<DataModelType, DataViewModelType> itemVM)
        {
            if (CanDeleteItem())
            {
                ItemsVM.Remove(itemVM);
                var deleteModel = itemVM.GetItemModel();
                var currentModel = CurrentVM.GetItemModel();

                if (deleteModel.DataModel.Equals(currentModel.DataModel))
                {
                    CurrentVM = null;
                }
                addedAndDelatedItems[deleteModel] = ChangeStatus.Delete;
                Debug.Assert(StateCanChanged != null);
                StateCanChanged(this, new EventArgs());
            }
        }

        public bool CanDeleteItem()
        {
            return IsEditing;
        }

        public void EditList()
        {
            if (CanEditList())
            {
                IsEditing = true;
                IsSaved = false;
                Debug.Assert(StateCanChanged != null);
                StateCanChanged(this, new EventArgs());
            }
        }

        public bool CanEditList()
        {
            return IsSaved;
        }

        public void SaveList()
        {

            if (CanSaveList())
            {
                var addItems = addedAndDelatedItems.Where(el => el.Value == ChangeStatus.Add)
            .Select(el => el.Key).ToList();
                var delItems = addedAndDelatedItems.Where(el => el.Value == ChangeStatus.Delete)
                    .Select(el => el.Key).ToList();

                _model.AddItems(addItems);
                _model.DeleteItems(delItems);

                addedAndDelatedItems.Clear();


                IsEditing = false;
                IsSaved = true;

                UpdateList();

                Debug.Assert(StateCanChanged != null);
                StateCanChanged(this, new EventArgs());
            }
        }

        public bool CanSaveList()
        {
            return IsEditing;
        }
    }
}
