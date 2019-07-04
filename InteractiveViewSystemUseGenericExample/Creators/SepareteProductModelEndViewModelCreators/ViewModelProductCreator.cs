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

namespace InteractiveViewSystemUseGenericExample.Creators.SepareteProductModelEndViewModelCreators
{
    public class ViewModelProductCreator :
        IViewModelCreator<ProductModel, ProductViewModel, ProductDetailViewModel>
    {
        private static DetailItemViewModelTimer<ProductModel, ProductDetailViewModel> _previosDetailViewModel;
        public IDetailItemViewModel<ProductModel, ProductDetailViewModel> CreateDetailViewModel(IItemModelAdapter<ProductModel> model)
        {
            if(_previosDetailViewModel != null)
                _previosDetailViewModel.Dispose();

            _previosDetailViewModel = new DetailItemViewModelTimer<ProductModel, ProductDetailViewModel>(model, new ProductDataDetailViewModelCreator(), new ProductModelAdapterCreator());
            return _previosDetailViewModel;
        }

        public IItemViewModel<ProductModel, ProductViewModel> CreateItemViewModel(IItemModelAdapter<ProductModel> itemModel)
        {
            var dataViewModelCreator = new ProductDataViewModelCreator();
            return new ItemViewModel<ProductModel, ProductViewModel>(itemModel, dataViewModelCreator);
        }
    }
}
