using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAuthServiceApi.Common.Middlewares.ApiKeyMiddleware
{
    public static class ApiKeyMiddlewareExtensions
    {
        public static void UseApiKey(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<ApiKeyMiddleware>();
        }
    }
}
