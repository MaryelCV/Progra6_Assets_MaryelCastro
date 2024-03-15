namespace Progra6_Assets_MaryelCastro.ModelsDTOs
{
    public class UserPostDTO
    {
        //Esta version de DTO se utiliza para agregar un usuario. Para el Post 
        //Aqui está la contrasennia

        public int CodigoUsuario { get; set; }

        public string Cedula { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string? Telefono { get; set; }

        public string? Direccion { get; set; }

        public string Correo { get; set; } = null!;

        public string Contrasennia { get; set; } = null!;

        public bool? Activo { get; set; }

        public int CodigoDeRol { get; set; }

        public string? RolDeUsuario { get; set; }




    }
}
