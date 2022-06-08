using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism.Exceptions
{
    internal class BookNotFoundException : Exception
    {
        public BookNotFoundException(string msg) : base(msg)
        {
                
        }
    }
}
