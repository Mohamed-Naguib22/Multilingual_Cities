namespace Multilingual.Extensions
{
    public class LanguageMiddleware
    {
        private readonly RequestDelegate _next;
        public LanguageMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Check if the Accept-Language header is present
            if (context.Request.Headers.TryGetValue("Accept-Language", out var headerValues))
            {
                var language = headerValues.FirstOrDefault();
                // Set the language preference in the request context
                context.Items["Language"] = language;
            }

            await _next(context);
        }
    }

    public static class LanguageMiddlewareExtension
    {
        /// <summary>
        /// Adds middleware for Get The Language from Header.
        /// </summary>
        /// /// <param name="context">The <see cref="HttpContext"/> for the request.</param>
        /// <returns>A task that represents the completion of request processing.</returns>
        /// 
        public static IApplicationBuilder UseLanguageMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LanguageMiddleware>();
        }
    }
}
