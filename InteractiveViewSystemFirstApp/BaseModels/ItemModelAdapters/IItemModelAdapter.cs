using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystem.BaseModels.ItemModelAdapters
{
    public interface IItemModelAdapter<DataModelType>
    {
        /// <summary>
        /// дата модель, содержащаяся в этом контейнере 
        /// </summary>
        DataModelType DataModel { get; }

        /// <summary>
        /// оповещает подписчиков об изменениях
        /// </summary>
        event EventHandler<ItemModelAdapterEventArgs<DataModelType>> Updated;

        /// <summary>
        /// сохраняет изменения, переданные в saveModel
        /// </summary>
        /// <param name="saveModel"></param>
        void Save(IItemModelAdapter<DataModelType> saveModel);

        /// <summary>
        /// обновляет модель из источников
        /// </summary>
        void Update();
    }
}
