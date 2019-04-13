using System;

namespace Lab3.Exceptions
{
    internal class Email : Exception
    {
        public Email(string val)
            : base(val) { }
    }
}