using System;
using System.Collections.Generic;
using System.Text;

namespace DAO_EFCORE.Business.Exceptions
{
    public class ChecklistNotFoundException:ApplicationException
    {
        public ChecklistNotFoundException() { }
        public ChecklistNotFoundException(string message) : base(message)
        {

        }

    }
}
