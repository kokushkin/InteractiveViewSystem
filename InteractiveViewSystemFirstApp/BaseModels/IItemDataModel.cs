using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystem.BaseModels
{
    public interface IItemDataModel<DataModelType>
    {
        /// <summary>
        /// save changings
        /// </summary>
        /// <param name="saveDataModel"></param>

        void Save(DataModelType saveDataModel);

        /// <summary>
        /// update state of this ItemDataModel
        /// </summary>

        void Update();
    }
}
