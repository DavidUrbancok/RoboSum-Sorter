using System;
using System.Net.Mail;

namespace RoboSum.ObjectModels
{
    /// <summary>
    /// 
    /// </summary>
    public class Team
    {
        /// <summary>
        /// Team name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Team email.
        /// </summary>
        public MailAddress Email { get; set; }

        /// <summary>
        /// Team's first competitor.
        /// </summary>
        public Competitor FirstCompetitor { get; set; }

        /// <summary>
        /// Team's second competitor.
        /// </summary>
        public Competitor SecondCompetitor { get; set; }

        /// <summary>
        /// Team coach.
        /// </summary>
        public Coach Coach { get; set; }

        /// <summary>
        /// School from which the team comes.
        /// </summary>
        public School School { get; set; }

        /// <summary>
        /// Creates a new instance of <see cref="Team"/>.
        /// </summary>
        /// <param name="name">Team name.</param>
        /// <param name="email">Team email.</param>
        /// <param name="firstCompetitor">Team's first competitor.</param>
        /// <param name="secondCompetitor">Team's second competitor.</param>
        /// <param name="coach">Team's coach.</param>
        /// <param name="school">School from which the team comes.</param>
        public Team(string name, MailAddress email, Competitor firstCompetitor, Competitor secondCompetitor, Coach coach, School school)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            FirstCompetitor = firstCompetitor ?? throw new ArgumentNullException(nameof(firstCompetitor));
            SecondCompetitor = secondCompetitor ?? throw new ArgumentNullException(nameof(secondCompetitor));
            Coach = coach ?? throw new ArgumentNullException(nameof(coach));
            School = school ?? throw new ArgumentNullException(nameof(school));
        }
    }
}
