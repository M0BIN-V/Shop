using Api.Config;

WebApplication
    .CreateBuilder(args)
    .AddServices()
    .Build()
    .ConfigurePipeLine()
    .Run();