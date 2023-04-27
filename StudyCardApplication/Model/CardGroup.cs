using SQLite;

namespace StudyCardApplication.Model
{
    public class CardGroup
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
