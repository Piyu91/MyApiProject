using System;
using System.Collections.Generic;
using System.Text;

namespace DAO_EFCORE.Business.Exceptions
{
    public class LabelNotFoundException:ApplicationException
    {
        public LabelNotFoundException() { }
        public LabelNotFoundException(string message) : base(message)
        {

        }
    }
}
