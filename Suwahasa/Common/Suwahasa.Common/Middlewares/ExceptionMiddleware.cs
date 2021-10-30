using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

using Suwahasa.Common.Models;

namespace Suwahasa.Common.Middlewares
{
    public class ExceptionMiddleware
    {
        /// <summary>
        /// The next
        /// </summary>
        private readonly RequestDelegate next;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<ExceptionMiddleware> logger;

		/// <summary>
		/// Initializes a new instance of the <see cref="ExceptionMiddleware"/> class.
		/// </summary>
		/// <param name="next">The next.</param>
		/// <param name="logger">The logger.</param>
		public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
		{
			this.logger = logger;
			this.next = next;
		}

		/// <summary>
		/// Invokes the asynchronous.
		/// </summary>
		/// <param name="httpContext">The HTTP context.</param>
		public async Task InvokeAsync(HttpContext httpContext)
		{
			try
			{
				await next(httpContext);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(httpContext, ex);
			}
		}

		/// <summary>
		/// Handles the exception asynchronous.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <param name="ex">The ex.</param>
		private async Task HandleExceptionAsync(HttpContext context, Exception ex)
		{
			var statusCode = (int)HttpStatusCode.InternalServerError;
			var message = ex.Message;
			var description = "An error occured in downstream service. Please contact your system administrator.";

			var response = context.Response;
			response.ContentType = "application/json";
			response.StatusCode = statusCode;

			logger.LogError($"{ex}");

			var errorResponse = new ErrorResponse();
			errorResponse.Errors.Add(new ErrorDto()
			{
				Message = message,
				Description = description
			});

			await response.WriteAsync(JsonConvert.SerializeObject(errorResponse,
			  new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
		}
	}
}
