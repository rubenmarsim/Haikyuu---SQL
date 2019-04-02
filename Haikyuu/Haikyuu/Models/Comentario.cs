using SQLite;

namespace Haikyuu.Models
{
    public class Comentario
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string Name { get; set; }
        public string NameCharacter { get; set; } 
        public string Notes { get; set; }
    }
}
