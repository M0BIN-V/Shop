using Api;

WebApplication
    .CreateBuilder(args)
    .AddServices()
    .Build()
    .ConfigurePipeLine()
    .Run();