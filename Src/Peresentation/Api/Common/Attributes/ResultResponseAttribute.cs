namespace Api.Common.Attributes;

public class ResultResponseAttribute(int statusCode) : ProducesResponseTypeAttribute<ResponseTemplate>(statusCode);
public class ResultResponseAttribute<TContent>(int statusCode) : ProducesResponseTypeAttribute<ResponseTemplate<TContent>>(statusCode);
