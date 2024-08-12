using Domain.Errors;
using Resulver;
using System.Collections.ObjectModel;

namespace Api.Mappers;

public static class ErrorMapper
{
    public static Error ToGraphQlError(this ResultError resultError)
    {
        if (resultError is ValidationError)
        {
            var dictionary = new Dictionary<string, object?>
            {
                { "fieldName", resultError.Title }
            };

            var extensions = new ReadOnlyDictionary<string, object?>(dictionary);

            return new Error(resultError.Message, code: resultError.Id, extensions: extensions);
        }
        else
        {
            return new Error(resultError.Message, code: resultError.Id);
        }
    }

    public static List<Error> ToGraphQlErrors(this List<ResultError> resultError)
    {
        var errors = new List<Error>();

        foreach (var error in resultError)
        {
            errors.Add(error.ToGraphQlError());
        }

        return errors;
    }
}
