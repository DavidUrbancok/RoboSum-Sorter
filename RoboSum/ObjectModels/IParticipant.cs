namespace RoboSum.ObjectModels
{
    /// <summary>
    /// 
    /// </summary>
    public interface IParticipant
    {
        /// <summary>
        /// 
        /// </summary>
        string LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string Firstname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string GetParticipantName();
    }
}
