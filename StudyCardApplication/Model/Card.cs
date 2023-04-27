using SQLite;

namespace StudyCardApplication.Model
{
    public class Card
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [Indexed]
        public int CardGroupID { get; set; }
        public string Question { get; set; }
        public string AcceptableAnswers { get; set; } // One string of answers separated by commas, since sqlite doesn't take arrays.

    }
}
