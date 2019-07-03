using InteractiveViewSystem.BaseCreators.SepareteCreators;
using InteractiveViewSystem.BaseModels;
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
    public class ProductDataDetailViewModelCreator : IDataDetailViewModelCreator<ProductModel, ProductDetailViewModel>
    {
        public ProductDetailViewModel CreateDataDetailViewModel(ProductModel dataModel)
        {
            return new ProductDetailViewModel(dataModel);
        }
    }
}
