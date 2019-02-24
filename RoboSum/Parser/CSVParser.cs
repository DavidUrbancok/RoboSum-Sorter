using Microsoft.VisualBasic.FileIO;
using RoboSum.ObjectModels;
using System.Net.Mail;

namespace RoboSum.Parser
{
    /// <summary>
    /// Class providing functionality for parsing CSV files.
    /// </summary>
    public class CSVParser
    {
        /// <summary>
        /// Gets or sets the temporary storage of parsed data.
        /// </summary>
        private Storage Storage { get; }

        /// <summary>
        /// Creates a new instance of <see cref="CSVParser"/>.
        /// </summary>
        /// <param name="storage">Instance of a temporary storage.</param>
        public CSVParser(Storage storage)
        {
            Storage = storage;
        }

        /// <summary>
        /// Parses a CSV file from <paramref name="fileName"/> to a list of teams.
        /// </summary>
        /// <param name="fileName">Absolute path to the CSV file including filename.</param>
        public void ParseTeams(string fileName)
        {
            using (var parser = new TextFieldParser(fileName))
            {
                parser.SetDelimiters(";", ",");

                while (!parser.EndOfData)
                {
                    try
                    {
                        var team = ParseLineToTeam(parser.ReadFields());

                        Storage.Save(team);
                    }
                    catch (MalformedLineException)
                    {
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Parses <paramref name="line"/> to an instance of <see cref="Team"/>.
        /// </summary>
        /// <param name="line">One line of CSV file.</param>
        private Team ParseLineToTeam(string[] line)
        {
            string teamName = line[0];
            MailAddress teamEmail = new MailAddress(line[1]);

            var firstCompetitor = new Competitor(line[2], line[3], int.Parse(line[4]));
            var secondCompetitor = new Competitor(line[5], line[6], int.Parse(line[7]));

            var coach = new Coach(line[8], line[9]);

            var school = new School(line[10], line[11]);

            var team = new Team(teamName, teamEmail, firstCompetitor, secondCompetitor, coach, school);

            return team;
        }
    }
}
