namespace Api.Abstractions;

public interface IEndpointBuilder
{
    void ConfigureEndpoint(IEndpointRouteBuilder builder);
}
