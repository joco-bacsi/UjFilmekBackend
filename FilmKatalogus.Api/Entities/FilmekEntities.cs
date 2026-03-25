namespace FilmKatalogus.Api.Entities;

    public class FilmekEntities
    {
        public int Id { get; set; }
        public string Rendezo { get; set; } = string.Empty;
        public string Cim { get; set; } = string.Empty;
        public MufajEntities? Mufaj { get; set; }
        public int MufajId { get; set; }
        public TimeOnly Hossz { get; set; }
        public string Nyelv { get; set; } = string.Empty;
        public DateOnly MegjelenesiDatum { get; set; }
        public double ImDbErtekeles { get; set; }
        public double SajatErtekeles { get; set; }
    }


