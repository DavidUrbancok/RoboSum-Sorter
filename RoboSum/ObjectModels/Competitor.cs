using System;

namespace RoboSum.ObjectModels
{
    /// <summary>
    /// 
    /// </summary>
    public class Competitor : IParticipant
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
        public int Grade { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lastName"></param>
        /// <param name="firstname"></param>
        /// <param name="grade"></param>
        public Competitor(string lastName, string firstname, int grade)
        {
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Firstname = firstname ?? throw new ArgumentNullException(nameof(firstname));
            Grade = grade;
        }

        /// <summary>
        /// 
        /// </summary>
        public string GetParticipantName() => $"{Firstname} {LastName}";
    }
}
