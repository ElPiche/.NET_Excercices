namespace Tarea_04_SignalR_Blazor.Model
{
    public class User
    {
        public string? Email { get; set; }
        public Boolean? Verified { get; set; }
        public string? Password { get; set; }

        public User() { }

        public User(string email, string password, Boolean verified)
        {
            this.Verified = verified;
            this.Email = email;
            this.Password = password;
        }

        public Boolean verifyUser(User user)
        {
            if (user == null) throw new ArgumentNullException("Usuario no existe");

            if (user.Verified == null) throw new InvalidOperationException("El estado de verificación es indefinido");

            if (!user.Verified.Value)
            {
                user.Verified = true;
                return true;
            }

            Console.WriteLine("Usuario ya verificado");

            return true;
        }
    }
}
