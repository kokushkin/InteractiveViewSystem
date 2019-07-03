using InteractiveViewSystem.BaseCreators.SepareteCreators;
using InteractiveViewSystem.BaseViewModels;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents;
using InteractiveViewSystem.GeneralizedCreaters.ProcessesAndEvents.SepareteCreators;
using InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InteractiveViewSystem.GeneralizedViewModels.ProcessesAndEvents
{
    public class ProcessViewModel : Notifier, IProcessViewModel
    {
        IProcessModel _model;

        public long Id
        {
            get
            {
                return _model.Id;
            }
            set
            {
                _model.Id = value;
                NotifyPropertyChanged("Id");
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
                NotifyPropertyChanged("Name");
            }
        }

        public DateTime TimeStart
        {
            get
            {
                return _model.TimeStart;
            }
            set
            {
                _model.TimeStart = value;
                NotifyPropertyChanged("TimeStart");
            }
        }

        public DateTime TimeEnd
        {
            get
            {
                return _model.TimeEnd;
            }
            set
            {
                _model.TimeEnd = value;
                NotifyPropertyChanged("TimeEnd");
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
                NotifyPropertyChanged("Description");
            }
        }

        IListViewModel<IEventModel, IEventViewModel, IDetailEventViewModel> events;
        public IListViewModel<IEventModel, IEventViewModel, IDetailEventViewModel> Events
        {
            get
            {
                return events;
            }
            set
            {
                events = value;
                NotifyPropertyChanged("Events");
            }
        }

        public ProcessViewModel(IProcessModel model, EventViewModelCreator creator,
            EventModelAdapterCreator eventModelCreator)
        {
            _model = model;
            Events = new ListViewModel<IEventModel, IEventViewModel, IDetailEventViewModel>(_model, creator, eventModelCreator);
        }

        public void Update()
        {
            NotifyPropertyChanged("Id");
            NotifyPropertyChanged("Name");
            NotifyPropertyChanged("TimeStart");
            NotifyPropertyChanged("TimeEnd");
            NotifyPropertyChanged("Description");
            NotifyPropertyChanged("Events");
        }



    }
}
