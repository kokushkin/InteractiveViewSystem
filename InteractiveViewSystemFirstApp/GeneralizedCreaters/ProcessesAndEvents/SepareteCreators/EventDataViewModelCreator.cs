using InteractiveViewSystem.BaseCreators.SepareteCreators;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using InteractiveViewSystem.GeneralizedViewModels.ProcessesAndEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents.SepareteCreators
{
    public class EventDataViewModelCreator : 
        IDataViewModelCreator<IEventModel, IEventViewModel>
    {
        public IEventViewModel CreateDataViewModel(IEventModel dataModel)
        {
            return new EventViewModel(dataModel);
        }
    }
}
