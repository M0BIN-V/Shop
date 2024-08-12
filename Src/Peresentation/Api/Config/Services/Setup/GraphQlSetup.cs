using Api.GraphQl.Mutations;
using Api.GraphQl.Queries;
using HotChocolate.Execution.Configuration;
using System.Reflection;

namespace Api.Config.Services.Setup;

public static class GraphQlSetupExtension
{
    public static IServiceCollection AddGraphQlSetup(this IServiceCollection services)
    {
        services

            .AddGraphQLServer()

            .AddTypesFromAssembly(Assembly.GetExecutingAssembly())

            .AddMutationType<RootMutation>()

            .AddQueryType<RootQuery>();

        return services;
    }

    static IRequestExecutorBuilder AddTypesFromAssembly(this IRequestExecutorBuilder builder, Assembly assembly)
    {
        var types = assembly
            .GetTypes()
            .Where(t => t.IsSubclassOf(typeof(ObjectType)))
            .ToList();

        var scalarTypes = assembly
            .GetTypes()
            .Where(t => t.IsSubclassOf(typeof(ScalarType)) && !t.IsAbstract)
            .ToList();

        types.AddRange(scalarTypes);

        foreach (var type in types)
        {
            builder.AddType(type);
        }

        return builder;
    }
}
