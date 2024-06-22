#pragma warning disable 8625,8603
namespace Beey.DataExchangeModel;

public class Error(string message, object data = null)
{
    public string Message { get; } = message;
    public object Data { get; } = data;
}
