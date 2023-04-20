namespace CoreAppBiblioteca.Models
{
    public class Utente
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public Utente(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public Utente() { }
    }
}
