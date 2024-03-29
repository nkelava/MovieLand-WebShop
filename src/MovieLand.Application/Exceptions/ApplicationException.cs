﻿using System;


namespace MovieLand.Application.Exceptions
{
    public class ApplicationException : Exception
    {
        internal ApplicationException(string message)
            : base(message) { }


        internal ApplicationException(string message, Exception exception)
            : base(message, exception) { }
    }
}
