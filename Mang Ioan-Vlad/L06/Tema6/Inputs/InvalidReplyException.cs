using System;
using System.Collections.Generic;
using System.Text;

namespace Tema6.Inputs
{
    public class InvalidReplyException : Exception
    {
        public InvalidReplyException() {  }
        public InvalidReplyException(string reply):base($"Invalid text:{reply}") { }
    }
}
