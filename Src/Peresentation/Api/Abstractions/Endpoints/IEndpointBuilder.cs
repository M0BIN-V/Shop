namespace Api.Abstractions.Endpoints;

public interface IEndpointBuilder
{
    void ConfigureEndpoint(IEndpointRouteBuilder builder);
}
