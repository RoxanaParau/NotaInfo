using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotaInfo.BLL
{
    public class DuplicateAdministratorException : Exception
    {
        public DuplicateAdministratorException(string message)
            : base(message)
        {
        }
    }
}