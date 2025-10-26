using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionVisits.Application.DTo
{
    public class ApiResponse<T> : BaseResponse
    {

        public T? Result { get; set; }
        public ApiResponse()
        {
            IsSuccess = true;
            StatusCode = !IsSuccess ? 400 : 200;

        }
        public ApiResponse(T? data)
        {
            Result = data;
            IsSuccess = true;
            StatusCode = !IsSuccess ? 400 : 200;
        }
        public ApiResponse(T? data, int count)
        {
            Result = data;
            IsSuccess = true;
            StatusCode = !IsSuccess ? 400 : 200;
            Count = count;
        }
        public ApiResponse(Exception error) : this(error, error.Message)
        {
            SetException(error);
        }

        public ApiResponse(Exception error, string message)
        {
            IsSuccess = error == null;
            Message = message;
            Error = error;
        }
        public ApiResponse(T data, string message)
        {
            Result = data;
            IsSuccess = true;
            Message = message;
            StatusCode = 200;
        }
        public ApiResponse(T data, List<string> ErrorMessage, string message)
        {
            Result = data;
            IsSuccess = true;
            ErrorMessages = ErrorMessage;
            Message = message;
            StatusCode = 200;
        }

        public ApiResponse(List<string> ErrorMessage, string message)
        {

            IsSuccess = false;
            ErrorMessages = ErrorMessage;
            Message = message;
            StatusCode = 400;
        }

        public ApiResponse<T> SetException(Exception ex)
        {
            return new ApiResponse<T>
            {
                Error = ex,
                ErrorMessages = new List<string> { ex.Message },
                Message = ex.Message,
                IsSuccess = false
            }; ;
        }



        //[JsonIgnore>]

        public static implicit operator ApiResponse<T>(Type v)
        {
            throw new NotImplementedException();
        }
    }
}
