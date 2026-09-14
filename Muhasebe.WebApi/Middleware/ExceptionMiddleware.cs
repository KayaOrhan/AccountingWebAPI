using FluentValidation;

namespace Muhasebe.WebApi.Middleware
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next(context);
            }
			catch (Exception ex)
			{
                await HandleExceptionAsync(context, ex);
			}
        }

        private  Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = ex switch
            {
                InvalidOperationException => StatusCodes.Status400BadRequest,
                KeyNotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            if(ex.GetType() == typeof(ValidationException))
            {
                return context.Response.WriteAsync(new ValidationErrorDetails
                {
                    Errors = ((ValidationException)ex).Errors.Select(e => e.PropertyName),
                    StatusCode = context.Response.StatusCode
                }.ToString());
            }

            var errorResult = new ErrorResult
            {
                Message = ex.Message,
                StatusCode = context.Response.StatusCode
            };
            return context.Response.WriteAsync(errorResult.ToString());
        }
    }
}
