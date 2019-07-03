using InteractiveViewSystem.BaseCreators.SepareteCreators;
using InteractiveViewSystemUseGenericExample.Models;
using InteractiveViewSystemUseGenericExample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystemUseGenericExample.Creators.SepareteProductModelEndViewModelCreators
{
    public class ProductDataViewModelCreator :
        IDataViewModelCreator<ProductModel, ProductViewModel>
    {
        public ProductViewModel CreateDataViewModel(ProductModel dataModel)
        {
            return new ProductViewModel(dataModel);
        }
    }
}
