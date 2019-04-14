using System.Collections.Generic;

namespace RoboSum.ObjectModels
{
    /// <summary>
    /// Temporary memory storage for data.
    /// </summary>
    public class Storage
    {
        /// <summary>
        /// List of participating teams.
        /// </summary>
        public List<Team> Teams { get; set; }

        /// <summary>
        /// Creates a new instance of <see cref="Storage"/>.
        /// </summary>
        public Storage()
        {
            Teams = new List<Team>();
        }

        /// <summary>
        /// Saves the <paramref name="team"/> to the temporary storage.
        /// </summary>
        /// <param name="team">Instance of the team to save.</param>
        public void Save(Team team)
        {
            if (!Teams.Contains(team))
            {
                Teams.Add(team);
            }
        }
    }
}
