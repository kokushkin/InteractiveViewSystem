using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystem.BaseModels
{
    public class ItemModel<DataModelType> : IItemModel<DataModelType> 
        where DataModelType : IItemDataModel<DataModelType>
    {
        static Logger log = LogManager.GetCurrentClassLogger();

        public DataModelType DataModel { get; private set;}

        public event EventHandler<ItemModelEventArgs<DataModelType>> Updated;

        public ItemModel(DataModelType dataModel)
        {
            DataModel = dataModel;
        }

        public void Save(IItemModel<DataModelType> saveModel)
        {
            try
            {
                DataModel.Save(saveModel.DataModel);

                if (Updated != null)
                {
                    Updated(this, new ItemModelEventArgs<DataModelType>(this));
                }
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

                if (Updated != null)
                {
                    Updated(this, new ItemModelEventArgs<DataModelType>(this));
                }
            }
            catch (Exception ex)
            {
                log.Error(ex, "Update");
            }
        }

    }
}
