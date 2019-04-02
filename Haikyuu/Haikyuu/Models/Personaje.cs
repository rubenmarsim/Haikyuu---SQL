using SQLite;

namespace Haikyuu.Models
{
    public class Personaje
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public string numPuntuacion { get; set; }
        public string Image { get; set; }
    }
}
