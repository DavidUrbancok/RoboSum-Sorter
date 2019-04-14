using Microsoft.VisualBasic.FileIO;

using RoboSum.ObjectModels;

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
                        var line = parser.ReadFields();
                        var team = new Team(line[0], line[1], line[2]);

                        Storage.Save(team);
                    }
                    catch (MalformedLineException)
                    {
                        throw;
                    }
                }
            }
        }
    }
}
