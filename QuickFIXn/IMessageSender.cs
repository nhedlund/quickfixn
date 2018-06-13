namespace QuickFix
{
    /// <summary>
    /// Sends FIX messages to connection targets.
    /// </summary>
    public interface IMessageSender
    {
        /// <summary>
        /// Sends a message to the session specified by the provider session ID.
        /// </summary>
        /// <param name="message">FIX message</param>
        /// <param name="sessionId">Target session ID</param>
        /// <returns>True if send was successful, false otherwise</returns>
        bool SendToTarget(Message message, SessionID sessionId);
    }
}