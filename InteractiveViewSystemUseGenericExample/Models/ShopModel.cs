using InteractiveViewSystem.BaseModels;
using InteractiveViewSystem.BaseModels.ItemModelAdapters;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystemUseGenericExample.Models
{
    public class ShopModel : IItemDataModel<ShopModel>, IListModel<ProductModel>
    {
        static Logger log = LogManager.GetCurrentClassLogger();

        public string Name { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public List<ProductModel> Products { get; private set; }

        public ShopModel(string name, string address, string description, List<ProductModel> products = null)
        {
            Name = name;
            Address = address;
            Description = description;
            if (products == null)
                Products = new List<ProductModel>();
            else
                Products = products;
        }

        public void Save(ShopModel saveShopModel)
        {
            Address = saveShopModel.Address;
            Description = saveShopModel.Description;
        }

        public void Update()
        {
            try
            {
                if (Updated != null)
                {
                    Updated(this, new ListModelEventArgs<ProductModel>(this));
                }
            }
            catch (Exception ex)
            {
                log.Error(ex, "Update");
            }
        }

        public event EventHandler<ListModelEventArgs<ProductModel>> Updated;

        public void AddItems(IEnumerable<IItemModelAdapter<ProductModel>> addItems)
        {
            try
            {
                Products.AddRange(addItems.Select(itm => itm.DataModel).ToArray());
            }
            catch (Exception ex)
            {
                log.Error(ex, "AddItems");
            }   
        }

        public void DeleteItems(IEnumerable<IItemModelAdapter<ProductModel>> remItems)
        {
            try
            {
                foreach (var remEv in remItems)
                {
                    Products.Remove(remEv.DataModel);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex, "DeleteItems");
            }
        }

        public IEnumerable<IItemModelAdapter<ProductModel>> GetItems()
        {
            return Products.Select(prod => new ItemModelAdapterForPassive<ProductModel>(prod)).ToList();
        }

        public override int GetHashCode()
        {
            return Name.Count();
        }

        public override bool Equals(object obj)
        {
            var shop = obj as ShopModel;
            return shop.Name == Name;
        }
    }
}
