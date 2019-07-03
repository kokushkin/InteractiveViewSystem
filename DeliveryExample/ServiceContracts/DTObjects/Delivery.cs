using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryExample.DTObjects
{
    [DataContract]
    public class Delivery
    {
        [DataMember]
        public int Id { get; private set; }

        [DataMember]
        public DeliveryStatus Status { get; private set; }

        [DataMember]
        public string Title { get; private set; }

        [DataMember]
        public int? DeliveryMenId { get; private set; }

        [DataMember]
        public DateTime CreationTime { get; private set; }

        [DataMember]
        public DateTime ModificationTime { get; private set; }

        [DataMember]
        public DateTime ExpirationTime { get; private set; }
    }
}
