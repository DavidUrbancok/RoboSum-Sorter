using System;

namespace RoboSum.ObjectModels
{
    /// <summary>
    /// 
    /// </summary>
    public class Coach : IParticipant
    {
        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lastName"></param>
        /// <param name="firstName"></param>
        public Coach(string lastName, string firstName)
        {
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Firstname = firstName ?? throw new ArgumentNullException(nameof(firstName));
        }

        /// <summary>
        /// 
        /// </summary>
        public string GetParticipantName() => $"{Firstname} {LastName}";
    }
}
