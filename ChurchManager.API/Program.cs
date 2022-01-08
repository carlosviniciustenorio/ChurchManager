using ChurchManager.API;
using ChurchManager.API.Extensions;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args)
    .UseStartup<Startup>();