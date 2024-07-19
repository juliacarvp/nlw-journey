﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Journey.Exception.ExceptionsBase
{
    public abstract class JourneyException : SystemException
    {
        // Construtor
        public JourneyException(string message) : base(message)
        {

        }

        // Fazendo com que todas as classes que herdam de "JourneyException"
        // vai precisar ter uma:

        public abstract HttpStatusCode GetStatusCode();
        public abstract IList<string> GetErrorsMessages();
    }
}
