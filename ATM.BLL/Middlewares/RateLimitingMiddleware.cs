using Microsoft.AspNetCore.Http;

namespace ATM.BLL.Middlewares
{
    public class RateLimitingMiddleware
    {
        private readonly RequestDelegate next;
        private static int counter = 0;
        private static DateTime lastDateTime = DateTime.Now;
        public RateLimitingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            counter++;
            // the diffrence between new request date and the last request date grater than 10
            // difne spesific date 
            if (DateTime.Now.Subtract(lastDateTime).Seconds > 10)
            {
                // reset counter, rest lastdate and move request to next middleware
                counter = 1;
                lastDateTime = DateTime.Now;
                await next(httpContext);
            }
            else
                if(counter > 5)
            {
                lastDateTime = DateTime.Now;
                await httpContext.Response.WriteAsync("Rate Limiting Execeed ");
            }
            else
            {
                lastDateTime = DateTime.Now;
                await next(httpContext);
            }
        }



    }
}
