
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace ATM.BLL.Middlewares
{
    public class ProfileMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ProfileMiddleware> logger;

        public ProfileMiddleware(RequestDelegate next , ILogger<ProfileMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            await next(httpContext);
            stopwatch.Stop();
            logger.LogInformation($"Request {httpContext.Request.Path} took {stopwatch.ElapsedMilliseconds} ms to excute");
        }



    }
}
