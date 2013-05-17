using RefactoredBattleField.Model;
using System;
using System.Runtime.Serialization;

namespace RefactoredBattleField.Exceptions
{
    [Serializable]
    class AlreadyExplodedBombException : Exception
    {
        public AlreadyExplodedBombException()
            : this("Trying to blow up an already expoded bomb.")
        {
        }

        public AlreadyExplodedBombException(Bomb bomb)
            : this(string.Format("Trying to blow up an already expoded bomb on coordinates ({0}, {1}).", bomb.Position.Row, bomb.Position.Col))
        {
        }

        public AlreadyExplodedBombException(string message)
            : base(message)
        {
        }

        public AlreadyExplodedBombException(Bomb bomb, Exception inner)
            : this(string.Format("Trying to blow up an already expoded bomb on coordinates ({0}, {1}).", bomb.Position.Row, bomb.Position.Col), inner)
        {
        }

        public AlreadyExplodedBombException(string message, Exception inner)
            : base(message, inner)
        {
        }

        // This constructor is needed for serialization.
        protected AlreadyExplodedBombException(SerializationInfo info, StreamingContext context)
            : base (info, context)
        {
        }
    }
}
