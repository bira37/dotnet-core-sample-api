using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;

namespace Commander.Error
{
  public class ExceptionHandlerMiddleware : IMiddleware
  {
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
      try
      {
        await next(context);
      }
      catch (BaseException ex)
      {
        await HandleExceptionAsync(context, ex);
      }
    }

    private static Task HandleExceptionAsync(HttpContext context, BaseException exception)
    {
      context.Response.ContentType = "application/json";
      context.Response.StatusCode = exception.StatusCode;

      var json = new
      {
        context.Response.StatusCode,
        Message = exception.Message,
      };

      return context.Response.WriteAsync(JsonConvert.SerializeObject(json));
    }
  }
}