using OnionArchitecture.Utils.Enums;

namespace OnionArchitecture.Utils;

public class Result<T>
{
	public T Data { get; set; }
	public string Message { get; set; }
	public bool IsSuccess { get; set; }
	public EnumStatusCode StatusCode { get; set; }

}
