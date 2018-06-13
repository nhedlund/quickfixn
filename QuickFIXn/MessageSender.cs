namespace QuickFix
{
    public class MessageSender : IMessageSender
    {
        public bool SendToTarget(Message message, SessionID sessionId)
        {
            return Session.SendToTarget(message, sessionId);
        }
    }
}