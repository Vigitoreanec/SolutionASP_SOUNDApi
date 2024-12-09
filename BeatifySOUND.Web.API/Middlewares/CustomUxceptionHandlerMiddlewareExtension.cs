namespace BeautifySOUND.Web.API.Middlewares;

public static class CustomUxceptionHandlerMiddlewareExtension
{
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder) =>
        builder.UseMiddleware<CustomUxceptionHandlerMiddleware>();
}
