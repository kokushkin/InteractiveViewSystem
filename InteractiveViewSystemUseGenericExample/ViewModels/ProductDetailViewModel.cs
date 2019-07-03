using InteractiveViewSystem.BaseViewModels;
using InteractiveViewSystem.GeneralizedViewModels;
using InteractiveViewSystem.GeneralizedViewModels.ProcessesAndEvents;
using InteractiveViewSystemUseGenericExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystemUseGenericExample.ViewModels
{
    public class ProductDetailViewModel : Notifier, IItemDataViewModel
    {
        ProductModel _model;

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

        public int Count
        {
            get
            {
                return _model.Count;
            }
            set
            {
                _model.Count = value;
                NotifyPropertyChanged("Total");
            }
        }

        public double Price
        {
            get
            {
                return _model.Price;
            }
            set
            {
                _model.Price = value;
                NotifyPropertyChanged("Total");
            }
        }

        public double Total
        {
            get
            {
                return _model.Count * _model.Price;
            }
        }


        public ProductDetailViewModel(ProductModel model)
        {
            _model = model;
        }

        public void Update()
        {
            NotifyPropertyChanged("Name");
            NotifyPropertyChanged("Count");
            NotifyPropertyChanged("Price");
            NotifyPropertyChanged("Total");
        }
    }
}
