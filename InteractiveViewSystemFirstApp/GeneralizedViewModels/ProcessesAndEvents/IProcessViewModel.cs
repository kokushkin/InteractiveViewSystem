using InteractiveViewSystem.BaseViewModels;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystem.GeneralizedViewModels.ProcessesAndEvents
{
    public interface IProcessViewModel : IItemDataViewModel
    {
        long Id { get; set; }

        string Name { get; set; }

        DateTime TimeStart { get; set; }

        DateTime TimeEnd { get; set; }

        string Description { get; set; }

        IListViewModel<IEventModel, IEventViewModel, IDetailEventViewModel> Events { get; set; }


    }
}
