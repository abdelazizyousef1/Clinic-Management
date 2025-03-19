using Microsoft.AspNetCore.Mvc;

namespace clinic.Middlewares
{
    public class CustomeMiddleware 
    {
        private RequestDelegate _next;

        public CustomeMiddleware(RequestDelegate next) { _next = next; }


        
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("THE REQUEST IS SHOWEN " + context.Request.Path);
            await _next(context);
            Console.WriteLine("Done");
        }

    }
}
