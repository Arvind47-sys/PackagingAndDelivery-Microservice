using log4net;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackagingAndDelivery_Microservice.Logger
{
    /// <summary>
    /// Log filter to catch all the possible exceptions in the application.
    /// </summary>
    public class LogFilterAttribute : ExceptionFilterAttribute
    {
        ILog logger;

        public LogFilterAttribute()
        {
            logger = LogManager.GetLogger(typeof(LogFilterAttribute));
        }

        public override void OnException(ExceptionContext context)
        {
            logger.Error(context.Exception.Message + " - " + context.Exception.StackTrace);
        }
    }
}
