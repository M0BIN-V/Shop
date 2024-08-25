
namespace Application.Behaviors;

internal static class ResultGenerator<TResult> where TResult : Result
{
    public static TResult MakeResult(params ResultError[] errors)
    {
        var resultType = typeof(TResult);

        if (resultType == typeof(Result))
        {
            return (new Result(errors) as TResult)!;
        }
        else if (resultType.IsGenericType && resultType.GetGenericTypeDefinition() == typeof(Result<>))
        {
            var genericParameterType = resultType.GetGenericArguments();

            var genericResultType = resultType.GetGenericTypeDefinition()
                .MakeGenericType(genericParameterType);

            var instance = Activator.CreateInstance(genericResultType, errors);

            return (instance as TResult)!;
        }

        throw new Exception($"Invalid result type {resultType.Name}");
    }
}