using Api.Config.DependencyInjection;
using Api.Config.PipeLine;

WebApplication
    .CreateBuilder(args)
    .AddServices()
    .Build()
    .ConfigurePipeLine()
    .Run();