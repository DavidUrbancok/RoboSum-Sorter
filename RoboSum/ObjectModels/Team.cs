using System;

namespace RoboSum.ObjectModels
{
    /// <summary>
    /// Represents a team participating in RoboSum.
    /// </summary>
    public class Team
    {
        /// <summary>
        /// Team name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// School from which the team comes.
        /// </summary>
        public string School { get; set; }

        /// <summary>
        /// Home city of the team.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="Team"/>.
        /// </summary>
        /// <param name="name">Team name.</param>
        /// <param name="school">School from which the team comes.</param>
        /// <param name="city">Home city of the team.</param>
        public Team(string name, string school, string city)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            School = school ?? throw new ArgumentNullException(nameof(school));
            City = city ?? throw new ArgumentNullException(nameof(city));
        }
    }
}
