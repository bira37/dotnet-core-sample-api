using System;

namespace Commander.Error
{
  public class BaseException : Exception
  {

    public int StatusCode { get; }
    protected BaseException(string message, int code) : base(message)
    {
      StatusCode = code;
    }
  }

  public class NotFoundException : BaseException
  {
    public NotFoundException(string message) : base(message, 404) { }
  }
}
