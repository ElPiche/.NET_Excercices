namespace Tarea03_a_SignalR.Hub;
using Microsoft.AspNetCore.SignalR;
using Tarea03_a_SignalR.Model; //acceso a clase Users


public class VerificationLoginHub : Hub
{

    private  readonly ILogger<VerificationLoginHub> _logger;

    public VerificationLoginHub(ILogger<VerificationLoginHub> logger)
    {

    _logger = logger; }


    public void Login(string email, string password)
    {
        _logger.LogInformation("Generando identificacion del usuario con id de conexion: " + Context.ConnectionId);

        //creo un usuario con los datos ingresados en el login
        User user = new User(email, password, false);

        //Verifico usuario y genero una url para el mismo.
        if (user.verifyUser(user)) //si puedo verificar usuario
            //en un ejemplo mas complejo podria verificar al usuario desde el endpoint /verify/user/ enviando datos como id de usuario.
        {
            string userId = Context.ConnectionId;
            _logger.LogInformation("Verificar usuario con el siguiente link: ");
            //se realiza con fines demostrativos, es mala practica enviar identifiaciones en urls
            //normalmente se generaria un token, el cual seria un atributo del objeto usuario 
            //o seria un objeto dentro de un objeto usuario y seria validado por un endpoint utilizando ese token,
            //sin comprometer informacion del usuario, ya que la informacion esta encriptada pero url permanece en el navegador.
            _logger.LogInformation(" curl https://localhost:7154/verify/user/" + userId);

        }
        else
        {
            _logger.LogInformation("No se pudo verificar usuario, no se ha generado link de verificacion.");
        }

    }

    public void userVerifiedNotification()
    {
        //notificacion a un cliente bajo un mismo usuario, de esta forma si un usuario abre otra
        //pestaña tendra el mismo UserIdentifier por lo tanto enviará notificaciones por ambas pestañas
        Clients.User(Context.UserIdentifier).SendAsync("userVerifiedSuccesfully", ""); 
    }

}
