using System;

namespace Lab3.Exceptions
{
    internal class Birth : Exception
    {
        public Birth(string val)
            : base(val) { }
    }
}