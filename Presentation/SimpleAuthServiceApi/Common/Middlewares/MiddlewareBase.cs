using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAuthServiceApi.Common.Middlewares
{
    public abstract class MiddlewareBase
    {
        protected readonly RequestDelegate _next;

        public MiddlewareBase(RequestDelegate next)
        {
            _next = next;
        }

        public abstract Task InvokeAsync(HttpContext context);
    }
}
