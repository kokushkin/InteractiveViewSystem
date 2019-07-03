using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveViewSystem.GeneralizedModels.ProcessesAndEvents
{
    public class EventModel : IEventModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime Time { get; set; }

        public string Description { get; set; }

        public IProcessModel SubProcess { get; set; }

        public EventModel(long id, string name, DateTime time, string description, IProcessModel subProcess = null)
        {
            Id = id;
            Name = name;
            Time = time;
            Description = description;
            SubProcess = subProcess;
        }

        public void Save(IEventModel saveDataModel)
        {
            Id = saveDataModel.Id;
            Name = saveDataModel.Name;
            Time = saveDataModel.Time;
            Description = saveDataModel.Description;
            SubProcess = saveDataModel.SubProcess;
        }

        public void Update()
        {
            return;
        }

        public override int GetHashCode()
        {
            return (int)Id;
        }

        public override bool Equals(object obj)
        {
            var eventObj = obj as EventModel;
            if (eventObj == null)
                return false;
            return eventObj.Id == Id;
        }
    }
}
