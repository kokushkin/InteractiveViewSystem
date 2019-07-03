using InteractiveViewSystem.BaseViewModels;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InteractiveViewSystem.GeneralizedViewModels.ProcessesAndEvents
{
    public interface IDetailEventViewModel : IItemDataViewModel
    {
        long Id {get; set;}

        string Name {get; set;}

        DateTime Time { get; set; }

        string Description {get; set;}

        IProcessViewModel SubProcess { get; set; }

        
    }
}
