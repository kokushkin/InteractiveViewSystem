using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents.SepareteCreators;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using System;

namespace InteractiveViewSystem.GeneralizedViewModels.ProcessesAndEvents
{
    public class DetailEventViewModel : Notifier, IDetailEventViewModel
    {
        IEventModel _model;

        public long Id
        {
            get
            {
                return _model.Id;
            }
            set
            {
                _model.Id = value;
                NotifyPropertyChanged();
            }
        }

        public string Name
        {
            get
            {
                return _model.Name;
            }
            set
            {
                _model.Name = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime Time
        {
            get
            {
                return _model.Time;
            }
            set
            {
                _model.Time = value;
                NotifyPropertyChanged();
            }
        }

        public string Description
        {
            get
            {
                return _model.Description;
            }
            set
            {
                _model.Description = value;
                NotifyPropertyChanged();
            }
        }

        public IProcessViewModel SubProcess { get; set; }

        public DetailEventViewModel(IEventModel model, EventViewModelCreator creator = null,
            EventModelAdapterCreator eventModelCreator = null)
        {
            _model = model;
            if(_model.SubProcess != null)
            {
                SubProcess = new ProcessViewModel(_model.SubProcess, creator, eventModelCreator);
            }
        }

        public void Update()
        {
            NotifyPropertyChanged("Id");
            NotifyPropertyChanged("Name");
            NotifyPropertyChanged("Time");
            NotifyPropertyChanged("Description");
        }

        
    }
}
