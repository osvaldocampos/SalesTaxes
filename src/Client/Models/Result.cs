﻿namespace SalesTaxes.Models
{
    public class Result<T>
    {
        public T Value { get; private set; }
        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }

        private Result(T value, bool isSucces, string message = null)
        {
            Value = value;
            IsSuccess = isSucces;
            Message = message;
        }

        public static Result<T> Ok(T value)
        {
            return new Result<T>(value, true);
        }

        public static Result<T> Fail(string message)
        {
            return new Result<T>(default(T), false, message);
        }
    }
}

