namespace Progra6_Assets_MaryelCastro.ModelsDTOs
{
    public class UserDTO
    {
        //Un DTO (data transfer object) sirve para varios objetivos:
        //1.Desaclopar el modelo de la funcionalidad de los controller 
        //para evitar que en futuras actualizaciones de los modelos
        //puedan ocurrir errores dificiles de reparar

        //2.Sirve para simplificar modelos muy complejos y que tiene
        //compisiciones recursivas, muy comunes cuando generan mediante ORM como Entity framework, Dapper, Django

        //3. Por un asunto de seguridad. Ya que normalmente 
        //los equipos de desarrollo de las apps y web apis estan separados, y no se quiere 
        // que los programadores de front end sepan como estan 
        //estructurada la base de datos tomando como base los modelos.

        public int CodigoUsuario { get; set; }

        public string Cedula { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string? Telefono { get; set; }

        public string? Direccion { get; set; }

        public string Correo { get; set; } = null!;

        //En este ejemplo no usaremos la contrasennia ya que ese DTO 
        //será usado para mostrar la lista de usuarios de una UI
        //Tendremos otra versión de DTO que si tiene la contrasennia 
        //para cuando querramos agregar un usuario


        //public string Contrasennia { get; set; } = null!;

        public bool? Activo { get; set; }

        public int CodigoDeRol { get; set; }

        public string? RolDeUsuario { get; set; }

        public string? NotasDelUsuario { get; set; }

        //Aca se pueden agregar los atributos que sean necesarios


        //FIN
    }
}
