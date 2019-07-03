using InteractiveViewSystem.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents
{
    public interface IEventModel : IItemDataModel<IEventModel>
    {
        long Id { get; set; }

        string Name { get; set; }

        DateTime Time { get; set; }

        string Description { get; set; }

        IProcessModel SubProcess { get; set; }
    }
}
