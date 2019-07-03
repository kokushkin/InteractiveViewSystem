using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryExample.Models.NativeModels
{
    public class Delivery
    {
        public int Id { get; private set; }

        public DeliveryStatus Status { get; private set; }

        public string Title { get; private set; }

        public int? DeliveryMenId { get; private set; }

        public DateTime CreationTime { get; private set; }

        public DateTime ModificationTime { get; private set; }

        public DateTime ExpirationTime { get; private set; }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            Delivery delivery = obj as Delivery;
            if (delivery == null)
                return false;
            return delivery.Id == this.Id;
        }

    }
}
