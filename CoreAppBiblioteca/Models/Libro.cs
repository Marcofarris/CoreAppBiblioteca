namespace CoreAppBiblioteca.Models
{
    public class Libro
    {
        public bool Disponiile { get; set; }
        public int Id { get; set; }
        public string Titolo{ get; set; }

        public Libro(int id,bool disponiile, string titolo)
        {
            Disponiile = disponiile;
            Titolo = titolo;
            Id = id;
        }

       public Libro() { }
    }
}
