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
    class ShopDataDetailViewModelCreator : IDataDetailViewModelCreator<ShopModel, ShopDetailViewModel>
    {
        public ShopDetailViewModel CreateDataDetailViewModel(ShopModel dataModel)
        {
            return new ShopDetailViewModel(dataModel);
        }
    }
}
