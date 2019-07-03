using AutoMapper;
using DeliveryExample.Models.NativeModels;
using DeliveryExample.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryExample
{
    public static class ServiceWrap
    {
        static IMapper dtoMapper;

        static ServiceWrap()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DTObjects.DeliveryMen, DeliveryMen>();
                cfg.CreateMap<DTObjects.Delivery, Delivery>();
            });
            config.AssertConfigurationIsValid();

            dtoMapper = config.CreateMapper();
        }

        public static List<Delivery> GetAvailableDeliveries()
        {
            var factory = new System.ServiceModel.ChannelFactory<IDeliveryService>("DeliveryService");
            try
            {
                var channel = factory.CreateChannel();
                var dtoDeliveries = channel.GetAvailableDeliveries();
                factory.Close();

                if (dtoDeliveries == null)
                    return new List<Delivery>();

                var deliveries = dtoMapper.Map<DTObjects.Delivery[], Delivery[]>(dtoDeliveries).ToList();

                return deliveries;
            }
            catch (Exception ee)
            {
                if (factory != null) factory.Abort();
                return new List<Delivery>();
            }
        }

        public static bool TakeDelivery(int deliveryMenId, int deliveryId)
        {
            var factory = new System.ServiceModel.ChannelFactory<IDeliveryService>("DeliveryService");
            try
            {
                var channel = factory.CreateChannel();
                var result = channel.TakeDelivery(deliveryMenId, deliveryId);
                factory.Close();

                return result;
            }
            catch (Exception ee)
            {
                if (factory != null) factory.Abort();
                return false;
            }
        }

        public static List<DeliveryMen> GetDeliveryMens()
        {
            var factory = new System.ServiceModel.ChannelFactory<IDeliveryService>("DeliveryService");
            try
            {
                var channel = factory.CreateChannel();
                var dtoDeliveryMens = channel.GetDeliveryMens();
                factory.Close();

                if (dtoDeliveryMens == null)
                    return new List<DeliveryMen>();

                var deliveryMens = dtoMapper.Map<DTObjects.DeliveryMen[], DeliveryMen[]>(dtoDeliveryMens).ToList();

                return deliveryMens;
            }
            catch (Exception ee)
            {
                if (factory != null) factory.Abort();
                return new List<DeliveryMen>();
            }
        }

    }
}
