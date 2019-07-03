using InteractiveViewSystem.BaseViewModels;
using InteractiveViewSystem.GeneralizedViewModels;
using InteractiveViewSystemUseGenericExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystemUseGenericExample.ViewModels
{
    public class ShopViewModel : Notifier, IItemDataViewModel
    {
        ShopModel _model;

        public string Name
        {
            get
            {
                return _model.Name;
            }
        }

        public ShopViewModel(ShopModel model)
        {
            _model = model;
        }

        public void Update()
        {
            NotifyPropertyChanged("Name");
        }

        public override int GetHashCode()
        {
            return _model.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var shopVM = obj as ShopViewModel;
            return shopVM._model.Equals(_model);
            
        }
    }
}
