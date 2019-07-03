using InteractiveViewSystem.BaseCreators.SepareteCreators;
using InteractiveViewSystemUseGenericExample.Models;
using InteractiveViewSystemUseGenericExample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystemUseGenericExample.Creators.SepareteShopModelEndViewModelCreator
{
    public class ShopDataViewModelCreator :
        IDataViewModelCreator<ShopModel, ShopViewModel>
    {
        public ShopViewModel CreateDataViewModel(ShopModel dataModel)
        {
            return new ShopViewModel(dataModel);
        }
    }
}
