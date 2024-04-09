namespace Progra6_Assets_MaryelCastro.ModelsDTOs
{
    public class UserPostDTO
    {
        //Esta version de DTO se utiliza para agregar un usuario. Para el Post 
        //Aqui está la contrasennia

        //usaremos este dto para el proceso de crear un usuario nmuevo 
       
        public string Cedula { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string? Telefono { get; set; }

        public string? Direccion { get; set; }

        public string Correo { get; set; } = null!;

        public string Contrasennia { get; set; } = null!;
   
        public int CodigoDeRol { get; set; }

        




    }
}
