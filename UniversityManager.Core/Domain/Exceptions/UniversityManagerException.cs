using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityManager.Core.Domain.Exceptions
{
    public abstract class UniversityManagerException : Exception
    {
        public string Code { get; }

        protected UniversityManagerException()
        {
        }

        protected UniversityManagerException(string code)
        {
            Code = code;
        }

        protected UniversityManagerException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        protected UniversityManagerException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        protected UniversityManagerException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        protected UniversityManagerException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
