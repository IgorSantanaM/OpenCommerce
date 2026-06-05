using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCommerce.Domain.Core.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException() { }

        public DomainException(string message) : base(message) { }
    }
}
