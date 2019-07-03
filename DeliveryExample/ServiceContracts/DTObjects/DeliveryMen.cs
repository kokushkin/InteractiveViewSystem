using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DeliveryExample.DTObjects
{
    [DataContract]
    public class DeliveryMen
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Location { get; set; }

        [DataMember]
        public virtual List<Delivery> Deliveries { get; set; }
    }
}