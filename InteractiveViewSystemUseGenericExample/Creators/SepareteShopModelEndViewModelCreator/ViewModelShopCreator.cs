using InteractiveViewSystem.BaseCreators.SepareteCreators;
using InteractiveViewSystem.BaseModels.ItemModelAdapters;
using InteractiveViewSystem.BaseViewModels;
using InteractiveViewSystemUseGenericExample.Models;
using InteractiveViewSystemUseGenericExample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystemUseGenericExample.Creators.SepareteShopModelEndViewModelCreator
{
    class ViewModelShopCreator :
        IViewModelCreator<ShopModel, ShopViewModel, ShopDetailViewModel>
    {
        private static DetailItemViewModelTimer<ShopModel, ShopDetailViewModel> _previosDetailViewModel;
        public IDetailItemViewModel<ShopModel, ShopDetailViewModel> CreateDetailViewModel(IItemModelAdapter<ShopModel> model)
        {
            if (_previosDetailViewModel != null)
                _previosDetailViewModel.Dispose();

            _previosDetailViewModel = new DetailItemViewModelTimer<ShopModel, ShopDetailViewModel>(model, new ShopDataDetailViewModelCreator(), new ShopModelAdapterCreator());
            return _previosDetailViewModel;
        }

        public IItemViewModel<ShopModel, ShopViewModel> CreateItemViewModel(IItemModelAdapter<ShopModel> itemModel)
        {
            var dataViewModelCreator = new ShopDataViewModelCreator();
            return new ItemViewModel<ShopModel, ShopViewModel>(itemModel, dataViewModelCreator);
        }
    }
}
