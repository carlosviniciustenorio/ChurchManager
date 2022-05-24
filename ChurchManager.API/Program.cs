using ChurchManager.API;
using ChurchManager.API.Extensions;
using Microsoft.AspNetCore.Builder;
using Sentry;
using System;

using (SentrySdk.Init(o =>
{
    o.Dsn = "https://41816325e7714781b6ac62d168addcf0@o1053240.ingest.sentry.io/6305669";
    o.Debug = true;
    o.TracesSampleRate = 1.0;
}))
{
    // App code goes here. Dispose the SDK before exiting to flush events.
}

var builder = WebApplication.CreateBuilder(args)
    .UseStartup<Startup>();