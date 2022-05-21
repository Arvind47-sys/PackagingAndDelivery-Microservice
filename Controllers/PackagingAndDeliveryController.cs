using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PackagingAndDelivery_Microservice.Constants;
using PackagingAndDelivery_Microservice.Models;
using System;

namespace PackagingAndDelivery_Microservice.Controllers
{
    /// <summary>
    /// Packaging and Delivery Controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PackagingAndDeliveryController : ControllerBase
    {
        private readonly IOptions<PackagingAndDeliveryCost> _packagingAndDeliveryCost;

        public PackagingAndDeliveryController(IOptions<PackagingAndDeliveryCost> packagingAndDeliveryCost)
        {
            _packagingAndDeliveryCost = packagingAndDeliveryCost;
        }
        /// <summary>
        /// Gets Packaging and Delivery Cost based on Component type and Count
        /// </summary>
        /// <param name="componentType"></param>
        /// <param name="count"></param>
        /// <returns>Packaging And Delivery Cost</returns>
        [HttpGet("GetPackagingDeliveryCharge")]
        public ActionResult<double> GetPackagingDeliveryCharge(string componentType, int count)
        {
            double packagingAndDeliveryCharge = 0;

            var packagingAndDeliveryChargeDetails = _packagingAndDeliveryCost.Value;

            if (componentType == PackagingAndDeliveryConstants.Accessory)
            {
                packagingAndDeliveryCharge =
                    (Convert.ToDouble(packagingAndDeliveryChargeDetails.AccessoryPackageCost)
                    + Convert.ToDouble(packagingAndDeliveryChargeDetails.ProtectiveSheathCost)
                    + Convert.ToDouble(packagingAndDeliveryChargeDetails.AccessoryDeliveryCost)) * count;

            }

            if (componentType == PackagingAndDeliveryConstants.Integral)
            {
                packagingAndDeliveryCharge =
                    (Convert.ToDouble(packagingAndDeliveryChargeDetails.IntegralPackageCost)
                    + Convert.ToDouble(packagingAndDeliveryChargeDetails.ProtectiveSheathCost)
                    + Convert.ToDouble(packagingAndDeliveryChargeDetails.IntegralDeliveryCost)) * count;
            }

            return packagingAndDeliveryCharge;
        }
    }
}
