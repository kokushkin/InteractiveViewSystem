using InteractiveViewSystem.BaseCommands.ItemCommands;
using InteractiveViewSystem.BaseCreators;
using InteractiveViewSystem.BaseCreators.SepareteCreators;
using InteractiveViewSystem.BaseModels;
using InteractiveViewSystem.BaseModels.ItemModelAdapters;
using InteractiveViewSystem.GeneralizedViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InteractiveViewSystem.BaseViewModels
{
    public class DetailItemViewModel<DataModelType, DataDetailViewModelType> : Notifier, 
        IDetailItemViewModel<DataModelType, DataDetailViewModelType>
        where DataDetailViewModelType : IItemDataViewModel
    {
        IItemModelAdapter<DataModelType> _model;

        IItemModelAdapter<DataModelType> _saveTempModel;
        IItemModelAdapter<DataModelType> _realModel;

        IDataDetailViewModelCreator<DataModelType, DataDetailViewModelType> _viewModelCreator;
        IItemModelAdapterCreator<DataModelType> _itemModelCreator;


        DataDetailViewModelType _dataViewModel;
        public DataDetailViewModelType DataViewModel
        {
            get
            {
                return _dataViewModel;
            }
            set
            {
                _dataViewModel = value;
                NotifyPropertyChanged("DataViewModel");
            }
        }

        bool isEditing;
        public bool IsEditing
        {
            get
            {
                return isEditing;
            }
            private set
            {
                isEditing = value;
                NotifyPropertyChanged("IsEditing");
            }
        }

        bool isSaved = true;
        public bool IsSaved
        {
            get
            {
                return isSaved;
            }
            private set
            {
                isSaved = value;
                NotifyPropertyChanged("IsSaved");
            }
        }

        public ICommand UpdateCommand { get; private set; }

        public ICommand EditCommand { get; private set; }

        public ICommand SaveCommand { get; private set; }

        public event EventHandler StateCanChanged;

        /// <summary>
        /// Исключения:
        ///   System.ArgumentNullException:
        ///     Параметр model имеет значение null.
        /// </summary>
        /// <param name="model"></param>
        public DetailItemViewModel(IItemModelAdapter<DataModelType> model,
            IDataDetailViewModelCreator<DataModelType, DataDetailViewModelType> viewModelCreator,
            IItemModelAdapterCreator<DataModelType> itemModelCreator)
        {
            if (model == null)
                throw new ArgumentNullException("model can't be null");
            if (viewModelCreator == null)
                throw new ArgumentNullException("viewModelCreator can't be null");
            if (itemModelCreator == null)
                throw new ArgumentNullException("itemModelCreator can't be null");

            _model = model;
            _model.Updated += OnUpdate;
            UpdateCommand = new UpdateItemCommand<DataModelType, DataDetailViewModelType>(this);
            EditCommand = new EditItemCommand<DataModelType, DataDetailViewModelType>(this);
            SaveCommand = new SaveItemCommand<DataModelType, DataDetailViewModelType>(this);

            Debug.Assert(_model.DataModel != null);
            _viewModelCreator = viewModelCreator;
            _itemModelCreator = itemModelCreator;
            DataViewModel = _viewModelCreator.CreateDataDetailViewModel(_model.DataModel);
        }

        void OnUpdate(object sender, ItemModelAdapterEventArgs<DataModelType> e)
        {
            if (!IsEditing)
            {
                if (!IsSaved)
                {
                    _model = _realModel;
                    IsSaved = true;
                }

                DataViewModel.Update();
                NotifyPropertyChanged("DataViewModel");

            }
        }

        public void Save()
        {
            if (CanSave())
            {
                Debug.Assert(_model != null, "_model is null!!");
                IsEditing = false;
                DataViewModel = _viewModelCreator.CreateDataDetailViewModel(_realModel.DataModel);
                _realModel.Save(_saveTempModel);              
                Debug.Assert(StateCanChanged != null);
                StateCanChanged(this, new EventArgs());
            }             
        }

        public bool CanSave()
        {
            return IsEditing;
        }

        public void Update()
        {
            if (CanUpdate())
            {
                Debug.Assert(_model != null, "_model is null!!");
                _model.Update();
                Debug.Assert(StateCanChanged != null);
                StateCanChanged(this, new EventArgs());
            }
        }

        public bool CanUpdate()
        {
            return !IsEditing && IsSaved;
        }

        public void Edit()
        {
            if (CanEdit())
            {
                Debug.Assert(_model != null, "_model is null!!");
                _saveTempModel = _itemModelCreator.CreateDeepCopyOfItemModel(_model);
                _realModel = _model;
                _model = _saveTempModel;
                DataViewModel = _viewModelCreator.CreateDataDetailViewModel(_saveTempModel.DataModel);
                IsEditing = true;
                IsSaved = false;
                Debug.Assert(StateCanChanged != null);
                StateCanChanged(this, new EventArgs());
            }
        }

        public bool CanEdit()
        {
            return IsSaved;
        }

        public IItemModelAdapter<DataModelType> GetItemModel()
        {
            return _model;
        }
    }
}
