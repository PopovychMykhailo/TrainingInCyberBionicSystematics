using System;

namespace Race
{
    class EngineIsDeadException : Exception
    {
        public EngineIsDeadException() { }
        public EngineIsDeadException(string message) : base(message) { }
        public EngineIsDeadException(string message, Exception inner) : base(message, inner) { }
    }
}
