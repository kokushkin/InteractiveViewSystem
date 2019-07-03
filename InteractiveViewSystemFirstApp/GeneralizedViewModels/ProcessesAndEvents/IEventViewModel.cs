using InteractiveViewSystem.BaseViewModels;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystem.GeneralizedViewModels.ProcessesAndEvents
{
    public interface IEventViewModel : IItemDataViewModel
    {
        string Name { get;}

        string Description { get; }
    }
}
