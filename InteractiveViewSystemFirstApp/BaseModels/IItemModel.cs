using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystem.BaseModels
{
    public interface IItemModel<DataModelType> 
        where DataModelType : IItemDataModel<DataModelType>
    {

        /// <summary>
        /// дата модель, содержащаяся в этом контейнере 
        /// </summary>
        DataModelType DataModel { get; }

        /// <summary>
        /// оповещает подписчиков об изменениях
        /// </summary>
        event EventHandler<ItemModelEventArgs<DataModelType>> Updated;

        /// <summary>
        /// сохраняет изменения, переданные в saveModel
        /// </summary>
        /// <param name="saveModel"></param>
        void Save(IItemModel<DataModelType> saveModel);

        /// <summary>
        /// обновляет модель из источников
        /// </summary>
        void Update();

    }
}
