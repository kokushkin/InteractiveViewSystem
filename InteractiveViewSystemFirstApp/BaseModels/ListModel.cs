using InteractiveViewSystem.BaseModels.ItemModelAdapters;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystem.BaseModels
{
    public class ListModel<DataModelType> : IListModel<DataModelType> 
        where DataModelType : IItemDataModel<DataModelType>
    {
        static Logger log = LogManager.GetCurrentClassLogger();

        List<IItemModelAdapter<DataModelType>> items;

        public event EventHandler<ListModelEventArgs<DataModelType>> Updated;

        public ListModel()
        {
            items = new List<IItemModelAdapter<DataModelType>>();
        }

        public void AddItems(IEnumerable<IItemModelAdapter<DataModelType>> addItems)
        {
            try
            {
                items.AddRange(addItems);
            }
            catch (Exception ex)
            {
                log.Error(ex, "AddItems");
            }   
        }

        public void DeleteItems(IEnumerable<IItemModelAdapter<DataModelType>> remItems)
        {
            try
            {
                foreach (var remEv in remItems)
                {
                    items.Remove(remEv);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex, "DeleteItems");
            }
        }

        public IEnumerable<IItemModelAdapter<DataModelType>> GetItems()
        {
            return items.ToList();
        }

        public void Update()
        {
            try
            {
                Updated?.Invoke(this, new ListModelEventArgs<DataModelType>(this));
            }
            catch (Exception ex)
            {
                log.Error(ex, "Update");
            }
        }
    }
}
