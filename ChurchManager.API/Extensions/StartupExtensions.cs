﻿using Microsoft.AspNetCore.Builder;
using System;

namespace ChurchManager.API.Extensions
{
    public static class StartupExtensions
    {
        public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder WebAppBuilder) where TStartup : IStartup
        {
            var startup = Activator.CreateInstance(typeof(TStartup), WebAppBuilder.Configuration) as IStartup;

            if (startup == null)
                throw new ArgumentException("Classe Startup.cs inválida");

            startup.ConfigureServices(WebAppBuilder.Services);

            var app = WebAppBuilder.Build();
            startup.Configure(app, app.Environment);
            app.Run();

            return WebAppBuilder;
        }
    }
}
