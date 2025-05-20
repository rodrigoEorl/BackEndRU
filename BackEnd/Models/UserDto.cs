using System.Xml.Linq;

namespace BackEnd.Models
{
    public class UserDto
    {
        public string NombreCompleto { get; set; }
        public string Genero { get; set; }
        public string Ubicacion { get; set; }
        public string Correo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Foto { get; set; }
    }
}
