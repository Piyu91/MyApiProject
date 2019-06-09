using System;
using System.Collections.Generic;
using System.Text;

namespace DAO_EFCORE.Business.Exceptions
{
    public class DuplicatesFoundException: ApplicationException
    {
        public DuplicatesFoundException() { }
        public DuplicatesFoundException(string message) : base(message)
        {

        }
    }
}

