using SaviaHomeTest.API.Middlewares;

namespace SaviaHomeTest.API.Extensions
{
    /// <summary>
    /// Adds custom middlewares
    /// </summary>
    /// <param name="services"></param>
    public static class MiddlewareExtensions
    {
        public static void UseMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
