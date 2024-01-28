
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace ATM.BLL.Filters
{
    public class LogActivityFilter : IAsyncActionFilter
    {
        private readonly ILogger<LogActivityFilter> logger;

        public LogActivityFilter(ILogger<LogActivityFilter> logger)
        {
            this.logger = logger;
        }
      
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            logger.LogInformation($"the request went to controller {context.Controller} and action {context.ActionDescriptor} with arguments {JsonSerializer.Serialize(context.ActionArguments)} ");
            await next();
            logger.LogInformation($"the request went to controller {context.Controller} and action {context.ActionDescriptor} with arguments {JsonSerializer.Serialize(context.ActionArguments)} ");


        }
    }
}
