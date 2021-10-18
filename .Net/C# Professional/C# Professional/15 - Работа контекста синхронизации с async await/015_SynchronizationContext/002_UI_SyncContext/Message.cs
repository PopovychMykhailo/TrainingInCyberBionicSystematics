using System.Threading;

namespace UI_SyncContext
{
    internal class Message
    {
        public SendOrPostCallback Callback { get; set; }
        public object State { get; set; }

        public Message() { }

        public Message(SendOrPostCallback callback, object state)
        {
            Callback = callback;
            State = state;
        }
    }
}
