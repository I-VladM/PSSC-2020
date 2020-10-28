using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.PostQuestionWorkflow
{
    [Serializable]
    public class InvalidVoteException : Exception
    {
        public InvalidVoteException() { }
        public InvalidVoteException(int vote) : base ($"scorul \"{vote}\"obtinut din voturi trebuie sa corespunda cu suma tuturor voturilor individualei") { }
    }
}
