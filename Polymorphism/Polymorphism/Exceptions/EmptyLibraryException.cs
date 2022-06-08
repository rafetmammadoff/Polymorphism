using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism.Exceptions
{
    public class EmptyLibraryException : Exception
    {
        public EmptyLibraryException(string message) : base(message)    
        {

        }
    }
}
