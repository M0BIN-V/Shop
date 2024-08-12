using Api.Config;
using Api.Config.Services;

WebApplication
    .CreateBuilder(args)
    .AddServices()
    .Build()
    .ConfigurePipeLine()
    .Run();