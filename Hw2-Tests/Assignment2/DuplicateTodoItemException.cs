using System;
using System.Collections.Generic;
using System.Text;

namespace Hw2_Tests.Assignment2
{
    public class DuplicateTodoItemException : Exception
    {
        public DuplicateTodoItemException()
        {
        }

        public DuplicateTodoItemException(string message)
            : base(message)
        {
        }

    }
}
