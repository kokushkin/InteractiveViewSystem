using DeliveryExample.DTObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryExample.ServiceContracts
{
    [ServiceContract]
    public interface IDeliveryService
    {

        [OperationContract]
        [ServiceKnownType(typeof(Delivery))]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Delivery[] GetAvailableDeliveries();

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool TakeDelivery(int deliveryMenId, int deliveryId);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        DeliveryMen[] GetDeliveryMens();
    }
}
