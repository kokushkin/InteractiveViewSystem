using InteractiveViewSystem.BaseViewModels;
using InteractiveViewSystem.GeneralizedViewModels;
using InteractiveViewSystemUseGenericExample.Creators;
using InteractiveViewSystemUseGenericExample.Creators.SepareteProductModelEndViewModelCreators;
using InteractiveViewSystemUseGenericExample.Creators.SepareteShopModelEndViewModelCreator;
using InteractiveViewSystemUseGenericExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystemUseGenericExample.ViewModels
{
    public class ShopDetailViewModel : Notifier, IItemDataViewModel
    {
        ShopModel _model;

        public string Name
        {
            get
            {
                return _model.Name;
            }
            set
            {
                _model.Name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public string Address
        {
            get
            {
                return _model.Address;
            }
            set
            {
                _model.Address = value;
                NotifyPropertyChanged("Address");
            }
        }

        public string Description
        {
            get
            {
                return _model.Description;
            }
            set
            {
                _model.Description = value;
                NotifyPropertyChanged("Description");
            }
        }

        IListViewModel<ProductModel, ProductViewModel, ProductDetailViewModel> products;
        public IListViewModel<ProductModel, ProductViewModel, ProductDetailViewModel> Products
        {
            get
            {
                return products;
            }
            set
            {
                products = value;
                NotifyPropertyChanged("Products");
            }
        }

        public ShopDetailViewModel(ShopModel model)
        {
            _model = model;
            ViewModelProductCreator creator = new ViewModelProductCreator();
            var shopModelCreator = new ProductModelAdapterCreator();
            Products = new ListViewModel<ProductModel, ProductViewModel, ProductDetailViewModel>(_model, creator, shopModelCreator);

        }

        public void Update()
        {
            NotifyPropertyChanged("Name");
            NotifyPropertyChanged("Address");
            NotifyPropertyChanged("Description");
            NotifyPropertyChanged("Products");
        }
    }
}
