using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MovieShopMVC.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MovieShopExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MovieShopExceptionMiddleware> _logger;

        public MovieShopExceptionMiddleware(RequestDelegate next, ILogger<MovieShopExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)//统一处理异常，之后可以创建一个错误日志文件，把异常信息写到文件中
            {
                var exceptionDetails=new
                 {
                    Message=ex.Message,
                    StackTrace=ex.StackTrace,
                    ExceptionDateTime=DateTime.UtcNow,
                    ExceptionType=ex.GetType(),
                    Path=httpContext.Request.Path,
                    HttpMethod=httpContext.Request.Method,
                    user=httpContext.User.Identity.IsAuthenticated? httpContext.User.Identity.Name:null
                    //Email,userId, QueryString, Headers,etc
                };
            }
            httpContext.Response.Redirect("/Home/Error");
            return;
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MovieShopExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseMovieShopExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MovieShopExceptionMiddleware>();
        }
    }
}
