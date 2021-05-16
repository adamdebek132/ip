using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;


namespace ip.Utils
{
    public class CustomAsyncPageFilter : IAsyncPageFilter
    {
        private readonly IConfiguration _config;
        public string ClientIPAddr { get; private set; }

        private readonly HttpContext con;

        public CustomAsyncPageFilter(IConfiguration config)
        {
            _config = config;
        }

        public Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
        {
            ClientIPAddr = con.Connection.RemoteIpAddress.ToString();
            ViewData["IP"] = ClientIPAddr;
            return Task.CompletedTask;
        }

        public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context,
                                                      PageHandlerExecutionDelegate next)
        {
            // Do post work.
            await next.Invoke();
        }
    }
}
