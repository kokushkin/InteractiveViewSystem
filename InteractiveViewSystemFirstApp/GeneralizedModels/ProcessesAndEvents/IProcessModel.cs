using InteractiveViewSystem.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents
{
    public interface IProcessModel : IItemDataModel<IProcessModel>, IListModel<IEventModel>
    {
        long Id { get; set; }

        string Name { get; set; }

        DateTime TimeStart { get; set; }

        DateTime TimeEnd { get; set; }

        string Description { get; set; }

        List<IEventModel> Events { get; set; }

    }
}
