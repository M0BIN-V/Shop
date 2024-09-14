namespace Api.Common;

public record ResponseTemplate(string Message);
public record ResponseTemplate<TContent>(string Message, TContent Content);