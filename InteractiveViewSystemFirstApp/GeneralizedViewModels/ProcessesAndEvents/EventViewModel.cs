using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystem.GeneralizedViewModels.ProcessesAndEvents
{
    public class EventViewModel : Notifier, IEventViewModel
    {
        IEventModel _model;

        public string Name
        {
            get
            {
                return _model.Name;
            }
        }

        public string Description
        {
            get
            {
                return _model.Description;
            }
        }

        public EventViewModel(IEventModel model)
        {
            _model = model;
        }

        public void Update()
        {
            NotifyPropertyChanged("Name");
            NotifyPropertyChanged("Description");
        }

        public override int GetHashCode()
        {
            return _model.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var eventObj = obj as EventViewModel;
            if (eventObj == null)
                return false;
            return eventObj._model.Equals(_model);
        }
    }
}
