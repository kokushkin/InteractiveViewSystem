using InteractiveViewSystem.BaseCreators.SepareteCreators;
using InteractiveViewSystem.BaseModels.ItemModelAdapters;
using InteractiveViewSystemUseGenericExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystemUseGenericExample.Creators.SepareteProductModelEndViewModelCreators
{
    public class ProductModelAdapterCreator : IItemModelAdapterCreator<ProductModel>
    {
        public ProductModel CreateNewDataModel()
        {
            return new ProductModel("Unknown", 0, 1);
        }

        public IItemModelAdapter<ProductModel> CreateDeepCopyOfItemModel(IItemModelAdapter<ProductModel> model)
        {
            var oldDataModel = model.DataModel;
            var newDataModel
                = new ProductModel(oldDataModel.Name, oldDataModel.Count, oldDataModel.Price);
            var newModel = new ItemModelAdapterForPassive<ProductModel>(newDataModel);
            return newModel;
        }

        public IItemModelAdapter<ProductModel> CreateItemModel(ProductModel dataModel)
        {
            return new ItemModelAdapterForPassive<ProductModel>(dataModel);
        }
    }
}
