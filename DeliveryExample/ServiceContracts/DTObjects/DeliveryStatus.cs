using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryExample.DTObjects
{
    [DataContract]
    public enum DeliveryStatus
    {
        [EnumMember]
        Unknown = 0,
        [EnumMember]
        Available = 1,
        [EnumMember]
        Expired = 2,
        [EnumMember]
        Taken = 3
    }
}
