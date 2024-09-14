using Resulver;

namespace Api.Extensions;

public static class ResultExtensions
{
    public static object ToResponseTemplate(this Result result)
    {
        return new { message = result.Message };
    }

    public static object ToResponseTemplate<TContent>(this Result<TContent> result)
    {
        return new { message = result.Message, content = result.Content };
    }
}
