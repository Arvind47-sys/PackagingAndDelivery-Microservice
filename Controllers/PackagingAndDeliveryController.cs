using Microsoft.AspNetCore.Mvc;
using PackagingAndDelivery_Microservice.Constants;

namespace PackagingAndDelivery_Microservice.Controllers
{
    /// <summary>
    /// Packaging and Delivery Controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PackagingAndDeliveryController : ControllerBase
    {
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

            if (componentType == PackagingAndDeliveryConstants.Accessory)
            {
                packagingAndDeliveryCharge =
                    (PackagingAndDeliveryConstants.AccessoryPackageCost + PackagingAndDeliveryConstants.ProtectiveSheathCost
                    + PackagingAndDeliveryConstants.AccessoryDeliveryCost) * count;

            }

            if (componentType == PackagingAndDeliveryConstants.Integral)
            {
                packagingAndDeliveryCharge =
                    (PackagingAndDeliveryConstants.IntegralPackageCost + PackagingAndDeliveryConstants.ProtectiveSheathCost
                    + PackagingAndDeliveryConstants.IntegralDeliveryCost) * count;
            }

            return packagingAndDeliveryCharge;
        }
    }
}
