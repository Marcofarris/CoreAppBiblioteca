namespace CoreAppBiblioteca.Models
{
    public static class DB
    {
        static List<Libro> listaLibri = new List<Libro>()
        {
            new Libro(1, true, "Madame Bovary"),
            new Libro(2, false, "Metamorfosi")
        };

        static List<Utente> listaUtenti = new List<Utente>()
        {
            new Utente("Marco", "1"),
            new Utente("Nicolò", "2")
        };

        public static string Login(string nome)
        {
            var utente = listaUtenti.FirstOrDefault(l => l.UserName == nome);
            
            if (utente != null)
            {
                return "1234";
            }
            else return "0";
        }

        public static List<Libro> GetList()
        {
            return listaLibri;
        }
        public static void AddLibro(Libro l)
        {
            var maxId = listaLibri.Max(i => i.Id);
            l.Id = maxId + 1;
            listaLibri.Add(l);
        }

        public static Libro GetLibro(int id)
        {
             return listaLibri.FirstOrDefault(l => l.Id == id)!;
        }

        public static Libro GetLibroByName(string name)
        {
            var libro = listaLibri.FirstOrDefault(l => l.Titolo == name);
            if (libro.Disponiile == true)
            {
                libro.Disponiile = false;
                return libro;
            }
            else return null;
            
        }

        public static void Replace(Libro l)
        {
            var Libro = listaLibri.FirstOrDefault(i => i.Id == l.Id);
            listaLibri.Remove(Libro);
            listaLibri.Add(l);
        }

    }
}
