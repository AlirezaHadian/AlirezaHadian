using AlirezaHadian.Data;
using AlirezaHadian.Models;
using DeviceDetectorNET;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace AlirezaHadian.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext, UnitOfWork db)
        {
            if (httpContext.Session.GetString("UserInfoSaved")== null)
            {
                string userAgent = httpContext.Request.Headers["User-Agent"];
                string userIp = httpContext.Connection.RemoteIpAddress?.ToString();
                string referrer = httpContext.Request.Headers["Referer"];
                if (referrer == null)
                {
                    referrer = "Null until publish";
                }
                string operatingSystem = "Unknown";
                DateTime requestTime = DateTime.Now;
                string browserLanguage = httpContext.Request.Headers["Accept-Language"];

                if (userAgent.Contains("Windows"))
                {
                    operatingSystem = "Windows";
                }
                else if (userAgent.Contains("Macintosh"))
                {
                    operatingSystem = "Mac";
                }
                else if (userAgent.Contains("Linux"))
                {
                    operatingSystem = "Linux";
                }
                else if (userAgent.Contains("Android"))
                {
                    operatingSystem = "Android";

                }
                else if (userAgent.Contains("Iphone"))
                {
                    operatingSystem = "Iphone";
                }

                var dd = new DeviceDetector(userAgent);
                dd.Parse();

                string deviceType = dd.GetDeviceName(); // e.g., "Desktop", "Tablet", "Smartphone"
                string brand = dd.GetBrandName(); // e.g., "Apple", "Samsung"
                string model = dd.GetModel(); // e.g., "iPhone 12", "Galaxy S21"
                string deviceSpecifications = $"{deviceType} - {brand} {model}";

                UserData data = new UserData()
                {
                    BrowserLanguage = browserLanguage,
                    IPAddress = userIp,
                    UserAgent = userAgent,
                    Referrer = referrer,
                    OperatingSystem = operatingSystem,
                    RequestTime = requestTime,
                    DeviceSpecifications = deviceSpecifications
                };
                db.UserDataRepository.Insert(data);
                db.Save();

                httpContext.Session.SetString("UserInfoSaved", "true");
            }            

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
