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
        /// List of partaking competitors.
        /// </summary>
        public List<Competitor> Competitors { get; set; }

        /// <summary>
        /// List of participating schools.
        /// </summary>
        public List<School> Schools { get; set; }

        /// <summary>
        /// List of team coaches.
        /// </summary>
        public List<Coach> Coaches { get; set; }

        /// <summary>
        /// Creates a new instance of <see cref="Storage"/>.
        /// </summary>
        public Storage()
        {
            Teams = new List<Team>();
            Competitors = new List<Competitor>();
            Schools = new List<School>();
            Coaches = new List<Coach>();
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

            if (!Competitors.Contains(team.FirstCompetitor))
            {
                Competitors.Add(team.FirstCompetitor);
            }

            if (!Competitors.Contains(team.SecondCompetitor))
            {
                Competitors.Add(team.SecondCompetitor);
            }

            if (!Schools.Contains(team.School))
            {
                Schools.Add(team.School);
            }

            if (!Coaches.Contains(team.Coach))
            {
                Coaches.Add(team.Coach);
            }
        }
    }
}
