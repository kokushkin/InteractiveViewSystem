using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryExample.Models.NativeModels
{
    public class DeliveryMen
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public virtual List<Delivery> Deliveries { get; set; }

        public void Update()
        {
            var updatedDeliveryMen = ServiceWrap.GetDeliveryMens()
                .Where(dlm => dlm.Id == Id).FirstOrDefault();
            Name = updatedDeliveryMen.Name;
            Location = updatedDeliveryMen.Location;
            Deliveries = updatedDeliveryMen.Deliveries;
        }

        public void Save()
        {
            var takenDeliveries = ServiceWrap.GetDeliveryMens()
                .Where(dlm => dlm.Id == Id)
                .FirstOrDefault()
                .Deliveries;

            var nwDeliveries = Deliveries.Except(takenDeliveries).ToList();
            foreach(var deliv in nwDeliveries)
            {
                ServiceWrap.TakeDelivery(Id, deliv.Id);
            }
        }
    }
}
