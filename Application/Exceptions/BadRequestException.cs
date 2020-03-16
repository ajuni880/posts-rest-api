using System;
using System.Collections.Generic;
using System.Text;

namespace PostsAPI.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public List<string> Errors { get; private set; }

        public BadRequestException(List<string> errors)
            :base("Invalid data provided")
        {
            Errors = errors;
        }
    }
}
