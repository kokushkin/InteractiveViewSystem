using InteractiveViewSystem.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystemUseGenericExample.Models
{
    public class ProductModel : IItemDataModel<ProductModel>
    {
        public string Name { get; set; }

        public int Count { get;  set; }

        public double Price { get; set; }

        public ProductModel(string name, int count, double price)
        {
            Name = name;
            Count = count;
            Price = price;
        }

        public void Save(ProductModel saveDataModel)
        {
            Name = saveDataModel.Name;
            Count = saveDataModel.Count;
            Price = saveDataModel.Price;
        }

        public void Update()
        {
            return;
        }
    }
}
