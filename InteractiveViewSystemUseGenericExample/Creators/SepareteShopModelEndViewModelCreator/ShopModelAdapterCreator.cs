using InteractiveViewSystem.BaseCreators.SepareteCreators;
using InteractiveViewSystem.BaseModels.ItemModelAdapters;
using InteractiveViewSystemUseGenericExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystemUseGenericExample.Creators.SepareteShopModelEndViewModelCreator
{
    public class ShopModelAdapterCreator : IItemModelAdapterCreator<ShopModel>
    {
        public ShopModel CreateNewDataModel()
        {
            return new ShopModel("Unknown", "Unknown", "Unknown");
        }

        public IItemModelAdapter<ShopModel> CreateDeepCopyOfItemModel(IItemModelAdapter<ShopModel> model)
        {
            var oldDataModel = model.DataModel;
            var newDataModel
                = new ShopModel(oldDataModel.Name, oldDataModel.Address, oldDataModel.Description);
            var newModel = new ItemModelAdapterForPassive<ShopModel>(newDataModel);
            return newModel;
        }

        public IItemModelAdapter<ShopModel> CreateItemModel(ShopModel dataModel)
        {
            return new ItemModelAdapterForPassive<ShopModel>(dataModel);
        }


    }
}
