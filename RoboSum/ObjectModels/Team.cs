using System;
using System.Net.Mail;

namespace RoboSum.ObjectModels
{
    public class Team
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MailAddress Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Competitor FirstCompetitor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Competitor SecondCompetitor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Coach Coach { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public School School { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="firstCompetitor"></param>
        /// <param name="secondCompetitor"></param>
        /// <param name="coach"></param>
        /// <param name="school"></param>
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
