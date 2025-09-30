namespace Phonebook.Domain.Results
{
   public abstract class Result
   {
      public bool IsSuccess { get; private set; }
      public string Message { get; private set; }

      protected Result(bool isSuccess, string message)
      {
         IsSuccess = isSuccess;
         Message = message;
      }
   }

   public class ResultData<T> : Result
   {
      public T? Data { get; set; }

      public ResultData(T? data, bool isSuccess = true, string message = "") : base(isSuccess, message)
      {
         Data = data;
      }

      public static ResultData<T> Success(T data, string message) => new ResultData<T>(data, true, message);

      public static ResultData<T> Failure(string message) => new ResultData<T>(default, false, message);

   }
}