using ApiKeyPersistence;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuthServiceApi.Common.Middlewares.ApiKeyMiddleware
{
    public class ApiKeyMiddleware : MiddlewareBase
    {
        private readonly ApiKeyDbContext _apiKeyDbContext;

        public ApiKeyMiddleware(
            RequestDelegate next,
            ApiKeyDbContext apiKeyDbContext) : base(next)
        {
            _apiKeyDbContext = apiKeyDbContext;
        }

        public override async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments(new PathString("/api")))
            {
                var hasValidApiKey = false;

                if (context.Request.Headers["Api-Key"].Count > 0)
                {
                    var apiKeys = await _apiKeyDbContext.ApiKeys.ToListAsync();
                    var requestApiKey = context.Request.Headers["Api-Key"].First();

                    if (apiKeys.Where(i => requestApiKey == i.KeyString).Any())
                    {
                        hasValidApiKey = true;
                    }
                }

                if (hasValidApiKey)
                {
                    await _next(context);
                }
                else
                {
                    //short circuit
                    context.Response.StatusCode = 401;
                }
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
