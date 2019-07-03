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
    public class EventDataDetailViewModelCreator 
        : IDataDetailViewModelCreator<IEventModel, IDetailEventViewModel>
    {
        public virtual IDetailEventViewModel CreateDataDetailViewModel(IEventModel dataModel)
        {
            var creator = new EventViewModelCreator();
            return new DetailEventViewModel(dataModel, creator);
        }
    }
}
