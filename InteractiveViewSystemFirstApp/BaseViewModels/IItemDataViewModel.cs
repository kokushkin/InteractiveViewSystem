using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystem.BaseViewModels
{
    public interface IItemDataViewModel
    {
        /// <summary>
        /// действия еобходимые для обновления представления
        /// </summary>
        void Update();
    }
}
