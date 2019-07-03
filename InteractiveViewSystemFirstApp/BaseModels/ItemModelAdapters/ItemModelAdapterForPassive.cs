using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystem.BaseModels.ItemModelAdapters
{
    public class ItemModelAdapterForPassive<DataModelType>
        :IItemModelAdapter<DataModelType> 
        where  DataModelType : IItemDataModel<DataModelType>
    {
        static Logger log = LogManager.GetCurrentClassLogger();

        public DataModelType DataModel { get; private set; }

        public event EventHandler<ItemModelAdapterEventArgs<DataModelType>> Updated;

        public ItemModelAdapterForPassive(DataModelType dataModel)
        {
            DataModel = dataModel;
        }

        public void Save(IItemModelAdapter<DataModelType> saveModel)
        {
            try
            {
                DataModel.Save(saveModel.DataModel);

                Updated?.Invoke(this, new ItemModelAdapterEventArgs<DataModelType>(this));
            }
            catch (Exception ex)
            {
                log.Error(ex, "Save");
            }
        }

        public void Update()
        {
            try
            {
                DataModel.Update();

                Updated?.Invoke(this, new ItemModelAdapterEventArgs<DataModelType>(this));
            }
            catch (Exception ex)
            {
                log.Error(ex, "Update");
            }
        }

        public override string ToString()
        {
            return DataModel.ToString();
        }
    }
}
