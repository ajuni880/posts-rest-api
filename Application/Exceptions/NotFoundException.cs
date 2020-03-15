using System;
using System.Collections.Generic;
using System.Text;

namespace PostsAPI.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entity, object value)
            :base($"Resource {entity} not found with id {value}")
        {

        }
    }
}
