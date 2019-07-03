using InteractiveViewSystem.BaseCreators;
using InteractiveViewSystem.BaseCreators.SepareteCreators;
using InteractiveViewSystem.BaseModels;
using InteractiveViewSystem.BaseModels.ItemModelAdapters;
using InteractiveViewSystem.GeneralizedViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystem.BaseViewModels
{
    public class ItemViewModel<DataModelType, DataViewModelType> : Notifier, IItemViewModel<DataModelType, DataViewModelType>
        where DataViewModelType : IItemDataViewModel
    {
        IItemModelAdapter<DataModelType> _model;

        public DataViewModelType DataViewModel { get; private set; }

        /// <summary>
        /// Исключения:
        ///   System.ArgumentNullException:
        ///     Параметр model имеет значение null.
        /// </summary>
        /// <param name="model"></param>
        public ItemViewModel(IItemModelAdapter<DataModelType> model, IDataViewModelCreator<DataModelType, DataViewModelType> creator)
        {
            if (model == null)
                throw new ArgumentNullException("model can't be null");
            _model = model;
            if (creator == null)
                throw new ArgumentNullException("creator can't be null");

            DataViewModel = creator.CreateDataViewModel(_model.DataModel);
            _model.Updated += OnUpdate;
        }

        void OnUpdate(object sender, ItemModelAdapterEventArgs<DataModelType> e)
        {
            DataViewModel.Update();
            NotifyPropertyChanged("DataViewModel");
        }

        public IItemModelAdapter<DataModelType> GetItemModel()
        {
            return _model;
        }
    }
}
